// See https://aka.ms/new-console-template for more information
using SOLID.SRP;

PeopleService productInventory = new PeopleService();

string print = string.Empty;
string userInput = string.Empty;
string quantityInput = string.Empty;
productInventory.GenerateReport();

while (string.IsNullOrEmpty(userInput))
{
    Console.WriteLine("Ingresa el Id de una Persona:");

    userInput = Console.ReadLine();
    
    Console.WriteLine("Ingresa la cantidad agregada a un producto:");

    quantityInput = Console.ReadLine();

    int idProduct = 0;
    int.TryParse(userInput, out idProduct);

    int quantity = 0;
    int.TryParse(quantityInput, out quantity);
    productInventory.AddPersonYears(idProduct, quantity);
    productInventory.GenerateReport();
    userInput = string.Empty;
    quantityInput = string.Empty;
}

Console.ReadLine(); 