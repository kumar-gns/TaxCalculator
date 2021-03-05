using System;
using TaxCalculator.Constants;

namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            do
            {
                Console.WriteLine("Enter Total CTC");
                str = Console.ReadLine();
                if (decimal.TryParse(str, out decimal actualSalary))
                {
                    Console.WriteLine("Incometax is 10% : {0}", CalculateIncomeTax(actualSalary));
                    Console.WriteLine("Social Contributions are 15% = {0}", CalculateSocialContributionTax(actualSalary));
                    Console.WriteLine("Total Taxes = {0}", CalculateIncomeTax(actualSalary) + CalculateSocialContributionTax(actualSalary));
                    Console.WriteLine("Take Home Salary = {0}", (actualSalary - CalculateIncomeTax(actualSalary) - CalculateSocialContributionTax(actualSalary)));
                }
                Console.WriteLine("Do you want to continue (Y/N)? ");
            }
            while (Console.ReadLine() != "Y");
        }

        /// <summary>
        /// Calculate Social Contribution Tax
        /// </summary>
        /// <param name="grossSalary"></param>
        /// <returns></returns>
        public static decimal CalculateSocialContributionTax(decimal grossSalary)
        {
            if (grossSalary > 3000)
            {
                decimal baseTax = 3000 - 1000;
                decimal incomeAfterTax = Math.Round(baseTax * Convert.ToDecimal(IncomeTaxConstants.SocialContributionTaxRate), 2);
                return incomeAfterTax;
            }
            else if (grossSalary > 1000)
            {
                decimal taxBase = grossSalary - 1000;
                decimal incomeAfterTax = Math.Round(taxBase * Convert.ToDecimal(IncomeTaxConstants.SocialContributionTaxRate), 2);
                return incomeAfterTax;
            }
            return 0;
        }
        /// <summary>
        /// Calculate Income Tax
        /// </summary>
        /// <param name="grossSalary"></param>
        /// <returns></returns>
        public static decimal CalculateIncomeTax(decimal grossSalary)
        {
            if (grossSalary > 1000)
            {
                decimal baseTax = grossSalary - 1000;
                decimal incomeAfterTax = Math.Round(baseTax * Convert.ToDecimal(IncomeTaxConstants.IncomeTaxRate), 2);
                return incomeAfterTax;
            }
            return 0;
        }
    }
}
