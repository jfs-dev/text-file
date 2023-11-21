using text_file.Models;
using text_file.Services;

var filePath = "Data/TextFile.txt";

List<Customer> writeCustomers =
[
    new() { Name = "Peter Parker", Email = "peter.parker@marvel.com" },
    new() { Name = "Ben Parker", Email = "ben.parker@marvel.com" },
    new() { Name = "Mary Jane", Email = "mary.jane@marvel.com" }
];

TextFileService.WriteDataToTextFile(filePath, writeCustomers);

var readCustomers = TextFileService.ReadDataFromTextFile(filePath);

Console.ForegroundColor = ConsoleColor.Magenta;

foreach (var currentCustomer in readCustomers)
    Console.WriteLine($"Id: { currentCustomer.Id }, Nome: { currentCustomer.Name }, e-mail: { currentCustomer.Email }");