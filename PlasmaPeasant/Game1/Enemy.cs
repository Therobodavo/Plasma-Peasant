using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
/*
 * Enemy Class
 * Programned by David and Fred
 */
namespace PlasmaPeasant
{
    class Enemy:Characters
    {
        // rangedweap
        RangedWeap rangeWeap;
        // shootval to keep enemy from shooting too fast
        int fireRate;
        // int value for how long since a direction change
        int directRate;
        // random movement for now
        Random rgen = new Random();

        // animation stuff// ANI TEST
        int frame;
        double timePerFrame = 100;
        int numFrames = 3;
        int framesElapsed;

        //sound effect
        //SoundEffect effect;
        //SoundEffect effectTwo;
        //SoundEffect effectThree;

        // default constructor
        public Enemy(Level lvl, int x, int y, int width, int height, int hp, int speed, int dmg) : base(lvl,x, y, width, height, hp, speed)
        {
            rangeWeap = new RangedWeap(this, lvl, x, y, dmg, 100, 10);
            fireRate = 100;
            directRate = 450;
        }

        //load
        public override void Load(ContentManager content)
        {
            //effect = content.Load<SoundEffect>("Laser_Shoot");
            //effectTwo = content.Load<SoundEffect>("hit");
            base.Load(content);
        }

        // randomly move for the time
        public void Move()
        {
            // AI Stuffs
            // get player position
            Rectangle play = lvl.player.Rectangle;

            // have enemy face player
            // if player is to the left of the enemy
            if(play.X == rectangle.X)
            {
                if(play.Y <= rectangle.Y)
                {
                    motion = Direction.Up;
                }
                else
                {
                    motion = Direction.Down;
                }
            }
            else if(play.X <= this.rectangle.X)
            {
                // check if Y values is the same
                if(play.Y == rectangle.Y)
                {
                    motion = Direction.Left;
                }
                // if player is above enemy
                else if(play.Y <= rectangle.Y)
                {
                    motion = Direction.Up_Left;
                }
                // if player is below enemy
                else 
                {
                    motion = Direction.Down_Left;
                }
            }
            // if player is to the right of the enemy
            else
            {
                // check if Y values is the same
                if (play.Y == rectangle.Y)
                {
                    motion = Direction.Right;
                }
                // if player is above enemy
                if (play.Y <= rectangle.Y)
                {
                    motion = Direction.Up_Right;
                }
                // if player is below enemy
                else
                {
                    motion = Direction.Down_Right;
                }
            }
            // check which direction to move
            // only runs after a set time of not running
            /*
            if(directRate >= 50)
            {
                int dir = rgen.Next(0, 8);
                if (dir == 0) { this.Motion = Direction.Down; }
                if (dir == 1) { this.Motion = Direction.Down_Left; }
                if (dir == 2) { this.Motion = Direction.Down_Right; }
                if (dir == 3) { this.Motion = Direction.Left; }
                if (dir == 4) { this.Motion = Direction.Right; }
                if (dir == 5) { this.Motion = Direction.Up; }
                if (dir == 6) { this.Motion = Direction.Up_Left; }
                if (dir == 7) { this.Motion = Direction.Up_Right; }
                directRate = 0;
            }*/

            // move based one direction of motion
            // TURNED OFF FOR SHOOT TEST
            if (this.Motion == Direction.Up) { Y = Y - speed; }
            if (this.Motion == Direction.Up_Left) { Y = Y - speed; X = X - speed; }
            if (this.Motion == Direction.Up_Right) { Y = Y - speed; X = X + speed; }
            if (this.Motion == Direction.Right) { X = X + speed; }
            if (this.Motion == Direction.Left) { X = X - speed; }
            if (this.Motion == Direction.Down) { Y = Y + speed; }
            if (this.Motion == Direction.Down_Left) { Y = Y + speed; X = X - speed; }
            if (this.Motion == Direction.Down_Right) { Y = Y + speed; X = X + speed; }

            // has weapons position follow the player
            rangeWeap.X = this.X;
            rangeWeap.Y = this.Y;

            //save last postion
            int lastPosX = X;
            int lastPosY = Y;

            //Checks if player collides with objects
            if (lvl.CheckCollisionObjects(this))
            {
                X = lastPosX;
                Y = lastPosY;
            }
            directRate++;
        }

        // shooting enemy
        // enemy always shoots when it can
        public void Shoot()
        {
            if (fireRate > rangeWeap.FireRate)
            {
                //float volume = 0.1f;
                //float pitch = 0.0f;
                //float pan = 0.0f;
                //effect.Play(volume, pitch, pan);
                rangeWeap.Attack();
                fireRate = 0;
            }
            else
            {
                fireRate++;
            }
        }

        // check if being hit
        public void CheckHits()
        {
            Projectile i = lvl.CheckCollisionProjectiles(this);
            if (i == null)
            {
                return;
            }
            else
            {
                //float volume = 0.4f;
                //float pitch = 0.0f;
                //float pan = 0.0f;
                //effectTwo.Play(volume, pitch, pan);
                this.Health -= i.Damage;
                if(this.Health <= 0)
                {
                    lvl.enemies.Remove(this);
                }
            }
        }

        // Enemy update
        public override void Update()
        {
            framesElapsed = (int)(lvl.GmTime.TotalGameTime.TotalMilliseconds / timePerFrame);
            frame = framesElapsed % numFrames + 1;
            this.CheckHits();
            this.Shoot();
            this.Move();
            base.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(textureFileName == "Enemy3AnimFull")
            {
                numFrames = 1;
            }
            // checks direction and displays sprite for it
            if (motion == Direction.Up)
            {
                if(textureFileName == "enemy1Sheet")
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(0, 0, 256, 256), Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 0, 256, 256), Color.White);
                }
            }
            else if (motion == Direction.Up_Right)
            {
                if (textureFileName == "enemy1Sheet")
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(256, 0, 256, 256), Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 256, 256, 256), Color.White);
                }
            }
            else if (motion == Direction.Right)
            {
                if (textureFileName == "enemy1Sheet")
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(512, 0, 256, 256), Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 512, 256, 256), Color.White);
                }
            }
            else if (motion == Direction.Down_Right)
            {
                if (textureFileName == "enemy1Sheet")
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(768, 0, 256, 256), Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 768, 256, 256), Color.White);
                }
            }
            else if (motion == Direction.Down)
            {
                if (textureFileName == "enemy1Sheet")
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(0, 256, 256, 256), Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 1024, 256, 256), Color.White);
                }
            }
            else if (motion == Direction.Down_Left)
            {
                if (textureFileName == "enemy1Sheet")
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(256, 256, 256, 256), Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 1280, 256, 256), Color.White);
                }
            }
            else if (motion == Direction.Left)
            {
                if (textureFileName == "enemy1Sheet")
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(512, 256, 256, 256), Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 1536, 256, 256), Color.White);
                }
            }
            else if (motion == Direction.Up_Left)
            {
                if (textureFileName == "enemy1Sheet")
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(768, 256, 256, 256), Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 1792, 256, 256), Color.White);
                }
            }
        }
    }
}
