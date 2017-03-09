using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 * GDAPS 2 Online Section 2
 * Plasma Peasant Main Game File
 * Programmed by David Knolls
 */
namespace PlasmaPeasant
{
    public class Game1 : Game
    {
        //Objects used
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Global State variable used for switching screens
        public enum GameStates{MainScreen, Dungeons, Options, Shop};
        public static GameStates currentScreen;

        //Game Constructor
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        //Game Initialize Method
        protected override void Initialize()
        {
            currentScreen = GameStates.MainScreen;
            base.Initialize();
        }

        //Game LoadContent Method
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Loads current screen
            switch (currentScreen)
            {
                case GameStates.MainScreen:
                    break;
                case GameStates.Shop:
                    break;
                case GameStates.Dungeons:
                    break;
                case GameStates.Options:
                    break;
            }
        }

        //Game UnloadContent Method
        protected override void UnloadContent()
        {

        }

        //Game Update Method
        protected override void Update(GameTime gameTime)
        {
            //Updates current screen
            switch (currentScreen)
            {
                case GameStates.MainScreen:
                    break;
                case GameStates.Shop:
                    break;
                case GameStates.Dungeons:
                    break;
                case GameStates.Options:
                    break;
            }
            base.Update(gameTime);
        }

        //Game Draw Method
        protected override void Draw(GameTime gameTime)
        {
            //Sets background color
            GraphicsDevice.Clear(Color.White);

            //Draws current screen
            switch (currentScreen)
            {
                case GameStates.MainScreen:
                    break;
                case GameStates.Shop:
                    break;
                case GameStates.Dungeons:
                    break;
                case GameStates.Options:
                    break;
            }
            base.Draw(gameTime);
        }
    }
}
