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
            graphics.PreferredBackBufferWidth = 640; // detta ändrar fönstrets storlek!
            graphics.PreferredBackBufferHeight = 640;
            graphics.ApplyChanges();// lägger in de nya ändringarna
            Content.RootDirectory = "Content";//kollar i content
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
            camera.scaleWindow(graphics);// kör så att den kollar skalningen när den laddar!

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
            GraphicsDevice.Clear(Color.Crimson);

            spriteBatch.Begin();

            int x;
            int countB = 1;
            int y = 0;

            Texture2D blackBlock = new Texture2D(graphics.GraphicsDevice, camera.getTileSize, camera.getTileSize);//laddar in blocken
            Texture2D whiteBlock = new Texture2D(graphics.GraphicsDevice, camera.getTileSize, camera.getTileSize);

            Color[] data = new Color[width * height];

            //Vector2 coor = new Vector2(10, 10);
            
            for (x = 0; x < 8; x++)//för varje x
            {
                for (y = 0; y < 8; y++)// så ska vi ha en kub på y 
                {

                    if (countB % 2 == 0)//när countB delat på 1 blir 0 så kommer svarta rutor att skrivas ut!
                    {
                        
                        for (int i = 0; i < data.Length; i++)
                        {
                            data[i] = Color.Black;
                        }
                        blackBlock.SetData(data);

                        //spriteBatch.Draw(blackBlock, camera.rotationOfField(x, y), Color.Black);//denna roterar spelet!
                        //spriteBatch.Draw(blackBlock, camera.returnPosition(x, y), Color.Black);

                        spriteBatch.Draw(blackBlock, camera.returnPositionOfField(x, y), Color.Black);// denna genererar ut alla svarta block
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
                        spriteBatch.Draw(whiteBlock, camera.returnPositionOfField(x, y), Color.White);// denna genererar ut alla vita block
                    }
                    countB++;
                }
                countB++;// denna behövs för annars så blir det bara svarta och vita streck
            }
            float resize = camera.scaleOfField(chessPiece.Bounds.Height, chessPiece.Bounds.Width);
            /*Visuella koordinater - 0,0 = 64,64 || 6,0 = 384,64 || 2,7 = 128,512 || 7,7 = 512,512*/
            spriteBatch.Draw(chessPiece, camera.returnPositionOfField(1, 1), null, Color.White, 0f, Vector2.Zero, resize, SpriteEffects.None, 0f);

            /*Visuella koordinater - 0,0 = 512,512 || 6,0 = 128,512 || 2,7 = 384,64 || 7,7 = 64,64 */// denna flippar brädet!
            //spriteBatch.Draw(chessPiece, camera.rotationOfField(1, 2), null, Color.White, 0f, Vector2.Zero, resize, SpriteEffects.None, 0f);// genererar ut en chess del

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
