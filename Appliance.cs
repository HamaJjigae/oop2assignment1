/*
 * File: Appliance.cs and Respective children
 * Author: Matthew Biggs
 * Date: July 1st 2024
 * Description: File seeks to create Appliance and Children objects and apply functionality through relation with the MainMenu method
 */

namespace Ass1
{
    public abstract class Appliance
    {
        //all variables were set to private and then given getters and setters (when needed or thought logical to need)
        private int id;
        private string? brand;
        private int quantity;
        private int wattage;
        private string? colour;
        private float price;

        public int Id
        {
            get { return id; }
        }
        public string? Brand
        {
            get { return brand; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int Wattage
        {
            get { return wattage; }
        }

        public string? Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        public Appliance(int id, string? brand, int quantity, int wattage, string? colour, float price)
        {
            this.id = id;
            this.brand = brand;
            this.quantity = quantity;
            this.wattage = wattage;
            this.colour = colour;
            this.price = price;
        }

        //Very simply checks for quantity being above 0
        public bool IsAvailable()
        {
            if (quantity > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Decrements quantity
        public void Checkout()
        {
            quantity = quantity - 1;
        }

        //ToString used as a baseline for all other classes
        public override string ToString()
        {
            return $"ItemNumber: {id}\nBrand: {brand}\nQuantity: {quantity}\n" +
                    $"Wattage: {wattage}\nColour: {colour}\nPrice: {price}";
        }
        //Created a virtual template for other children classes to build on since this Parent class would never run a Format.
        public virtual string FormatForFile()
        {
            return $"{id};{brand};{quantity};{wattage};{colour};{price};";
        }
    }
}
