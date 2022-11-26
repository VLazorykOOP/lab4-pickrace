using System;

namespace Lab3
{
    class Date
    {
        private int day, month, year;
        public void SetDay(int newDay)
        {
            day = newDay;
        }

        public int GetDay()
        {
            return day;
        }
        public void SetMonth(int newMonth)
        {
            month = newMonth;
        }

        public int GetMonth()
        {
            return month;
        }
        public void SetYear(int newYear)
        {
            year = newYear;
        }

        public int GetYear()
        {
            return year;
        }
        public Date(int d, int m, int y)
        {
            day = d;
            month = m;
            year = y;
        }

        private string getMonth()
        {
            switch (month)
            {
                case 1: return "січня";
                case 2: return "лютого";
                case 3: return "березня";
                case 4: return "квітня";
                case 5: return "травня";
                case 6: return "червня";
                case 7: return "липня";
                case 8: return "серпня";
                case 9: return "вересня";
                case 10: return "жовтня";
                case 11: return "листопада";
                case 12: return "грудня";
                default: return "помилка";
            }
        }

        public void PrintWithLiteral()
        {
            Console.WriteLine($"{day} {getMonth()} {year} року");
        }

        public void Print()
        {
            Console.WriteLine($"{day}.{month}.{year}");
        }
        private static bool LeapYear(int year)
        {
            return (year % 100 != 0 && year % 4 == 0) || (year % 400 == 0);
        } // end leapYear

        public bool Check()
        {
            bool validation = !!(year >= 1600 && year <= 2100);

            if (day < 1)
                validation = false;

            switch (month)
            {
                case 2:
                    if (LeapYear(year)) // We only care about leap years in February 
                        if (day > 29)
                            validation = false;
                        else
                        if (day > 28)
                            validation = false;
                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (day > 31)
                        validation = false;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (day > 30)
                        validation = false;
                    break;
                default: // the month is not between 1 and 12
                    validation = false;
                    break;
            }
            return validation;
        }

        // To store number of days in
        // all months from January to Dec.
        static int[] _monthDays = { 31, 28, 31,
            30, 31, 30,
            31, 31, 30,
            31, 30, 31 };
        // This function counts number of
        // leap years before the given date
        static int countLeapYears(Date d)
        {
            int years = d.year;

            // Check if the current year
            // needs to be considered
            // for the count of leap years or not
            if (d.month <= 2)
            {
                years--;
            }

            // An year is a leap year if it is
            // a multiple of 4, multiple of 400
            // and not a multiple of 100.
            return years / 4
                   - years / 100
                   + years / 400;
        }
        public static int getDifference(Date dt1, Date dt2)
        {

            // COUNT TOTAL NUMBER OF DAYS
            // BEFORE FIRST DATE 'dt1'

            // initialize count using years and day
            int n1 = dt1.year * 365 + dt1.day;

            // Add days for months in given date
            for (int i = 0; i < dt1.month - 1; i++)
            {
                n1 += _monthDays[i];
            }

            // Since every leap year is of 366 days,
            // Add a day for every leap year
            n1 += countLeapYears(dt1);

            // SIMILARLY, COUNT TOTAL
            // NUMBER OF DAYS BEFORE 'dt2'
            int n2 = dt2.year * 365 + dt2.day;
            for (int i = 0; i < dt2.month - 1; i++)
            {
                n2 += _monthDays[i];
            }
            n2 += countLeapYears(dt2);

            // return difference between two counts
            return (n2 - n1);
        }

        public int getCentury()
        {
            return year / 100;
        }

        public string this[int index]
        {
            get
            {
                DateTime setted = new DateTime(year, month, day);
                return setted.AddDays(index).ToString();

            }
        }

        public static bool operator !(Date date)
        {
            DateTime setted = new DateTime(date.year, date.month, date.day);
            if (setted.Day != DateTime.DaysInMonth(date.year, date.month))
                return true;
            return false;
        }
        public static bool operator true(Date date)
        {
            if (date.month == 1 && date.day == 1) return true;
            return false;
        }
        public static bool operator false(Date date)
        {
            if (date.month == 1 && date.day == 1) return false;
            return true;
        }

