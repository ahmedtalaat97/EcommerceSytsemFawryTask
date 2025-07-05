using Xunit;
using EcommerceSytsem;
using System;

namespace EcommerceSystemTests
{
    public class ShippedItemTests
    {
        [Fact]
        public void ShippedItemConstructor_WithShippableProduct_ShouldCreateSuccessfully()
        {
            // arrange
            var product = new Product("Test Product", 100, 10, canBeShipped: true, false, null, 1.5);

            // act
            var shippedItem = new ShippedItem(product, 2);

            // assert
            Assert.Equal(product, shippedItem.Product);
            Assert.Equal(2, shippedItem.Quantity);
        }

        [Fact]
        public void ShippedItemConstructor_WithNoShippedProduct_ShouldThrowException()
        {
            // arrange
            var product = new Product("Test Product", 100.0, 10, false);

            // assert
            var exception = Assert.Throws<Exception>(() => new ShippedItem(product, 1));
            Assert.Contains("cant be shipped", exception.Message);
        }

        [Fact]
        public void GetName_ReturnFormattedName()
        {
            // arrange
            var product = new Product("Test Product", 100.0, 10, true);
            var shippedItem = new ShippedItem(product, 3);

            // act
            var name = shippedItem.GetName();

            // assert
            Assert.Equal(" 3x Test Product", name);
        }

        [Fact]
        public void GetWeight_ReturnCorrectWeightMultipliedByQuantity()
        {
            // arrange
            var product = new Product("Test Product", 100.0, 10, true, false, null, 1.5);
            var shippedItem = new ShippedItem(product, 2);

            // act
            var weight = shippedItem.GetWeight();

            // assert
            Assert.Equal(3.0, weight); 
        }

        [Fact]
        public void GetWeight_0Quantity_Return0()
        {
            // arrange
            var product = new Product("Test Product", 100.0, 10, true, false, null, 1.5);
            var shippedItem = new ShippedItem(product, 0);

            // act
            var weight = shippedItem.GetWeight();

            // assert
            Assert.Equal(0.0, weight);
        }

        [Fact]
        public void GetWeight_WithZeroProductWeight_ShouldReturnZero()
        {
            // arrange
            var product = new Product("Test Product", 100, 10, true, false, null, 0.0);
            var shippedItem = new ShippedItem(product, 5);

            // act
            var weight = shippedItem.GetWeight();

            // assert
            Assert.Equal(0, weight);
        }
    }
} 