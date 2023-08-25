using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using snake.Interfaces;
using snake.FileManagement;


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
        private Song startMenuMusic;
        private MouseState currentMouseState;
        private MouseState previousMouseState;
        public bool StartButtonClicked { get; private set; } = false;
        private ScoreManager scoreManager;
        private const string ScoreFilePath = "HighScore.csv"; //
        private SpriteFont scoreFont;

        public StartMenu(
            SpriteBatch _spriteBatch
            , IAssetManager _assetManager
            , GraphicsDevice _graphicsDevice
        )
            : base(_spriteBatch, _assetManager, _graphicsDevice)
        {

            LetterS = _assetManager.GetLetterTexture('S');
            LetterN = _assetManager.GetLetterTexture('N');
            LetterA = _assetManager.GetLetterTexture('A');
            LetterK = _assetManager.GetLetterTexture('K');
            LetterE = _assetManager.GetLetterTexture('E');
            StartButton = _assetManager.GetButton("start");
            startMenuMusic = _assetManager.GetSong("menu");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.5f; // 50% volume
            MediaPlayer.Play(startMenuMusic);
            scoreManager = new ScoreManager(ScoreFilePath);
            scoreFont = _assetManager.GetFont("Arial");

        }

        public override void Update(GameTime gameTime)
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            int screenWidth = _graphicsDevice.Viewport.Width;
            int startButtonX = (screenWidth - StartButton.Width) / 2;
            int buttonYPosition = 100 + LetterS.Height + 20;
            
            bool isMouseOverStartButton = currentMouseState.X >= startButtonX &&
                                  currentMouseState.X <= startButtonX + StartButton.Width &&
                                  currentMouseState.Y >= buttonYPosition &&
                                  currentMouseState.Y <= buttonYPosition + StartButton.Height;
            
            if (isMouseOverStartButton && 
                currentMouseState.LeftButton == ButtonState.Pressed && 
                previousMouseState.LeftButton == ButtonState.Released)
                {
                    StartButtonClicked = true;
                }

        }

        public override void Draw(GameTime gameTime)
        {
            int screenWidth = _graphicsDevice.Viewport.Width; 

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

            
            int scoreListStartingY = buttonYPosition + StartButton.Height + 30; // 30 pixels below the Start button
            var topScores = scoreManager.GetTopScores();
           _spriteBatch.DrawString(scoreFont, "High Scores", new Vector2(startingX, scoreListStartingY), Color.White);

            for (int i = 0; i < topScores.Count; i++)
            {
                var scoreEntry = topScores[i];
                string scoreText = $"{scoreEntry.Item1}: {scoreEntry.Item2}"; // Format: INITIALS: SCORE
                // Assuming you have a SpriteFont loaded to draw the text
                _spriteBatch.DrawString(scoreFont, scoreText, new Vector2(startingX, scoreListStartingY + i * 25), Color.White); // 25 pixels gap between scores
            }
            
            _spriteBatch.End();
        }

    }
}
