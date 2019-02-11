using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * GDAPS 2 Online Section 2
 * Characters Class
 * Programmed by Fred and David
 */
namespace PlasmaPeasant
{
    class Characters:Objects
    {
        // variables
        protected int health;
        protected int speed;

        // accessors
        public int Health { get { return health; } set { health = value; } }
        public int Speed { get { return speed; } set { speed = value; } }

        //Constructors
        public Characters(Level lvl, int xloc, int yloc,int width, int height) : base(lvl, new Rectangle(xloc,yloc,width,height))
        {
            this.fileTexture = "enemy1";
        }
        public Characters(Level lvl, int xloc, int yloc, int width, int height, int hp, int spd) : base(lvl, new Rectangle(xloc, yloc, width, height))
        {
            this.fileTexture = "enemy1";
            this.health = hp;
            this.speed = spd;
        }


        // checks if character is dead then removes them
        public bool CheckDead()
        {
            if(this.health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
