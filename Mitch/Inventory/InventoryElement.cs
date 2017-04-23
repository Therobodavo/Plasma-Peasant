using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * Mitch Steffens
 * Section 02
 * Plasma Peasant
 * Represents an object in the inventory, there are no object that are type InventoryElement because it is abstract
 */
namespace InventoryTest2
{
    abstract class InventoryElement
    {
        //attributes define where the element is positioned and its texture
        Rectangle rect;
        Texture2D tex; //texture will be set in the Load method of inventory screen
        protected int x, y, width, height;

        //texture should not be accessed
        public Texture2D Tex
        {
            get { return tex; }
            set { tex = value; }
        }

        //height and width should not change
        public int Width
        {
            get { return width; }
        }
        
        public int Height
        {
            get { return height; }
        }

        //The rectangle for an element can be modified
        public Rectangle Rect
        {
            get { return rect; }
            set
            {
                rect = value;
                x = Rect.X;
                y = Rect.Y;
            }
        }

        //sets initial values for the position of the screen
        public InventoryElement(int xPos, int yPos, int width, int height)
        {
            x = xPos;
            y = yPos;
            this.width = width;
            this.height = height;
            rect = new Rectangle(x, y, width, height);
        }

        //calls standard Draw method
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, rect, Color.White);
        }

        //if the cursor is over the object
        public bool IsMouseOver(MouseState ms)
        {          
            //used for readability
            int mouseX = ms.Position.X;
            int mouseY = ms.Position.Y;

            //space beyond the rectangle that is counted
            int buffer = 0;

            //checks to see if the mouse is within the bounds of the rectangle of the object
            if(mouseX > x - buffer && mouseX < x + width + buffer && mouseY > y - buffer && mouseY < y + height + buffer)
            {
                return true;
            }
            return false;
        }

        //if left click is down on this object
        public bool IsPressed(MouseState ms)
        {
            //if the mouse is over it and LMB is down
            if(IsMouseOver(ms) && ms.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }
    }
}
