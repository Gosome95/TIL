using System;

namespace MyApp
{
    internal class Program
    {
        enum ClassType
        {
            None = 0,
            Knight = 1,
            Arcer = 2,
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

        // 로비 = 직업 선택하기
        // 하드코딩 된 숫자를 enum 타입으로 보기좋게 만들기 
        static ClassType ChooseClass()
        {
            ClassType choice = ClassType.None;

            Console.WriteLine("게임에 접속했습니다");
            Console.WriteLine("환영합니다 tRPG 맹고 입니다");
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            Console.Write("당신의 직업을 선택해주세요 : ");
            string input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    choice = ClassType.Knight;
                    Console.WriteLine();
                    break;
                case "2":
                    choice = ClassType.Arcer;
                    Console.WriteLine();
                    break;
                case "3":
                    choice = ClassType.Mage;
                    Console.WriteLine();
                    break;
            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("캐릭터가 생성되었습니다");
            return choice;
        }
        // Player가 선택한 정보를 갖고 능력치(Stat) 셋팅해주기
        static void CreatePlayer(ClassType choice, out Player player)
        {
            switch(choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    Console.WriteLine("당신의 직업은 [기사] 입니다");
                    break;
                case ClassType.Arcer:
                    player.hp = 100;
                    player.attack = 10;
                    Console.WriteLine("당신의 직업은 [궁수] 입니다");
                    break;
                case ClassType.Mage:
                    player.hp = 100;
                    player.attack = 10;
                    Console.WriteLine("당신의 직업은 [마법사] 입니다");
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
            Console.WriteLine($"| 현재 캐릭터 스텟 |  HP : {player.hp} 공격력 {player.attack}");
        }
        static void CreateMonster(out Monster monster)
        {
            // 랜덤하게 리스폰
            Random rand = new Random();
            MonsterType randMonster = (MonsterType)rand.Next(1, 4);
            switch(randMonster)
            {
                case MonsterType.Slime:
                    monster.hp = 10;
                    monster.attack = 2;
                    Console.WriteLine($"슬라임이 나타났습니다 HP {monster.hp} 공격력 {monster.attack}");
                    break;
                case MonsterType.Orc:
                    monster.hp = 20;
                    monster.attack = 5;
                    Console.WriteLine($"오크가 나타났습니다 HP {monster.hp} 공격력 {monster.attack}");
                    break;
                case MonsterType.Skeleton:
                    monster.hp = 16;
                    monster.attack = 8;
                    Console.WriteLine($"스켈레톤이 나타났습니다 HP {monster.hp} 공격력 {monster.attack}");
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }

        static void Fight(ref Player player, ref Monster monster)
        {
            while(true)
            {
                monster.hp -= player.attack;
                Console.WriteLine($"몬스터에게 {player.attack} 데미지를 입혔습니다");
                if(monster.hp <= 0)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("전투승리!");
                    Console.WriteLine($"현재 당신의 남은 체력 : {player.hp}");
                    Console.WriteLine();
                    break;
                }

                player.hp -= monster.attack;
                Console.WriteLine($"몬스터 공격 {monster.attack} 피해를 입었습니다");
                if(player.hp <=0)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("당신의 패배!");
                    Console.WriteLine("마을로 돌아갑니다");
                    Console.WriteLine();
                    break;
                }
            }
        }

        static void EnterField(ref Player player)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("필드에 들어왔습니다");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("야생의 몬스터 출현  적 몬스터는...");
                // 랜덤 몬스터 생성
                Monster monster;
                CreateMonster(out monster);

                // 배틀 구현 
                Console.WriteLine("무엇을 하시겠습니다");
                Console.WriteLine("[1] 싸운다");
                Console.WriteLine("[2] 마을로 도망가기");
                Console.Write(" : ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    // 배틀 개시  함수 호출
                    Fight(ref player, ref monster);
                }
                else
                {
                    // 마을로 도망
                    Random rand = new Random();
                    int randValue = rand.Next(1, 101);
                    if (randValue <= 33)
                    {
                        Console.WriteLine("도망치는데 성공했습니다");
                        Console.WriteLine("마을로 돌아갑니다");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("----------------------------------");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망치는데 실패했습니다");
                        Console.WriteLine("전투 개시");
                        Console.WriteLine();
                        Fight(ref player, ref monster);    // 전투 개시 
                    }
                }
            }
        }

        static void EnterTown(ref Player player)
        {
            while(true)
            {
                Console.WriteLine("마을에 접속했습니다");
                Console.WriteLine("무엇을 하시겠습니까?");
                Console.WriteLine("[1] 필드로 가기");
                Console.WriteLine("[2] 로비로 돌아가서 직업 재선택");
                Console.Write("행선지를 입력해주세요 : ");
                string input = Console.ReadLine();

                if (input == "1")
                    EnterField(ref player);     //필드로 가기 
                else
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            while(true)
            {
                // 로비 만들기
                ClassType choice = ChooseClass();
                if (choice == ClassType.None)
                    continue;
                // Player Character 만들기 = 능력치 배양 
                Player player;
                CreatePlayer(choice, out player);

                // 마을로 가기
                EnterTown(ref player);

            }
        }
    }
}