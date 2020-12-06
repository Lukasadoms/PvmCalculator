using System;


namespace PvmCalculator
{
    public interface IPvmCalculator
    {
        public decimal GetPvm(Seller seller);
        public decimal CalculatePvm(decimal sum, decimal pvm);
        public string CalculateSum(decimal Sum, Seller seller, Buyer buyer);

    }
    public class PvmCalculator : IPvmCalculator
    {

        public decimal GetPvm(Seller seller)
        {
            decimal Pvm = seller.Country switch
            {
                "LT" => 21,
                "LV" => 22,
                "EE" => 20, 
                "Non EU" => 0,  //More Countries can be added here
                _ => throw new ArgumentException(string.Format("{0} is not a valid country", seller.Country))
            };
            return Pvm;

        }

        public decimal CalculatePvm(decimal sum, decimal pvm)
        {
            decimal sumPvm = sum + sum * pvm / 100;

            return Math.Round(sumPvm, 2);
        }

        public string CalculateSum(decimal Sum, Seller seller, Buyer buyer)
        {
            decimal result;
            if (Sum < 0)
            {
                throw new ArgumentException(string.Format("{0} invalid argument for Sum", Sum));
            }

            else if (seller.PvmPayer == false || buyer.Country == "Non EU" || buyer.Country != seller.Country && buyer.PvmPayer == true)
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
