using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using snake.Interfaces;

namespace snake.Scenes
{
    public class Level : Scene
    {
        public Level(
            SpriteBatch _spriteBatch
            , IAssetManager _assetManager
            , GraphicsDevice _graphicsDevice
        )
            : base(_spriteBatch, _assetManager, _graphicsDevice)
        {

        }

        public override void Update(GameTime gameTime)
        {
            
        }


        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.End();
        }
        
    }
}