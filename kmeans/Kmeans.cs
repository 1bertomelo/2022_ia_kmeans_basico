using System;
using System.Collections.Generic;
using System.Text;

namespace kmeans
{
	internal class Kmeans
	{

		public List<int> BaseTreinamento { get; private set; }
		public List<int> k1 { get; private set; }
		public List<int> k2 { get; private set; }
		public int K { get; private set; }

		public Kmeans(int k)
		{
			K = k;
			k1 = new List<int>();
			k2 = new List<int>();	
		}

		public void Treinar(List<int> baseTreinamento)
		{
			//calculo do kmeans
			double m1 = 4;// depois sortear aletorio
			double m2 = 12;//depois sortear aletorio
			double d1, d2;
			List<int> k1anterior = new List<int>();
			List<int> k2anterior = new List<int>();
			bool k1Mudou = true;
			bool k2Mudou = true;
			while (k1Mudou || k2Mudou)
			{
				foreach (var item in baseTreinamento)
				{
					//calcular distancia entre item e m1 e m2
					d1 = DistanciaEuclidiana(item, m1);//2 e 4
					d2 = DistanciaEuclidiana(item, m2);//2 e 12
					if (d1 <= d2)
						k1.Add(item);
					else
						k2.Add(item);
				}
				m1 = MediaGrupo(k1);    m2 = MediaGrupo(k2);
				k1Mudou = GruposSaoDiferentes(k1, k1anterior);
				k2Mudou = GruposSaoDiferentes(k2, k2anterior);
				k1anterior.Clear(); 	k2anterior.Clear();
				if(k1Mudou || k2Mudou)
				{
					CopiaGrupo(k1, k1anterior);
					CopiaGrupo(k2, k2anterior);
					k1.Clear();
					k2.Clear();
				}
			}
	
		}

		private double DistanciaEuclidiana(double x , double y)
		{
			return Math.Sqrt((x - y) * (x - y));
		}

		private double MediaGrupo(List<int> g)
		{
			double media = 0;
			foreach (var item in g)
				media += item;
			return media / g.Count;
		}

		private bool GruposSaoDiferentes(List<int> g1, List<int> g2)
		{ //g1 2,3,4    g2 2,3,5,10
			if (g1.Count != g2.Count)
				return true;
			for (int i = 0; i < g1.Count; i++)
				if (g1[i] != g2[i])
					return true;
			return false;
		}

		private void CopiaGrupo(List<int> g1, List<int> g2)
		{
			foreach (var item in g1)
				g2.Add(item);
		}
	}
}
