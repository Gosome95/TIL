using System;

namespace MyApp
{
    internal class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Archer = 2,
            Mage = 3,
        }
        struct Player
        {
            public int hp;
            public int attack;
        }

        enum MonsterType
        {
            None = 0,
            Slime = 1,
            Orc = 2,
            Skeleton = 3
        }
        struct Monster
        {
            public int hp;
            public int attack;
        }

        static ClassType ChooseClass()
        {
            ClassType choice = ClassType.None;
            Console.WriteLine("게임에 접속했습니다");
            Console.WriteLine("[1] 기사 ");
            Console.WriteLine("[2] 궁수 ");
            Console.WriteLine("[3] 법사 ");
            Console.Write("당신의 직업을 선택해주세요 : ");
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
            Console.WriteLine($"당신의 선택 직업 {choice} 입니다");
            return choice;
        }
        static void CreatePlayer(ClassType choice, out Player player)
        {
            // Player 선택에 따른 직업 스텟 설정
            // 선택 = choice 변수
            switch(choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 150;
                    player.attack = 5;
                    break;
                case ClassType.Mage:
                    player.hp = 50;
                    player.attack = 15;
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
            Console.WriteLine("캐릭터가 생성되었습니다");
            Console.WriteLine($"현재 당신의 능력치 입니다 {choice} : HP {player.hp}  Attack {player.attack}");
        }

        static void CreateMonster(out Monster monster)
        {
            // 랜덤하게 몬스터 생성
            Random rand = new Random();
            MonsterType radomMonster = (MonsterType)rand.Next(1, 4);

            switch (radomMonster)
            {
                case MonsterType.Slime:
                    monster.hp = 10;
                    monster.attack = 3;
                    Console.WriteLine("몬스터 슬라임이 리스폰 되었습니다");
                    Console.WriteLine($"현재 몬스터 상태: HP{monster.hp}  Attack{monster.attack}");
                    break;
                case MonsterType.Orc:
                    monster.hp = 20;
                    monster.attack = 5;
                    Console.WriteLine("몬스터 오크가 리스폰 되었습니다");
                    Console.WriteLine($"현재 몬스터 상태: HP{monster.hp}  Attack{monster.attack}");
                    break;
                case MonsterType.Skeleton:
                    monster.hp = 15;
                    monster.attack = 7;
                    Console.WriteLine("몬스터 스켈레톤이 리스폰 되었습니다");
                    Console.WriteLine($"현재 몬스터 상태: HP {monster.hp}  Attack {monster.attack}");
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }

        }

        static void EnterTown()
        {
            while (true)
            {
                Console.WriteLine("마을에 접속했습니다");
                Console.WriteLine("[1] 필드로 가기");
                Console.WriteLine("[2] 로비로 돌아가기");
                Console.Write("다음 행선지를 입력해주세요 : ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    // 필드 함수 실행
                    EnterField();
                }
                else
                {
                    break;
                }
            }
        }
        static void EnterField()
        {
            Console.WriteLine("필드에 입장하였습니다");
            Monster monster;

            CreateMonster(out monster);
        }

        static void Main(string[] args)
        {
            // 로비 만들기
            while(true)
            {
                ClassType choice = ChooseClass();
                // 로비 함수 로드
                if(choice != ClassType.None)
                {
                    // 캐릭터 생성
                    Player player;
                    CreatePlayer(choice, out player);

                    // 마을에 접속
                    EnterTown();
                }

            }
        }
    }
}