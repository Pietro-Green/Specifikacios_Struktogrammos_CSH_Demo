using System.Collections.Generic;

namespace Legmelegebb_t._leghidegebb_napjai
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] s = Console.ReadLine().Split(' ');
            int.TryParse(s[0], out int N);
            int.TryParse(s[1], out int M);
            int[,] temps = new int[N, M];
            int maxT = 0;
            List<int> maxTC = new List<int>();

            for (int i = 0; i < N; i++)
            {
                string[] curTemp = Console.ReadLine().Split(' ');
                for (int j = 0; j < M; j++)
                {
                    int.TryParse(curTemp[j], out temps[i, j]);
                    if (temps[i, j] > maxT)
                    {
                        maxT = temps[i, j];
                        maxTC.Clear();
                        maxTC.Add(i+1);
                    }
                    else if (temps[i, j] == maxT)
                    {
                        maxTC.Add(i + 1);
                    }
                }
            }
            List<int> sorszamok = new List<int>();
            HashSet<int> tempSet = new HashSet<int>(maxTC);
            int[] maxTCSet = tempSet.ToArray();
            for (int i = 0; i < maxTCSet.Count(); i++)
            {
                int min = 51;
                for (int j = 0; j < M; j++)
                {
                    if (temps[maxTCSet[i] - 1, j] < min)
                    {
                        min = temps[maxTCSet[i] - 1, j];
                    }
                }
                for (int j = 0; j < M; j++)
                {
                    if (temps[maxTCSet[i] - 1, j] == min)
                    {
                        sorszamok.Add(j + 1);
                    }
                }
            }
            HashSet<int> set = new HashSet<int>(sorszamok);
            List<int> sorszSort = set.ToList();
            sorszSort.Sort();
            Console.Write(sorszSort.Count());
            foreach (int item in sorszSort)
            {
                Console.Write(" " + item);
            }
        }
    }
}