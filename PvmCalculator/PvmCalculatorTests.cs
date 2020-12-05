using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PvmCalculator
{
    public class PvmCalculatorTests
    {
        

        [Theory]
        [InlineData("LT", true, "LT", false, 100, "€121.00")]
        [InlineData("LV", true, "LT", false, 100, "€122.00")]
        [InlineData("LV", true, "LV", false, 100, "€122.00")]
        [InlineData("LT", true, "EE", true, 100, "€100.00")]
        [InlineData("LT", true, "LT", false, 200.12, "€242.15")]

        public void pvmCalculator_shouldReturnExpectedSumWithPvm(string sellerCountry, bool sellerIsPvmPayer, string buyerCountry, bool buyerIsPvmPayer, decimal Sum, string expected)
        {
            PvmCalculator pvmCalculator = new PvmCalculator();
            Buyer buyer = new Buyer();
            Seller seller = new Seller();

            seller.Country = sellerCountry;
            seller.PvmPayer = sellerIsPvmPayer;
            buyer.Country = buyerCountry;
            buyer.PvmPayer = buyerIsPvmPayer;

            //Act
            string result = pvmCalculator.CalculateSum(Sum, seller, buyer);

            Console.WriteLine(buyer.Country);
            //Assert
            Assert.Equal(expected, result);
        }
    }
}
