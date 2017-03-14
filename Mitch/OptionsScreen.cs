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
 * Methods needed to operate an options screen
 */
namespace PlasmaPeasant
{
    class OptionsScreen : Screen
    {
        //attributes for the background
        Texture2D optionsBackground;
        Rectangle backgroundRct;

        //attributes for buttons
        Button resumeButton;

        //custom color
        Color neonPink;

        public OptionsScreen()
        {
            resumeButton = new Button(350, 200, 100, 50);
            neonPink = new Color(255, 0, 255);
            backgroundRct = new Rectangle(100, 100, 600, 400);
        }

        //loads in the textures needed
        public override void Load(ContentManager content)
        {
            optionsBackground = content.Load<Texture2D>("optionsBackground");
            resumeButton.Texture = content.Load<Texture2D>("resumeButton");
        }

        //if resume is pressed moves to MainScreen GameState
        public override void Update()
        {
            if (resumeButton.IsPressed())
            {
                Game1.currentScreen = Game1.GameStates.MainScreen;
            }
        }

        //draws options Background as the menu and the button
        public override void Draw(SpriteBatch spriteBatch)
        {
            //seems to be an error when switching between GameStates
            spriteBatch.Draw(optionsBackground, backgroundRct, Color.White);
            resumeButton.Draw(spriteBatch, neonPink);           
        }
    }
}
