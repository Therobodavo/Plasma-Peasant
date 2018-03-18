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
        Button exitButton;

        //attributes for the background
        Texture2D mainBackground;
        Rectangle backgroundRct;

        //Attribute for logo
        Texture2D logo;

        //custom Colors
        Color neonPink;
        Color neonGreen;

        //constructor to be called in Game1.Initialize
        public MainMenu()
        {
            backgroundRct = new Rectangle(0, 0, 1024, 768);
            playButton = new Button(450, 400, 100, 50);
            exitButton = new Button(450, 475, 100, 50);
            neonPink = new Color(255, 0, 255);
            neonGreen = new Color(0, 255, 0);
        }

        //loads in all textures when called in Game1.LoadContent
        public override void Load(ContentManager content)
        {
            //effect = content.Load<SoundEffect>("Play");
            logo = content.Load<Texture2D>("PlasmaLogo");
            mainBackground = content.Load<Texture2D>("mainBack");
            playButton.Texture = content.Load<Texture2D>("playButton");
            exitButton.Texture = content.Load<Texture2D>("exitButton");
        }

        //updated when called in Game1.Update
        public override void Update()
        {
            if (playButton.IsPressed())
            {
                Game1.currentScreen = Game1.GameStates.Dungeons;
            }
            else if (exitButton.IsPressed())
            {
                Game1.needsClosed = true;
            }
        }

        //draws every sprite when called in Game1.Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draws background
            spriteBatch.Draw(mainBackground, backgroundRct, Color.White);

            //Dras Logo
            spriteBatch.Draw(logo, new Rectangle(0,50,1024,300), Color.White);

            //drawing the buttons
            playButton.Draw(spriteBatch, Color.Red);
            exitButton.Draw(spriteBatch, neonPink);
        }
    }
}
