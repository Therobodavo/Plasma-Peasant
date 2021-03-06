﻿using System;
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
        Button backButton;

        //custom color
        Color neonPink;

        public OptionsScreen()
        {
            backButton = new Button(462, 309, 100, 50);
            neonPink = new Color(255, 0, 255);
            backgroundRct = new Rectangle(0, 0, 1024, 786);
        }

        //loads in the textures needed
        public override void Load(ContentManager content)
        {
            optionsBackground = content.Load<Texture2D>("optionsBackground");
            backButton.Texture = content.Load<Texture2D>("backButton");
        }

        //if resume is pressed moves to the Main Menu
        public override void Update()
        {
            if (backButton.IsPressed())
            {
                Game1.currentScreen = Game1.GameStates.MainScreen;
            }
        }

        //draws options Background as the menu and the button
        public override void Draw(SpriteBatch spriteBatch)
        {
            //seems to be an error when switching between GameStates
            spriteBatch.Draw(optionsBackground, backgroundRct, Color.White);

            backButton.Draw(spriteBatch, neonPink);           
        }
    }
}
