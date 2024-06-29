namespace Ass1
{
    public class Dishwasher : Appliance
    {
        private string feature;
        public string SoundRating;

        public Dishwasher(int id, string? brand, int quantity, int wattage, string? colour, float price, string feature, string soundRating)
            : base(id, brand, quantity, wattage, colour, price)
        {
            this.feature = feature;
            this.SoundRating = soundRating;
        }
        public override string ToString()
        {
            //I really wanted to do this inside the formatted string but you can't use expression switch in there...so sad....
            string soundText = SoundRating switch
            {
                "Qt" => "Quietest",
                "Qr" => "Quieter",
                "Qu" => "Quiet",
                _ => "Moderate"
            };
            return $"{base.ToString()}\nFeature: {feature}\nSoundRating: {soundText}";
        }

        public override string FormatForFile()
        {
            return $"{base.FormatForFile()};{feature};{SoundRating};";
        }
    }
}
