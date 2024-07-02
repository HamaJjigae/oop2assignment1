namespace Ass1
{
    //see comments for refrigerator as same applies here.
    public class Microwave : Appliance
    {
        private float capacity;
        private string roomType;

        public string RoomType
        {
            get { return roomType; }
        }

        public Microwave(int id, string? brand, int quantity, int wattage, string? colour, float price, float capacity, string roomType)
            : base(id, brand, quantity, wattage, colour, price)
        {
            this.capacity = capacity;
            this.roomType = roomType;
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
            return $"{base.FormatForFile()}{capacity};{RoomType};";
        }
    }
}
