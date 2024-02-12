using LiteValidator;

Console.WriteLine("Iniciando LiteValidator!");
Console.WriteLine("------------------------------------\b\n");

var client = new Client(1, "Jhon");
Console.WriteLine("Adicionando Cliente.");
client.AddClient();
Console.WriteLine("\b\nFinalizado processamento de Cliente.");
Console.WriteLine("------------------------------------\b\n");


var product1 = new Product(1, "Water", 0, quantity: 0);
Console.WriteLine("Adicionando Produto.");
product1.AddProduct();
Console.WriteLine("\b\nFinalizado processamento de Produto.");
Console.WriteLine("------------------------------------\b\n");