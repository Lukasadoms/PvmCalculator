using System;
using System.Collections.Generic;
using System.Text;

namespace PvmCalculator
{
    class Program
    {

    
        public static void Main(string[] args)
        {
            PvmCalculator pvmCalculator = new PvmCalculator();
            Seller seller = new Seller();
            Buyer buyer = new Buyer();
            decimal Sum = 1;

            pvmCalculator.CalculateSum(Sum, seller, buyer);           

           
        }
    }
}
