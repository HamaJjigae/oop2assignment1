namespace Ass1
{
    //see comments for refrigerator as same applies here.
    public class Vacuum : Appliance
    {
        private string grade;
        private int batteryVoltage;

        public int BatteryVoltage
        {
            get { return batteryVoltage; }
        }
        public Vacuum(int id, string? brand, int quantity, int wattage, string? colour, float price, string grade, int batteryVoltage)
            : base(id, brand, quantity, wattage, colour, price)
        {
            this.grade = grade;
            this.batteryVoltage = batteryVoltage;
        }

        public override string ToString()
        {
            string batteryText = BatteryVoltage switch
            {
                18 => "Low",
                _ => "High"
            };
            return $"{base.ToString()}\nGrade: {grade}\nBattery Voltage: {batteryText}";
        }

        public override string FormatForFile()
        {
            return $"{base.FormatForFile()}{grade};{BatteryVoltage};";
        }
    }
}
