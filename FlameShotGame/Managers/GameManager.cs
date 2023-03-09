using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using FlameShotGame;
using FlameShotGame.GameObjects;

namespace FlameShotGame.Managers
{
    // This might have to be static itself.
    public class GameManager
    {
        private static GameManager uniqueInstance = new GameManager();

        Globals global = Globals.Instance();
        // This will hold all of the sub managers that are inheriting from GameManager.
        private static List<GameManager> Managers { get; set; }
        Controller controller = Controller.Instance();
        SpawnManager spawnManager = SpawnManager.Instance();
        DrawManager drawManager = DrawManager.Instance();
        private readonly Player _player;

        public static GameManager Instance()
        {
            return uniqueInstance;
        }

        protected GameManager()
        {
            Managers = new List<GameManager>();
            // Set ALL sprites here.
            _player = new (global.Content.Load<Texture2D>("Sprites/player"), new Vector2(0, 0));
            // Populate the Managers list with all of the submanagers.
            Managers.Add(controller);
            Managers.Add(spawnManager);
            //Managers.Add(drawManager);

            spawnManager.SpawnEntity(_player);
        }

        // Gets called every tick, MUST get overridden by subclasses
        public virtual void Update()
        {
            // Go through Managers list and call the update function in there.
            foreach (var manager in Managers)
            {
                manager.Update();
            }
        }
        public void Draw()
        {
            drawManager.Update();
        }
    }
}
