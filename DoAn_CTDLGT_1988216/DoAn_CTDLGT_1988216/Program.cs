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
        static int[] readHexNumbers(string FilePath)
        {
            StreamReader file = new StreamReader(FilePath);
            string ln;
            List<int> intList = new List<int>();

            while((ln = file.ReadLine()) != null)
            {
                string[] strArr = ln.Split(' '); // Tách chuỗi để đưa vào array bởi space
                int numOfElement = strArr.Length;

                for (int i = 0; i < numOfElement; i++)
                {
                    intList.Add(Convert.ToInt32(strArr[i], 16));
                }
            }
            file.Close();

            return intList.ToArray(); // Chuyển đổi từ List qua Array
        }


        static void writeHexNumbers(int[] intArr)
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
           
            StreamWriter file = new StreamWriter("../../sorted_numbers.txt");
            file.Write(hexString);
            file.Close();

            
        }

        static int[] selectionSort(int[] intArr)
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

            Console.WriteLine("=> File " + fileName + ".txt da duoc ghi!!!");
        }

        static void printIntArray(int[] arr)
        {
            foreach(int x in arr)
            {
                Console.Write(x + " ");
            }
        }

        static void showMenu()
        {
            Console.WriteLine("****************************************************************");
            Console.WriteLine("**           DO AN - CAU TRUC DU LIEU VA GIAI THUAT           **");
            Console.WriteLine("****************************************************************");
            Console.WriteLine("**  1 - Doc mang so nguyen luu trong tap tin hex_numbers.txt  **");
            Console.WriteLine("**  2 - Sap xep mang bang thuat toan Selection Sort           **");
            Console.WriteLine("**  3 - Xuat mang da sap xep bang Selection Sort ra tap tin   **");
            Console.WriteLine("**  4 - Tim kiem 1 so nguyen tren mang bang Binary Search     **");
            Console.WriteLine("**  5 - Xuat hang doi (Queue) CHAN va LE ra tap tin           **");
            Console.WriteLine("**  0 - THOAT CHUONG TRINH                                    **");
            Console.WriteLine("****************************************************************");
        }

        static void Main(string[] args)
        {

            int modeSelection;
            string x;
            bool flag = true;
            showMenu();

            while (flag)
            {
                Console.Write("\nVui long chon chuc nang theo menu o tren => ");
                x = Console.ReadLine();
                // Kiem tra xem nguoi dung nhap vao co phai la so hay khong?
                while (!int.TryParse(x, out modeSelection))
                {
                    Console.Write("=> Mode phai la SO NGUYEN, vui long nhap lai => ");
                    x = Console.ReadLine();
                }

                // Neu vuot qua duoc doan vong lap while o tren thi co nghia nguoi dung nhap dung la 1 so nguyen,
                // va viec chon Mode se duoc thuc hien
                switch (modeSelection)
                {
                    case 1:
                        {
                            int[] arrInt = readHexNumbers("../../hex_numbers.txt");
                            Console.WriteLine("=> Cac phan tu so nguyen trong mang duoc doc tu file hex_numbers.txt");
                            printIntArray(arrInt);
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        {
                            int[] arrInt = readHexNumbers("../../hex_numbers.txt");
                            Console.WriteLine("=> Cac phan tu so nguyen trong mang TRUOC KHI duoc sap xep: ");
                            printIntArray(arrInt);
                            Console.WriteLine();

                            int[] sortedArr = selectionSort(arrInt);
                            Console.WriteLine("=> Cac phan tu trong mang SAU KHI sap xep bang Selection Short: ");
                            printIntArray(sortedArr);
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        {
                            writeHexNumbers(selectionSort(readHexNumbers("../../hex_numbers.txt")));
                            Console.Write("=> File sorted_numbers.txt da duoc ghi !!!");
                            Console.WriteLine();
                        }
                        break;
                    case 4:
                        {
                            Console.Write("=> Nhap vao gia tri x can tim = ");
                            string key = Console.ReadLine();
                            int intKey;

                            while (!int.TryParse(key, out intKey))
                            {
                                Console.Write("=> So x can tim da nhap KHONG HOP LE!!! Nhap lai => ");
                                key = Console.ReadLine();

                            }

                            int[] arrInt = readHexNumbers("../../hex_numbers.txt");
                            int[] sortedArr = selectionSort(arrInt);
                            int idx = binarySearch(sortedArr, 0, sortedArr.Length - 1, intKey);
                            if (idx != -1)
                            {
                                Console.WriteLine("=> Vi tri cua phan tu x = " + intKey + " la " + idx);
                            }
                            else
                            {
                                Console.WriteLine("=> Khong tim thay x = " + intKey + " trong mang da cho");
                            }
                            Console.WriteLine();
                        }
                        break;
                    case 5:
                        {
                            int[] arrInt = readHexNumbers("../../hex_numbers.txt");
                            int[] sortedArr = selectionSort(arrInt);

                            Queue oddQueue = getOdd(sortedArr);
                            Queue evenQueue = getEven(sortedArr);

                            Console.WriteLine("=> Hang doi (Queue) chua so LE bao gom:");
                            oddQueue.printQueue();
                            writeToFile(oddQueue, "odd_queue");
                            Console.WriteLine();

                            Console.WriteLine("=> Hang doi (Queue) chua so CHAN bao gom:");
                            evenQueue.printQueue();
                            writeToFile(evenQueue, "even_queue");
                            Console.WriteLine();
                        }
                        break;
                    case 0:
                        flag = false;
                        Console.Write("CHUONG TRINH DA KET THUC!!! Press any key to continue!");
                        break;
                    default:
                        {
                            Console.WriteLine("=> Ban chon Mode khong ton tai, vui long chon lai !!!");
                            Console.WriteLine();
                            showMenu();
                        }
                        break;
                }

            }
            Console.ReadLine();
        }

    }
}
