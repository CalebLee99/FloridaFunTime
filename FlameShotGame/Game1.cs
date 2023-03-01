using FlameShotGame;
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
        private Player player;
        private Vector2 initialPlayerPosition;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Adding in Sprites of entities: Player, Midboss, Boss, and Enemy
        }

        protected override void Initialize()
        {
            // Initialize Player class and position on the screen.
            
            // This is where you can query any required services and load any non-graphic related content.

            base.Initialize();
        }

        protected override void LoadContent() // Called once per game
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
        }

        protected override void Update(GameTime gameTime) // Called multiple times per second
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) // Called multiple times per second
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}