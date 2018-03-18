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

        // game time 
        GameTime gmTime;
        public GameTime GmTime { get { return gmTime; } }

        //Global State variable used for switching screens
        public enum GameStates{MainScreen, Dungeons, Options, Shop};
        public static GameStates currentScreen;
        public static bool needsClosed = false;

        //Screens
        Arena lvl1 = new Arena();
        MainMenu mainScreen = new MainMenu();
        OptionsScreen optionsScreen = new OptionsScreen();
        ShopScreen shopScreen = new ShopScreen();

        //Game Constructor
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        //Game Initialize Method
        protected override void Initialize()
        {
            //Set Game Window Size
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;

            //Show Mouse
            IsMouseVisible = true;

            //Default Screen
            currentScreen = GameStates.MainScreen;

            base.Initialize();
        }

        //Game LoadContent Method
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Loads every screen so they can be drawn (may change this)
            mainScreen.Load(this.Content);
            shopScreen.Load(this.Content);
            lvl1.Load(this.Content);
            optionsScreen.Load(this.Content);
        }

        //Game UnloadContent Method
        protected override void UnloadContent()
        {

        }

        //Game Update Method
        protected override void Update(GameTime gameTime)
        {
            if (needsClosed)
            {
                this.Exit();
            }
            //Updates current screen
            switch (currentScreen)
            {
                case GameStates.MainScreen:
                    mainScreen.Update();
                    break;
                case GameStates.Shop:
                    shopScreen.Update();
                    break;
                case GameStates.Dungeons:
                    if (lvl1.NeedsReset)
                    {
                        lvl1.Reset();
                    }
                    lvl1.GmTime = gameTime;
                    lvl1.Update();
                    gmTime = gameTime;
                    break;
                case GameStates.Options:
                    optionsScreen.Update();
                    break;
            }
            base.Update(gameTime);
        }

        //Game Draw Method
        protected override void Draw(GameTime gameTime)
        {
            //Sets background color
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            //Draws current screen
            switch (currentScreen)
            {
                
                case GameStates.MainScreen:
                    mainScreen.Draw(spriteBatch);
                    break;
                case GameStates.Shop:
                    shopScreen.Draw(spriteBatch);
                    break;
                case GameStates.Dungeons:
                    lvl1.Draw(spriteBatch);
                    break;
                case GameStates.Options:
                    optionsScreen.Draw(spriteBatch);
                    break;
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
