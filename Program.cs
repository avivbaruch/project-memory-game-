using System;


namespace memory_game
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] matrix = matrixs(EvenNumber());
            PrintMatrixPlay(matrix);
            Play(matrix);

        }
        public static int EvenNumber()
        {

            int size1 = 0;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Select the game size");
                size1 = int.Parse(Console.ReadLine());
                if (size1 < 8 && size1 % 2 == 0 && size1 > 0)
                {
                    flag = false;
                }


            }


            return size1;
        }
        public static int[,] matrixs(int size)
        {
            int[,] matrix = new int[size, size];
            int a = (matrix.Length) / 2;
            for (int i = 1; i <= a; i++)
            {
                int help = 0;
                while (help <= 1)
                {
                    Random num = new Random();
                    int b = num.Next(0, size);
                    int c = num.Next(0, size);

                    if (matrix[b,c] == 0)
                    {
                        matrix[b,c] = i;
                        help++;
                    }


                }

            }
            return matrix;

        }
        //public static void PrintMatrix(int[,] matrix)
        //{
        //    for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
        //    {
        //        for (int j = 0; j < Math.Sqrt(matrix.Length); j++)
        //        {
        //            Console.Write(matrix[i, j]);
        //            Console.Write("    ");
        //        }
        //        Console.Write("\n");


        //    }
        //}
        public static void Play(int[,] matrix)
        {
            int help = 0;
            int player1 = 0;
            int player2 = 0;
            while (help < matrix.Length / 2)
            {
                object[] o = new object[3];
                o = PlayHelper(matrix, "player 1", player1, help);
                matrix = (int[,])o[0];
                player1 = (int)o[1];
                help = (int)o[2];

                object[] o1 = new object[3];
                o1 = PlayHelper(matrix, "player 2", player2, help);
                matrix = (int[,])o[0];
                player2 = (int)o[1];
                help = (int)o[2];

                Console.WriteLine(help);

            }
            Console.Write("player 1 point: ");
            Console.Write(player1);
            Console.Write("player 2 point: ");
            Console.Write(player2);
        }

        public static object[] PlayHelper(int[,] matrix, string str, int player, int help)
        {
            bool flag = true;
            while (flag && help < matrix.Length / 2)
            {
                Console.WriteLine(str + ": enter 2 number for card 1");
                int playeri = int.Parse(Console.ReadLine());
                int playerj = int.Parse(Console.ReadLine());
                Console.WriteLine(str + ": enter 2 number for card 2");
                int playeri2 = int.Parse(Console.ReadLine());
                int playerj2 = int.Parse(Console.ReadLine());
                if (matrix[playeri, playerj] == matrix[playeri2, playerj2] && matrix[playeri, playerj] != 0)
                {
                    matrix[playeri, playerj] = 0;
                    matrix[playeri2, playerj2] = 0;
                    player++;
                    help++;
                }
                else
                {
                    flag = false;
                }
                PrintMatrixPlay(matrix);
            }
            object[] o = new object[] { matrix, player, help };

            return o;
        }
        public static void PrintMatrixPlay(int[,] matrix)
        {
            for (int i = 0; i < Math.Sqrt(matrix.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(matrix.Length); j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        Console.Write("x");
                        Console.Write("    ");

                    }
                    else
                    {
                        Console.Write(matrix[i, j]);
                        Console.Write("    ");
                    }

                }
                Console.Write("\n");


            }
        }


    }

}