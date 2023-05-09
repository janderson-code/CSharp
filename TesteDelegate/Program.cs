using System;
namespace TesteDelegate
{

//Example 1
delegate List<int> MeuDelegate(int x, int y);

// Example 2
public delegate int del (int x);
public delegate void Deltexto(string texto);


public class Program
{
    public static void Main(string[] args)
    {
        //Example 1
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

        // Example 2
        del handle = testeDel;
		handle += testeDel2;
		handle +=(a) => 2 *10;
		Console.WriteLine(handle(3));
		Deltexto handleTexto = textoTeste;
		MetodoCallback(1,2,handleTexto);
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
    	public static int testeDel(int num){
		
		return num * 2;
	}
	public static int testeDel2(int num){
	
		return num *3;
	}
	public static void textoTeste(string message){
	
		Console.Write(message);
	}
	public static void MetodoCallback(int num, int num2, Deltexto callback)
	{
	   callback("O calculo é"+ (num + num2).ToString());
	}
}
}