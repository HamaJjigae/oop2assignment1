namespace Ass1
{
    //see comments for refrigerator as same applies here.
    public class Dishwasher : Appliance
    {
        private string feature;
        private string soundRating;

        public string SoundRating
        {
            get { return soundRating; }
        }

        public Dishwasher(int id, string? brand, int quantity, int wattage, string? colour, float price, string feature, string soundRating)
            : base(id, brand, quantity, wattage, colour, price)
        {
            this.feature = feature;
            this.soundRating = soundRating;
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
            return $"{base.FormatForFile()}{feature};{SoundRating};";
        }
    }
}
