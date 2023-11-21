using text_file.Models;

namespace text_file.Services;

public static class TextFileService
{
    private const string CommaTab = "\t";

    public static void WriteDataToTextFile(string filePath, List<Customer> customers)
    {
        using StreamWriter writer = new(filePath);

        foreach (var currentCustomer in customers)
            writer.WriteLine($"{ currentCustomer.Id }{ CommaTab }{ currentCustomer.Name }{ CommaTab }{ currentCustomer.Email }");
    }

    public static List<Customer> ReadDataFromTextFile(string filePath)
    {
        List<Customer> customers = [];

        if (File.Exists(filePath))
        {
            using StreamReader reader = new(filePath);
            
            string? currentReadLine;

            while ((currentReadLine = reader.ReadLine()) != null)
            {
                string[] parts = currentReadLine.Split(CommaTab);
                string id = parts[0];

                if (Guid.TryParse(id, out Guid guidId) && (parts.Length == 3))
                    customers.Add(new Customer
                    {
                        Id = guidId,
                        Name = parts[1],
                        Email = parts[2]
                    });
            }            
        }

        return customers;
    }
}