using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Items class for generic items
 * Programmed by Fred
 * Needs changed - David
 */
namespace PlasmaPeasant
{
    class Items:Objects
    {

        //THIS NEEDS CHANGED - David (needs changed into different item classes)

        // take values to add to player
        protected int health;
        protected int speed;
        protected int damage;

        public int Health { get { return health; } }
        public int Speed { get { return speed; } }
        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        public Items(Level lvl, int x, int y, int healthVal, int speedVal, int damageVal) : base(lvl, new Rectangle(x, y, 32, 32))
        {
            health = healthVal;
            speed = speedVal;
            damage = damageVal;
        }
        public Items(Level lvl, int x, int y, int healthVal, int speedVal, int damageVal, string texture):base(lvl,new Rectangle(x,y,32,32),texture)
        {
            health = healthVal;
            speed = speedVal;
            damage = damageVal;
        }
    }
}
