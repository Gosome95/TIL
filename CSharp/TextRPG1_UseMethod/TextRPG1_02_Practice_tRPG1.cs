using System;
using System.Numerics;

// player & monster 공격력이 일정한 확률에 따른 랜덤 데미지
// 계속 사냥을 계속 할 것인지 묻는 문

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

        // 로비 생성 = 직업 선택
        static ClassType ChooseClass()
        {
            ClassType choice = ClassType.None;

            Console.WriteLine("환영합니다 OOO World 입니다");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            Console.Write("직업을 선택해주세요 : ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    choice = ClassType.Knight;
                    Console.WriteLine();
                    Console.WriteLine("----------------------");
                    Console.WriteLine("당신의 직업은 [기사] 입니다");
                    break;
                case "2":
                    choice = ClassType.Archer;
                    Console.WriteLine();
                    Console.WriteLine("----------------------");
                    Console.WriteLine("당신의 직업은 [궁수] 입니다");
                    break;
                case "3":
                    choice = ClassType.Mage;
                    Console.WriteLine();
                    Console.WriteLine("----------------------");
                    Console.WriteLine("당신의 직업은 [마법사] 입니다");
                    break;
            }
            return choice;
        }
        static void CreatePlayer(ClassType choice, out Player player)
        {
            switch (choice)
            {
                case ClassType.Knight:
                    player.hp = 100;
                    player.attack = 10;
                    Console.WriteLine($"현재 능력치 : HP {player.hp} 공격력 10~12");
                    break;
                case ClassType.Archer:
                    player.hp = 80;
                    player.attack = 10;
                    Console.WriteLine($"현재 능력치 : HP {player.hp} 공격력 11~15");
                    break;
                case ClassType.Mage:
                    player.hp = 70;
                    player.attack = 10;
                    Console.WriteLine($"현재 능력치 : HP {player.hp} 공격력 13~18");
                    break;
                default:
                    player.hp = 0;
                    player.attack = 0;
                    break;
            }
            Console.WriteLine("캐릭터가 성공적으로 생성되었습니다");
            Console.WriteLine("마을로 이동합니다");
            Console.WriteLine("----------------------");
            Console.WriteLine("----------------------");
        }

        static void CreateMonster(ref MonsterType randMonster, out Monster monster)
        {
            Random rand = new Random();
            randMonster = (MonsterType)rand.Next(1, 4);
            switch(randMonster)
            {
                case MonsterType.Slime:
                    monster.hp = 10;
                    monster.attack = 2;
                    Console.WriteLine($"슬라임 체력 {monster.hp} 공격력 2~5");
                    break;
                case MonsterType.Orc:
                    monster.hp = 20;
                    monster.attack = 3;
                    Console.WriteLine($"오크 체력 {monster.hp} 공격력 3~7");
                    break;
                case MonsterType.Skeleton:
                    monster.hp = 15;
                    monster.attack = 2;
                    Console.WriteLine($"스켈레톤 체력 {monster.hp} 공격력 2~10");
                    break;
                default:
                    monster.hp = 0;
                    monster.attack = 0;
                    break;
            }
        }

        static void Fight(ClassType choice, MonsterType mChoice, ref Player player, ref Monster monster)
        {
            while (true)
            {
                Console.WriteLine("");
                // 랜덤데미지로 설정
                switch(choice)
                {
                    case ClassType.Knight:
                        Random rand = new Random();
                        int randDamage = rand.Next(10, 13);
                        player.attack = randDamage;
                        break;
                    case ClassType.Archer:
                        rand = new Random();
                        randDamage = rand.Next(11, 16);
                        player.attack = randDamage;
                        break;
                    case ClassType.Mage:
                        rand = new Random();
                        randDamage = rand.Next(13, 19);
                        player.attack = randDamage;
                        break;
                }
                switch(mChoice)
                {
                    case MonsterType.Slime:
                        Random rand = new Random();
                        int mRandDamage = rand.Next(2, 6);
                        monster.attack = mRandDamage;
                        break;
                    case MonsterType.None:
                        rand = new Random();
                        mRandDamage = rand.Next(3, 8);
                        monster.attack = mRandDamage;
                        break;
                    case MonsterType.Skeleton:
                        rand = new Random();
                        mRandDamage = rand.Next(2, 11);
                        monster.attack = mRandDamage;
                        break;
                }

                monster.hp -= player.attack;
                Console.WriteLine($"몬스터에게 {player.attack} 데미지를 입혔습니다");
                if(monster.hp <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("전투에서 승리하였습니다");
                    Console.WriteLine($"현재 상태 체력 {player.hp}");
                    break;
                }

                player.hp -= monster.attack;
                Console.WriteLine($"플레이어가 몬스터에게 {monster.attack} 데미지를 입었습니다");
                if (player.hp <= 0)
                {
                    Console.WriteLine("전투에서 패배하였습니다");
                    Console.WriteLine("마을로 돌아갑니다");
                    Console.WriteLine("----------------------");
                    Console.WriteLine("----------------------");
                    break; 
                }
            }
        }

        static void EnterField(ref ClassType choice, ref Player player)
        {
            // 들어왔을 때 한번만 호출되길 바람
            Console.WriteLine("필드에 들어왔습니다");
            while (true)
            {
                // 몬스터 생성
                Monster monster;
                MonsterType monsterType = MonsterType.None;

                Console.WriteLine("몬스터가 나타났습니다! 적 몬스터는...");
                CreateMonster(ref monsterType, out monster);
                Console.WriteLine("[1] 싸운다");
                Console.WriteLine("[2] 도망친다");
                Console.Write(" : ");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("전투가 시작됩니다");
                    Fight(choice, monsterType, ref player, ref monster);
                    // 계속 사냥할 것인지 묻기
                    if(player.hp > 0)
                    {
                        Console.WriteLine("----------------------");
                        Console.WriteLine("계속 [사냥] 하시겠습니까?");
                        Console.WriteLine("[1] 계속 사냥한다");
                        Console.WriteLine("[2] 마을로 돌아간다");
                        Console.Write(" : ");
                        input = Console.ReadLine();
                        if (input == "1")
                            continue;
                        else if (input == "2")
                        {
                            Console.WriteLine("마을로 돌아갑니다");
                            Console.WriteLine();
                            Console.WriteLine("----------------------");
                            Console.WriteLine("----------------------");
                            break;
                        }
                    }
                }
                else if (input == "2")
                {
                    // 랜덤하게 도망치기
                    Random rand = new Random();
                    int randValue = rand.Next(1, 101);
                    if(randValue <= 33)
                    {
                        Console.WriteLine("도망치는데 성공했습니다");
                        Console.WriteLine("마을로 돌아갑니다");
                        Console.WriteLine();
                        Console.WriteLine("----------------------");
                        Console.WriteLine("----------------------");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("도망치지 못했습니다");
                        Fight(choice, monsterType, ref player, ref monster);
                        // 계속 사냥할 것인지 묻기
                        if (player.hp > 0)
                        {
                            Console.WriteLine("----------------------");
                            Console.WriteLine("계속 [사냥] 하시겠습니까?");
                            Console.WriteLine("[1] 계속 사냥한다");
                            Console.WriteLine("[2] 마을로 돌아간다");
                            Console.Write(" : ");
                            input = Console.ReadLine();
                            if (input == "1")
                                continue;
                            else if (input == "2")
                            {
                                Console.WriteLine("마을로 돌아갑니다");
                                Console.WriteLine();
                                Console.WriteLine("----------------------");
                                Console.WriteLine("----------------------");
                                break;
                            }
                        }
                    }
                }
            }
        }
        static void EnterGame(ref ClassType choice, ref Player player)
        {
            while(true)
            {
                Console.WriteLine("마을에 입장했습니다");
                Console.WriteLine("[1] 필드로 가기");
                Console.WriteLine("[2] 로비로 돌아가기");
                Console.Write(" : ");
                string input = Console.ReadLine();
                if(input == "1")
                {
                    // 필드함수
                    EnterField(ref choice, ref player);
                    // break;
                    // break 문 호출하면 다시 로비로 돌아감 - Main에서 while문 한 턴이 끝나기 때문
                }
                else if (input == "2")
                {
                    Console.WriteLine("로비로 돌아갑니다");
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            while(true)
            {
                ClassType choice = ChooseClass();
                if (choice == ClassType.None)
                    continue;

                Player player;
                CreatePlayer(choice, out player);
                EnterGame(ref choice, ref player);
            }
        }
    }
}
