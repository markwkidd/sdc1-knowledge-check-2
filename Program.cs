namespace PlantInventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String? input = String.Empty;
            Int32 numberOfRecords = 0;

            Console.WriteLine("== Plant Inventory Manager v0.1 ==");
            Console.WriteLine("");
            Console.WriteLine("** TEST MODE ENABLED       **");
            Console.WriteLine("** ADDING SQUASH VARIEITES **");
            Console.WriteLine("");
            Console.WriteLine("Commands:");
            Console.WriteLine("    X - Exit");
            Console.WriteLine("");
            Console.Write("How many squash varieties would you like to add to the database? ");

            input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                if (input.Equals("X", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Exiting.");
                    return;
                }
                try
                {
                    numberOfRecords = Int32.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{input}'");
                    Main(args); // go back to main menu. this will be refactored to a separate function to support more types of plants
                }
            }

            var recordList = new List<PlantVariety>();
            for (int i = 0; i < numberOfRecords; i++)
            {
                String? commonName, genus, species;

                Console.WriteLine($"\nAllocating new record entry {(i+1)} of {numberOfRecords}");
                Console.Write("Common name: ");
                commonName = Console.ReadLine();
                Console.Write("Genus: ");
                genus = Console.ReadLine();
                Console.Write("Species: ");
                species = Console.ReadLine();

                if (string.IsNullOrEmpty(commonName) || string.IsNullOrEmpty(genus) || string.IsNullOrEmpty(species))
                {
                    Console.WriteLine("\nINVALID INPUT. PLEASE RETRY.\n");
                    i--;
                    continue;
                }
                Squash newRecord = new Squash(commonName, genus, species);

                Console.Write("Any known toxicity (Y)es/(N)o/(U)nknown: ");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    switch (input)
                    {
                        case string s when s.Equals("y", StringComparison.CurrentCultureIgnoreCase):
                            {
                                newRecord.Toxicity = PlantVariety.ToxicStatus.KNOWN_TOXIC;
                                break;
                            }
                        case string s when s.Equals("n", StringComparison.CurrentCultureIgnoreCase):
                            {
                                newRecord.Toxicity = PlantVariety.ToxicStatus.NON_TOXIC;
                                break;
                            }
                        case string s when s.Equals("u", StringComparison.CurrentCultureIgnoreCase):
                            {
                                newRecord.Toxicity = PlantVariety.ToxicStatus.UNKOWN_TOXICITY;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("\nINVALID INPUT. PLEASE RETRY.\n");
                                i--;
                                continue;
                            }
                    }
                }

                Console.Write("Squash Bush Habit (B)ush/(V)ine/(U)nknown: ");
                input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    switch (input)
                    {
                        case string s when s.Equals("b", StringComparison.CurrentCultureIgnoreCase):
                            {
                                newRecord.BushHabit = Squash.BushHabitOptions.BUSH_HABIT;
                                break;
                            }
                        case string s when s.Equals("v", StringComparison.CurrentCultureIgnoreCase):
                            {
                                newRecord.BushHabit = Squash.BushHabitOptions.VINE_HABIT;
                                break;
                            }
                        case string s when s.Equals("u", StringComparison.CurrentCultureIgnoreCase):
                            {
                                newRecord.BushHabit = Squash.BushHabitOptions.UNKNOWN;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("\nINVALID INPUT. PLEASE RETRY.");
                                i--;
                                continue;
                            }
                    }
                }

                recordList.Add(newRecord);
            }

            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("** TEST MODE ENABLED    **");
            Console.WriteLine("** PLANT INVENTORY LIST **\n");

            foreach (var record in recordList)
            {
                Console.WriteLine(record.ToString());
            }

            Console.WriteLine("\nTEST COMPLETE. EXITING.");

        }
    }
}
