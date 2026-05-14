using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Summitive
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D gameEndTexture;
        Texture2D gameIntroTexture;
        Texture2D animationRTexture;
        Texture2D animationLTexture;
        Texture2D whiteButterfly;
        Texture2D brownButterfly;
        Texture2D blueButterfly;
        Texture2D yellowButterfly;
        Texture2D orangeButterfly;

        Rectangle window;
        Rectangle nextSign;
        Rectangle exitSign;
        MouseState mouseState;
        KeyboardState keyboardState;

       Rectangle brButterflyRect;
       Rectangle blButterflyRect; 
       Rectangle yeButterflyRect; 
       Rectangle whButterflyRect; 
       Rectangle orButterflyRect;

        enum Screen
        {
            Intro,
            AnimationDay, 
            AnimationNight,
            GameOut
        }
        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            screen = Screen.Intro;
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            nextSign = new Rectangle(385, 415, 165, 45);
            exitSign = new Rectangle(345, 315, 165, 50);
            brButterflyRect = new Rectangle(685, 43, 40, 40);
            blButterflyRect = new Rectangle(47, 333, 40, 40);
            yeButterflyRect = new Rectangle(690, 370, 45, 40);
            whButterflyRect = new Rectangle(249, 218, 45, 40);
            orButterflyRect = new Rectangle(110, 73, 45, 40);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gameIntroTexture = Content.Load<Texture2D>("In-The-Garden-Intro-Screen");
            animationRTexture = Content.Load<Texture2D>("GardenDay");
            animationLTexture = Content.Load<Texture2D>("GardenNight");
            gameEndTexture = Content.Load<Texture2D>("In-The-Garden-Out");
            brownButterfly = Content.Load<Texture2D>("brownButterfly");
            whiteButterfly = Content.Load<Texture2D>("whiteButterfly");
            blueButterfly = Content.Load<Texture2D>("blueButterfly");
            yellowButterfly  = Content.Load<Texture2D>("yellowButterfly");
            orangeButterfly  = Content.Load<Texture2D>("orangeButterfly");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

            Window.Title = "In The Garden " + mouseState.Position.ToString();

            if (nextSign.Contains(mouseState.Position))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.AnimationDay;
                }
            }

            if (exitSign.Contains(mouseState.Position))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    Exit();
                }
            }

            if (screen == Screen.AnimationDay)
            {
                if (keyboardState.IsKeyDown(Keys.N))
                {
                    screen = Screen.AnimationNight; 

                }
            }

            if (screen == Screen.AnimationNight)
            {
                if (keyboardState.IsKeyDown(Keys.O))
                {
                    screen = Screen.GameOut;

                }
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(gameIntroTexture, new Rectangle(0, 0, 800, 600), Color.White);

            }

            if (screen == Screen.AnimationDay)
            {
                _spriteBatch.Draw(animationRTexture, new Rectangle(0, 0, 800, 600), Color.White);
                _spriteBatch.Draw(brownButterfly, brButterflyRect, Color.White);
                _spriteBatch.Draw(whiteButterfly, whButterflyRect, Color.White);
                _spriteBatch.Draw(orangeButterfly, orButterflyRect, Color.White);
                _spriteBatch.Draw(yellowButterfly, yeButterflyRect, Color.White);
                _spriteBatch.Draw(blueButterfly, blButterflyRect, Color.White);

            }

            if (screen == Screen.AnimationNight)
            {
                _spriteBatch.Draw(animationLTexture, new Rectangle(0, 0, 800, 600), Color.White);
                
            }

            if (screen == Screen.GameOut)
            {
                _spriteBatch.Draw(gameEndTexture, new Rectangle(0, 0, 800, 600), Color.White);

            }

            _spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
