namespace Ass1
{
    public class Vacuum : Appliance
    {
        private string grade;
        public int BatteryVoltage;

        public Vacuum(int id, string? brand, int quantity, int wattage, string? colour, float price, string grade, int batteryVoltage)
            : base(id, brand, quantity, wattage, colour, price)
        {
            this.grade = grade;
            this.BatteryVoltage = batteryVoltage;
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
            return $"{base.FormatForFile()};{grade};{BatteryVoltage};";
        }
    }
}
