using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Summative_Assignment_1_5
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        enum Screen
        {
            intro, intro2, animation, credits
        }
        float seconds;
        KeyboardState keyState, prevKeyState;
        Screen screen;
        int screenWidth = 500;
        int screenHeight = 400;
        Rectangle introsRect, pacManRect, msPacManRect;
        Texture2D introTexture, intro2Texture, pacManTexture, msPacManTexture;
        SpriteFont introText;
        SoundEffect introMusic;
        SoundEffectInstance introMusicInstance;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.ApplyChanges();
            introsRect = new Rectangle(0, 0, screenWidth, screenHeight);
            pacManRect = new Rectangle(0, , 10, 10);
            msPacManRect = new Rectangle(100, 100, 258, 281);
            base.Initialize();
            seconds = 0f;

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            introTexture = Content.Load<Texture2D>("PacManIntro");
            introText = Content.Load<SpriteFont>("IntroText");
            intro2Texture = Content.Load<Texture2D>("PacManIntro2");
            introMusic = Content.Load<SoundEffect>("PacManMusic");
            pacManTexture = Content.Load<Texture2D>("PacMan");
            msPacManTexture = Content.Load<Texture2D>("MsPacMan");
            introMusicInstance = introMusic.CreateInstance();
            introMusicInstance.IsLooped = true;
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            prevKeyState = keyState;
            keyState = Keyboard.GetState();

            if (screen == Screen.intro)
            {
                if (keyState.IsKeyDown(Keys.Enter) && prevKeyState.IsKeyDown(Keys.Enter))
                {
                    screen = Screen.intro2;
                    
                }
            }

            if (screen == Screen.intro2)
            {
                seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (seconds > 5f)
                {
                    seconds = 0f;
                    screen = Screen.animation;
                    introMusicInstance.Play();
                }
                

            }

            if (screen == Screen.animation)
            {

                if (keyState.IsKeyDown(Keys.Enter) && prevKeyState.IsKeyDown(Keys.Enter))
                {

                }

            }
                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);
            _spriteBatch.Begin();

            if (screen == Screen.intro) 
            {
                _spriteBatch.Draw(introTexture, introsRect, Color.White);
                _spriteBatch.DrawString(introText, ("Click Enter to continue"), new Vector2 (10, 100), Color.White);
            }

            if (screen == Screen.intro2)
            {
                _spriteBatch.Draw(intro2Texture, introsRect, Color.White);
            }
            
            if (screen == Screen.animation)
            {
                _spriteBatch.Draw(pacManTexture, pacManRect, Color.White);
                _spriteBatch.Draw(msPacManTexture, msPacManRect, Color.White);
            }
            

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}