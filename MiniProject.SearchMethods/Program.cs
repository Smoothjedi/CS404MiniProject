using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace MiniProject.SearchMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var results = new List<string>() { "SortType, NumberOfElements, TimeInTicks" };
            SearchMethods sm = new SearchMethods();
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            var randomSeed = new Random();

            for (int i = 10; i < 10000; i+=100)
            {
                var ints = new List<int>();
                for (int j = 0; j < i; j++)
                {
                    var randomNumber = randomSeed.Next();
                    ints.Add(randomNumber);
                }
                    var serializedList = JsonSerializer.Serialize(ints);

                    var bubbleSortCopy = JsonSerializer.Deserialize<List<int>>(serializedList);
                    results.Add(BubbleSort(sm, bubbleSortCopy));

                    var quickSortCopy = JsonSerializer.Deserialize<List<int>>(serializedList);
                    results.Add(QuickSort(sm, quickSortCopy));                
            }
            using (StreamWriter outputFile = 
                new StreamWriter("Output.txt"))
            {
                foreach (string result in results)
                    outputFile.WriteLine(result);
            }
        }

        private static string BubbleSort(SearchMethods sm, List<int> listToSort)
        {
            if (listToSort == null) return string.Empty;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var bsResult = sm.BubbleSort(listToSort);
            sw.Stop();
            var result = $"BubbleSort, {listToSort.Count}, {sw.ElapsedTicks}";
            sw.Reset();
            return result;
        }

        private static string QuickSort(SearchMethods sm, List<int> listToSort)
        {
            if (listToSort == null) return string.Empty;
            Stopwatch sw = new Stopwatch(); 
            sw.Start();
            var qsResult = sm.QuickSort(listToSort, 0, listToSort.Count - 1);
            sw.Stop();
            var result = $"QuickSort, {listToSort.Count}, {sw.ElapsedTicks}";
            sw.Reset();
            return result;
        }
    }
}
