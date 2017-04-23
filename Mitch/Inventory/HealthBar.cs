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
 * HealthBar is a class for creating a non-percentage based
 * indicator of current player health
 */
namespace InventoryTest2
{
    class HealthBar
    {
        //attributes used for positioning
        Texture2D healthTex, barTex;
        Rectangle healthRect, barRect;
        int xPos, yPos, height, maxHealth;

        //Rectangle properties with accessors
        public Rectangle HealthRect
        {
            get { return healthRect; }
        }

        public Rectangle BarRect
        {
            get { return barRect; }
        }

        //Texture properties with mutators
        public Texture2D HealthTex
        {
            set { healthTex = value; }
        }

        public Texture2D BarTex
        {
            set { barTex = value; }
        }

        //constructor sets up all the values for the attributes
        public HealthBar(int maxHealth, int xPos, int yPos, int height)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.height = height;
            this.maxHealth = maxHealth;
            healthRect = new Rectangle(xPos, yPos, maxHealth * 20, height);
            barRect = new Rectangle(xPos, yPos, maxHealth * 20 + 8, height + 8);
        }

        //draws a health meter infront of a background bar
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(barTex, barRect, Color.White);
            spriteBatch.Draw(healthTex, healthRect, Color.White);
        }

        //draws the life bar based on maxHealth
        public void Update(int currentHealth)
        {
            barRect = new Rectangle(xPos, yPos, maxHealth * 20 + 8, height + 8);
            healthRect = new Rectangle(xPos + 4, yPos + 4, currentHealth * 20, height);
        }
    }
}
