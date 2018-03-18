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
    class ShopScreen : Screen
    {
        //attributes for the background
        Texture2D shopBackground;
        Rectangle backgroundRct;

        //attributes for buttons
        Button backButton;

        //custom color
        Color neonYellow;

        public ShopScreen()
        {
            backButton = new Button(462, 309, 100, 50);
            neonYellow = new Color(100, 100, 0);
            backgroundRct = new Rectangle(0, 0, 1024, 768);
        }

        //loads in the textures needed
        public override void Load(ContentManager content)
        {
            shopBackground = content.Load<Texture2D>("shopBackground"); //need different background texture
            backButton.Texture = content.Load<Texture2D>("backButton");
        }

        //if resume is pressed moves to MainScreen GameState
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
            spriteBatch.Draw(shopBackground, backgroundRct, Color.White);
            backButton.Draw(spriteBatch, neonYellow);           
        }
    }
}
