namespace LiteValidator
{
    public class Product(int id, string name, decimal price, decimal quantity)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
        public decimal Quantity { get; set; } = quantity;
        public decimal Total 
        {
            get { return Price * Quantity; }
        }

        public void AddProduct()
        {
            Console.WriteLine("Validando Produto.");            
            var validatorResult = ValidateProduct(this);

            if (!validatorResult.IsValid)
            {
                foreach (var item in validatorResult.Messages)
                {
                    Console.WriteLine(item);
                }
                return;
            }
            SaveProduct();
        }
        ValidationResult ValidateProduct(Product product)
        {
            return new LiteValidator<Product>()
            .AddRule(f => !string.IsNullOrEmpty(f.Name))
            .AddError("*** Nome não pode ser nulo. ***")
            .Then()
            .AddRule(f => f.Quantity > 0)
            .AddError("*** Quantidade deve ser maior que zero. ***")
            .Then()
            .AddRule(f => f.Price > 0)
            .AddError("*** Preço deve ser maior que zero. ***")
            .Validate(product);
        }

        public void SaveProduct()
        {
            //Implementação de persistência
            Console.WriteLine("Salvando Product.");
        }
    }
}