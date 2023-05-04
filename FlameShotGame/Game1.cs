using FlameShotGame;
using FlameShotGame.Managers;
using FlameShotGame.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// using Microsoft.Xna.Framework.Storage;

namespace FlameShotGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Globals globals = Globals.Instance();
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Adding in Sprites of entities: Player, Midboss, Boss, and Enemy
        }

        protected override void Initialize()
        {
            globals.Content = Content;
            globals.GraphicsDevice = this._graphics;

            /*            if (GraphicsDevice == null)
                        {
                            _graphics.ApplyChanges();
                        }
                        // Change the resolution to match your current desktop
                        _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
                        _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
                        _graphics.ApplyChanges();*/

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            GameManager gameManager = GameManager.Instance();
            base.Initialize();
        }

        protected override void LoadContent() // Called once per game
        { 
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            globals.SpriteBatch = this._spriteBatch;
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) // Called multiple times per second
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            GameManager gameManager = GameManager.Instance();
            // TODO: Add your update logic here
            gameManager.Update();
            Globals.Update(gameTime);
            base.Update(gameTime);
            if (Globals.player._currentHealth == 0)
            {
                Exit();
            }
        }

        protected override void Draw(GameTime gameTime) // Called multiple times per second
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GameManager gameManager = GameManager.Instance();
            // TODO: Add your drawing code here
            gameManager.Draw();
            
            base.Draw(gameTime);
        }

        public void Quit()
        {
            this.Exit();
        }
    }
}