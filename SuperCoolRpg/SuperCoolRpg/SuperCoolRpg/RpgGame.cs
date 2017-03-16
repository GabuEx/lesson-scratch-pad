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
using Microsoft.Xna.Framework.Content.Pipeline;
using System.IO;
using System.Xml;

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
        Vector2 lightWarriorsPosition = new Vector2(5, 6);

        Texture2D mapTexture;
        int mapTextureColumnCount;
        int mapTileWidth;
        int mapTileHeight;
        int mapWidth;
        int mapHeight;
        int[,] mapIndexes;

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
            mapTexture = this.Content.Load<Texture2D>("SpriteSheets/Corneria");

            string mapPath = @"..\..\..\..\SuperCoolRpgContent\MapFiles\";

            XmlTextReader xmlReader = new XmlTextReader(mapPath + "Corneria.tmx");

            xmlReader.ReadToFollowing("tileset");

            mapTileWidth = int.Parse(xmlReader.GetAttribute("tilewidth"));
            mapTileHeight = int.Parse(xmlReader.GetAttribute("tileheight"));
            mapTextureColumnCount = int.Parse(xmlReader.GetAttribute("columns"));

            xmlReader.ReadToFollowing("layer");

            mapWidth = int.Parse(xmlReader.GetAttribute("width"));
            mapHeight = int.Parse(xmlReader.GetAttribute("height"));

            mapIndexes = new int[mapWidth, mapHeight];

            xmlReader.ReadToFollowing("data");

            string data = xmlReader.ReadString();
            string[] dataLines = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int y = 0; y < Math.Min(dataLines.Length, mapHeight); y++)
            {
                string[] dataElements = dataLines[y].Split(',');

                for (int x = 0; x < Math.Min(dataElements.Length, mapWidth); x++)
                {
                    mapIndexes[x, y] = int.Parse(dataElements[x]) - 1;
                }
            }

            xmlReader.Close();
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
        double timeSinceLastCharacterMove = 0;
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            if (timeSinceLastCharacterMove > 75)
            {
                timeSinceLastCharacterMove = 0;
            else
                {
                    timeSinceLastCharacterMove = timeSinceLastCharacterMove + gameTime.ElapsedGameTime.TotalMilliseconds;
                }

                // TODO: Add your update logic here

                Vector2 newPosition = lightWarriorsPosition;

                if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Left))
                {
                    newPosition.X = Math.Max(newPosition.X - 1, 0);
                }
                else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Right))
                {
                    newPosition.X = Math.Min(newPosition.X + 1, Window.ClientBounds.Width - 16);
                }

                if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Up))
                {
                    newPosition.Y = Math.Max(newPosition.Y - 1, 0);
                }
                else if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Down))
                {
                    newPosition.Y = Math.Min(newPosition.Y + 1, Window.ClientBounds.Height - 16);
                }
                if (mapIndexes[(int)lightWarriorsPosition.X, (int)lightWarriorsPosition.Y] == 838 || mapIndexes[(int)lightWarriorsPosition.X, (int)lightWarriorsPosition.Y] == 889 || mapIndexes[(int)lightWarriorsPosition.X, (int)lightWarriorsPosition.Y] == 891 || mapIndexes[(int)lightWarriorsPosition.X, (int)lightWarriorsPosition.Y] == 892 || mapIndexes[(int)lightWarriorsPosition.X, (int)lightWarriorsPosition.Y] == 890 || mapIndexes[(int)lightWarriorsPosition.X, (int)lightWarriorsPosition.Y] == 894 || mapIndexes[(int)lightWarriorsPosition.X, (int)lightWarriorsPosition.Y] == 842 || mapIndexes[(int)lightWarriorsPosition.X, (int)lightWarriorsPosition.Y] == 887)
                {
                    lightWarriorsPosition = newPosition;
                }
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

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    int tileIndex = mapIndexes[x, y];
                    int tileXPosition = tileIndex % mapTextureColumnCount;
                    int tileYPosition = tileIndex / mapTextureColumnCount;

                    spriteBatch.Draw(mapTexture, new Vector2(x * mapTileWidth, y * mapTileHeight), new Rectangle(tileXPosition * mapTileWidth, tileYPosition * mapTileHeight, mapTileWidth, mapTileHeight), Color.White);
                }
            }

            spriteBatch.Draw(lightWarriorsTexture, new Vector2(lightWarriorsPosition.X * 16, lightWarriorsPosition.Y * 16), new Rectangle(78, 313, 16, 16), Color.White);
            spriteBatch.Draw(lightWarriorsTexture, new Vector2(50, 50), new Rectangle(1, 40, 16, 16), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
