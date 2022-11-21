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
            Mage = 3
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

            Console.WriteLine("Player 클래스를 로드합니다");
            Console.WriteLine("(1) : 기사");
            Console.WriteLine("(2) : 궁수");
            Console.WriteLine("(3) : 마법사");
            Console.Write("원한는 직업을 선택해주세요 : ");
            string input = Console.ReadLine();
            switch (input)
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
        static void CreatePlayer(ClassType choice, out Player player)
        {
            switch(choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    break;
                case ClassType.Archer:
                    player.hp = 90;
                    player.attack = 12;
                    break;
                case ClassType.Mage:
                    player.hp = 80;
                    player.attack = 15;
                    break;

                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }

        }

        static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            MonsterType monsterType = (MonsterType)rand.Next(1, 4);
            switch (monsterType)
            {
                case MonsterType.Slime:
                    monster.hp = 10;
                    monster.attack = 1;
                    Console.WriteLine($"몬스터가 나타났습니다 : {monsterType}");
                    Console.WriteLine($"몬스터 Status HP :{monster.hp} | Attack :{monster.attack}");
                    break;
                case MonsterType.Orc:
                    monster.hp = 20;
                    monster.attack = 5;
                    Console.WriteLine($"몬스터가 나타났습니다 : {monsterType}");
                    Console.WriteLine($"몬스터 Status HP :{monster.hp} | Attack :{monster.attack}");
                    break;
                case MonsterType.Skeleton:
                    monster.hp = 15;
                    monster.attack = 7;
                    Console.WriteLine($"몬스터가 나타났습니다 : {monsterType}");
                    Console.WriteLine($"몬스터 Status HP :{monster.hp} | Attack :{monster.attack}");
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }

        static void EnterGame()
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
                    EnterField();
                }
                else
                {
                    Console.WriteLine("로비로 돌아갑니다");
                    break;
                }
            }
        }
        static void EnterField()
        {
            Console.WriteLine("필드에 접속했습니다");
            // 몬스터 생성
            Monster monster;
            CreateRandomMonster(out monster);
        }


        static void Main(string[] args)
        {
            // 기사 궁수 마법사
            while(true)
            {
                Console.WriteLine("게임에 접속했습니다");
                // 게임접속  로비
                ClassType choice = ChooseClass();

                if(choice != ClassType.None)
                {
                    Console.WriteLine($"당신의 직업은 {choice} 입니다.");      // Log 기록용

                    // 캐릭터 생성
                    Player player;
                    CreatePlayer(choice, out player);
                    Console.WriteLine($"현재 캐릭터 능력치 HP:{player.hp} Attack {player.attack}");

                    // 마을 또는 필드 입장
                    EnterGame(); 
                }
            }
        }
    }
}