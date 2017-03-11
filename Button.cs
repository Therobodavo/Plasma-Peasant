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
 * Plasma Peasant
 * Generic Button
 */
namespace PlasmaPeasant
{
    class Button
    {
        //attributes for drawing the button
        Rectangle rct;
        Texture2D texture;

        //MouseState used for checking the position of the mouse, and the state of the mouse buttons
        MouseState mouseState;

        //allows the texture of the button to be set
        public Texture2D Texture
        {
            set { texture = value; }
        }

        //Constructor takes in variables for a rectangle
        public Button(int xPos, int yPos, int width, int height)
        {
            rct = new Rectangle(xPos, yPos, width, height);
        }

        //used exclusively in button class to see if mouse is over the button
        bool IsMouseOver()
        {
            mouseState = Mouse.GetState();
            bool inX;
            bool inY;
            //looks to see if the mouse is within the x coordinates of the button
            if ((mouseState.Position.X > rct.X) && (mouseState.Position.X < rct.X + rct.Width))
            {
                inX = true;
            }
            else
            {
                inX = false;
            }
            //looks to see if the mouse is within the y coordinates of the button
            if ((mouseState.Position.Y > rct.Y) && (mouseState.Position.Y < rct.Y + rct.Height))
            {
                inY = true;
            }
            else
            {
                inY = false;
            }
            //if mouse is within both the x and y of the button
            if (inX == true && inY == true)
            {
                return true;
            }
            return false;
        }

        //highlights the button if the mouse is over it
        public void Draw(SpriteBatch spriteBatch)
        {
            if(this.IsMouseOver() == true)
            {
                spriteBatch.Draw(texture, rct, new Color(255, 0, 255, 200));
            }
            else
            {
                spriteBatch.Draw(texture, rct, Color.White);
            }
        }

        //checks to see if the button is clicked
        public bool IsPressed()
        {
            if(IsMouseOver() && (mouseState.LeftButton == ButtonState.Pressed))
            {
                return true;
            }
            return false;
        }
    }
}
