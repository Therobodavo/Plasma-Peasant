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
 * Plasma Peasant
 * Generates the screen for the main menu when methods are called
 * in their respective places in Game1
 */
namespace PlasmaPeasant
{
    class MainMenu : Screen
    {
        //Buttons for the menu
        Button playButton;
        Button optionsButton;
        Button shopButton;
        Button exitButton;

        //custom Colors
        Color neonPink;
        Color neonGreen;

        //constructor to be called in Game1.Initialize
        public MainMenu()
        {
            playButton = new Button(350, 100, 100, 50);
            optionsButton = new Button(350, 175, 100, 50);
            shopButton = new Button(350, 250, 100, 50);
            exitButton = new Button(350, 325, 100, 50);
            neonPink = new Color(255, 0, 255);
            neonGreen = new Color(0, 255, 0);
        }

        //loads in all textures when called in Game1.LoadContent
        public override void Load(ContentManager content)
        {
            playButton.Texture = content.Load<Texture2D>("playButton");
            optionsButton.Texture = content.Load<Texture2D>("optionsButton");
            shopButton.Texture = content.Load<Texture2D>("shopButton");
            exitButton.Texture = content.Load<Texture2D>("exitButton");
        }

        //updated when called in Game1.Update
        public override void Update()
        {
            if (playButton.IsPressed())
            {
                Game1.currentScreen = Game1.GameStates.Dungeons;
            }
            else if (optionsButton.IsPressed())
            {
                Game1.currentScreen = Game1.GameStates.Options;
            }
            else if (shopButton.IsPressed())
            {
                Game1.currentScreen = Game1.GameStates.Shop;
            }
            else if (exitButton.IsPressed())
            {
                //implement events to cause the game to close

            }
        }

        //draws every sprite when called in Game1.Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            //drawing the buttons
            playButton.Draw(spriteBatch, Color.Red);
            optionsButton.Draw(spriteBatch, Color.Blue);
            shopButton.Draw(spriteBatch, neonGreen);
            exitButton.Draw(spriteBatch, neonPink);
        }
    }
}
