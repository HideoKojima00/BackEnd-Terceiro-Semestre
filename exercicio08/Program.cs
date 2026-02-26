using System;

class Program
{
    static void Main()
    {
        IAutenticavel user = new Usuario("Felipe_dev", "1234");
        IAutenticavel admin = new Administrador("admin_master", "root");

        Console.WriteLine("--- Teste de Autenticação ---");
        
        Console.Write("Usuário comum: ");
        user.Autenticar("1234"); 

        Console.Write("Administrador: ");
        admin.Autenticar("senha_errada"); 
    }
}

interface IAutenticavel
{
    bool Autenticar(string senha);
}

class Usuario : IAutenticavel
{
    public string Login { get; set; }
    private string _senha;

    public Usuario(string login, string senha)
    {
        Login = login;
        _senha = senha;
    }

    public bool Autenticar(string senha)
    {
        if (_senha == senha)
        {
            Console.WriteLine($"Acesso concedido ao usuário {Login}.");
            return true;
        }
        Console.WriteLine($"Acesso negado para o usuário {Login}.");
        return false;
    }
}

class Administrador : IAutenticavel
{
    public string Cargo { get; set; }
    private string _senhaMestra;

    public Administrador(string cargo, string senha)
    {
        Cargo = cargo;
        _senhaMestra = senha;
    }

    public bool Autenticar(string senha)
    {
        if (_senhaMestra == senha)
        {
            Console.WriteLine($"LOG: Administrador ({Cargo}) entrou no sistema.");
            return true;
        }
        Console.WriteLine("ALERTA: Tentativa de invasão na conta administrativa!");
        return false;
    }
}
