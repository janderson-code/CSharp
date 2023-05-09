using System;
namespace TesteDelegate
{
    delegate List<int> MeuDelegate(int x, int y);


public class Program
{
    public static void Main(string[] args)
    {
        MeuDelegate meuDelegate = new MeuDelegate(Soma);
        meuDelegate += Subtracao;
        meuDelegate += Multiplicacao;

        List<int> resultados = meuDelegate(2, 3);

        foreach (int resultado in resultados)
        {
            Console.WriteLine(resultado);
        }

        List<Delegate> delegates = meuDelegate.GetInvocationList().ToList();
        foreach (Delegate del in delegates)
        {
            MeuDelegate metodo = (MeuDelegate) del;
            List<int> resultadoMetodo = metodo(2, 3);
            Console.WriteLine(resultadoMetodo[0]);
        }
    }

    static List<int> Soma(int x, int y)
    {
        List<int> resultados = new List<int>();
        int resultado = x + y;
        resultados.Add(resultado);
        return resultados;
    }

    static List<int> Subtracao(int x, int y)
    {
        List<int> resultados = new List<int>();
        int resultado = x - y;
        resultados.Add(resultado);
        return resultados;
    }

    static List<int> Multiplicacao(int x, int y)
    {
        List<int> resultados = new List<int>();
        int resultado = x * y;
        resultados.Add(resultado);
        return resultados;
    }
}


}