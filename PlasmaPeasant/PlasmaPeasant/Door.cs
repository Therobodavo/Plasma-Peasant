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
 * Door used to go from one room to another
 * Used in Arena
 * Programmed by David and Fred
 */
namespace PlasmaPeasant
{
    class Door:Objects
    {
        // attribute
        private bool open;
        private Texture2D openTexture;
        private int nextRoom;
        private int nextX;
        private int nextY;
        private Arena game;

        //Properties
        public bool Open { get { return open; } set { open = value; } }
        public int NextRoom { get { return nextRoom; } }
        public int NextX { get { return nextX; } }
        public int NextY { get { return nextY; } }

        //Constructor
        public Door(Arena lvl, Rectangle rectangle, int nxtRoom, int nextX, int nextY) : base(lvl,rectangle, "DoorClosed")
        {
            //Sets variables
            nextRoom = nxtRoom;
            open = false;
            this.nextX = nextX;
            this.nextY = nextY;
            game = lvl;
        }

        //Loads Textures
        public override void Load(ContentManager content)
        {
            openTexture = content.Load<Texture2D>("DoorOpen");
            base.Load(content);
        }

        //Updates door
        public override void Update()
        {
            if (open)
            {
                this.fileTexture = "DoorOpen";

                //If the player is in the door
                if (playerCollision())
                {
                    //Switch levels
                    game.LevelNum = nextRoom;
                    game.NeedsLoaded = true;
                    game.NextX = this.NextX;
                    game.NextY = this.nextY;
                }
            }
            base.Update();
        }

        //Check player collision with the door
        public bool playerCollision()
        {
            if (game.player.Rectangle.Intersects(rectangle))
            {
                return true;
            }
            return false;
        }
    }
}
