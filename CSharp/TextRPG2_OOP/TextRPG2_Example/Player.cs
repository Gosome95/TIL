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
        protected int _hp = 0;
        protected int _attack = 0;
        protected PlayerType _type = PlayerType.None;

        protected Player(PlayerType type)
        {
            _type = type;
        }

        protected void SetInfo(int hp, int attack)
        {
            _hp = hp;
            _attack = attack;
        }
        public PlayerType GetPlayerType(){ return _type; }
        public int GetHP(){ return _hp; }
        public int GetAttack(){ return _attack; }
        public bool IsDead() { return _hp <= 0; }
        public void OndDamaged(int damage)
        {
            _hp -= damage;
            if (_hp < 0)
                _hp = 0;
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