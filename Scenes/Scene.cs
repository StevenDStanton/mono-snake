using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace snake.Scenes
{
    public abstract class Scene
    {
        protected readonly SpriteBatch _spriteBatch;
        protected readonly Interfaces.IAssetManager _assetManager;
        protected readonly GraphicsDevice _graphicsDevice;

        public Scene(SpriteBatch spriteBatch, Interfaces.IAssetManager assetManager, GraphicsDevice graphicsDevice)
        {
            _spriteBatch = spriteBatch;
            _assetManager = assetManager;
            _graphicsDevice = spriteBatch.GraphicsDevice;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
