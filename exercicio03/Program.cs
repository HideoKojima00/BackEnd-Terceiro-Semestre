using System;

class Program
{
    static void Main()
    {
        Pessoa p = new Pessoa();
        p.Nome = "Carlos";
        
        p.Idade = -5; 
        
        p.Idade = 25;

        Console.WriteLine($"Nome: {p.Nome}");
        Console.WriteLine($"Idade: {p.Idade}");
    }
}

class Pessoa
{
    public string Nome { get; set; }
    
    private int _idade;
    public int Idade
    {
        get { return _idade; }
        set 
        {
            if (value > 0)
            {
                _idade = value;
            }
            else
            {
                Console.WriteLine("Erro: A idade deve ser maior que zero.");
            }
        }
    }
}
