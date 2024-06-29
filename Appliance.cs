namespace Ass1
{
    public abstract class Appliance
    {
        private int id;
        private string? brand;
        private int quantity;
        private int wattage;
        private string? colour;
        private float price;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string? Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int Wattage
        {
            get { return wattage; }
            set { wattage = value; }
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

        public void Checkout()
        {
            quantity = quantity - 1;
        }

        public override string ToString()
        {
            return $"ItemNumber: {id}\nBrand: {brand}\nQuantity: {quantity}\n" +
                    $"Wattage: {wattage}\nColour: {colour}\nPrice: {price}";
        }
        public virtual string FormatForFile()
        {
            return $"{id};{brand};{quantity};{wattage};{colour};{price};";
        }
    }
}
