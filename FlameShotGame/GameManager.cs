using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FlameShotGame
{
    // This might have to be static itself.
    public class GameManager
    {
        private static GameManager uniqueInstance = new GameManager();

        Globals global = Globals.instance();
        // This will hold all of the sub managers that are inheriting from GameManager.
        private static List<GameManager> Managers {get; set;}
        Controller controller = Controller.Instance();
        private readonly Player _player;

        public static GameManager Instance()
        {
            return uniqueInstance;
        }

        protected GameManager()
        {
            Managers = new List<GameManager>();
            _player = new(global.Content.Load<Texture2D>("../Content/Sprites/player.png"), new(600, 600));

            // Populate the Managers list with all of the submanagers.
            Managers.Add(controller);
        }

        // Gets called every tick, MUST get overridden by subclasses
        protected virtual void Update()
        {
            // Go through Managers list and call the update function in there.
            controller.Update();
            _player.Move();
            _player.Draw();
            return;
        }
    }
}
