using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
/*
 * Mitch Steffens
 * Section 02
 * Plasma Peasant
 * Class used to operate and draw the UI for the player, should be combined or called 
 * with the primary game method
 */
namespace InventoryTest2
{
    class InventoryScreen : Screen
    {
        //HealthBar used in the main screen
        HealthBar lifeBar;

        //Arrays for holding slots and items
        InventorySlot[] slots;
        InventoryItem[] items;

        //unique items
        InventoryItem item1;
        InventoryItem item2;

        //mouseState used for all the mouseControls
        MouseState mouseState;

        //font for testing
        SpriteFont font;

        //Texture for the ui
        Texture2D background;

        //element Sizes are customizable
        int elementSize;

        //initializes values
        public InventoryScreen()
        {
            elementSize = 32; //custom sizes for the inventory elements
            mouseState = Mouse.GetState(); //initializes the mouse controls

            //initializing the HealthBar item
            lifeBar = new HealthBar(10, 50, 420, elementSize);

            //initializing the InventoryElement arrays
            items = new InventoryItem[2];
            slots = new InventorySlot[4];
            
            //instantiating InventoryItems
            item1 = new InventoryItem(200, 300, elementSize, elementSize);
            item2 = new InventoryItem(280, 300, elementSize, elementSize);

            //adding items to the InventoryItem array
            items[0] = item1;
            items[1] = item2;

            //slots all have the same texture
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i] = new InventorySlot(300 + (i * (elementSize * 2)), 420, elementSize, elementSize);
            }
        }

        //loads in textures
        public override void Load(ContentManager content)
        {
            background = content.Load<Texture2D>("background");

            //loading in textures for healthbar
            lifeBar.BarTex = content.Load<Texture2D>("healthBar"); //background healthbar texture
            lifeBar.HealthTex = content.Load<Texture2D>("health"); //texture for health meter

            //loading in unique textures for items (these are default textures that should be changed)
            item1.Tex = content.Load<Texture2D>("testItem");
            item2.Tex = content.Load<Texture2D>("testItem");

            //loading in spritefont for development trouble shooting
            font = content.Load<SpriteFont>("mainFont");

            //loading in the same texture for all the slots
            foreach(InventorySlot slot in slots)
            {
                slot.Tex = content.Load<Texture2D>("stoneSlot");
            }
        }

        //Moving of onscreen objects happens here
        public override void Update()
        {
            //updating the mouse position every tick
            mouseState = Mouse.GetState();

            //currentPlayer health get passed into lifeBar to change its width
            lifeBar.Update(10);

            //updating every item
            foreach (InventoryItem item in items)
            {
                item.Update(mouseState, slots);

                //setting the items to active
                item.Active = true;
            }
            //updating every slot
            foreach(InventorySlot slot in slots)
            {
                slot.Update(items);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //draws the texture for the background
            spriteBatch.Draw(background, new Rectangle(-20, 400, 850, 100), Color.White);

            //draws the textures for the lifeBar
            lifeBar.Draw(spriteBatch);

            //drawing all the slots
            foreach (InventorySlot slot in slots)
            {
                slot.Draw(spriteBatch);
            }
            //drawing all the items
            foreach(InventoryItem item in items)
            {
                item.Draw(spriteBatch, mouseState);
            }
            /*
             * Used for development troubleshooting 
            spriteBatch.DrawString(font, "Mouse X: " + mouseState.Position.X + "Mouse Y: " + mouseState.Position.Y, new Vector2(0,0), Color.White);
            spriteBatch.DrawString(font, "Slot 1: " + slots[0].Filled + "Slot 2: " + slots[1].Filled + "Slot 3: " + slots[2].Filled + "Slot 4: " + slots[3].Filled, new Vector2(0, 50), Color.Black);
            */
        }
    }
}
