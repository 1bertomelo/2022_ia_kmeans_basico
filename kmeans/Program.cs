using System;
using System.Collections.Generic;

namespace kmeans
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			List<int> baseTreinamento = new List<int>
			{
			 2,3,4,10,11,12,20,25,30
			};

			Kmeans kmeans = new Kmeans(2);
			kmeans.Treinar(baseTreinamento);

			Console.WriteLine("Treinamento Finalizado!!");

			Console.ReadLine();

		}
	}
}