        public static bool operator &(Date date1, Date date2)
        {
            if (date1.day == date2.day && date1.month == date2.month && date1.year == date2.year) return true;
            return false;
        }
        public override string ToString() {
            return $"{day}-{month}-{year}";
        }

    }
    //2.10. Створити клас VectorByte (вектор цілих чисел).
    class VectorByte
    {
        private byte[] BArray;
        private uint n;
        private int codeError;
        private static uint num_vec;

        public VectorByte()
        {
            BArray = new byte[1];
            BArray[0] = 0;
            n = 1;
            codeError = 0;
            num_vec++;
        }

        public VectorByte(uint size)
        {
            BArray = new byte[size];
            for (var i = 0; i < size; i++)
            {
                BArray[i] = 0;
            }

            this.n = size;
            num_vec++;
            codeError = 0;
        }

        public VectorByte(uint size, byte num)
        {
            BArray = new byte[size];
            for (var i = 0; i < size; i++)
            {
                BArray[i] = num;
            }

            this.n = size;
            num_vec++;
            codeError = 0;
        }

        ~VectorByte()
        {
            Console.WriteLine("Destructor");
        }

        public void inputArr()
        {
            for (var i = 0; i < n; i++)
            {
                byte.TryParse(Console.ReadLine(), out BArray[i]);
            }
        }

        public void printArr()
        {
            for (var i = 0; i < n; i++)
            {
                Console.Write($"{BArray[i]} ");
            }
            Console.WriteLine();
        }

        public void setArr(byte num)
        {
            for (var i = 0; i < n; i++)
            {
                BArray[i] = num;
            }
        }

        public uint getSize()
        {
            return n;
        }
        public byte this[uint index]
        {
            get
            {
                if (index > n)
                {
                    codeError = -1;
                    return 0;
                }
                return BArray[index];
            }
            set
            {
                if (index > n)
                {
                    codeError = -1;
                }
                else
                {
                    BArray[index] = value;
                }
            }
        }
        public static VectorByte operator ++(VectorByte vectorByte)
        {
            for (var i = 0; i < vectorByte.n; i++)
            {
                vectorByte.BArray[i]++;
            }
            return vectorByte;
        }

