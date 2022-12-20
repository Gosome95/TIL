using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextRPG2_Example
{
   public enum PlayerType
    {
        None,
        Knight,
        Archer,
        Mage
    }

    class Player : Creature
    {
        protected PlayerType playerType = PlayerType.None;
        protected Player(PlayerType type) : base(CreatureType.Player)
        {
            playerType = type;
        }

        public PlayerType GetPlayerType() { return playerType; }

        // Random damage
        public int randDamage()
        {
            int randAttack;
            switch (playerType)
            {
                case PlayerType.Knight:
                    randAttack = _rand.Next(10, 16);
                    _attack = randAttack;
                    break;
                case PlayerType.Archer:
                    randAttack = _rand.Next(12, 17);
                    _attack = randAttack;
                    break;
                case PlayerType.Mage:
                    randAttack = _rand.Next(14, 20);
                    _attack = randAttack;
                    break;
            }
            return _attack;
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
            SetInfo(70, 12);
        }
    }
    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            SetInfo(60, 16);
        }
    }
}