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
        private RenderTarget2D _renderTarget;
        // Using the abstract Scene class for polymorphism
        public Scene currentScene;
        public float scale  = 0.44444f;

        public Snake()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(Content);
            serviceCollection.AddSingleton<IAssetManager, AssetManager>();
            _serviceProvider = serviceCollection.BuildServiceProvider();

            // Initialize with StartMenu or any other scene


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _renderTarget = new RenderTarget2D(GraphicsDevice, 1920, 1080);
            currentScene = new Scenes.StartMenu(_spriteBatch, _serviceProvider.GetService<IAssetManager>(), GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            currentScene?.Update(gameTime);

            if(currentScene is StartMenu startMenu && startMenu.StartButtonClicked)
            {
                currentScene = new Scenes.Level(_spriteBatch, _serviceProvider.GetService<IAssetManager>(), GraphicsDevice);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            
            scale = 1F / (1080f / _graphics.GraphicsDevice.Viewport.Height);
            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(Color.Blue);

            currentScene?.Draw(gameTime);

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Blue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(_renderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
