using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextRPG2_Example
{
   public enum GameMode
    {
        None,
        Lobby,
        Town,
        Field
    }

    class Game
    {
        private Player player;
        private Monster monster;
        private Random rand = new Random();
        private GameMode _mode = GameMode.Lobby;
        public void Process()
        {
            switch(_mode)
            {
                case GameMode.Lobby:
                    ProcessLobby();
                    break;
                case GameMode.Town:
                    ProcessTown();
                    break;
                case GameMode.Field:
                    ProcessField();
                    break;
            }
        }

        private void ProcessField()
        {
            Console.WriteLine("필드에 들어왔습니다");
            Console.WriteLine();
            CreateMonster();
            Console.WriteLine("[1] 싸운다");
            Console.WriteLine("[2] 도망간다");
            Console.Write(" : ");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    Fight();
                    break;
                case "2":
                    TryEscape();
                    break;
            }
        }

        private void Fight()
        {
            while (true)
            {
                int damage = player.randDamage();
                monster.OnDamaged(damage);
                Console.WriteLine($"{player.GetAttack()} 데미지를 입혔습니다");
                if (monster.GetHP() <= 0)
                {
                    Console.WriteLine("승리했습니다");
                    Console.WriteLine($"현재 남은 체력: {player.GetHP()}");
                    break;
                }

                damage = monster.GetAttack();
                player.OnDamaged(damage);
                if (player.GetHP() <= 0)
                {
                    Console.WriteLine("패배했습니다");
                    _mode = GameMode.Lobby;
                    break;
                }
            }
        }
        private void TryEscape()
        {
            int tryRand = rand.Next(1, 101);
            if(tryRand <= 33)
            {
                Console.WriteLine("마을로 돌아갑니다");
                _mode = GameMode.Town;
            }
            else
            {
                Console.WriteLine("도망치지 못했습니다");
                Fight();
            }
        }

        private void CreateMonster()
        {
            int randVlaue = rand.Next(1, 4);
            switch(randVlaue)
            {
                case 1:
                    monster = new Slime();
                    Console.WriteLine("슬라임이 리젠되었습니다");
                    break;
                case 2:
                    monster = new Orc();
                    Console.WriteLine("오크가 리젠되었습니다");
                    break;
                case 3:
                    monster = new Skeleton();
                    Console.WriteLine("스켈레톤이 리젠되었습니다");
                    break;
            }
        }

        private void ProcessTown()
        {
            Console.WriteLine("마을에 입장했습니다");
            Console.WriteLine("[1] 필드로 간다");
            Console.WriteLine("[2] 로비로 돌아간다");
            Console.Write(" : ");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    _mode = GameMode.Field;
                    break;
                case "2":
                    _mode = GameMode.Lobby;
                    Console.WriteLine("로비로 돌아갑니다");
                    Console.WriteLine();
                    Console.WriteLine("-------------------");
                    Console.WriteLine("-------------------");
                    break;
            }
        }
        private void ProcessLobby()
        {
            Console.WriteLine("게임에 접속했습니다");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[2] 마법사");
            Console.WriteLine("직업을 선택해주세요");
            Console.Write(" : ");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    player = new Knight();
                    Console.WriteLine("당신의 직업은 [기사] 입니다");
                    Console.WriteLine($"현재 능력치 | 체력: {player.GetHP()} 공격력: {player.GetAttack()} | ");
                    _mode = GameMode.Town;
                    break;
                case "2":
                    player = new Archer();
                    Console.WriteLine("당신의 직업은 [궁수] 입니다");
                    Console.WriteLine($"현재 능력치 | 체력: {player.GetHP()} 공격력: {player.GetAttack()} | ");
                    _mode = GameMode.Town;
                    break;
                case "3":
                    player = new Mage();
                    Console.WriteLine("당신의 직업은 [마법사] 입니다");
                    Console.WriteLine($"현재 능력치 | 체력: {player.GetHP()} 공격력: {player.GetAttack()} | ");
                    _mode = GameMode.Town; ;
                    break;
            }
        }
    }
}