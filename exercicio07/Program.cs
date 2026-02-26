using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Veiculo> garagem = new List<Veiculo>();
        
        garagem.Add(new Carro());
        garagem.Add(new Bicicleta());

        Console.WriteLine("--- Testando a Locomoção ---");
        foreach (var v in garagem)
        {
            v.Mover(); 
        }
    }
}
class Veiculo
{
    public virtual void Mover()
    {
        Console.WriteLine("O veículo está se movendo.");
    }
}

class Carro : Veiculo
{
    public override void Mover()
    {
        Console.WriteLine("O carro está acelerando pelo asfalto: Vrum vrum!");
    }
}

class Bicicleta : Veiculo
{
    public override void Mover()
    {
        Console.WriteLine("A bicicleta está sendo pedalada pela ciclovia.");
    }
}
