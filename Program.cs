namespace Ass1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Appliance> applianceList = new List<Appliance>();
            string filePath = Path.Combine(Environment.CurrentDirectory, "Appliances.txt");
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int lineNumber = 0;
                foreach (string line in lines)
                {
                    lineNumber++;

                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        string[] values = line.Split(";");

                        if (values.Length <= 7)
                        {
                            Console.WriteLine($"Error at line {lineNumber}: Invalid Format - Insufficient Lines");
                        }

                        try
                        {
                            char type = values[0][0];
                            int id = int.Parse(values[0]);
                            string brand = values[1];
                            int quantity = int.Parse(values[2]);
                            int wattage = int.Parse(values[3]);
                            string colour = values[4];
                            float price = float.Parse(values[5]);

                            Appliance appliance;
                            if (type == '1')
                            {
                                int doors = int.Parse(values[6]);
                                int height = int.Parse(values[7]);
                                int width = int.Parse(values[8]);
                                appliance = new Refrigerator(id, brand, quantity, wattage, colour, price, doors, height, width);
                            }
                            else if (type == '2' && (values[7] == "18" || values[7] == "24"))
                            {
                                string grade = values[6];
                                int batteryVoltage = int.Parse(values[7]);
                                appliance = new Vacuum(id, brand, quantity, wattage, colour, price, grade, batteryVoltage);
                            }
                            else if (type == '3' && (values[7] == "W" || values[7] == "K"))
                            {
                                float capacity = float.Parse(values[6]);
                                string roomType = values[7];
                                appliance = new Microwave(id, brand, quantity, wattage, colour, price, capacity, roomType);
                            }
                            else if ((type == '4' || type == '5') && (values[7] == "Qt" || values[7] == "Qr" || values[7] == "Qu" || values[7] == "M"))
                            {
                                string feature = values[6];
                                string soundRating = values[7];
                                appliance = new Dishwasher(id, brand, quantity, wattage, colour, price, feature, soundRating);
                            }
                            else
                            {
                                Console.WriteLine($"Error at line {lineNumber}: Invalid Format - Unexpected or Insufficient Information");
                                continue;
                            }

                            applianceList.Add(appliance);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"Error at line {lineNumber}: Invalid Format - Incorrect Data Type");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine($"Error at line {lineNumber}: Invalid Format - Missing Data Fields");
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }


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
                        if (selectedAppliance.IsAvailable())
                        {
                            selectedAppliance.Checkout();
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
                        int doorQuery = int.Parse(Console.ReadLine());
                        List<Refrigerator> filteredFridge = applianceList.OfType<Refrigerator>().Where(fridge => fridge.DoorNum == doorQuery).ToList();
                        foreach (Refrigerator fridge in filteredFridge)
                        {
                            Console.WriteLine(fridge.ToString());
                        }
                    }
                    else if (appliance_query == 2)
                    {
                        Console.WriteLine("Enter the battery voltage value. 18 V (low) or 24 V (high)");
                        int voltQuery = int.Parse(Console.ReadLine());
                        List<Vacuum> filteredVac = applianceList.OfType<Vacuum>().Where(vac => vac.Volt == voltQuery).ToList();
                        foreach (Vacuum vac in filteredVac)
                        {
                            Console.WriteLine(vac.ToString());

                        }
                    }
                    else if (appliance_query == 3)
                    {
                        Console.WriteLine("Room where the microwave will be installed: K (Kitchen) or W (work site):");
                        string? roomQuery = Console.ReadLine();
                        List<Microwave> filteredMicro = applianceList.OfType<Microwave>().Where(micro => micro.Room == roomQuery).ToList();
                        foreach (Microwave micro in filteredMicro)
                        {
                            Console.WriteLine(micro.ToString());
                        }
                    }
                    else if (appliance_query == 4)
                    {
                        Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                        string? soundQuery = Console.ReadLine();
                        List<Dishwasher> filteredDw = applianceList.OfType<Dishwasher>().Where(dw => dw.Sound == soundQuery).ToList();
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