        public static VectorByte operator --(VectorByte vectorByte)
        {
            for (var i = 0; i < vectorByte.n; i++)
            {
                vectorByte.BArray[i]--;
            }
            return vectorByte;
        }
        public static bool operator true(VectorByte vectorByte)
        {
            if (vectorByte.n != 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(VectorByte vectorByte)
        {
            if (vectorByte.n != 0)
            {
                return false;
            }
            return true;
        }
        public static VectorByte operator +(VectorByte vectorByte, byte num)
        {
            for (var i = 0; i < vectorByte.n; i++)
            {
                vectorByte.BArray[i] += num;
            }
            return vectorByte;
        }

        public static VectorByte operator +(VectorByte a, VectorByte b)
        {
            uint lessSize = a.n < b.n ? a.n : b.n;
            for (var i = 0; i < lessSize; i++)
            {
                a.BArray[i] += b.BArray[i];
            }
            return a;
        }
        public static VectorByte operator -(VectorByte vectorByte, int num)
        {
            for (var i = 0; i < vectorByte.n; i++)
            {
                vectorByte.BArray[i] = Convert.ToByte(vectorByte.BArray[i] - num);
            }
            return vectorByte;
        }

        public static VectorByte operator -(VectorByte a, VectorByte b)
        {
            double lessSize = a.n < b.n ? a.n : b.n;
            for (var i = 0; i < lessSize; i++)
            {
                a.BArray[i] -= b.BArray[i];
            }
            return a;
        }
        public static VectorByte operator *(VectorByte vectorByte, int num)
        {
            for (var i = 0; i < vectorByte.n; i++)
            {
                vectorByte.BArray[i] = Convert.ToByte(vectorByte.BArray[i] * num);
            }
            return vectorByte;
        }

        public static VectorByte operator *(VectorByte a, VectorByte b)
        {
            double lessSize = a.n < b.n ? a.n : b.n;
            for (var i = 0; i < lessSize; i++)
            {
                a.BArray[i] *= b.BArray[i];
            }
            return a;
        }
        public static VectorByte operator /(VectorByte vectorByte, int num)
        {
            for (var i = 0; i < vectorByte.n; i++)
            {
                vectorByte.BArray[i] = Convert.ToByte(vectorByte.BArray[i] / num);
            }
            return vectorByte;
        }

        public static VectorByte operator /(VectorByte a, VectorByte b)
        {
            double lessSize = a.n < b.n ? a.n : b.n;
            for (var i = 0; i < lessSize; i++)
            {
                a.BArray[i] /= b.BArray[i];
            }
            return a;
        }

        public static VectorByte operator %(VectorByte vectorByte, int num)
        {
            for (var i = 0; i < vectorByte.n; i++)
            {
                vectorByte.BArray[i] = Convert.ToByte(vectorByte.BArray[i] % num);
            }
            return vectorByte;
        }

        public static VectorByte operator %(VectorByte a, VectorByte b)
        {
            uint lessSize = a.n < b.n ? a.n : b.n;
            for (var i = 0; i < lessSize; i++)
            {
                a.BArray[i] %= b.BArray[i];
            }
            return a;
        }
    }

    //3.10. Створити клас MatrixByte (матриця цілих чисел)
    class MatrixByte
    {
        private byte[,] BArray;
        private uint n, m;
        private int codeError;
        private static uint num_m;

        public MatrixByte()
        {
            BArray = new byte[1, 1];
            BArray[0, 0] = 0;
            n = 1;
            m = 1;
            codeError = 0;
            num_m++;
        }

        public MatrixByte(uint n, uint m)
        {
            BArray = new byte[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    BArray[i, c] = 0;
                }
            }
            this.n = n;
            this.m = m;
            num_m++;
            codeError = 0;
        }

        public MatrixByte(uint n, uint m, byte num)
        {
            BArray = new byte[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    BArray[i, c] = num;
                }
            }
            this.n = n;
            this.m = m;
            num_m++;
            codeError = 0;
        }

        ~MatrixByte()
        {
            Console.WriteLine("Destructor");
        }

