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
 * Projectile Class used to create Projectiles
 * Programmed by Fred and David
 */
namespace PlasmaPeasant
{
    class Projectile : Objects
    {
        // attributes
        protected int damage;
        protected int despawn;
        protected int speed;
        protected Objects sender;

        // properties
        public int Damage { get { return damage; } }
        public Objects Sender { get { return sender; } }


        public Projectile(Level lvl, Objects host, Rectangle rec, int dmg, int desp, int travelTime, Direction dir, string texture) : base(lvl, rec)
        {
            // assigning variables
            damage = dmg;
            despawn = desp;
            speed = travelTime;
            motion = dir;
            sender = host;
            fileTexture = texture;
        }


        // method to update projectile based on direction
        public override void Update()
        {
            if(motion == Direction.Up) { Y = Y - speed; }
            if(motion == Direction.Up_Left) { Y = Y - speed; X = X - speed; }
            if(motion == Direction.Up_Right) { Y = Y - speed; X = X + speed; }
            if(motion == Direction.Down) { Y = Y + speed; }
            if(motion == Direction.Down_Left) { Y = Y + speed; X = X - speed; }
            if(motion == Direction.Down_Right) { Y = Y + speed; X = X + speed; }
            if(motion == Direction.Left) { X = X - speed; }
            if(motion == Direction.Right) { X = X + speed; }

            // control number of projectiles
            despawn = despawn + 1;

            // check if ready for despawn
            if (despawn == 2000)
            {
                this.Despawn();
            }

            // despawn if collides with object
            if (CheckCollideObj())
            {
                this.Despawn();
            }
        }

        //despawns projectile
        public void Despawn()
        {
            lvl.projs.Remove(this);
        }

        // checks if collides with a objects (temporary until enemy added)
        public bool CheckCollideObj()
        {
            foreach (Objects obj in lvl.objs)
            {
                if (this.Rectangle.Intersects(obj.Rectangle)) { return true; }
            }
            return false;
        }



        public override void Draw(SpriteBatch spriteBatch)
        {
            // checks direction and displays sprite for it
            if (motion == Direction.Up)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(0, 0, 256, 256), Color.White);
            }
            else if (motion == Direction.Up_Left)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(768, 256, 256, 256), Color.White);
            }
            else if (motion == Direction.Up_Right)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(256, 0, 256, 256), Color.White);
            }
            else if (motion == Direction.Left)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(512, 256, 256, 256), Color.White);
            }
            else if (motion == Direction.Right)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(512, 0, 256, 256), Color.White);
            }
            else if (motion == Direction.Down_Left)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(256, 256, 256, 256), Color.White);
            }
            else if (motion == Direction.Down_Right)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(768, 0, 256, 256), Color.White);
            }
            else if (motion == Direction.Down)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(0, 256, 256, 256), Color.White);
            }
        }
    }
}
