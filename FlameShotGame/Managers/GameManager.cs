using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using FlameShotGame;
using FlameShotGame.GameObjects;
using System.Diagnostics;

namespace FlameShotGame.Managers
{
    // This might have to be static itself.
    public class GameManager
    {
        //private static GameManager uniqueInstance = new GameManager();

        Globals global = Globals.Instance();
        // This will hold all of the sub managers that are inheriting from GameManager.
        //private static List<GameManager> Managers { get; set; }
        Controller controller = Controller.Instance();
        SpawnManager spawnManager = SpawnManager.Instance();
        DrawManager drawManager = DrawManager.Instance();
        CollisionManager collisionManager = CollisionManager.Instance();

        private readonly Player _player;

        private static GameManager uniqueInstance = new GameManager();

        public static GameManager Instance()
        {
            return uniqueInstance;
        }

        protected GameManager()
        {
            // Set ALL sprites here.
            _player = new Player(global.Content.Load<Texture2D>("Sprites/player"), new Vector2(300, 250));
            // Populate the Managers list with all of the submanagers.
            //Managers.Add(drawManager);


            // Set player in global
            Globals.player = _player;
                
            // Spawn 

/*            spawnManager.SpawnPlayer();*/ 
            //spawnManager.SpawnEntity();


            // Make sure CollisionManager called after Spawn Manager

        }

        // Gets called every tick, MUST get overridden by subclasses
        public virtual void Update()
        {
            // Go through Managers list and call the update function in there.
            controller.Update();
            spawnManager.Update();
            _player.Move();
            collisionManager.Update();
            
            //TODO: Add SpawnManager.Update();
        }
        public void Draw()
        {
            drawManager.Update();
        }
    }
}
