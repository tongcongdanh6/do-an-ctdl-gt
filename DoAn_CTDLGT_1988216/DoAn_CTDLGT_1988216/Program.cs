using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace DoAn_CTDLGT_1988216
{
    class Program
    {
        static public int[] readHexNumbers(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            string ln;
            List<int> intList = new List<int>();

            while((ln = file.ReadLine()) != null)
            {
                // Tách chuỗi để đưa vào array bởi space, hoặc tab, và thêm option remove các duplicate space ...
                string[] strArr = ln.Split((char[])null, StringSplitOptions.RemoveEmptyEntries); 
                int numOfElement = strArr.Length;

                for (int i = 0; i < numOfElement; i++)
                {
                    // Kiểm tra việc phân tích từ Hex sang Decimal có thành công hay không
                    // Có 2 trường hợp không thành công là
                    // 1. Kí tự đặc biệt
                    // 2. Cũng là kí tự nhưng nằm ngoài range [A-F] của Hex
                    if(int.TryParse(strArr[i], NumberStyles.HexNumber, new CultureInfo("en-US") , out int res))
                    {
                        // Nếu Parse thành công thì add vào List
                        intList.Add(Convert.ToInt32(strArr[i], 16));
                    }
                }
            }
            file.Close();

            // Chuyển đổi từ List qua Array
            return intList.ToArray(); 
        }

        static public int[] selectionSort(int[] intArr)
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

        static public void writeHexNumbers(int[] intArr, string pathFile)
        {
            string hexString = "";

            for (int i = 0; i < intArr.Length; i++)
            {
                // Chuyển từ Dec sang Hex với 2 digit
                hexString += intArr[i].ToString("X2") + " ";
            }

            // Remove space cuối cùng
            hexString = hexString.Remove(hexString.Length - 1);

            StreamWriter file = new StreamWriter(pathFile);
            // Ghi chuỗi ra file
            file.Write(hexString);
            file.Close();
        }

        static public int binarySearch(int[] arr, int left, int right, int x)
        {
            // Nếu chưa hết mảng thì thực hiện Binary Search
            if(left <= right)
            {
                int mid = (left + right) / 2;

                if (x < arr[mid]) // x < a[mid] tìm phần bên trái bằng cách hiệu chỉnh lại right
                {
                    return binarySearch(arr, left, mid - 1, x);
                }
                if (x > arr[mid]) // x > a[mid] tìm phần bên phải bằng cách hiệu chỉnh lại left
                {
                    return binarySearch(arr, mid + 1, right, x);
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
            // Khởi tạo hàng đợi lẻ
            Queue oddQueue = new Queue();
            foreach(int x in arr)
            {
                if(x % 2 != 0)
                {
                    // Thêm vào hàng đợi lẻ bằng method push trong class Queue
                    oddQueue.push(x);
                }
            }
            // Trả về một hàng đợi chứa các phần tử nguyên lẻ
            return oddQueue;
        }

        static public Queue getEven(int[] arr)
        {
            // Khởi tạo hàng đợi chẵn
            Queue evenQueue = new Queue();
            foreach (int x in arr)
            {
                if (x % 2 == 0)
                {
                    // Thêm vào hàng đợi chẵn bằng method push trong class Queue
                    evenQueue.push(x);
                }
            }
            // Trả về một hàng đợi chứa các phần tử nguyên chẵn
            return evenQueue;
        }

        static public void writeToFile(Queue myQueue, string filePath)
        {
            string hexString = "";

            // Khi hàng đợi không rỗng thì thực hiện việc thêm vào hexString
            while(!myQueue.isQueueEmpty())
            {
                // Chuyển từ Dec sang Hex với 2 digit
                hexString += myQueue.pop().ToString("X2") + " ";
            }

            // Remove space cuối chuỗi
            hexString = hexString.Remove(hexString.Length - 1);

            StreamWriter file = new StreamWriter(filePath);
            file.Write(hexString);
            file.Close();
        }

        static void Main(string[] args)
        {

            const string INPUT_FILE_PATH = "../../hex_numbers.txt";
            const string SORTED_FILE_PATH = "../../sorted_numbers.txt";
            const string EVEN_QUEUE_FILE_PATH = "../../even_queue.txt";
            const string ODD_QUEUE_FILE_PATH = "../../odd_queue.txt";

            // Setup doc file tu hex_numbers.txt
            int[] myArr = readHexNumbers(INPUT_FILE_PATH);

            // Setup cho Selection Sort
            int[] sortedArr = selectionSort(myArr);
            writeHexNumbers(sortedArr, SORTED_FILE_PATH);

            // Setup cho Binary Search
            // Validate truong hop nhap khong phai la so bang TryParse

            // Neu nhap truc tiep tu CMD thi thay vi doc tu Console.ReadLine
            // thi bay gio lay truc tiep args[0]
            int n;
            bool validInt = true;
            if(args.Length > 0)
            {
                validInt = int.TryParse(args[0], out n);
                if(args.Length > 1)
                {
                    Console.WriteLine("Ban da nhap nhieu hon 1 argument. Chuong trinh chi lay tham so SO NGUYEN " +
                        "dau tien la {0} de thuc hien viec tim kiem", args[0]);
                }
            }
            // Neu doc tu Debug Program hoac chay truc tiep EXE thi doc bang ReadLine()
            else
            {
                validInt = int.TryParse(Console.ReadLine(), out n);
            }

            if(validInt)
            {
                int foundIdx = binarySearch(sortedArr, 0, sortedArr.Length - 1, n);
                if (foundIdx == -1)
                {
                    Console.WriteLine("Khong tim thay {0}", n);
                }
                else
                {
                    Console.WriteLine("Vi tri cua {0} la {1}", n, foundIdx);
                }
            }
            else
            {
                Console.WriteLine("So da nhap khong hop le !!!");
            }


            // Setup cho Queue
            Queue evenQueue = new Queue();
            Queue oddQueue = new Queue();

            evenQueue = getEven(sortedArr);
            oddQueue = getOdd(sortedArr);

            writeToFile(evenQueue, EVEN_QUEUE_FILE_PATH);
            writeToFile(oddQueue, ODD_QUEUE_FILE_PATH);

            Console.ReadKey(true);
        }
    }
}
