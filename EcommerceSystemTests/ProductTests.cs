using Xunit;
using EcommerceSytsem;
using System;

namespace EcommerceSystemTests
{
    public class ProductTests
    {
        [Fact]
        public void ProductConstructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange & Act
            var product = new Product("Test Product", 100.0, 10, true, true, DateTime.Today.AddDays(30), 1.5);

            // Assert
            Assert.Equal("Test Product", product.Name);
            Assert.Equal(100.0, product.Price);
            Assert.Equal(10, product.StockQuantity);
            Assert.True(product.CanBeShipped);
            Assert.True(product.CanExpire);
            Assert.Equal(DateTime.Today.AddDays(30), product.ExpiryDate);
            Assert.Equal(1.5, product.Weight);
        }

        [Fact]
        public void IsOutOfStock_WhenStockIsZero_ReturnTrue()
        {
            // Arrange
            var product = new Product("Test", 100.0, 0, true);

            //act
            var expected=product.IsOutOfStock();

            // assert
            Assert.Equal(true,expected);
        }

        [Fact]
        public void IsOutOfStock_WhenStockIsPositive_ReturnFalse()
        {
            // Arrange
            var product = new Product("Test", 100.0, 5, true);

            //act
            var expected = product.IsOutOfStock();



            // Act & Assert
            Assert.Equal(false,expected);
        }

        [Fact]
        public void IsExpired_WhenProductExpired_ReturnTrue()
        {
            // Arrange
            var product = new Product("Test", 100.0, 5, true, true, DateTime.Today.AddDays(-1));

            //act
            var expected = product.IsExpired();
            // assert
            Assert.Equal(true, expected);
        }

        [Fact]
        public void IsExpired_ProductCannotExpire_ShouldReturnFalse()
        {
            // Arrange
            var product = new Product("Test", 100.0, 5, true, false);

            //act

            var expected = product.IsExpired();

            // assert
            Assert.Equal(false, expected);
        }

        [Fact]
        public void IsExpired_ProductCanExpireButDateIsFuture_ShouldReturnFalse()
        {
            // Arrange
            var product = new Product("Test", 100.0, 5, true, true, DateTime.Today.AddDays(1));

            //act
            var expected = product.IsExpired();

            // assert
            Assert.Equal(false, expected);
        }

        [Fact]
        public void DecreaseStock_ValidQuantity10_ShouldDecreaseStockTo7IfDecreased3()
        {
            // Arrange
            var product = new Product("Test", 100.0, 10, true);

            // Act
            product.DecreaseStock(3);

            // Assert
            Assert.Equal(7, product.StockQuantity);
        }

        [Fact]
        public void DecreaseStock_WithNegativeQuantity_ShouldThrowException()
        {
            // arrange
            var product = new Product("Test", 100.0, 10, true);

            // act w assert
            var exception = Assert.Throws<Exception>(() => product.DecreaseStock(-1));
            Assert.Contains("Please enter a postive number", exception.Message);
        }

        [Fact]
        public void DecreaseStock_WithQuantityGreaterThanStock_ThrowException()
        {
            // arrange
            var product = new Product("Test", 100.0, 5, true);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => product.DecreaseStock(10));
            Assert.Contains("not enough stock", exception.Message);
        }

        [Fact]
        public void IncreaseStock_WithValidQuantity10_ShouldIncreaseStockTo15IfAdded5()
        {
            // arrange
            var product = new Product("Test", 100.0, 10, true);

            // Act
            product.IncreaseStock(5);

            // Assert
            Assert.Equal(15, product.StockQuantity);
        }

        [Fact]
        public void IncreaseStock_WithNegativeQuantity_ShouldThrowException()
        {
            // arrange
            var product = new Product("Test", 100.0, 10, true);

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => product.IncreaseStock(-1));
            Assert.Contains("Please enter a postive number", exception.Message);
        }
    }
} 