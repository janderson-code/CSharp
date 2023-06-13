using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

					
public class Teste
{
	public static void Main()
	{
	 /*	var lista = new[]{"Corinthians","Santos","Palmeiras"};
		Action<string> minhaAction = new Action<string>(Console.WriteLine);
		
		//Array.ForEach(lista,Console.WriteLine);
		
		Array.ForEach(lista,minhaAction);
		*/
		Clube cl = new Clube();
		
		var listaTimes = cl.ListarTimes();
		
		Action<Clube> actionClube = new Action<Clube>(cl.MudarNomeClube);
		
		listaTimes.ForEach(actionClube);
		
		foreach(var clube in listaTimes){
		
			Console.WriteLine(clube.Nome);
		}
	}
	
}

public class Clube{

	public string Nome{get;set;}
	public string Estadio{get;set;}


	public List<Clube> ListarTimes()
	{

		return new List<Clube>(){new Clube{Nome ="Corinthians",Estadio= "Itaquera"},new Clube{Nome = "Real madrid",Estadio="Bernabeu"}};
	}
	
	public void MudarNomeClube(Clube clube){
	
		clube.Nome = "Barcelona";
	}
}