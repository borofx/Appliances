namespace appliances
{
    public class Program
    {
        static void Main(string[] args)
        {
            ApplianceStore store = new ApplianceStore("ednodve", "MyStore");
            StreamReader reader = new StreamReader("input.txt");
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split();

                    string code = parts[0];
                    string manufacturer = parts[1];
                    string type = parts[2];
                    double price = double.Parse(parts[3]);
                    double consumption = double.Parse(parts[4]);
                    string efficiency = parts[5];
                    int quantity = int.Parse(parts[6]);

                    Appliance appliance = new Appliance(code, manufacturer, type, price, consumption, efficiency, quantity);
                    store.AddAppliance(appliance);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] input = command.Split();

                switch (input[0])
                {
                    case "Add":
                        string code = input[1];
                        string manufacturer = input[2];
                        string type = input[3];
                        double price = double.Parse(input[4]);
                        double consumption = double.Parse(input[5]);
                        string efficiency = input[6];
                        int quantity = int.Parse(input[7]);
                        store.AddAppliance(new Appliance(code, manufacturer, type, price, consumption, efficiency, quantity));
                        break;

                    case "Remove":
                        store.RemoveAppliance(input[1]);
                        break;

                    case "SearchByType":
                        string typeSearch = input[1];
                        var appliancesByType = store.SearchByType(typeSearch);
                        using (StreamWriter writer = new StreamWriter("searchByType.txt"))
                        {
                            foreach (var appliance in appliancesByType)
                            {
                                writer.WriteLine($"{appliance.Code}: {appliance.Manufacturer} - {appliance.Type} - {appliance.Price} - {appliance.Consumption} - {appliance.Efficiency} - {appliance.Quantity}");
                            }
                        }
                        break;

                    case "SearchByManufacturer":
                        string manufacturerSearch = input[1];
                        var appliancesByManufacturer = store.SearchByManufacturer(manufacturerSearch);
                        using (StreamWriter writer = new StreamWriter("searchByManufacturer.txt"))
                        {
                            foreach (var appliance in appliancesByManufacturer)
                            {
                                writer.WriteLine($"{appliance.Code}: {appliance.Manufacturer} - {appliance.Type} - {appliance.Price} - {appliance.Consumption} - {appliance.Efficiency} - {appliance.Quantity}");
                            }
                        }
                        break;

                    case "GetOutOfStock":
                        var outOfStockAppliances = store.GetOutOfStockAppliances();
                        StreamWriter getOut = new StreamWriter("outOfStock.txt");
                        {
                            foreach (var item in outOfStockAppliances)
                            {
                                getOut.WriteLine($"Code: {item.Code}, Manufacturer: {item.Manufacturer}, Type: {item.Type}, Price: {item.Price}, Efficiency: {item.Efficiency}, Quantity: {item.Quantity}");
                            }
                        }
                        getOut.Close();
                        break;

                    case "CalculateTotalPrice":
                        decimal totalPrice = store.CalculateTotalPrice();
                            Console.WriteLine($"Total Price: {totalPrice}");
                        break;

                    case "top10":
                        string typee = input[1];
                        var top10List = store.GetTop10ByEfficiency(typee);
                        StreamWriter writerEf = new StreamWriter("getTop10.txt");
                        {
                            foreach (var item in top10List)
                            {
                                writerEf.WriteLine($"Code: {item.Code}, Manufacturer: {item.Manufacturer}, Type: {item.Type}, Price: {item.Price}, Efficiency: {item.Efficiency}, Quantity: {item.Quantity}");
                            }
                        }
                        writerEf.Close();
                        break;
                }
            }

            reader.Close();
        }
    }
}
        
