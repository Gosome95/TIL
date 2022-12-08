using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextRPG2_Example
{
    public enum CreatureType
    {
        None,
        Player = 1,
        Monster = 2
    }

    class Creature
    {
        protected int hp = 0;
        protected int attack = 0;
        protected CreatureType creatureType = CreatureType.None;
        protected Creature(CreatureType type)
        {
            creatureType = type;
        }

        public CreatureType GetCreatureType(){return creatureType; }
        public void SetInfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }

        public int GetHp(){return hp;}
        public int GetAttack(){return attack;}
        public bool IsDead(){return hp <= 0;}
        public void OndDamaged(int damage)
        {
            hp -= damage;
            if(hp < 0)
                hp = 0;
        }
    }
}