using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizza_Builder
{
    public class Calculate
    {
        public string Size { get; set; }
        public string FamilyMeal { get; set; }
        public string ExtraCheese { get; set; }
        public string ExtraMeat { get; set; }
        public string ExtraVeg { get; set; }


        public Calculate(String size, String familyMeal, string extraCheese, string extraMeat, string extraVeg)
        {
            this.Size = size;
            this.FamilyMeal = familyMeal;
            this.ExtraCheese = extraCheese;
            this.ExtraMeat = extraMeat;
            this.ExtraVeg = extraVeg;

        }

        public double getSizeCost()
        {
            double SizeCost;

            if (Size == "x-large")
            {
                SizeCost = 13.21;
            }
            else if (Size == "large")
            {
                SizeCost = 10.64;
            }
            else if (Size == "medium")
            {
                SizeCost = 8.12;
            }
            else if (Size == "small")
            {
                SizeCost = 6.02;
            }
            else
            {
                SizeCost = 0;
            }

            return SizeCost;
        }

        public int isPremium()
        {
            int premium = 0;

            if (ExtraCheese == "yes")
            {
                premium += 1;
            }
            else if (ExtraCheese == "no")
            {
                premium += 0;
            }

            if (ExtraMeat == "yes")
            {
                premium += 1;
            }
            else if (ExtraMeat == "no")
            {
                premium += 0;
            }

            if (ExtraVeg == "yes")
            {
                premium += 1;
            }
            else if (ExtraVeg == "no")
            {
                premium += 0;
            }

            return premium;
        }

        public double familyMealCost()
        {
            double sizeCost = getSizeCost();
            double FamilyCost;

            if (FamilyMeal == "yes")
            {
                FamilyCost = sizeCost + 4;
            }
            else {
                FamilyCost = sizeCost;
            }

            return FamilyCost;
        }

        public double calcTotal()
        {
            double Total;

            Total = familyMealCost() + isPremium();
            Total = Math.Round(Total, 2);

            return Total;
        }

        public double calcTax(double total)
        {
            double tax = total * .2;
            tax = Math.Round(tax, 2);

            return tax;
        }
    }
}