using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        SoundEffect birdsChirp;
        SoundEffectInstance birdsChirpInstance;
        SoundEffect insectsEffect;
        SoundEffectInstance insectsEffectInstance;
        SpriteFont instructions;

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

        Vector2 brButterflySpeed;
        Vector2 blButterflySpeed;
        Vector2 yeButterflySpeed;
        Vector2 orButterflySpeed;
        Vector2 whButterflySpeed;

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

            brButterflySpeed = new Vector2(4, 5);
            blButterflySpeed = new Vector2(3, 4);
            yeButterflySpeed = new Vector2(3, 3);
            orButterflySpeed = new Vector2(4, 5);
            whButterflySpeed = new Vector2(2, 4);

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
            birdsChirp = Content.Load<SoundEffect>("birds");
            birdsChirpInstance = birdsChirp.CreateInstance();
            insectsEffect = Content.Load<SoundEffect>("insects");
            insectsEffectInstance = birdsChirp.CreateInstance();
            instructions = Content.Load<SpriteFont>("pixelFont");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();
            birdsChirpInstance.IsLooped = false;

            Window.Title = "In The Garden " + mouseState.Position.ToString();
 
            if (screen == Screen.GameOut)
            {
                if (nextSign.Contains(mouseState.Position))
                {
                    if (mouseState.RightButton == ButtonState.Pressed)
                    {
                        screen = Screen.Intro;
                    }
                }
                if (exitSign.Contains(mouseState.Position))
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        Exit();
                    }
                }
            }

            else if (screen == Screen.Intro)
            {
                if (nextSign.Contains(mouseState.Position))
                {
                    if (mouseState.LeftButton == ButtonState.Pressed)
                    {
                        screen = Screen.AnimationDay;
                        birdsChirpInstance.Play();
                    }
                }
            }

            else if (screen == Screen.AnimationDay)
            {
                brButterflyRect.X += (int)brButterflySpeed.X;
                if (brButterflyRect.Right > window.Width || brButterflyRect.Left < 0)
                {
                    brButterflySpeed.X *= -1;
                   
                }
                if (brButterflyRect.Bottom > window.Height || brButterflyRect.Top < 0)
                {
                    brButterflySpeed.Y *= -1;
                    
                }
                brButterflyRect.Y += (int)brButterflySpeed.Y;

                blButterflyRect.X += (int)blButterflySpeed.X;
                if (blButterflyRect.Right > window.Width || blButterflyRect.Left < 0)
                {
                    blButterflySpeed.X *= -1;

                }
                if (blButterflyRect.Bottom > window.Height || blButterflyRect.Top < 0)
                {
                    blButterflySpeed.Y *= -1;

                }
                blButterflyRect.Y += (int)blButterflySpeed.Y;

                yeButterflyRect.X += (int)yeButterflySpeed.X;
                if (yeButterflyRect.Right > window.Width || yeButterflyRect.Left < 0)
                {
                    yeButterflySpeed.X *= -1;

                }
                if (yeButterflyRect.Bottom > window.Height || yeButterflyRect.Top < 0)
                {
                    yeButterflySpeed.Y *= -1;

                }
                yeButterflyRect.Y += (int)yeButterflySpeed.Y;

                orButterflyRect.X += (int)orButterflySpeed.X;
                if (orButterflyRect.Right > window.Width || orButterflyRect.Left < 0)
                {
                    orButterflySpeed.X *= -1;

                }
                if (orButterflyRect.Bottom > window.Height || orButterflyRect.Top < 0)
                {
                    orButterflySpeed.Y *= -1;

                }
                orButterflyRect.Y += (int)orButterflySpeed.Y;

                whButterflyRect.X += (int)whButterflySpeed.X;
                if (whButterflyRect.Right > window.Width || whButterflyRect.Left < 0)
                {
                    whButterflySpeed.X *= -1;

                }
                if (whButterflyRect.Bottom > window.Height || whButterflyRect.Top < 0)
                {
                    whButterflySpeed.Y *= -1;

                }
                whButterflyRect.Y += (int)whButterflySpeed.Y;

                if (birdsChirpInstance.State == SoundState.Stopped)
                {
                    screen = Screen.AnimationNight;
                    
                }
            }

            else if (screen == Screen.AnimationNight)
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

            else if (screen == Screen.AnimationDay)
            {
                _spriteBatch.Draw(animationRTexture, new Rectangle(0, 0, 800, 600), Color.White);
                _spriteBatch.Draw(brownButterfly, brButterflyRect, Color.White);
                _spriteBatch.Draw(whiteButterfly, whButterflyRect, Color.White);
                _spriteBatch.Draw(orangeButterfly, orButterflyRect, Color.White);
                _spriteBatch.Draw(yellowButterfly, yeButterflyRect, Color.White);
                _spriteBatch.Draw(blueButterfly, blButterflyRect, Color.White);

            }

            else if (screen == Screen.AnimationNight)
            {
                _spriteBatch.Draw(animationLTexture, new Rectangle(0, 0, 800, 600), Color.White);
                _spriteBatch.DrawString(instructions, "Press O to end animation.", new Rectangle(600, 200, 25, 25), Color.Gold);
            }

            else if (screen == Screen.GameOut)
            {
                _spriteBatch.Draw(gameEndTexture, new Rectangle(0, 0, 800, 600), Color.White);

            }

            _spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
