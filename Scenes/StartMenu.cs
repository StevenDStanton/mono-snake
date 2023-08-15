using System.Reflection.Metadata;
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
        private Texture2D StartButton;

        public StartMenu(SpriteBatch _spriteBatch, IAssetManager _assetManager, GraphicsDevice _graphicsDevice)
            : base(_spriteBatch, _assetManager, _graphicsDevice)
        {

            LetterS = _assetManager.GetLetterTexture('S');
            LetterN = _assetManager.GetLetterTexture('N');
            LetterA = _assetManager.GetLetterTexture('A');
            LetterK = _assetManager.GetLetterTexture('K');
            LetterE = _assetManager.GetLetterTexture('E');
            StartButton = _assetManager.GetButton("start");

        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Implement the update logic for StartMenu
        }

        public override void Draw(GameTime gameTime)
        {
            int screenWidth = _graphicsDevice.Viewport.Width; // Assuming you have access to GraphicsDevice

            // Assuming all letters are of the same width.
            int letterWidth = LetterS.Width; // Using LetterS as reference, assuming all letters have the same width.

            int totalLettersWidth = 5 * letterWidth;  // Total width of the word "SNAKE"
            int startingX = (screenWidth - totalLettersWidth) / 2;  // Centering the word

            int yPosition = 100; // Top of the screen with a small padding

            _spriteBatch.Begin();

            // Array of letters for more concise iteration
            Texture2D[] letters = { LetterS, LetterN, LetterA, LetterK, LetterE };
            for (int i = 0; i < letters.Length; i++)
            {
                _spriteBatch.Draw(letters[i], new Vector2(startingX + i * letterWidth, yPosition), Color.White);
            }

            // Position the button below the letters. Adjust yPosition as necessary.
            int buttonYPosition = yPosition + LetterS.Height + 20;  // 20 is spacing, adjust as necessary
            int startButtonX = (screenWidth - StartButton.Width) / 2;  // Centering the button
            _spriteBatch.Draw(StartButton, new Vector2(startButtonX, buttonYPosition), Color.White);

            _spriteBatch.End();
        }

    }
}
