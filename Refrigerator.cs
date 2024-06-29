namespace Ass1
{
    public class Refrigerator : Appliance
    {
        public int Doors;
        private int height;
        private int width;

        public Refrigerator(int id, string? brand, int quantity, int wattage, string? colour, float price, int doors, int height, int width)
            : base(id, brand, quantity, wattage, colour, price)
        {
            this.Doors = doors;
            this.height = height;
            this.width = width;
        }

        public override string ToString()
        {
            string doorText = Doors switch
            {
                2 => "Two Doors",
                3 => "Three Doors",
                _ => "Four Doors"
            };
            return $"{base.ToString()}\nNumber of Doors: {doorText}\nHeight: {height}\nWidth: {width}";
        }

        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{Doors};{height};{width};";
        }
    }
}
