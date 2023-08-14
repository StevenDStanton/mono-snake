using Microsoft.Xna.Framework;

namespace snake.Scenes
{
    public abstract class Scene
    {
        protected readonly Snake _snakeGame;  // Fixed the typo here
        protected readonly Interfaces.IAssetManager _assetManager;  // Made this protected so derived classes can access

        public Scene(Snake snakeGame, Interfaces.IAssetManager assetManager)
        {
            _snakeGame = snakeGame;
            _assetManager = assetManager;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
