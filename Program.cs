namespace Ass1
{
    class Program
    {
        //instantiates variables to be used for the rest of the methods
        static List<Appliance> applianceList = new List<Appliance>();
        static string filePath = Path.Combine(Environment.CurrentDirectory, "appliances.txt");
        //main that runs the Program methods
        static void Main(string[] args)
        {

            applianceList = LoadApplianceData();
            MainMenu(applianceList, filePath);
        }
        //method that loads the appliance data from the txt file and outputs that to applianceList
        static List<Appliance> LoadApplianceData()
        {
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
                            continue;
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
                            //added value checking for consistency with this and the following appliance types
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
                                //simple format checking
                                Console.WriteLine($"Error at line {lineNumber}: Invalid Format - Unexpected or Insufficient Information");
                                continue;
                            }

                            applianceList.Add(appliance);
                        }
                        catch (FormatException)
                        {
                            // FormatException checks, skips line if error is called
                            Console.WriteLine($"Error at line {lineNumber}: Invalid Format - Incorrect Data Type");
                            continue;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            // Index check that skips similar to previous
                            Console.WriteLine($"Error at line {lineNumber}: Invalid Format - Missing Data Fields");
                            continue;
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                //IOException catch
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            return applianceList;
        }
        //Method that runs the Main execution of our program
        static void MainMenu(List<Appliance> applianceList, string filePath)
        {
            //infinite loop
            for (; ; )
            {
                Console.WriteLine("Welcome to Modern Appliances!");
                Console.WriteLine("How may we assist you?");
                Console.WriteLine("1 - Check out appliance\n" +
                    "2 - Find appliances by brand\n" +
                    "3 - Display appliances by type\n" +
                    "4 - Produce random appliance list\n" +
                    "5 - Save & exit");
                Console.WriteLine("Enter option:  ");
                Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop);
                string? option_select = Console.ReadLine();

                if (option_select == "1")
                {
                    Console.WriteLine("Enter the number of an appliance:  ");
                    Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop);
                    string? input = Console.ReadLine()?.Trim();
                    if (int.TryParse(input, out int appliance_query))
                    {
                        //Below is going to check if appliance with that # exists
                        Appliance? selectedAppliance = applianceList.Find(appliance => appliance.Id == appliance_query);
                        if (selectedAppliance == null)
                        {
                            Console.WriteLine("No appliances found with that item number.\n\n\n");
                        }
                        else
                        {
                            // calls isAvailable method from appliance class to theck
                            if (selectedAppliance.IsAvailable())
                            {
                                //calls Checkout method to decrement amount
                                selectedAppliance.Checkout();
                                Console.WriteLine($"Appliance \"{selectedAppliance.Id}\" has been checked out.\n\n\n");
                            }
                            else
                            {
                                Console.WriteLine("The appliance is not available to be checked out.\n\n\n");
                            }
                        }
                    }
                }
                else if (option_select == "2")
                {
                    Console.WriteLine("Enter brand to search for:");
                    Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop);
                    string? brand_query = Console.ReadLine()?.ToLower().Trim();
                    if (brand_query != null)
                    {
                        Console.WriteLine("Matching Appliances:");
                        //starts to use FindAll here instead of Find to search throughout the entire list based on criterea. Also makes it case insensitive and null-safe
                        List<Appliance> filteredAppliance = applianceList.FindAll(appliance => appliance.Brand != null && appliance.Brand.ToLower() == brand_query);
                        foreach (Appliance appliance in filteredAppliance)
                        {
                            Console.WriteLine($"{appliance.ToString()}\n\n\n");
                        }
                    }
                }
                else if (option_select == "3")
                {
                    Console.WriteLine("Appliance Types\n" +
                        "1 - Refrigerators\n" +
                        "2 - Vacuums\n" +
                        "3 - Microwaves\n" +
                        "4 - Dishwashers\n");
                    Console.WriteLine("Enter type of appliance:");
                    Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop);
                    string? appliance_query = Console.ReadLine();
                    if (appliance_query == "1")
                    {
                        Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors or 4 (four doors):");
                        Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop);
                        string? input = Console.ReadLine()?.Trim();
                        if (int.TryParse(input, out int door_query))
                        {
                            Console.WriteLine("Matching refrigerators:");
                            //below could probably have be written as FindAll but Where operates a little cleaner and FindAll was slower
                            List<Refrigerator> filteredFridge = applianceList.OfType<Refrigerator>().Where(fridge => fridge.Doors == door_query).ToList();
                            foreach (Refrigerator fridge in filteredFridge)
                            {
                                Console.WriteLine($"{fridge.ToString()}\n\n\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number of doors. \n\n\n");
                        }
                    }
                    else if (appliance_query == "2")
                    {
                        Console.WriteLine("Enter the battery voltage value. 18 V (low) or 24 V (high)");
                        Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop);
                        string? input = Console.ReadLine()?.Trim();
                        //adds a little nullcheck for the input and trims responses as previous did.
                        if (int.TryParse(input, out int volt_query) && (volt_query == 18 || volt_query == 24))
                        {
                            Console.WriteLine("Matching vacuums:");
                            List<Vacuum> filteredVac = applianceList.OfType<Vacuum>().Where(vac => vac.BatteryVoltage == volt_query).ToList();
                            foreach (Vacuum vac in filteredVac)
                            {
                                Console.WriteLine($"{vac.ToString()}\n\n\n");

                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid amount of voltage. \n\n\n");
                        }
                    }
                    else if (appliance_query == "3")
                    {
                        Console.WriteLine("Room where the microwave will be installed: K (Kitchen) or W (work site):");
                        Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop);
                        //below made case-insensitive
                        string? room_query = Console.ReadLine()?.ToUpper().Trim();
                        if (room_query == "K" || room_query == "W")
                        {
                            Console.WriteLine("Matching microwaves:");
                            List<Microwave> filteredMicro = applianceList.OfType<Microwave>().Where(micro => micro.RoomType == room_query).ToList();
                            foreach (Microwave micro in filteredMicro)
                            {
                                Console.WriteLine($"{micro.ToString()}\n\n\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter K or W for the room");
                        }
                    }
                    else if (appliance_query == "4")
                    {
                        Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
                        Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop);
                        //again made case-insensitive and trim. small note is all .Wheres were changed in Final Version to have null checks. Mainly to remove possible null dependencies.
                        string? sound_query = Console.ReadLine()?.Trim().ToLower();
                        if (sound_query == "qt" || sound_query == "qr" || sound_query == "qu" || sound_query == "m")
                        {
                            Console.WriteLine("Matching dishwashers:");
                            List<Dishwasher> filteredDw = applianceList.OfType<Dishwasher>().Where(dw => dw.SoundRating != null && dw.SoundRating.ToLower() == sound_query).ToList();
                            foreach (Dishwasher dw in filteredDw)
                            {
                                Console.WriteLine($"{dw.ToString()}\n\n\n");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input\n\n\n");
                    }
                }
                else if (option_select == "4")
                {
                    //I really like this because it reminded me of TwoSum. We just create a new Random and store each previously operated random into a Hashset to make sure there aren't duplicates.
                    Random random = new Random();
                    HashSet<int> usedIndices = new HashSet<int>();
                    Console.WriteLine("Enter number of appliances:");
                    Console.SetCursorPosition(Console.CursorLeft + 4, Console.CursorTop);
                    string? input = Console.ReadLine();
                    if (int.TryParse(input, out int random_query) && random_query > 0)
                    {
                        Console.WriteLine("Random appliances:");
                        for (int i = 0; i < random_query; i++)
                        {
                            int randomIndex;
                            do
                            {
                                randomIndex = random.Next(applianceList.Count());
                            } while (usedIndices.Contains(randomIndex));

                            usedIndices.Add(randomIndex);
                            Console.WriteLine($"{applianceList[randomIndex].ToString()}\n\n\n");
                        }
                    }
                }
                else if (option_select == "5")
                {
                    //below saves file to initiate filePath. Added applianceMaster in folder to allow for non-updated files.
                    List<string> formattedList = new List<string>();
                    foreach (Appliance appliance in applianceList)
                    {
                        formattedList.Add(appliance.FormatForFile());
                    }
                    File.WriteAllLines(filePath, formattedList);
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
