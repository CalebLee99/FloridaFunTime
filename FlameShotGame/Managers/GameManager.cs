using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FlameShotGame
{
    // This might have to be static itself.
    public class GameManager
    {
        Globals global = Globals.instance();
        // This will hold all of the sub managers that are inheriting from GameManager.
        private static List<GameManager> Managers {get; set;}
        Controller controller = Controller.instance();
        private readonly Player _player;

        public GameManager()
        {
            Managers = new List<GameManager>();
            _player = new(global.Content.Load<Texture2D>("../Content/Sprites/player.png"), new(600, 600));

            // Populate the Managers list with all of the submanagers.
            Managers.Add(controller);
        }

        // Gets called every tick.
        internal void Update()
        {
            // Go through Managers list and call the update function in there.
            Controller.Update();
            _player.Move();

            return;
        }
    }
}
