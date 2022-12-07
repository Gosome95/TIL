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
        protected GameMode mode = GameMode.Lobby;
        private Player player = null;
        private Monster monster = null;
        Random rand = new Random();

        public void Process()
        {
            switch(mode)
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

        private void ProcessLobby()
        {
            Console.WriteLine("환영합니다 OOO World 입니다");
            Console.WriteLine("[1] 기사");
            Console.WriteLine("[2] 궁수");
            Console.WriteLine("[3] 마법사");
            Console.Write("직업을 선택해주세요 : ");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    player = new Knight();
                    mode = GameMode.Town;
                    break;
                case "2":
                    player = new Archer();
                    mode = GameMode.Town;
                    break;
                case "3":
                    player = new Mage();
                    mode = GameMode.Town;
                    break;
            }
        }
        private void ProcessTown()
        {
            Console.WriteLine("마을에 들어왔습니다");
            Console.WriteLine("[1] 필드로 가기");
            Console.WriteLine("[2] 로비로 돌아가기");
            Console.Write(" : ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    mode = GameMode.Field;
                    break;
                case "2":
                    mode = GameMode.Lobby;
                    break;
            }
        }
        private void ProcessField()
        {
            Console.WriteLine("필드에 입장했습니다");
            CreateRandmMonster();

            Console.WriteLine("[1] 싸우기");
            Console.WriteLine("[2] 일정확률로 도망가기");
            string input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    ProcessFight();
                    break;
                case "2":
                    TryEscape();
                    break;
            }
        }
        private void CreateRandmMonster()
        {
            int randValue = rand.Next(0, 3);
            switch(randValue)
            {
                case 0:
                    monster = new Slime();
                    System.Console.WriteLine("슬라임이 생성되었습니다");
                    break;
                case 1:
                    monster = new Orc();
                    System.Console.WriteLine("슬라임이 생성되었습니다");
                    break;
                case 2:
                    monster = new Skeleton();
                    System.Console.WriteLine("슬라임이 생성되었습니다");
                    break;
            }
        }
        private void ProcessFight()
        {
            while(true)
            {
                int damage = player.GetAttack();
                monster.OnDamaged(damage);
                if(monster.IsDead())
                {
                    System.Console.WriteLine("승리했습니다");
                    System.Console.WriteLine($"남은 체력 {player.GetHP()}");
                    break;
                }

                damage = monster.GetAttack();
                player.OnDamaged(damage);
                if(player.IsDead())
                {
                    System.Console.WriteLine("패배했습니다");
                    System.Console.WriteLine("로비로 돌아갑니다");
                    mode = GameMode.Lobby;
                    break;
                }
            }
        }
        private void TryEscape()
        {
            int randValue = rand.Next(1, 101);
            if(randValue < 33)
            {
                mode = GameMode.Town;
            }
            else
                ProcessFight();
        }
    }
}