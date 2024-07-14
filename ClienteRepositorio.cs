namespace AppCliente;

public class clienteRepositorio
{
    public List<cliente> Clientes=new List<cliente>();
    public void exibirClientes()
    {
        Console.Clear();
        foreach(var cliente in Clientes)
        {
            ImprimirClientes(cliente);
        }
        Console.ReadKey();
    }



    public void cadastroCliente()
    {
        Console.Clear();

        Console.WriteLine("Nome CLiente: ");
        var nome=Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Data de nascimento: ");
        var dataNascimento = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Desconto ...");
        var desconto=decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        var Cliente =new cliente();
        {
            Cliente.Id=Clientes.Count+1;
            Cliente.Nome=nome;
            Cliente.Desconto=desconto;
            Cliente.CadastradoEm=DateTime.Now;
            Cliente.DataNascimento=dataNascimento;

            Console.WriteLine("Cliente Alterado com sucesso [Enter]");
            ImprimirClientes(Cliente);
            Console.ReadKey();
        }
    }



    public void ImprimirClientes(cliente cliente)
    {
        Console.WriteLine("ID.............: " + cliente.Id);
        Console.WriteLine("Nome...........: " + cliente.Nome);
        Console.WriteLine("Desconto.......: " + cliente.Desconto.ToString("0.00"));
        Console.WriteLine("Data Nascimento: " + cliente.DataNascimento);
        Console.WriteLine("Data Cadastro..: " + cliente.CadastradoEm);
        Console.WriteLine("------------------------------------");
    }




     public void gravarDadosClientes()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(Clientes);
        
        File.WriteAllText("clientes.txt", json);
    }








    public void lerDadosClientes()
    {
        if(File.Exists("clientes.txt"))
        {
            var dados = File.ReadAllText("Clientes.txt");
            
            var clientesArquivo = System.Text.Json.JsonSerializer.Deserialize<List<cliente>>(dados);
            
            Clientes.AddRange(clientesArquivo);
        }
    }



    public void excluirCliente()
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        var cliente = Clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado! [Enter]");
            Console.ReadKey();
            return;
        }

        ImprimirClientes(cliente);

        Clientes.Remove(cliente);

        Console.WriteLine("Cliente removido com sucesso! [Enter]");

        Console.ReadKey();
    }


    public void editarCliente()
    {
        Console.Clear();
        Console.Write("Informe o código do cliente: ");
        var codigo = Console.ReadLine();

        var cliente = Clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado! [Enter]");
            Console.ReadKey();
            return;
        }

        ImprimirClientes(cliente);

        Console.Write("Nome do cliente: ");
        var nome = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Data de nascimento: ");
        var dataNascimento = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Desconto: ");
        var desconto = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        cliente.Nome = nome;
        cliente.DataNascimento = dataNascimento;
        cliente.Desconto = desconto;
        cliente.CadastradoEm = DateTime.Now;


        Console.WriteLine("Cliente Alterado com sucesso! [Enter]");
        ImprimirClientes(cliente);
        Console.ReadKey();
    }


}
