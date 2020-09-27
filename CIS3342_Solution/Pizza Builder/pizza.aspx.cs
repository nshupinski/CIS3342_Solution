using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pizza_Builder
{
    public partial class process_pizza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                String username = Request["userName"];
                String phoneNumber = Request["PhoneNumber"];
                String address = Request["Address"];
                String PickupOrDeliver = Request["PickupOrDeliver"];
                String size = Request["PizzaSize"];
                String crust = Request["Crust"];
                String sauce = Request["Sauce"];
                String toppings = Request["toppings"];
                String extraCheese = Request["extraCheese"];
                String extraMeat = Request["extraMeat"];
                String extraVeg = Request["extraVeg"];
                String familyMeal = Request["familyMeal"];
                String soda = Request["soda"];
                String sides = Request["sides"];
                Double tip = Convert.ToDouble(Request["Tip"]);

                Calculate calc = new Calculate(size, familyMeal, extraCheese, extraMeat, extraVeg);

                double tax = calc.calcTax(calc.calcTotal());
                double grandTotal = calc.calcTotal() + tip + tax;

                Response.Write("<h3>Thank you for ordering from Crusty Frank's Pizza Emporium</h3>");
                Response.Write("<p>Name: " + username + "</p>");
                Response.Write("<p>Phone Number: " + phoneNumber + "</p>");
                Response.Write("<p>Address: " + address + "</p>");
                Response.Write("<p>Pick Up or Deliver: " + PickupOrDeliver + "</p>");
                Response.Write("<p>______________</p>");
                Response.Write("<p>Pizza Size: " + size + " = $" + calc.getSizeCost() + "</p>");
                Response.Write("<p>Toppings: " + toppings + "</p>");
                Response.Write("<p>______________</p>");
                if (extraCheese == "yes") { 
                    Response.Write("<p>Extra Cheese: " + extraCheese + " + $1</p>");
                }
                else
                {
                    Response.Write("<p>Extra Cheese: No</p>");
                }

                if (extraMeat == "yes")
                {
                    Response.Write("<p>Extra Meat: " + extraMeat + " + $1</p>");
                }
                else
                {
                    Response.Write("<p>Extra Meat: No</p>");
                }

                if (extraVeg == "yes")
                {
                    Response.Write("<p>Extra Veggies: " + extraVeg + " + $1</p>");
                }
                else
                {
                    Response.Write("<p>Extra Veggies: No</p>");
                }
                Response.Write("<p><b>Premium Additions: + $" + calc.isPremium() + "</b></p>");
                Response.Write("<p>______________</p>");
               
                if (familyMeal == "yes")
                {
                    Response.Write("<p>Family Meal: " + familyMeal + " + $4" + "</p>");
                    Response.Write("<p>Soda: " + soda + "</p>");
                    Response.Write("<p>Sides: " + sides + "</p>");
                }
                else
                {
                    Response.Write("<p>Family Meal: " + familyMeal + "</p>");
                }
                Response.Write("<p>________________________</p>");
                Response.Write("<p>Tax: $" + tax + "</p>");
                Response.Write("<p>Tip: $" + tip + "</p>");
                Response.Write("<p><b>Total: $" + grandTotal + "</b>");
            }
        }
    }
}