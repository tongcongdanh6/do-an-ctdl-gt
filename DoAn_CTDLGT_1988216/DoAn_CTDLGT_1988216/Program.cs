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
            ln = file.ReadLine();
            file.Close();

            string[] strArr = ln.Split(' '); // Tách chuỗi để đưa vào array bởi space
            int numOfElement = strArr.Length;
            int[] intArr = new int[numOfElement]; // Khởi tạo mảng số nguyên

            for(int i = 0; i < numOfElement; i++)
            {
                intArr[i] = Convert.ToInt32(strArr[i], 16);
            }

            // For DEBUG
            for (int i = 0; i < numOfElement; i++)
            {
                Console.Write(intArr[i]+" ");
            }

            return intArr;
        }

        static void WriteHexNumbers(int[] intArr)
        {
            string hexString = "";

            for(int i = 0; i < intArr.Length; i++)
            {
                if(i < intArr.Length - 1)
                {
                    hexString += intArr[i].ToString("X") + " ";
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

        static void Main(string[] args)
        {
            int[] arrInt = ReadHexNumbers("../../ex1data.txt");
            int[] selectionshort = SelectionSort(arrInt);
            Console.Write("\nSelection Short:\n");
            foreach (int a in selectionshort)
            {
                Console.WriteLine(a);
            }


            Console.Write("\n\nWRITE TO FILE:\n\n");
            WriteHexNumbers(selectionshort);
            Console.ReadLine();
        }

    }
}
