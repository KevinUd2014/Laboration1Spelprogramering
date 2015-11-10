﻿using Microsoft.Xna.Framework;
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
        //int size = Camera.SizeOfTiles
        Camera camera;

        //Texture2D blackBlock;
        //Texture2D whiteBlock;
        Texture2D chessPiece;
        int width = 64;
        int height = 64;

        public Game1()
        {
            camera = new Camera();
            graphics = new GraphicsDeviceManager(this);
            Window.AllowUserResizing = true;
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

            //blackBlock = Content.Load<Texture2D>("blackBlock.png");
            //whiteBlock = Content.Load<Texture2D>("whiteBlock.png");
            chessPiece = Content.Load<Texture2D>("11.png");

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
        protected override void Draw(GameTime gameTime)  // denna ritar ut allt i spelet!
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            int x;
            int countB = 1;
            int y = 0;

            Texture2D blackBlock = new Texture2D(graphics.GraphicsDevice, camera.getTileSize, camera.getTileSize);
            Texture2D whiteBlock = new Texture2D(graphics.GraphicsDevice, camera.getTileSize, camera.getTileSize);

            Color[] data = new Color[width * height];

            Vector2 coor = new Vector2(10, 10);
            
            for (x = 0; x < 8; x++)
            {
                for (y = 0; y < 8; y++)
                {

                    if (countB % 2 == 0)
                    {
                        //spriteBatch.Draw(blackBlock, camera.rotationOfField(x, y), Color.Black);//denna roterar spelet!
                        //spriteBatch.Draw(blackBlock, camera.returnPosition(x, y), Color.Black);
                        for (int i = 0; i < data.Length; i++)
                        {
                            data[i] = Color.Black;
                        }
                        blackBlock.SetData(data);

                        spriteBatch.Draw(blackBlock, camera.returnPosition(x, y), Color.Black);// denna genererar ut alla svarta block
                    }

                    else
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            data[i] = Color.White;
                        }
                        whiteBlock.SetData(data);
                        //spriteBatch.Draw(whiteBlock, camera.rotationOfField(x, y), Color.White);//denna roterar spelet!
                        //spriteBatch.Draw(whiteBlock, camera.returnPosition(x, y), Color.White);
                        spriteBatch.Draw(whiteBlock, camera.returnPosition(x, y), Color.White);// denna genererar ut alla vita block
                    }
                    countB++;
                }
                countB++;
            }
            Vector2 resize = new Vector2(0.15f, 0.15f);
            spriteBatch.Draw(chessPiece, camera.returnPosition(1, 2), null, Color.White, 0f, Vector2.Zero, resize, SpriteEffects.None, 0f);
            //spriteBatch.Draw(chessPiece, camera.rotationOfField(0, 0), Color.White);// genererar ut en chess del

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
