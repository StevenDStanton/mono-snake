using Microsoft.Xna.Framework;
using snake.Interfaces;

namespace snake.Scenes
{
    public class StartMenu : Scene
    {
        public StartMenu(Snake snakeGame, IAssetManager assetManager)
            : base(snakeGame, assetManager)  // Call the base constructor
        {
        }

        // You must implement these abstract methods from the base class
        public override void Update(GameTime gameTime)
        {
            // TODO: Implement the update logic for StartMenu
        }

        public override void Draw(GameTime gameTime)
        {
            // TODO: Implement the draw logic for StartMenu
        }
    }
}
