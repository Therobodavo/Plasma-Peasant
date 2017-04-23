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
 * Plamsa Peasant
 * InventorySlot is used for storage of InventoryItems in the inventory
 */
namespace InventoryTest2
{
    class InventorySlot : InventoryElement
    {
        //if there is an item in the slot filled = true
        bool filled;

        //property for filled
        public bool Filled
        {
            get { return filled; }
            set { filled = value; }
        }

        //constructs object with a rectangle with hard coded size
        public InventorySlot(int xPos, int yPos, int width, int height) : base(xPos, yPos, width, height)
        {
            filled = false;
        }

        //method to be called in InventoryScreen Update
        public void Update(InventoryItem[] items)
        {
            filled = false;
            //if any item is in the slot, filled is set to true
            foreach(InventoryItem item in items)
            {
                if (this.Rect.Intersects(item.Rect))
                {
                    filled = true;
                }
            }
        }
    }
}
