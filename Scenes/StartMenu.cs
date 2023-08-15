using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using snake.Interfaces;

namespace snake.Scenes
{
    public class StartMenu : Scene
    {
        private Texture2D LetterS;
        private Texture2D LetterN;
        private Texture2D LetterA;
        private Texture2D LetterK;
        private Texture2D LetterE;

        public StartMenu(SpriteBatch _spriteBatch, IAssetManager _assetManager, GraphicsDevice _graphicsDevice)
            : base(_spriteBatch, _assetManager, _graphicsDevice)
        {

            LetterS = _assetManager.GetLetterTexture('S');
            LetterN = _assetManager.GetLetterTexture('N');
            LetterA = _assetManager.GetLetterTexture('A');
            LetterK = _assetManager.GetLetterTexture('K');
            LetterE = _assetManager.GetLetterTexture('E');

        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Implement the update logic for StartMenu
        }

        public override void Draw(GameTime gameTime)
        {
            int screenWidth = _graphicsDevice.Viewport.Width;  // Assuming you have access to GraphicsDevice
            int totalWidth = 5 * 50;  // Total width of the word "SNAKE"
            int startingX = (screenWidth - totalWidth) / 2;  // Centering the word
            int yPosition = 100;  // Top of the screen with a small padding

            _spriteBatch.Begin();

            _spriteBatch.Draw(LetterS, new Vector2(startingX, yPosition), Color.White);
            _spriteBatch.Draw(LetterN, new Vector2(startingX + 50, yPosition), Color.White);
            _spriteBatch.Draw(LetterA, new Vector2(startingX + 100, yPosition), Color.White);
            _spriteBatch.Draw(LetterK, new Vector2(startingX + 150, yPosition), Color.White);
            _spriteBatch.Draw(LetterE, new Vector2(startingX + 200, yPosition), Color.White);

            _spriteBatch.End();

        }
    }
}
