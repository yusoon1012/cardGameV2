using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] cardNumber = new int[52];
            int cpuCard1 = 0;
            int cpuCard2 = 0;
            int mycard = 0;
            int cardIndex = 0;
            int deckCount = 52;
            string[] cardShape = { "♣", "♥", "◆", "♠" };
            int shapeIndex = 0;
            int myPoint = 100000;
            string input;
            int inputPoint = 0;


            bool myWIN = false;
            for (int i = 0; i < cardNumber.Length; i++)
            {
                cardNumber[i] = i;
               
            }
            Random rand = new Random();
            for(int i = 0;i<100;i++)
            {
                  int randomIdx1 = rand.Next(0,51);
                  int randomIdx2 = rand.Next(0, 51);
                SwapCard(ref cardNumber[randomIdx1],ref cardNumber[randomIdx2]);

            }


            while (cardIndex < cardNumber.Length - 2 && myPoint > 0 || myPoint > 300000)
            {
                Console.WriteLine("남은 덱 : {0}", deckCount - cardIndex-3);
                Console.WriteLine();
                Console.WriteLine("게임 룰 : 상대가 카드를 두장 뽑은 후 베팅한 후 ");
                Console.WriteLine("내 카드를 뽑아 상대 카드1번과 2번사이에 있으면 베팅점수의 2배로 돌려준다.");
                Console.WriteLine();

                cpuCard1 = cardNumber[cardIndex];
                cpuCard2 = cardNumber[cardIndex + 1];
                if (cpuCard1 % 13 + 1 > cpuCard2 % 13 + 1)
                {
                    SwapCard(ref cpuCard1, ref cpuCard2);
                }
                mycard = cardNumber[cardIndex + 2];
                Console.WriteLine("상대의 카드 : ");
                Thread.Sleep(1000);
                drawCard(ref cpuCard1, ref shapeIndex, cardShape);
                Thread.Sleep(1000);
                drawCard(ref cpuCard2, ref shapeIndex, cardShape);
                Thread.Sleep(1000);

                Console.WriteLine();
                Console.WriteLine("현재 점수 : {0} ", myPoint);
                while (true)
                {
                 
                    Console.WriteLine();
                    Console.Write("베팅할 점수를 입력해주세요 (최소 베팅 점수:1000) : ");
                    input = Console.ReadLine();
                    int.TryParse(input, out inputPoint);
                    if (inputPoint > myPoint)
                    {
                        Console.WriteLine("보유한 점수보다 큽니다. 다시입력해주세요.");
                        continue;
                    }
                    else if(inputPoint<1000)
                    {
                        Console.WriteLine("최소 베팅 점수보다 작습니다. 다시입력해주세요.");
                        continue;
                    }
                    else
                    {
                        myPoint -= inputPoint;
      
                     
                        break;
                    }
                }
                Thread.Sleep(1000);

                Console.Clear();
                Console.WriteLine("상대의 카드 : ");
                drawCard(ref cpuCard1, ref shapeIndex, cardShape);
                drawCard(ref cpuCard2, ref shapeIndex, cardShape);
                Thread.Sleep(1000);

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("[     [ENTER]를 눌러 나의카드보기     ]");
                Console.ReadLine();
                Console.WriteLine("나의 카드 :");
                Thread.Sleep(1000);

                drawCard(ref mycard, ref shapeIndex, cardShape);
                Thread.Sleep(1000);

                Console.WriteLine();
                Console.WriteLine("베팅한 점수 : {0}", inputPoint);
                Console.WriteLine();
                Thread.Sleep(1000);

                if (cpuCard1 % 13 + 1 < mycard % 13 + 1 && cpuCard2 % 13 + 1 > mycard % 13 + 1)
                {
                    myWIN = true;
                }
                else
                {
                    myWIN = false;
                }
                if (myWIN == true)
                {
                    Console.WriteLine("뽑은카드가 상대 카드 사이에 있습니다.");

                    Console.WriteLine("당신의 승리");
                    Thread.Sleep(1000);

                    Console.WriteLine("+{0}점 획득!",inputPoint*2);
                    Thread.Sleep(1000);

                    myPoint += (inputPoint * 2);
                Console.WriteLine("현재 점수 : {0} ", myPoint);
                }
                else if (myWIN==false)
                {
                    Console.WriteLine("뽑은카드가 상대 카드 사이에 없습니다.");
                    Console.WriteLine("당신의 패배");
                    Thread.Sleep(1000);

                    Console.WriteLine("베팅한점수 {0} 만큼 잃습니다.",inputPoint );
                    Thread.Sleep(1000);

                    Console.WriteLine("현재 점수 : {0} ", myPoint);

                }
                Console.WriteLine("[     [ENTER]를 눌러 계속 진행     ]");

                Console.ReadLine();
                Console.Clear();

                cardIndex += 3;

            }//while끝
          
           if(myPoint<=0)
            {
                Console.WriteLine("당신은 모든 점수를 잃어 쫓겨났습니다.");
            }
            else
            {
                Console.WriteLine("당신은 {0}만큼의 점수를 벌어 만족하고 집에 돌아갑니다.", myPoint);
            }
        }
            
        static void SwapCard(ref int a, ref int b)
        {
            int temp=a;
            a=b;
            b=temp;
        }
        static void drawCard(ref int cardNumber,ref int shapeIndex, string[] cardShape)
        {
            if (cardNumber < 13)
            { shapeIndex = 0; }
            else if (cardNumber >= 13 && cardNumber < 26)
            {
                shapeIndex = 1;
            }
            else if (cardNumber >= 26 && cardNumber < 39)
            {
                shapeIndex = 2;
            }
            else if (cardNumber >= 39 && cardNumber < 52)
            {
                shapeIndex = 3;
            }
            switch (cardNumber % 13 + 1)
            {
                case 1:
                    Console.WriteLine(" -----------------");
                    Console.WriteLine("| {0}A             |", cardShape[shapeIndex]);
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|             {0}A |", cardShape[shapeIndex]);
                    Console.WriteLine(" -----------------");


                    break;
                case 11:
                    Console.WriteLine(" -----------------");
                    Console.WriteLine("| {0}J             |", cardShape[shapeIndex]);
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|             {0}J |", cardShape[shapeIndex]);
                    Console.WriteLine(" -----------------");

                    break;
                case 12:
                    Console.WriteLine(" -----------------");
                    Console.WriteLine("| {0}Q             |", cardShape[shapeIndex]);
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|             {0}Q |", cardShape[shapeIndex]);
                    Console.WriteLine(" -----------------");

                    break;
                case 13:
                    Console.WriteLine(" -----------------");
                    Console.WriteLine("| {0}K             |", cardShape[shapeIndex]);
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|             {0}K |", cardShape[shapeIndex]);
                    Console.WriteLine(" -----------------");


                    break;
                default:
                    Console.WriteLine(" -----------------");
                    if (cardNumber % 13 + 1 < 10)
                    {
                    Console.WriteLine("| {0} {1}            |", cardShape[shapeIndex], cardNumber % 13 + 1);
                    }
                    else
                    {
                     Console.WriteLine("| {0}{1}            |", cardShape[shapeIndex], cardNumber % 13 + 1);
                    }
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    Console.WriteLine("|                 |");
                    if (cardNumber % 13 + 1 < 10)
                    {
                        Console.WriteLine("|            {0} {1} |", cardShape[shapeIndex], cardNumber % 13 + 1);
                    }
                    else
                    {
                        Console.WriteLine("|            {0}{1} |", cardShape[shapeIndex], cardNumber % 13 + 1);
                    }
                    Console.WriteLine(" -----------------");

                    break;
            }
        }


        
    }
}
