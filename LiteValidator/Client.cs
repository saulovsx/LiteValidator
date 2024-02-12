namespace LiteValidator
{
    public class Client(int id, string name)
    {
        public int Id { get; set; } = id;
        public string? Name { get; set; } = name;

        public void AddClient()
        {
            Console.WriteLine("Validando Client.");
            var validatorResult = BuilderValidateClient().Validate(this);
            
            if (!validatorResult.IsValid)
            {
                foreach (var item in validatorResult.Messages)
                {
                    Console.WriteLine(item);
                }
                return;
            }
            SaveClient();
        }        

        LiteValidator<Client> BuilderValidateClient()
        {
            return new LiteValidator<Client>()
            .AddRule(f => !string.IsNullOrEmpty(f.Name))
            .AddError("*** Nome não pode ser nulo. ***")
            .Build();
        }
        public void SaveClient()
        {
            //Implementação de persistência
            Console.WriteLine("Salvando Client.");
        }
    }
}