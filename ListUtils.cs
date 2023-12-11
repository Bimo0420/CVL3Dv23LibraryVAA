using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVL3Dv23LibraryVAA
{
    public static class ListUtils
    {
        public static List<int> GenerateNumberList(int startIndex, int count)
        {
            List<int> numbers = new List<int>();

            for (int i = startIndex; i < startIndex + count; i++)
            {
                numbers.Add(i);
            }
            return numbers;
        }

        public static List<T> IndexReverse<T>(List<T> list)
        {
            if (list.Count <= 1)
            {
                // Если список пустой или содержит только один элемент, возвращаем исходный список
                return list;
            }

            List<T> changedList = new List<T>(list.Count)
            {
                list[0]
            };

            for (int i = 1; i < list.Count; i++)
            {
                changedList.Insert(0, list[i]);
            }

            return changedList;
        }

        public static List<string> StringListGenerate(int count, string initialValue)
        {
            List<string> stringList = new List<string>();

            for (int i = 0; i < count; i++)
            {
                stringList.Add(initialValue + i);
            }

            return stringList;
        }

        public static List<string> AddValueToList(List<string> stringList, string valueToAdd)
        {
            List<string> modifiedList = new List<string>();

            foreach (string item in stringList)
            {
                string modifiedItem = item + valueToAdd;
                modifiedList.Add(modifiedItem);
            }

            return modifiedList;
        }

        public static List<T> FilterListByUniqueValues<T>(List<T> sourceList, List<T> filterList)
        {
            // Создаем хеш-множество для хранения уникальных значений
            HashSet<T> uniqueValues = new HashSet<T>();

            // Создаем новый список для отфильтрованных значений
            List<T> filteredList = new List<T>();

            for (int i = 0; i < sourceList.Count; i++)
            {
                T value = sourceList[i];

                // Если значение еще не было добавлено в уникальное множество,
                // то добавляем его в список отфильтрованных значений и в множество
                if (uniqueValues.Add(value))
                {
                    filteredList.Add(filterList[i]);
                }
            }

            return filteredList;
        }


    }

}
