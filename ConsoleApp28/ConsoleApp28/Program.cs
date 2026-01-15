using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp28
{


    internal class Program
    {
        static void Main(string[] args)
        {
            CinemaLogic logic = new CinemaLogic();
            CinemaView view = new CinemaView();


            while (true)
            {
                Console.Clear();

                view.BookingDisplay(logic.seats);
                Console.WriteLine("예매하시겠습니까?(1), 취소하시겠습니까?(2)");
                // 해당 버튼을 누른다
                int inputPress = int.Parse(Console.ReadLine());
                if (inputPress == 1)
                {
                    view.DisplayInput();
                    if (logic.Logic(view.row, view.col))
                    {
                        // 4. 검사가 통과되면(true), 예약을 확정짓기
                        logic.BookingComplete(view.row, view.col);
                    }
                }
                else if (inputPress == 2)
                {
                    view.CancelDisplayInput();
                    logic.BookingCancel(view.row, view.col);
                }

                Console.ReadLine();


            }

        }
    }



    class CinemaLogic
    {
        public int row;
        public int col;


        public int[,] seats = new int[4, 5];

        public bool Logic(int row, int col)
        {
            // 1. 앞에 'int'를 붙여주세요.
            int findRow = row - 1;
            int findCol = col - 1;

            if (findRow < 0 || findRow > 3)
            {
                Console.WriteLine("잘못된 입력입니다.");
                // 2. 실패했으니 false를 반환하고 끝내야 합니다.
                return false;
            }

            else if (findCol < 0 || findCol > 4)
            {
                Console.WriteLine("잘못된 입력입니다.");
                // 3. 여기도 false를 반환해주세요.
                return false;
            }

            // 4. 여기까지 무사히 왔다면 성공(true)입니다!
            return true;
        }




        public void BookingComplete(int row, int col)
        {
            // 1. 여기서도 행과 열 인덱스를 다시 계산해 주세요. (Logic 때랑 똑같이!)
            int findRow = row - 1;
            int findCol = col - 1;

            // 2. 만약 좌석(seats[findRow, findCol])이 0이라면(빈 좌석이라면)?
            if (seats[findRow, findCol] == 0)
            {
                Console.WriteLine("예매가 완료되었습니다");
                // 3. 좌석을 1(예약됨)로 바꿔주세요.
                seats[findRow, findCol] = 1;
            }
            else
            {
                Console.WriteLine("이미 예약된 좌석입니다.");
            }
        }



        public void BookingCancel(int row, int col)
        {
            int findRow = row - 1;
            int findCol = col - 1;

            if (seats[findRow, findCol] == 1)
            {
                Console.WriteLine("예매가 취소되었습니다.");
                seats[findRow, findCol] = 0;
            }
            else
            {
                Console.WriteLine("예약되지 않은 좌석입니다");
            }
        }


    }



    class CinemaView
    {
        // Main에서 가져갈 수 있게 public을 붙여주세요.
        public int row;
        public int col;

        // 좌석표(seats)를 받아서 화면에 그려주는 함수
        public void BookingDisplay(int[,] seats)
        {
            // 여기에 이중 for문을 사용하여 좌석을 출력하는 코드를 넣어주세요.
            for (int i = 0; i < seats.GetLength(0); i++)
            {
                for (int j = 0; j < seats.GetLength(1); j++)
                {
                    Console.Write($"{seats[i, j]} ");
                }
                Console.WriteLine();
            }

        }

        // 사용자에게 질문하고 입력을 받는 함수
        public void DisplayInput()
        {
            Console.WriteLine("몇 번째 행에 앉으시겠습니까?");
            // 여기에 입력을 받아 row에 저장하는 코드를 넣어주세요.
            string rowInput = Console.ReadLine();

            int.TryParse(rowInput, out row);

            Console.WriteLine("몇 번째 열에 앉으시겠습니까?");
            // 여기에 입력을 받아 col에 저장하는 코드를 넣어주세요.
            string colInput = Console.ReadLine();

            int.TryParse(colInput, out col);
        }



        public void CancelDisplayInput()
        {
            Console.WriteLine("몇 번째 행을 취소하시겠습니까?");
            // 여기에 입력을 받아 row에 저장하는 코드를 넣어주세요.
            string rowInput = Console.ReadLine();

            int.TryParse(rowInput, out row);

            Console.WriteLine("몇 번째 열을 취소하시겠습니까?");
            // 여기에 입력을 받아 col에 저장하는 코드를 넣어주세요.
            string colInput = Console.ReadLine();

            int.TryParse(colInput, out col);
        }





    }




}
