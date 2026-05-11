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
        Rectangle window;
        Rectangle nextSign;
        MouseState mouseState;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            gameIntroTexture = Content.Load<Texture2D>("In-The-Garden-Intro-Screen");
            //animationRTexture = Content.Load<Texture2D>("");
            //animationLTexture = Content.Load<Texture2D>("");
           // gameEndTexture = Content.Load<Texture2D>("");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mouseState = Mouse.GetState();
            Window.Title = "In The Garden " + mouseState.Position.ToString();

            if (nextSign.Contains(mouseState.Position))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.AnimationDay;
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
