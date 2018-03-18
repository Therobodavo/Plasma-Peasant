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
namespace PlasmaPeasant
{
    class InventoryScreen : Screen
    {
        //attributes used by InventoryScreen
        Texture2D background; //holds texture for background
        Rectangle backgroundLoc; //holds location and size of the background
        Player player; //hold the player for use in the player health;
        int elementSize; //default sizes of elements in the hud
        HealthBar lifebar;

        //constructor for this screen sets up initial values for the screen
        public InventoryScreen(Player player)
        {
            //bringing in the player for accurate
            this.player = player;

            //initializing data that is not changed
            backgroundLoc = new Rectangle(0, 700, 1024, 68);

            //used for width and height of elements in the hud
            elementSize = 32;

            //initializing healthbar
            lifebar = new HealthBar(player.Health, 202, 712, elementSize);
        }

        //loads in textures for this screen
        public override void Load(ContentManager content)
        {
            //loading in background texture
            background = content.Load<Texture2D>("background");

            //loading in textures used by healthbar
            lifebar.BarTex = content.Load<Texture2D>("healthBar");
            lifebar.HealthTex = content.Load<Texture2D>("health");
        }

        //updates lifebar to match player health
        public override void Update()
        {
            lifebar.Update(player.Health);
        }

        //draws background and healthbar for this screen
        public override void Draw(SpriteBatch spriteBatch)
        {            
            spriteBatch.Draw(background, backgroundLoc, Color.White); //drawing the background

            lifebar.Draw(spriteBatch); //drawing the lifebar
        }
    }
}
