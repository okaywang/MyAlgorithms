using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAlgorithms
{
    public class RoutineAlgorithms
    {
        public static int BinarySearch(int[] sortedItems, int target)
        {
            var fromIndex = 0;
            var endIndex = sortedItems.Length - 1;
            var midIndex = (endIndex - fromIndex) / 2;
            while (sortedItems[midIndex] != target)
            {
                if (fromIndex == endIndex)
                {
                    return -1;
                }
                if (sortedItems[midIndex] > target)
                {
                    endIndex = midIndex - 1;
                }
                else
                {
                    fromIndex = midIndex + 1;
                }
                midIndex = fromIndex + (endIndex - fromIndex) / 2;
            }
            return midIndex;
        }

        public static int BinarySearchRecursively(int[] sortedItems, int target, int fromIndex, int endIndex)
        {
            var midIndex = fromIndex + (endIndex - fromIndex) / 2;
            if (sortedItems[midIndex] == target)
            {
                return midIndex;
            }
            if (fromIndex == endIndex)
            {
                return -1;
            }

            if (sortedItems[midIndex] > target)
            {
                endIndex = midIndex - 1;
            }
            else
            {
                fromIndex = midIndex + 1;
            }
            return BinarySearchRecursively(sortedItems, target, fromIndex, endIndex);
        }

        public static void Hanoi(int[] cylinders, string fromPillar, string toPillar, string tempPillar)
        {
            if (cylinders.Count() == 0)
            {
                return;
            }

            var topPartCylinders = cylinders.Skip(1).ToArray();
            var lastCylinder = cylinders.First();

            Hanoi(topPartCylinders, fromPillar, tempPillar, toPillar);

            Console.WriteLine("move cylinder({0}) from {1} to {2}", lastCylinder, fromPillar, toPillar);

            Hanoi(topPartCylinders, tempPillar, toPillar, fromPillar);
        }

        public static int TreeDepth(BinaryTree bTree)
        {
            if (bTree == null)
            {
                return 0;
            }

            int dLeft = TreeDepth(bTree.Left);
            int dRight = TreeDepth(bTree.Right);

            var depth = Math.Max(dLeft, dRight);
            return depth + 1;
        }

        public static void PreOrderTraversal(BinaryTree bTree)
        {
            if (bTree == null)
            {
                return;
            }
            Console.WriteLine(bTree.Value);
            PreOrderTraversal(bTree.Left);
            PreOrderTraversal(bTree.Right);
        }

        public static void InOrderTraversal(BinaryTree bTree)
        {
            if (bTree == null)
            {
                return;
            }
            InOrderTraversal(bTree.Left);
            Console.WriteLine(bTree.Value);
            InOrderTraversal(bTree.Right);
        }

        public static void PostOrderTraversal(BinaryTree bTree)
        {
            if (bTree == null)
            {
                return;
            }
            PostOrderTraversal(bTree.Left);
            PostOrderTraversal(bTree.Right);
            Console.WriteLine(bTree.Value);
        }

        public static class Sort
        {
            #region 排序分类:"插入"排序
            #region 直接插入排序
            public static void StraightInsertionSort(int[] items)
            {
                int seqIndexTo = 0;
                for (int i = 1; i < items.Length; seqIndexTo++, i++)
                {
                    int candidate = items[i];
                    if (candidate < items[i - 1])
                    {
                        for (int j = 0; j < seqIndexTo + 1; j++)
                        {
                            if (items[j] > candidate)
                            {
                                Utility.MoveBackword(items, j, seqIndexTo);
                                items[j] = candidate;
                                break;
                            }
                        }
                    }
                }
            }
            #endregion

            #region 希尔排序
            public static void ShellSort(int[] items)
            {
                int increment = items.Length;
                do
                {
                    increment = increment / 3 + 1;
                    for (int i = increment; i < items.Length; i++)
                    {
                        if (items[i] < items[i - increment])
                        {
                            int candidate = items[i];
                            int j = i - increment;
                            for (; j >= 0 && candidate < items[j]; j -= increment)
                            {
                                items[j + increment] = items[j];
                            }
                            items[j + increment] = candidate;
                        }
                    }
                } while (increment > 1);
            }
            #endregion
            #endregion

            #region 排序分类:"交换"排序
            #region 冒泡排序
            public static void BubbleSort2Front(int[] items)
            {
                for (int i = 1; i < items.Length; i++)
                {
                    for (int j = items.Length - 1; j >= i; j--)
                    {
                        if (items[j - 1] > items[j])
                        {
                            Utility.Swap(items, j - 1, j);
                        }
                    }
                }
            }
            public static void BubbleSort2Behind(int[] items)
            {
                for (int i = 1; i < items.Length; i++)
                {
                    for (int j = 0; j <= items.Length - i - 1; j++)
                    {
                        if (items[j] > items[j + 1])
                        {
                            Utility.Swap(items, j, j + 1);
                        }
                    }
                }
            }
            #endregion

            #region 快速排序
            public static void QuickSort(int[] items)
            {
                QSort(items, 0, items.Length - 1);
            }
            private static void QSort(int[] items, int fromIndex, int endIndex)
            {
                int pivotIndex;
                if (fromIndex < endIndex)
                {
                    pivotIndex = PartitionUsingLastAsPivot(items, fromIndex, endIndex);
                    QSort(items, fromIndex, pivotIndex - 1);
                    QSort(items, pivotIndex + 1, endIndex);
                }
            }
            private static int PartitionUsingFirstAsPivot(int[] items, int fromIndex, int endIndex)
            {
                int pivotIndex = fromIndex;
                int pivotKey = items[pivotIndex];
                while (fromIndex < endIndex)
                {
                    while (fromIndex < endIndex && items[endIndex] > pivotKey)
                    {
                        endIndex--;
                    }
                    Utility.Swap(items, fromIndex, endIndex);
                    while (fromIndex < endIndex && items[fromIndex] < pivotKey)
                    {
                        fromIndex++;
                    }
                    Utility.Swap(items, fromIndex, endIndex);
                }
                return fromIndex;
            }
            private static int PartitionUsingLastAsPivot(int[] items, int fromIndex, int endIndex)
            {
                int pivotIndex = endIndex;
                int pivotKey = items[pivotIndex];
                while (fromIndex < endIndex)
                {
                    while (fromIndex < endIndex && items[fromIndex] < pivotKey)
                    {
                        fromIndex++;
                    }
                    Utility.Swap(items, fromIndex, endIndex);
                    while (fromIndex < endIndex && items[endIndex] > pivotKey)
                    {
                        endIndex--;
                    }
                    Utility.Swap(items, fromIndex, endIndex);
                }
                return fromIndex;
            }
            #endregion
            #endregion

            #region 排序分类:"选择"排序
            #region 直接选择排序
            public static void SelectionSourt(int[] items)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < items.Length; j++)
                    {
                        if (items[j] < items[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    if (minIndex != i)
                    {
                        Utility.Swap(items, i, minIndex);
                    }
                }
            }
            #endregion

            #region 堆排序
            public static void HeapSort(int[] items)
            {
                for (int i = items.Length / 2; i >= 0; i--)
                {
                    Utility.HeapifyMax(items, i, items.Length - 1);
                }

                for (int j = items.Length - 1; j >= 0; j--)
                {
                    Utility.Swap(items, 0, j);
                    Utility.HeapifyMax(items, 0, j - 1);
                }
            }
            #endregion
            #endregion

            #region 排序分类:"归并"排序
            #region 归并排序
            public static void MergingSort(ref int[] items)
            {
                int[] tgtItems = new int[items.Length];
                MSort(items, tgtItems, 0, items.Length - 1);
                items = tgtItems;
            }
            private static void MSort(int[] items, int[] tgtItems, int fromIndex, int endIndex)
            {
                int[] tmpItems = new int[items.Length];
                if (fromIndex == endIndex)
                {
                    tgtItems[fromIndex] = items[fromIndex];
                }
                else
                {
                    int midIndex = (fromIndex + endIndex) / 2;
                    MSort(items, tmpItems, fromIndex, midIndex);
                    MSort(items, tmpItems, midIndex + 1, endIndex);

                    Utility.MergeOrderly(tmpItems, tgtItems, fromIndex, midIndex, endIndex);
                }
            }
            #endregion
            #endregion 
        }
    }


    public static class Utility
    {
        public static void Swap(int[] items, int i, int j)
        {
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        public static void MoveBackword(int[] items, int fromIndex, int endIndex)
        {
            for (int i = endIndex; i >= fromIndex; i--)
            {
                items[i + 1] = items[i];
            }
        }

        public static void MergeOrderly(int[] srcTtems, int[] tgtItems, int fromIndex, int midIndex, int endIndex)
        {
            int recordCount = endIndex - fromIndex + 1;
            int tIndex = fromIndex;
            int i = fromIndex, j = midIndex + 1;
            for (; i <= midIndex && j <= endIndex; tIndex++)
            {
                if (srcTtems[i] < srcTtems[j])
                {
                    tgtItems[tIndex] = srcTtems[i++];
                }
                else
                {
                    tgtItems[tIndex] = srcTtems[j++];
                }
            }

            if (i <= midIndex)
            {
                for (int l = 0; l <= midIndex - i; l++)
                {
                    tgtItems[tIndex + l] = srcTtems[i + l];
                }
            }

            if (j <= endIndex)
            {
                for (int m = 0; m <= endIndex - j; m++)
                {
                    tgtItems[tIndex + m] = srcTtems[j + m];
                }
            }
        }

        public static void HeapifyMax(int[] items, int rootIndex, int maxIndex)
        {
            int temp = items[rootIndex];
            for (int childNodeIndex = rootIndex * 2 + 1; childNodeIndex <= maxIndex; childNodeIndex = 2 * childNodeIndex + 1)
            {
                if ((childNodeIndex + 1) <= maxIndex && items[childNodeIndex] < items[childNodeIndex + 1])
                {
                    ++childNodeIndex;
                }
                if (temp >= items[childNodeIndex])
                {
                    break;
                }
                items[rootIndex] = items[childNodeIndex];
                rootIndex = childNodeIndex;
            }

            items[rootIndex] = temp;
        }
    }

    public class BinaryTree
    {
        public Object Value { get; set; }
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
    }

    public static class Ex
    {
        public static void Each<T>(this T[] items, Action<T> action)
        {
            Array.ForEach(items, action);
        }

        public static int[] GetClone(this int[] items)
        {
            int[] t = new int[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                t[i] = items[i];
            }
            return t;
        }
    }
}


