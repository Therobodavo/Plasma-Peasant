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
 * Represents and item in the inventory system
 * items can be moved by the player in between slots
 */
namespace InventoryTest2
{
    class InventoryItem : InventoryElement
    {
        //attributes
        Rectangle originalRect; //used for position storage
        bool active; //if the item has been collected or not

        //property primarily used for allowing items to be added to the inventory
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        //constructor for this InventoryItems
        public InventoryItem(int xPos, int yPos, int width, int height) : base(xPos, yPos, width, height)
        {
            originalRect = this.Rect; //storing original position
            active = false; //all items are initially inactive
        }

        //method to be run in InventoryScreen Draw
        public void Draw(SpriteBatch spriteBatch, MouseState ms)
        {
            //only draws the item if it is active
            if(this.Active == true)
            {
                //As long as left click is down the item turns blue
                if (IsPressed(ms))
                {
                    spriteBatch.Draw(this.Tex, this.Rect, Color.Blue);
                }
                //otherwise the item is its default colors
                else
                {
                    spriteBatch.Draw(this.Tex, this.Rect, Color.White);
                }
            }            
        }

        //method to be run in InventoryScreen Update
        public void Update(MouseState ms, InventorySlot[] slots)
        {
            //only updates if the item is collected
            if(this.Active == true)
            {
                if (IsPressed(ms))
                {
                    //draws the clicked object around the cursor
                    this.Rect = new Rectangle(ms.Position.X - width / 2, ms.Position.Y - height / 2, width, height);
                    //looks at every slot
                    foreach (InventorySlot slot in slots)
                    {
                        //only updates "home" position if the slot is not filled
                        if (this.Rect.Intersects(slot.Rect) && slot.Filled == false)
                        {
                            originalRect = slot.Rect;
                        }
                    }
                }
                //returns object to its original placement
                else
                {
                    this.Rect = originalRect;
                }
            } 
        }
    }
}
