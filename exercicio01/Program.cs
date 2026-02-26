using System;
class Program
{
    static void Main()
    {
        Pessoa pessoa1 = new Pessoa();

        pessoa1.Nome = "Ana Silva";
        pessoa1.Idade = 28;

        Console.WriteLine($"Nome: {pessoa1.Nome}");
        Console.WriteLine($"Idade: {pessoa1.Idade} anos");
    }
}

class Pessoa
{
    public string Nome;
    public int Idade;
}
