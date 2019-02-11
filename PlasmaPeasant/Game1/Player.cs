using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
/*
* GDAPS 2 Online Section 2
* Player class
* Programmed by Fred and David
*/
namespace PlasmaPeasant
{
    class Player:Characters
    {
        // attributes to save kyboard values
        KeyboardState kstate;
        KeyboardState oldstate;
        int lastPosX;
        int lastPosY;
        InventoryScreen hud;

        // animation stuff
        int frame;
        double timePerFrame = 100;
        int numFrames = 3;
        int framesElapsed;

        // accesor for kstate
        public KeyboardState Kstate { get { return kstate; } }

        // int value to set how often to shoot
        int fireRate;

        // attribute for bag
        Bag bag = new Bag(20);

        // weapons
        // melee weapon
        // ranged weapon
        private RangedWeap rangeWeap;

        //sound effect
        //SoundEffect effect;
        //SoundEffect effectTwo;
        //SoundEffect effectThree;

        // basic constructor
        public Player(Level lvl, int x, int y, int width, int height, int hp, int speed) : base(lvl, x, y, width, height, hp, speed)
        {
            fireRate = 1000;
            fileTexture = "playerAnimFull";
            // test ranged weapon
            rangeWeap = new RangedWeap(this, lvl, x, y, 5, 25, 10);
            hud = new InventoryScreen(this);

        }

        public RangedWeap Weapon
        {
            get { return rangeWeap; }
            set { rangeWeap = value; }
        }

        public void Control()
        {
            // save last keyboard state
            oldstate = kstate;

            //save last postion
            lastPosX = X;
            lastPosY = Y;

            //Input from user (moving and shooting)
            GetInput();

            // has weapons position follow the player
            rangeWeap.X = this.X;
            rangeWeap.Y = this.Y;

            //Checks if player collides
            if (lvl.CheckCollisionObjects(this))
            {
                X = lastPosX;
                Y = lastPosY;
            }
            // check if player collides with enemies
            if (lvl.CheckCollisionEnemy(this))
            {
                X = lastPosX;
                Y = lastPosY;
                health = health - 1;
            }
        }

        // shooting controls
        public bool CanShoot()
        {
            // shooting controls
            if (fireRate > rangeWeap.FireRate)
            {
                if (kstate.IsKeyDown(Keys.Space))
                {
                    fireRate = 0;
                    return true;
                }
                else
                {
                    fireRate = fireRate + 1;
                    return false;
                }
            }
            fireRate = fireRate + 1;
            return false;
        }
        public void GetInput()
        {

            if (kstate.IsKeyDown(Keys.Escape))
            {
                lvl.NeedsReset = true;
                Game1.currentScreen = Game1.GameStates.MainScreen;
            }
            // save keyboard state
            kstate = Keyboard.GetState();

            // movement controls
            if (kstate.IsKeyDown(Keys.W))
            {
                Y = Y - speed;
            }
            if (kstate.IsKeyDown(Keys.A))
            {
                X = X - speed;
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                Y = Y + speed;
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                X = X + speed;
            }

            //Direction
            // code to figure out where player is aiming
            if (kstate.IsKeyDown(Keys.W))
            {
                if (kstate.IsKeyDown(Keys.A)) { motion = Direction.Up_Left; }
                else if (kstate.IsKeyDown(Keys.D)) { motion = Direction.Up_Right; }
                else { motion = Direction.Up; }
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                if (kstate.IsKeyDown(Keys.A)) { motion = Direction.Down_Left; }
                else if (kstate.IsKeyDown(Keys.D)) { motion = Direction.Down_Right; }
                else { motion = Direction.Down; }
            }
            if (kstate.IsKeyDown(Keys.A) && kstate.IsKeyDown(Keys.W) == false && kstate.IsKeyDown(Keys.S) == false && kstate.IsKeyDown(Keys.D) == false) { motion = Direction.Left; }
            if (kstate.IsKeyDown(Keys.D) && kstate.IsKeyDown(Keys.W) == false && kstate.IsKeyDown(Keys.S) == false && kstate.IsKeyDown(Keys.A) == false) { motion = Direction.Right; }

            // if no keys are down shoots straight up
            //if (kstate.IsKeyDown(Keys.A) == false && kstate.IsKeyDown(Keys.W) == false && kstate.IsKeyDown(Keys.S) == false && kstate.IsKeyDown(Keys.D) == false) { motion = Direction.Up; }

            if (CanShoot() && kstate.IsKeyDown(Keys.Space))
            {
                //float volume = 0.4f;
                //float pitch = 0.0f;
                //float pan = 0.0f;
                //effect.Play(volume, pitch, pan);
                rangeWeap.Attack();
            }

            // TEST USE ITEM FROM BAG
            // B to use first item in Bag
            if(kstate.IsKeyDown(Keys.B) && oldstate.IsKeyDown(Keys.B) != true)
            {
                this.TestItem();
            }
        }

