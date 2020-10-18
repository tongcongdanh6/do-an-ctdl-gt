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
        static void Main(string[] args)
        {
            int[] arrInt = ReadHexNumbers("../../ex1data.txt");

            Console.ReadLine();
        }

    }
}
