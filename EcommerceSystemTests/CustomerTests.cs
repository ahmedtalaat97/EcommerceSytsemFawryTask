using Xunit;
using EcommerceSytsem;
using System;

namespace EcommerceSystemTests
{
    public class CustomerTests
    {
        [Fact]
        public void CustomerConstructor_ShouldWork()
        {
            //  arrange
            var customer = new Customer("ahmed talaat", 1000);

            // assert
            Assert.Equal("ahmed talaat", customer.Name);
            Assert.Equal(1000, customer.Balance);
        }

        [Fact]
        public void AfterPaying_WithValidAmount300_ShouldDecreaseBalance700()
        {
            // arrange
            var customer = new Customer("ahmed talaat", 1000);

            // act
            customer.AfterPaying(300);

            // assert
            Assert.Equal(700, customer.Balance);
        }

        [Fact]
        public void AfterPaying_WithInsufficientBalance_ShouldThrowException()
        {
            // arrange
            var customer = new Customer("ahmed talaat", 100);

            //  
            var exception = Assert.Throws<Exception>(() => customer.AfterPaying(200));
            Assert.Equal("Insufficient balance.", exception.Message);
        }

        [Fact]
        public void AfterPaying_WithExactBalance_ShouldSetBalanceTo0()
        {
            // arrange
            var customer = new Customer("ahmed talaat", 100);

            // act
            customer.AfterPaying(100);

            // assert
            Assert.Equal(0, customer.Balance);
        }
    }
} 