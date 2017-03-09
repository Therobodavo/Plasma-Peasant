using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * GDAPS 2 Online Section 2
 * Plasma Peasant Screen File
 * Programmed by David Knolls
 */
namespace PlasmaPeasant
{
    //Screen Class, lays out the basics for any advanced Screen Object
    class Screen
    {
        //checks if the screen needs reset
        protected bool needsReset;

        //Screen Constructor
        public Screen()
        {
            //initially says the screen doesn't need reset
            needsReset = false;
        }

        //Reset properties
        public bool NeedsReset
        {
            get { return needsReset; }
            set { needsReset = value; }
        }

        //Screen Load Method
        public virtual void Load(ContentManager content)
        {

        }

        //Screen Update Method
        public virtual void Update()
        {

        }

        //Screen Draw Method
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        //Screen reset Method
        public virtual void Reset()
        {

        }
    }
}
