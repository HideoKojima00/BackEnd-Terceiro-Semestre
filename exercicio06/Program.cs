using System;

class Program
{
    static void Main()
    {
        // Instanciando o funcionário (que herda de Pessoa)
        Funcionario func = new Funcionario("Felipe", 35, 4500.50);

        // 1. Chamada sem parâmetros
        func.Apresentar();

        func.Apresentar("Fontes");
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

    public void Apresentar()
    {
        Console.WriteLine($"Olá, meu nome é {Nome}.");
    }

    public void Apresentar(string sobrenome)
    {
        Console.WriteLine($"Olá, meu nome completo é {Nome} {sobrenome}.");
    }
}

class Funcionario : Pessoa
{
    public double Salario { get; set; }

    public Funcionario(string nome, int idade, double salario) : base(nome, idade)
    {
        Salario = salario;
    }
}
