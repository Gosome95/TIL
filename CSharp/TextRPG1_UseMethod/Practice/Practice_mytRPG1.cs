using System;

namespace MyApp
{
    internal class Program
    {
        // 직업 설정
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3
        }

        struct PlayerStatus
        {
            public int hp;
            public int attack;
        }

        // 직업 선택창을 띄워주는 로비 함수
        static ClassType ChooseClass()
        {
            ClassType choice = ClassType.None;

            Console.WriteLine("게입에 접속하였습니다");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 법사");
            Console.Write("직업을 선택해주세요 : ");

            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    choice = ClassType.Knight;
                    break;
                case "2":
                    choice = ClassType.Archer;
                    break;
                case "3":
                    choice = ClassType.Mage;
                    break;
            }
            return choice; 
        }

        static void CreatePlayer(ClassType choice, out PlayerStatus playerStatus)
        {
            switch(choice)
            {
                case ClassType.Knight:
                    playerStatus.hp = 100;
                    playerStatus.attack = 10;
                    break;
                case ClassType.Archer:
                    playerStatus.hp = 75;
                    playerStatus.attack = 12;
                    break;
                case ClassType.Mage:
                    playerStatus.hp = 70;
                    playerStatus.attack = 15;
                    break;

                default:
                    playerStatus.attack = 0;
                    playerStatus.hp = 0;
                    break;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            while(true)
            {
                ClassType choice = ClassType.None;      // 변수초기화
                choice = ChooseClass();

                if(choice != ClassType.None)
                {
                    // Player의 직업선택
                    PlayerStatus playerstatus;
                    CreatePlayer(choice, out playerstatus);
                    Console.WriteLine($"HP {playerstatus.hp}  Attack {playerstatus.attack}");

                }

            }
        }
    }
}