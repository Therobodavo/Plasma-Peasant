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
* GDAPS 2 Online Section 2
* Objects Class
* Programmed by Fred
*/
namespace PlasmaPeasant
{
    class Objects
    {
        // variables
        protected Texture2D texture;
        protected Rectangle rectangle;
        protected Level lvl;
        public enum Direction { Up, Up_Left, Left, Down_Left, Down, Down_Right, Right, Up_Right }
        protected Direction motion;
        SoundEffect effect;

        // string for saving texture name
        protected string fileTexture;

        //  accessors
        public SoundEffect Effect { get { return effect; } set { effect = value; } }
        public Rectangle Rectangle { get { return rectangle; } }
        public Texture2D Texture { get { return texture; } set { texture = value; } }
        public string textureFileName { get { return fileTexture; } set { fileTexture = value; } }
        public int Width { get { return rectangle.Width; } }
        public int Height { get { return rectangle.Height; } }
        public int X { get { return rectangle.X; } set { rectangle.X = value; } }
        public int Y { get { return rectangle.Y; } set { rectangle.Y = value; } }
        public Direction Motion { get { return motion; }set { motion = value; } }

        public Objects(Level lvl, Rectangle rec)
        {
            rectangle = rec;
            this.lvl = lvl;
            fileTexture = "SpeedBoost";
        }

        // other constructor to assign texture individually
        public Objects(Level lvl, Rectangle rec, string tex2D)
        {
            rectangle = rec;
            fileTexture = tex2D;
            this.lvl = lvl;
        }
        
        //Screen Load Method
        public virtual void Load(ContentManager content)
        {
            texture = content.Load<Texture2D>(fileTexture);
        }

        //Screen Update Method
        public virtual void Update()
        {

        }

        //Screen Draw Method
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
