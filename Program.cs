namespace Ass1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Appliance> applianceList = new List<Appliance>();
            List<Refrigerator> fridgeList = new List<Refrigerator>();
            List<Vacuum> vacList = new List<Vacuum>();
            List<Microwave> microList = new List<Microwave>();
            List<Dishwasher> dwList = new List<Dishwasher>();
            Console.WriteLine("Welcome to Modern Appliances!");
            Console.WriteLine("How may we assist you?");
            Console.WriteLine("1 - Check out appliance\n" +
                "2 - Find appliances by brand\n" +
                "3 - Display appliances by type\n" +
                "4 - Produce random appliance list\n" +
                "5 - Save & exit");
            Console.WriteLine("Enter option:  ");
            int option_select = int.Parse(Console.ReadLine());
            Console.WriteLine(option_select);
            for (; ; )
            {
                if (option_select == 1)
                {
                    Console.WriteLine("Enter the number of an appliance:  ");
                    int appliance_query = int.Parse(Console.ReadLine());
                    //Below is going to check if appliance with that # exists
                    Appliance selectedAppliance = applianceList.Find(appliance => appliance.Id == appliance_query);
                    if (selectedAppliance == null)
                    {
                        Console.WriteLine("No appliances found with that item number.");
                    }
                    else
                    {
                        if (selectedAppliance.isAvailable())
                        {
                            selectedAppliance.checkout();
                            Console.WriteLine($"Appliance \"{selectedAppliance.Id}\" has been checked out ");
                        }
                        else
                        {
                            Console.WriteLine("The appliance is not available to be checked out.");
                        }
                    }
                }
                else if (option_select == 2)
                {
                    Console.WriteLine("Enter brand to search for:");
                    string? brand_query = Console.ReadLine();
                    List<Appliance> filteredAppliance = applianceList.FindAll(appliance => appliance.Brand == brand_query);
                    foreach (Appliance appliance in filteredAppliance)
                    {
                        Console.WriteLine(appliance.ToString());
                    }
                }
                else if (option_select == 3)
                {
                    Console.WriteLine("Appliance Types\n" +
                        "1 - Refrigerators\n" +
                        "2 - Vacuums\n" +
                        "3 - Microwaves\n" +
                        "4 - Dishwashers\n");
                    Console.WriteLine("Enter type of appliance:");



                    int appliance_query = int.Parse(Console.ReadLine());
                    if (appliance_query == 1)
                    {
                        Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors or 4 (four doors):");
                        int door_query = int.Parse(Console.ReadLine());
                        List<Refrigerator> filteredFridge = fridgeList.FindAll(fridge => fridge.doorNum == door_query);
                        foreach (Refrigerator fridge in filteredFridge)
                        {
                            Console.WriteLine(fridge.ToString());
                        }
                    }
                    else if (appliance_query == 2)
                    {
                        Console.WriteLine("Enter the battery voltage value. 18 V (low) or 24 V (high)");
                        int volt_query = int.Parse(Console.ReadLine());
                        List<Vacuum> filteredVac = vacList.FindAll(vac => vac.volt == volt_query);
                        foreach (Vacuum vac in filteredVac)
                        {
                            Console.WriteLine(vac.ToString());

                        }
                    }
                    else if (appliance_query == 3)
                    {
                        Console.WriteLine("Room where the microwave will be installed: K (Kitchen) or W (work site):");


                        string? room_query = Console.ReadLine();
                        List<Microwave> filteredMicro = microList.FindAll(micro => micro.room == room_query);
                        foreach (Microwave micro in filteredMicro)
                        {
                            Console.WriteLine(micro.ToString());
                        }
                    }
                    else if (appliance_query == 4)
                    {
                        Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                        string? sound_query = Console.ReadLine();
                        List<Dishwasher> filteredDw = dwList.FindAll(dw => dw.sound == sound_query);
                        foreach (Dishwasher dw in filteredDw)
                        {
                            Console.WriteLine(dw.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");


                    }
                }
                else if (option_select == 4)
                {
                    Random random = new Random();
                    HashSet<int> usedIndices = new HashSet<int>();
                    Console.WriteLine("Enter number of appliances:");
                    int random_query = int.Parse(Console.ReadLine());
                    for (int i = 0; i < random_query; i++)
                    {
                        int randomIndex;
                        do
                        {
                            randomIndex = random.Next(applianceList.Count());
                        } while (usedIndices.Contains(randomIndex));

                        usedIndices.Add(randomIndex);
                        Console.WriteLine(applianceList[randomIndex].ToString());


                    }
                }
                else if (option_select == 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");

                }
            }
        }
    }
}
