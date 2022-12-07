using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextRPG2_Example
{
   public enum CreatrueType
    {
        None,
        Player = 1,
        Monster = 2
    }

    class Creature
    {
        protected int _hp = 0;
        protected int _attack = 0;
        protected CreatrueType creatrueType = CreatrueType.None;

        protected Creature(CreatrueType type)
        {
            creatrueType = type;
        }

        public CreatrueType GetCreatrueType() { return creatrueType;  }
        public void SetInfo(int hp, int attack)
        {
            _hp = hp;
            _attack = attack;
        }
        public int GetHP() { return _hp; }
        public int GetAttack() { return _attack; }
        public bool IsDead() { return _hp <= 0; }
        public void OnDamaged(int damage)
        {
            _hp -= damage;
            if (_hp < 0)
                _hp = 0;
        }
    }
}