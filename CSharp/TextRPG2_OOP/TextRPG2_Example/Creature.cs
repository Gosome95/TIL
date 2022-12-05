using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextRPG2_Example
{
    enum CreatureType
    {
        None,
        Player = 1,
        Monster = 2
    }

    class Creature
    {
        protected int _hp = 0;
        protected int _attack = 0;
        protected CreatureType creatureType = CreatureType.None;
        protected Creature(CreatureType type)
        {
            creatureType = type;
        }

        public CreatureType GetCreatureType() { return creatureType; }
        protected void SetInfo(int hp, int attack)
        {
            _hp = hp;
            _attack = attack;
        }
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

}