        public void inputMat()
        {
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    byte.TryParse(Console.ReadLine(), out BArray[i, c]);
                }
            }
        }

        public void PrintMat()
        {
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    Console.Write($"{BArray[i, c]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void SetMat(byte num)
        {
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    BArray[i, c] = num;
                }
            }
        }

        public byte this[uint i, uint j]
        {
            get
            {
                if (i > n || j > m)
                {
                    codeError = -1;
                    return 0;
                }
                return BArray[i, j];
            }
            set
            {
                if (i > n || j > m)
                {
                    codeError = -1;
                }
                else
                {
                    BArray[i, j] = value;
                }
            }
        }

        public byte this[int index]
        {
            //rown = n, column = m
            get
            {
                if (index < n * m - 1)
                {

                    return BArray[index / m, (index % m)];
                }
                else
                {
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                if (index < n * m - 1)
                {
                    BArray[index / m, (index % m)] = value;
                }
                else
                {
                    codeError = -1;
                }
            }
        }

        public static MatrixByte operator ++(MatrixByte matrixByte)
        {
            for (var i = 0; i < matrixByte.n; i++)
            {
                for (var c = 0; c < matrixByte.m; c++)
                {
                    matrixByte.BArray[i, c]++;
                }
            }

            return matrixByte;
        }

        public static MatrixByte operator --(MatrixByte matrixByte)
        {
            for (var i = 0; i < matrixByte.n; i++)
            {
                for (var c = 0; c < matrixByte.m; c++)
                {
                    matrixByte.BArray[i, c]--;
                }
            }
            return matrixByte;
        }
        public static bool operator true(MatrixByte matrixByte)
        {
            if (matrixByte.n != 0 && matrixByte.m != 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(MatrixByte matrixByte)
        {
            if (matrixByte.n != 0 && matrixByte.m != 0)
            {
                return false;
            }
            return true;
        }
        public static MatrixByte operator +(MatrixByte matrixByte, byte num)
        {
            for (var i = 0; i < matrixByte.n; i++)
            {
                for (var c = 0; c < matrixByte.m; c++)
                {
                    matrixByte.BArray[i, c] = Convert.ToByte(matrixByte.BArray[i, c] + num);
                }
            }

            return matrixByte;
        }

        public static MatrixByte operator +(MatrixByte a, MatrixByte b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.BArray[i, c] += b.BArray[i, c];
                }
            }
            return a;
        }
        public static MatrixByte operator -(MatrixByte matrixByte, byte num)
        {
            for (var i = 0; i < matrixByte.n; i++)
            {
                for (var c = 0; c < matrixByte.m; c++)
                {
                    matrixByte.BArray[i, c] = Convert.ToByte(matrixByte.BArray[i, c] - num);
                }
            }

            return matrixByte;
        }

        public static MatrixByte operator -(MatrixByte a, MatrixByte b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.BArray[i, c] -= b.BArray[i, c];
                }
            }
            return a;
        }
        public static MatrixByte operator *(MatrixByte matrixByte, int num)
        {
            for (var i = 0; i < matrixByte.n; i++)
            {
                for (var c = 0; c < matrixByte.m; c++)
                {
                    matrixByte.BArray[i, c] = Convert.ToByte(matrixByte.BArray[i, c] * num);
                }
            }
            return matrixByte;
        }

        public static MatrixByte operator *(MatrixByte a, MatrixByte b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.BArray[i, c] *= b.BArray[i, c];
                }
            }
            return a;
        }
        public static MatrixByte operator /(MatrixByte matrixByte, int num)
        {
            for (var i = 0; i < matrixByte.n; i++)
            {
                for (var c = 0; c < matrixByte.m; c++)
                {
                    matrixByte.BArray[i, c] = Convert.ToByte(matrixByte.BArray[i, c] / num);
                }
            }

            return matrixByte;
        }

        public static MatrixByte operator /(MatrixByte a, MatrixByte b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.BArray[i, c] /= b.BArray[i, c];
                }
            }
            return a;
        }
    }



    static class Program
    {
        static void Main()
        {
            Date a = new(8, 2, 2021);
            Date b = new(10, 2, 2021);
            a.Print();
            a.SetYear(2022);
            b.SetYear(2022);
            b.Print();
            a.PrintWithLiteral();
            Console.WriteLine($"B century: {b.getCentury()}");
            Console.WriteLine($"A-B: {Date.getDifference(a, b)} days");
            //----------
            var arrA = new VectorByte();
            var arrB = new VectorByte(5, 12);
            Console.WriteLine($"Index[1]: {arrB[1]}");
            Console.WriteLine("Array A: ");
            arrA.printArr();
            Console.WriteLine("Array B: ");
            arrB.printArr();
            arrA++;
            Console.WriteLine("A++: ");
            arrA.printArr();
            arrA--;
            Console.WriteLine("A--: ");
            arrA.printArr();
            Console.WriteLine(arrA ? "Array A exists" : "Array A does not exists");
            Console.WriteLine(arrB ? "Array B exists" : "Array B does not exists");
            Console.WriteLine("Array B: ");
            arrB.printArr();
            arrB = arrB * 4;
            Console.WriteLine("Array B * 4: ");
            arrB.printArr();
            //-----------
            var matA = new MatrixByte();
            var matB = new MatrixByte(3, 3, 5);
            Console.WriteLine($"Index[1]: {matB[1]}");
            Console.WriteLine("Matrix A: ");
            matA.PrintMat();
            Console.WriteLine("Matrix B: ");
            matB.PrintMat();
            matB++;
            Console.WriteLine("Matrix B++: ");
            matB.PrintMat();
            Console.WriteLine(matA ? "Matrix A exists" : "Matrix A does not exists");
            Console.WriteLine(matB ? "Matrix B exists" : "Matrix B does not exists");
            Console.WriteLine("Matrix B: ");
            matB.PrintMat();
            matB = matB * 3;
            Console.WriteLine("Matrix B * 3: ");
            matB.PrintMat();
        }
    }


}



