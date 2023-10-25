using System.Text.Json;

namespace MiniProject.SearchMethods
{
    public class SearchMethods
    {
        public List<int> BubbleSort(List<int> initialList)
        {
            var listCopy = JsonSerializer.Serialize(initialList);
            var copiedList = JsonSerializer.Deserialize<List<int>>(listCopy);
            if (copiedList == null)
                return new List<int>();

            for (int j = 0; j <= copiedList.Count - 2; j++)
            {
                for (int i = 0; i <= copiedList.Count - 2; i++)
                {
                    if (copiedList[i] > copiedList[i + 1])
                    {
                        copiedList.Reverse(i, 2);
                    }
                }
            }
            return copiedList;
        }

        public List<int> QuickSort(List<int> list, int left, int right)
        {
            var i = left;
            var j = right;
            var pivot = list[left];
            while (i <= j)
            {
                while (list[i] < pivot)
                {
                    i++;
                }

                while (list[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                    i++;
                    j--;
                }
            }

            if (left < j)
                QuickSort(list, left, j);
            if (i < right)
                QuickSort(list, i, right);
            return list;
        }
    }
}
