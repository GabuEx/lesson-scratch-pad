using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SuperCoolRpg
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class RpgGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D lightWarriorsTexture;
        Vector2 lightWarriorsPosition;

        public RpgGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            // TODO: use this.Content to load your game content here
            lightWarriorsTexture = this.Content.Load<Texture2D>("SpriteSheets/LightWarriors");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            // TODO: Add your update logic here
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Left))
            {
                lightWarriorsPosition.X = Math.Max(lightWarriorsPosition.X - 16, 0);
            }
            else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Right))
            {
                lightWarriorsPosition.X = Math.Min(lightWarriorsPosition.X + 16, Window.ClientBounds.Width - 16);
            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Up))
            {
                lightWarriorsPosition.Y = Math.Max(lightWarriorsPosition.Y - 16, 0);
            }
            else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Down))
            {
                lightWarriorsPosition.Y = Math.Min(lightWarriorsPosition.Y + 16, Window.ClientBounds.Height - 16);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(lightWarriorsTexture, lightWarriorsPosition, new Rectangle(78, 313, 16, 16), Color.White);
            spriteBatch.Draw(lightWarriorsTexture, new Vector2(50, 50), new Rectangle(1, 40, 16, 16), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
