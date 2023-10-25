using System.Text.Json;

namespace MiniProject.SearchMethods
{
    public class SearchMethods
    {
        public List<int> BubbleSort(List<int> list)
        {
            for (int j = 0; j <= list.Count - 2; j++)
            {
                for (int i = 0; i <= list.Count - 2; i++)
                {
                    if (list[i] > list[i + 1])
                    {
                        list.Reverse(i, 2);
                    }
                }
            }
            return list;
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
