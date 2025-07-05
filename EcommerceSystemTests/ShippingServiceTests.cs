using Xunit;
using EcommerceSytsem;
using System;
using System.Collections.Generic;

namespace EcommerceSystemTests
{
    public class ShippingServiceTests
    {
        [Fact]
        public void CalculateShippingFee_WithEmptyList_ReturnZero()
        {
            // arrange
            var shippingService = new ShippingService();

            // act
            var fee = shippingService.CalculateShippingFee(new List<ShippedItem>());

            // assert
            Assert.Equal(0, fee);
        }

        [Fact]
        public void CalculateShippingFee_WithNullList_ReturnZero()
        {
            // arrange
            var shippingService = new ShippingService();

            // act
            var fee = shippingService.CalculateShippingFee(null);

            // assert
            Assert.Equal(0, fee);
        }

        [Fact]
        public void CalculateShippingFee_WithLightPackage_ReturnBaseFee()
        {
            // arrange
            var shippingService = new ShippingService();
            var product = new Product("Light Product", 100, 10, true, false, null, 500); 
            var shippedItem = new ShippedItem(product, 1);
            var items = new List<ShippedItem> { shippedItem };

            // act
            var fee = shippingService.CalculateShippingFee(items);

            // assert
            Assert.Equal(30, fee); 
        }

        [Fact]
        public void CalculateShippingFee_WithHeavyPackage_ReturnCalculatedFee()
        {
            // arrange
            var shippingService = new ShippingService();
            var product = new Product("Heavy Product", 100, 10, true, false, null, 1500); // 1.5kg
            var shippedItem = new ShippedItem(product, 1);
            var items = new List<ShippedItem> { shippedItem };

            // act
            var fee = shippingService.CalculateShippingFee(items);

            // assert 30+ (5*1.5)=>37.5
            Assert.Equal(37.5, fee);
        }

        [Fact]
        public void CalculateShippingFee_WithMultipleItems_CalculateTotalWeight()
        {
            // arrange
            var shippingService = new ShippingService();
            var product1 = new Product("Product 1", 100.0, 10, true, false, null, 800); 
            var product2 = new Product("Product 2", 50.0, 10, true, false, null, 400); 
            var shippedItem1 = new ShippedItem(product1, 1);
            var shippedItem2 = new ShippedItem(product2, 1);
            var items = new List<ShippedItem> { shippedItem1, shippedItem2 };

            // act
            var fee = shippingService.CalculateShippingFee(items);

            // assert 30 + (1.2 * 5) => 36
            Assert.Equal(36, fee); // 
        }

        [Fact]
        public void CalculateShippingFee_WithExactlyOneKilo_ReturnBaseFee()
        {
            // arrange
            var shippingService = new ShippingService();
            var product = new Product("One Kilo Product", 100, 10, true, false, null, 1000); 
            var shippedItem = new ShippedItem(product, 1);
            var items = new List<ShippedItem> { shippedItem };

            // act
            var fee = shippingService.CalculateShippingFee(items);

            // assert
            Assert.Equal(30, fee); 
        }

        [Fact]
        public void ShipmentNotice_WithEmptyList_ReturnEmptyString()
        {
            // arrange
            var shippingService = new ShippingService();

            // act
            var notice = shippingService.ShipmentNotice(new List<ShippedItem>());

            // assert
            Assert.Equal(string.Empty, notice);
        }

        [Fact]
        public void ShipmentNotice_WithNullList_ReturnEmptyString()
        {
            // arrange
            var shippingService = new ShippingService();

            // act
            var notice = shippingService.ShipmentNotice(null);

            // assert
            Assert.Equal(string.Empty, notice);
        }

        [Fact]
        public void ShipmentNotice_WithItems_ReturnFormattedNotice()
        {
            // arrange
            var shippingService = new ShippingService();
            var product1 = new Product("Product 1", 100, 10, true, false, null, 500);
            var product2 = new Product("Product 2", 50, 10, true, false, null, 300);
            var shippedItem1 = new ShippedItem(product1, 2);
            var shippedItem2 = new ShippedItem(product2, 1);
            var items = new List<ShippedItem> { shippedItem1, shippedItem2 };

            // act
            var notice = shippingService.ShipmentNotice(items);

            // assert
            Assert.Contains("** Shipment notice **", notice);
            Assert.Contains(" 2x Product 1      1000g", notice);
            Assert.Contains(" 1x Product 2      300g", notice);
            Assert.Contains("Total package weight 1.3kg", notice);
        }

    
    }
} 