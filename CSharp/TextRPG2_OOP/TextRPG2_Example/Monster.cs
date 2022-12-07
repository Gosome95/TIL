using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextRPG2_Example
{
   public enum MonsterType
    {
        None,
        Slime,
        Orc,
        Skeleton
    }

    class Monster : Creature
    {
        protected MonsterType monsterType = MonsterType.None;

        protected Monster(MonsterType type) : base(CreatrueType.Monster)
        {
            monsterType = type;
        }
        public MonsterType GetMonsterType() { return monsterType; }
    }

    class Slime : Monster
    {
        public Slime() : base(MonsterType.Slime)
        {
            SetInfo(10, 3);
        }
    }
    class Orc : Monster
    {
        public Orc() : base(MonsterType.Orc)
        {
            SetInfo(10, 3);
        }
    }
    class Skeleton : Monster
    {
        public Skeleton() : base(MonsterType.Skeleton)
        {
            SetInfo(10, 3);
        }
    }
}