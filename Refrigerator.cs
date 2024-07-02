namespace Ass1
{
    public class Refrigerator : Appliance
    {
        private int doors;
        private int height;
        private int width;

        //Needed to be able to get doors for functionality.
        public int Doors
        {
            get { return doors; }
        }

        public Refrigerator(int id, string? brand, int quantity, int wattage, string? colour, float price, int doors, int height, int width)
            : base(id, brand, quantity, wattage, colour, price)
        {
            this.doors = doors;
            this.height = height;
            this.width = width;
        }



        //creates a switch expression to change switch from its numerical to verbal forms. I personally think using _ is kind of lazy but there was no real use-case to have it another way.
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

        //builds onto virtual
        public override string FormatForFile()
        {
            return $"{base.FormatForFile()}{Doors};{height};{width};";
        }
    }
}