        // check if collided with objects to pick it up
        public void CheckItem()
        {
            Items i = lvl.CheckCollisionItems(this);
            if(i == null) { return; }
            else
            {
                //float volume = 0.4f;
                //float pitch = 0.0f;
                //float pan = 0.0f;
                //effectThree.Play(volume, pitch, pan);
                this.health += i.Health;
                if (health > 100)
                {
                    health = 100;
                }
                this.Speed += i.Speed;
                rangeWeap.Damage += i.Damage;
            }
        }

        // picks up the weapon on the floor
        public void CheckWeap()
        {
            RangedWeap i = lvl.CheckCollisionWeap(this);
            if (i == null) { return; }
            else
            {
                rangeWeap = i;
            }
        }

        // check if being hit
        public void CheckHits()
        {
            Projectile i = lvl.CheckCollisionProjectiles(this);
            if(i == null)
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
            }
        }

        // TEST METHOD USES FIRST ITEM IN BAG
        public void TestItem()
        {
            if(bag.Count == 0)
            {
                return;
            }
            this.UseItem(0);
        }
        

        // item use
        public void UseItem(int i)
        {
            // gets item from bag
            Items item = bag.Use(i);
            // applies item values to player
            this.Health += item.Health;
            if(health > 100)
            {
                health = 100;
            }
            this.Speed += item.Speed;
            rangeWeap.Damage += item.Damage;
        }

        // weapon swap
        public void WeapSwap()
        {
            // save old weapon and add to bag
            RangedWeap oldWeap = rangeWeap;
            bag.PickUp(oldWeap);
            // get first weapon to swap
            RangedWeap newWeap = bag.GetWeap(0);
            rangeWeap = newWeap;
        }
        public override void Update()
        {
            framesElapsed = (int)(lvl.GmTime.TotalGameTime.TotalMilliseconds / timePerFrame);
            frame = framesElapsed % numFrames + 1;
            this.CheckHits();
            this.CheckItem();
            this.Control();
            hud.Update();
            base.Update();
        }
        public override void Load(ContentManager content)
        {
            //effect = content.Load<SoundEffect>("Laser_Shoot");
            //effectTwo = content.Load<SoundEffect>("hit");
            //effectThree = content.Load<SoundEffect>("pickup");
            base.Load(content);
            hud.Load(content);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            // checks direction and displays sprite for it
            if (motion == Direction.Up)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 0, 256, 256), Color.White);
            }
            else if (motion == Direction.Up_Right)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 256, 256, 256), Color.White);
            }
            else if (motion == Direction.Right)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 512, 256, 256), Color.White);
            }
            else if (motion == Direction.Down_Right)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 768, 256, 256), Color.White);
            }
            else if (motion == Direction.Down)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 1024, 256, 256), Color.White);
            }
            else if (motion == Direction.Down_Left)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 1280, 256, 256), Color.White);
            }
            else if (motion == Direction.Left)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 1536, 256, 256), Color.White);
            }
            else if (motion == Direction.Up_Left)
            {
                spriteBatch.Draw(texture, rectangle, new Rectangle(0 + (256 * frame), 1792, 256, 256), Color.White);
            }
            hud.Draw(spriteBatch);
        }
    }
}
