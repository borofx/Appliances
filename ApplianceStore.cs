using appliances;

public class ApplianceStore
{
    private string _code = string.Empty;
    private string _name = string.Empty;
    private List<Appliance> _apps = new List<Appliance>();

    public ApplianceStore(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public string Code
    {
        get { return _code; }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Code cannot be null or empty.");
            _code = value;
        }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("Name cannot be null or empty.");
            _name = value;
        }
    }

    public List<Appliance> Appliances
    {
        get { return _apps; }
        private set
        {
            if (value == null)
                throw new ArgumentNullException("Appliances list cannot be null.");
            _apps = value;
        }
    }

    public void AddAppliance(Appliance appliance)
    {
        try
        {
            if (appliance == null)
                throw new ArgumentException("Appliance cannot be null.");

            Appliances.Add(appliance);
            Console.WriteLine($"Appliance added successfully: {appliance.Code}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding appliance: {ex.Message}");
        }
    }


    public void RemoveAppliance(string code)
    {
        Appliances.RemoveAll(a => a.Code == code);
    }

    public List<Appliance> SearchByType(string type)
    {
        return Appliances.Where(a => a.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalPrice = 0;
        foreach (var item in Appliances)
        {
            Console.WriteLine(item.Code +" "+ item.Price + " "+item.Quantity);
            totalPrice += (decimal)item.Price * (decimal)item.Quantity;
        }
        return totalPrice;
    }

    public List<Appliance> GetOutOfStockAppliances()
    {
        return Appliances.Where(a => a.Quantity == 0).ToList();
    }

    public List<Appliance> SearchByManufacturer(string manufacturer)
    {
        return Appliances.Where(a => a.Manufacturer.Equals(manufacturer, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Appliance> GetTop10ByEfficiency(string type)
    {
        try
        {            
            var temp =  Appliances
                .Where(a => a.Type == type)
                .OrderBy(a => a.CalculateEnergyEfficiecy())
                .ThenBy(a => a.Consumption)
                .Take(10)
                .ToList();
            Console.WriteLine(temp.Count);
            return temp;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting top 10 by efficiency: {ex.Message}");
            return new List<Appliance>();
        }
    }
}
