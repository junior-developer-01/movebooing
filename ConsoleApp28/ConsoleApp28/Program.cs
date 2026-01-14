using System.Runtime.ConstrainedExecution;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp28
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] seats = new int[4, 5];
            int row;
            int col;
            int findRow;
            int findCol;


            while (true) 
            {
                BookingDisplay();
                DisplayInput();
                // "만약 Logic()이 참(true)이라면..."
                if (Logic() == true)
                {
                    // "...그때만 예매를 진행해라."
                    BookingComplte();
                }

            }

            


                void BookingDisplay()
                {
                    // 영화관 예매 좌석 스크린
                    for (int i = 0; i < seats.GetLength(0); i++)
                    {
                        for (int j = 0; j < seats.GetLength(1); j++)
                        {
                            Console.Write($"{seats[i, j]} ");
                        }
                        System.Console.WriteLine();
                    }
                }
                
                void DisplayInput()
            {
                Console.WriteLine("몇 번째 행에 앉으시겠습니까?");
                row = int.Parse(Console.ReadLine());
                Console.WriteLine("몇 번째 열에 앉으시겠습니까?");
                col = int.Parse(Console.ReadLine());
            }

                bool Logic()
                {
                // 판별로직
                findRow = row - 1;
                findCol = col - 1;

                if (findRow < 0 || findRow > 3)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return false;
                }

                if (findCol < 0 || findCol > 4)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return false;
                }

                return true;
            }


                void BookingComplte()
            {
                // 예매 완료 처리
                if (seats[findRow, findCol] == 0)
                {
                    Console.WriteLine("예매가 완료되었습니다");
                    seats[findRow, findCol] = 1;
                }
                else
                {
                    Console.WriteLine("이미 예약된 좌석입니다.");
                }
            }

            





        }
    }
}
