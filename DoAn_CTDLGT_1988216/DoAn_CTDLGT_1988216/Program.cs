using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_CTDLGT_1988216
{
    class Program
    {

        static int[] ReadHexNumbers(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            string ln;
            List<int> stringList = new List<int>();

            while((ln = file.ReadLine()) != null)
            {
                string[] strArr = ln.Split(' '); // Tách chuỗi để đưa vào array bởi space
                int numOfElement = strArr.Length;

                for (int i = 0; i < numOfElement; i++)
                {
                    stringList.Add(Convert.ToInt32(strArr[i], 16));
                }
            }
            file.Close();

            return stringList.ToArray(); // Chuyển đổi từ List qua Array
        }

        static void WriteHexNumbers(int[] intArr)
        {
            string hexString = "";

            for(int i = 0; i < intArr.Length; i++)
            {
                if(i < intArr.Length - 1)
                {
                    if(intArr[i] >= 0 && intArr[i] < 16)
                    {
                        hexString += "0" + intArr[i].ToString("X") + " ";
                    }
                    else
                    {
                        hexString += intArr[i].ToString("X") + " ";
                    }
                }
                else
                {
                    hexString += intArr[i].ToString("X");
                }
            }
           
            StreamWriter file = new StreamWriter("../../ex1data_output.txt");
            file.Write(hexString);
            file.Close();

            Console.Write("File OUTPUT Wrote!!!");
        }

        static int[] SelectionSort(int[] intArr)
        {
            for(int i = 0; i < intArr.Length; i++)
            {
                int minIdx = i;
                // Tìm min trong array
                for (int j = i + 1; j < intArr.Length; j++)
                {
                    if(intArr[j] < intArr[minIdx])
                    {
                        minIdx = j;
                    }
                }
                // Swap min với vị trí thứ i hiện tại
                int tmp = intArr[i];
                intArr[i] = intArr[minIdx];
                intArr[minIdx] = tmp;
            }

            return intArr;
        }

        static public int BinarySearch(int[] arr, int left, int right, int x)
        {
            // Nếu chưa hết mảng thì thực hiện Binary Search
            if(left <= right)
            {
                int mid = (left + right) / 2;

                if (x < arr[mid]) // x < a[mid] tìm phần bên trái bằng cách hiệu chỉnh lại right
                {
                    return BinarySearch(arr, left, mid - 1, x);
                }
                if (x > arr[mid]) // x > a[mid] tìm phần bên phải bằng cách hiệu chỉnh lại left
                {
                    return BinarySearch(arr, mid + 1, right, x);
                }
                else // Trường hợp x = a[mid] thì trả về index = mid;
                {
                    return mid;
                }
            }
            // Nếu hết mảng rồi mà vẫn chưa tìm được x = a[mid] thì return -1
            return -1;
        }

        static public Queue getOdd(int[] arr)
        {
            Queue oddQueue = new Queue();
            foreach(int x in arr)
            {
                if(x % 2 != 0)
                {
                    oddQueue.push(x);
                }
            }
            return oddQueue;
        }

        static public Queue getEven(int[] arr)
        {
            Queue evenQueue = new Queue();
            foreach (int x in arr)
            {
                if (x % 2 == 0)
                {
                    evenQueue.push(x);
                }
            }
            return evenQueue;
        }

        static public void writeToFile(Queue myQueue, string fileName)
        {
            string hexString = "";
            int counter = myQueue.Count(); // Số lượng phần tử hiện có trong hàng đợi

            for (int i = 0; i < counter; i++)
            {
                if (i < counter - 1)
                {
                    if (myQueue.getFromQueue(i) >= 0 && myQueue.getFromQueue(i) < 16)
                    {
                        hexString += "0" + myQueue.getFromQueue(i).ToString("X") + " ";
                    }
                    else
                    {
                        hexString += myQueue.getFromQueue(i).ToString("X") + " ";
                    }
                }
                else
                {
                    hexString += myQueue.getFromQueue(i).ToString("X");
                }
            }

            StreamWriter file = new StreamWriter("../../"+ fileName+".txt");
            file.Write(hexString);
            file.Close();

            Console.Write("File " + fileName + ".txt Wrote!!!");
        }

        static void Main(string[] args)
        {
            int[] arrInt = ReadHexNumbers("../../hex_numbers.txt");

            Console.Write("\n\n ARRAY FROM ORIGINAL FILE:\n\n");
            foreach(int x in arrInt)
            {
                Console.Write(x + " ");
            }

            int[] SortedArrayBySelectionSort = SelectionSort(arrInt);
            Console.Write("\nSelection Short:\n");
            foreach (int a in SortedArrayBySelectionSort)
            {
                Console.WriteLine(a);
            }


            Console.Write("\n\nWRITE TO FILE:\n\n");
            WriteHexNumbers(SortedArrayBySelectionSort);
            

            Console.Write("\n\n BINARY SEARCH WITH x = 255:\n\n");
            Console.Write(BinarySearch(SortedArrayBySelectionSort, 0, SortedArrayBySelectionSort.Length - 1, 255));

            Console.Write("\n\n BINARY SEARCH WITH x = 254:\n\n");
            Console.Write(BinarySearch(SortedArrayBySelectionSort, 0, SortedArrayBySelectionSort.Length - 1, 254));


            Console.Write("\n\n QUEUE:\n\n");
            Queue oddQueue = getOdd(SortedArrayBySelectionSort);
            Queue evenQueue = getEven(SortedArrayBySelectionSort);
            Console.Write("\n\n ODD QUEUE:\n\n");
            oddQueue.printQueue();
            writeToFile(oddQueue, "odd_queue");
            Console.Write("\n\n EVEN QUEUE:\n\n");
            evenQueue.printQueue();
            writeToFile(evenQueue, "even_queue");

            Console.ReadLine();
        }

    }
}
