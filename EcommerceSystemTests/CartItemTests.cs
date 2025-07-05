using Xunit;
using EcommerceSytsem;
using System;

namespace EcommerceSystemTests
{
    public class CartItemTests
    {
        [Fact]
        public void CartItem_Constructor_ShouldSetPropertiesCorrectly()
        {
            // arrange
            var product = new Product("Test Product", 100, 10, true);

            // act
            var cartItem = new CartItem(product, 3);

            // assert
            Assert.Equal(product, cartItem.Product);
            Assert.Equal(3, cartItem.Quantity);
        }

        [Fact]
        public void GetTotalItemPrice_ShouldReturnCorrectTotal()
        {
            // arrange
            var product = new Product("Test Product", 100, 10, true);
            var cartItem = new CartItem(product, 3);

            // act
            var total = cartItem.GetTotalItemPrice();

            // assert
            Assert.Equal(300.0, total);
        }

        [Fact]
        public void GetTotalItemPrice_With0Quantity_Return0()
        {
            // arrange
            var product = new Product("Test Product", 100, 10, true);
            var cartItem = new CartItem(product, 0);

            // act
            var total = cartItem.GetTotalItemPrice();

            // assert
            Assert.Equal(0, total);
        }

        [Fact]
        public void GetTotalItemPrice_With0Price_Return0()
        {
            // arrange
            var product = new Product("Test Product", 0.0, 10, true);
            var cartItem = new CartItem(product, 5);

            // act
            var total = cartItem.GetTotalItemPrice();

            // assert
            Assert.Equal(0.0, total);
        }
    }
}