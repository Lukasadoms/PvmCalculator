using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PvmCalculator
{
    public class PvmCalculatorTests
    {

        [Fact]
        public void pvmCalculator_ShouldReturnTheRightSum() //Mock with NSubstitute
        {
            //Arrange
            var buyer = Substitute.For<Buyer>();
            var seller = Substitute.For<Seller>();
            var pvmCalculator = Substitute.For<IPvmCalculator>();

            seller.Country = "LT";
            seller.PvmPayer = true;
            buyer.Country = "LT";
            buyer.PvmPayer = false;

            //Act
            pvmCalculator.CalculateSum(100, seller, buyer).Returns("€121.00");


            //Assert
            Assert.Equal("€121.00", pvmCalculator.CalculateSum(100, seller, buyer));

        }
        [Fact]
        public void getPvm_shouldReturnExpectedPvm() //Mock with NSubstitute
        {
            //Arrange
            Seller seller = new Seller();
            var pvmCalculator = Substitute.For<IPvmCalculator>();

            //Act
            //Assert
            pvmCalculator.GetPvm(seller).Returns(22);
            Assert.Equal(22, pvmCalculator.GetPvm(seller));
            Assert.NotEqual(21, pvmCalculator.GetPvm(seller));
            }
            
        [Theory]
        [InlineData("LTT")]
        [InlineData("LT1")]
        [InlineData("asabasdf")]
        public void getPvm_ShouldThrowException(string sellerCountry)
        {
            //Arrange
            var seller = new Seller();
            var pvmCalculator = new PvmCalculator();
            seller.Country = sellerCountry;

            //Act
            Action act = () => pvmCalculator.GetPvm(seller);

            //assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(sellerCountry + " is not a valid country", exception.Message);
        }

        [Theory]
        [InlineData("LT", true, "LT", false, 100, "€121.00")]
        [InlineData("LV", true, "LT", false, 100, "€122.00")]
        [InlineData("LV", true, "LV", false, 100, "€122.00")]
        [InlineData("LT", true, "EE", true, 100, "€100.00")]
        [InlineData("LT", true, "LT", false, 200.12, "€242.15")]
        [InlineData("LT", true, "Non EU", false, 200.12, "€200.12")]

        public void pvmCalculator_ShouldCalculateCorrectSum(string sellerCountry, bool sellerIsPvmPayer, string buyerCountry, bool buyerIsPvmPayer, decimal Sum, string expected)
        {
            //Arrange
            var buyer = new Buyer();
            var seller = new Seller();
            var pvmCalculator = new PvmCalculator();
            seller.Country = sellerCountry;
            seller.PvmPayer = sellerIsPvmPayer;
            buyer.Country = buyerCountry;
            buyer.PvmPayer = buyerIsPvmPayer;

            //Act
            string result = pvmCalculator.CalculateSum(Sum, seller, buyer);

            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100, 21, 121)]
        [InlineData(100.12, 21, 121.15)]
      
        public void CalculatePvm_ShouldCalculateCorrectPvm(decimal sum, decimal pvm, decimal expected)
        {
            //Arrange
            PvmCalculator pvmCalculator = new PvmCalculator();

            decimal result =  pvmCalculator.CalculatePvm(sum, pvm);

            Assert.Equal(expected, result);
        }
        [Fact]       
        public void CalculateSum_ShouldThrowException()
        {
            //Arrange
            var pvmCalculator = new PvmCalculator();
            var buyer = new Buyer();
            var seller = new Seller();
            decimal Sum = -100;

            //Act
            Action act = () => pvmCalculator.CalculateSum(Sum, seller, buyer);

            //assert
            ArgumentException exception = Assert.Throws<ArgumentException>(act);
            Assert.Equal(Sum + " invalid argument for Sum", exception.Message);
        }
    }
}
