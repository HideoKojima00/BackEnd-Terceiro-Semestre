using System;

class Program
{
    static void Main()
    {
        Funcionario func = new Funcionario("Felipe Fontes", 35, 9500.50);
        func.ExibirDados();
    }
}

// Classe Base (Pai)
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
class Funcionario : Pessoa
{
    public double Salario { get; set; }

    public Funcionario(string nome, int idade, double salario) : base(nome, idade)
    {
        Salario = salario;
    }

    public void ExibirDados()
    {
        Console.WriteLine("--- Dados do Funcionário ---");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Idade: {Idade} anos");
        Console.WriteLine($"Salário: R$ {Salario:F2}"); 
    }
}

