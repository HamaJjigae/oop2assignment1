namespace Ass1
{
    public class Microwave : Appliance
    {
        private float capacity;
        public string RoomType;

        public Microwave(int id, string? brand, int quantity, int wattage, string? colour, float price, float capacity, string roomType)
            : base(id, brand, quantity, wattage, colour, price)
        {
            this.capacity = capacity;
            this.RoomType = roomType;
        }
        public override string ToString()
        {
            string roomText = RoomType switch
            {
                "W" => "Work Site",
                _ => "Kitchen"
            };
            return $"{base.ToString()}\nCapacity: {capacity}\nRoom Type: {roomText}";
        }

        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{capacity};{RoomType};";
        }
    }
}

