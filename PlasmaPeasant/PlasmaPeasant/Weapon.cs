using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Weapon Class
 * Programmed by David Knolls
 * Creates a generic Weapon
 */
namespace PlasmaPeasant
{
    class Weapon:Items
    {
        //Character that is firing this weapon
        protected Characters host;

        //Property for the host
        public Characters Host
        {
            get { return host; }
            set { host = value; }
        }

        //Weapon constructor
        public Weapon(Characters host, Level lvl,int x, int y, int damage) : base(lvl, x, y, 0, 0, damage)
        {
            this.host = host;
        }

        //Overridable Attack method
        public virtual void Attack()
        {

        }
    }
}
