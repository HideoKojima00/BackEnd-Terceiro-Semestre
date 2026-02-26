using System;

class Program
{
    static void Main()
    {
        Pessoa p = new Pessoa("Felipe Fontes", 30);

        Console.WriteLine($"Nome: {p.Nome}");
        Console.WriteLine($"Idade: {p.Idade}");

        Pessoa p2 = new Pessoa("Invalido", -10);
        Console.WriteLine($"Idade do p2: {p2.Idade}"); 
    }
}

class Pessoa
{
    
    public string Nome { get; set; }
    private int _idade;

    public int Idade
    {
        get { return _idade; }
        set { if (value > 0) _idade = value; }
    }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade; 
    }
}
