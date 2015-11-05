using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Laboration1del1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Camera camera;

        Texture2D blackBlock;
        Texture2D whiteBlock;

        public Game1()
        {
            camera = new Camera();
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 632; // detta ändrar fönstrets storlek!
            graphics.PreferredBackBufferHeight = 632;  
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            //graphics.IsFullScreen = false;// vet inte vad denna gör riktigt
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            blackBlock = Content.Load<Texture2D>("blackBlock.png");
            whiteBlock = Content.Load<Texture2D>("whiteBlock.png");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //Vector2 blackBlockPosition = new Vector2(0, 0);
            //Vector2 whiteBlockPosition = new Vector2(0, 100);

            int x;
            int countB = 1;


            for (x = 0; x < 8; x++)
            {
                int y;

                for (y = 0; y < 8; y++)
                {

                    if (countB % 2 == 0)
                        spriteBatch.Draw(blackBlock, camera.returnPosition(x, y), Color.Black);

                    else
                        spriteBatch.Draw(whiteBlock, camera.returnPosition(x, y), Color.White);

                    countB++;
                }
                countB++;
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
