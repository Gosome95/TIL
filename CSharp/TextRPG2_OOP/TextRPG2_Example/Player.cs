using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextRPG2_Example
{
    enum PlayerType
    {
        None = 0,
        Knight = 1,
        Archer = 2,
        Mage = 3
    }
    class Player
    {
        protected PlayerType type = PlayerType.None;
        protected int hp = 0;
        protected int attack = 0;
        protected Player(PlayerType type)
        {
            this.type = type;
        }

        // 외부접근용 은닉성! 
        public void SetInfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }
        public PlayerType GetPlayerType() {return type;}
        public int GetHP() {return hp;}
        public int GetAttack() {return attack;}
        public bool IsDead(){ return hp <= 0;}
        public void OnDamaged(int damage)
        {
            hp -= damage;
            if(hp < 0)
                hp = 0;
        }
        
    }

    class Knight : Player
    {
        public Knight() : base(PlayerType.Knight)
        {
            SetInfo(100, 10);
        }

    }
    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            SetInfo(75, 12);
        }
    }
    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            SetInfo(60, 15);
        }

    }
}