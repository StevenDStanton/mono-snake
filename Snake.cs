using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using snake.Interfaces;
using snake.Scenes;

namespace snake
{
    public class Snake : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private System.IServiceProvider _serviceProvider;

        // Using the abstract Scene class for polymorphism
        public Scene currentScene;

        public Snake()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(Content);
            serviceCollection.AddSingleton<IAssetManager, AssetManager>();
            _serviceProvider = serviceCollection.BuildServiceProvider();

            // Initialize with StartMenu or any other scene
            currentScene = new Scenes.StartMenu(this, _serviceProvider.GetService<IAssetManager>());

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Use polymorphism to update the current scene
            currentScene?.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Use polymorphism to draw the current scene
            currentScene?.Draw(gameTime);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
