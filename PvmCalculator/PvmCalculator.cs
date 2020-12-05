using System;
using System.Collections.Generic;
using System.Text;

namespace PvmCalculator
{
    public class PvmCalculator
    {

        public static decimal Pvm { get; set; }
       
        
        decimal result;
        public decimal GetPvm(Seller seller)
        {
            Pvm = seller.Country switch
            {
                "LT" => 21,
                "LV" => 22,
                "EE" => 20,
                "Non EU" => 0,
                _ => 0
            };
            return Pvm;

        }

        public static decimal CalculatePvm(decimal sum, decimal pvm)
        {
            decimal sumPvm = sum + sum * pvm / 100;

            return sumPvm;
        }

        public string CalculateSum(decimal Sum, Seller seller, Buyer buyer)
        {

            if (seller.PvmPayer == false || buyer.Country == "Non EU" || buyer.Country != seller.Country && buyer.PvmPayer == true)
            {
                result = Sum;
            }
            else 
            {
                result = CalculatePvm(Sum, GetPvm(seller));
            }

            return string.Format("€{0:N2}", result);

        }
    }
}
