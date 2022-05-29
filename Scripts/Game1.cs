using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using TiledSharp;
namespace platformer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        RenderTarget2D objectRender;
        RenderTarget2D tileRender;
        Vector2 scaleMult;
        Player player;
        SpriteSheet traffic;
        
        SpriteFont font;
        ParticleSystem particleSystem;
        SpriteSheet cup;

        Song song;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            SetGraphics();
            SetVarInInitialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            holder.spriteBatch = spriteBatch;
            LevelManager.game = this;
            LevelManager.LoadContent(Content);
            LoadingGraphics();
            SetVarInLoadContent();
            LevelManager.LoadMap(0, player);
            
            // TODO: use this.Content to load your game content here
        }
        public void SetGraphics()
        {
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            
            scaleMult = new Vector2(graphics.PreferredBackBufferWidth / 320, graphics.PreferredBackBufferHeight / 180);
            holder.scaleMultiplier = scaleMult;
            graphics.SynchronizeWithVerticalRetrace = false; //Vsync
            IsFixedTimeStep = true;
            TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / 60);
            graphics.ApplyChanges();
        }
        public void SetVarInInitialize()
        {
            objectRender = new RenderTarget2D(GraphicsDevice, 320, 180);
            tileRender = new RenderTarget2D(GraphicsDevice, 320, 180);
            song = Content.Load<Song>("sng");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
        }
        public void LoadingGraphics()
        {
           
            font = Content.Load<SpriteFont>("pixelart");

        }
        public void SetVarInLoadContent()
        {
            List<Rectangle> collision = new List<Rectangle>();
            foreach(var o in LevelManager.Level_0map.ObjectGroups["collision"].Objects)
            {
                collision.Add(new Rectangle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height));
            }


            List<Rectangle> kill = new List<Rectangle>();
            foreach (var o in LevelManager.Level_0map.ObjectGroups["kill"].Objects)
            {
                kill.Add(new Rectangle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height));
            }


            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(Content.Load<Texture2D>("onePixel"));
            particleSystem = new ParticleSystem(textures, new Vector2(150, 90), new Color(255, 255, 255), new Vector2(0.3f, 1.5f));


            player = new Player(new Object(true,new SpriteSheet(
                Vector2.Zero,
                Content.Load<Texture2D>("bird-Sheet"),
                new Dictionary<string, (int, int, float)> { {"null",(0, 0, 0) },{ "default", (1, 3, 100f) },{"walk", (4, 9, 25f) },{"fly", (10,13,15f) },{"drink",(14, 23, 100f) } }, //in ms
                32 , 32, 0, 12,18 ,12 , 8), 1, Vector2.Zero, 0f, Color.White, true, collision, kill), particleSystem, Content.Load<Microsoft.Xna.Framework.Audio.SoundEffect>("jumpExplode"), Content.Load<Microsoft.Xna.Framework.Audio.SoundEffect>("hurt"));
            player.entry = new Vector2((float)LevelManager.Level_0map.ObjectGroups["Entry"].Objects[0].X, (float)LevelManager.Level_0map.ObjectGroups["Entry"].Objects[0].Y);
            player.vObject.pos = player.entry;




            traffic = new SpriteSheet(new Vector2(0, 80), Content.Load<Texture2D>("jumpCount"), new Dictionary<string, (int, int, float)> { { "null", (0, 0, 0) }, {"oneStop", (1, 1,250f) },{ "default", (1, 6, 250f) } }, 20, 88, 2);
            traffic.setCurrentAnim("oneStop");
            
            

            Vector2 cupPos = new Vector2((float)LevelManager.Level_0map.ObjectGroups["cup"].Objects[0].X, (float)LevelManager.Level_0map.ObjectGroups["cup"].Objects[0].Y);
            player.cup = cup = new SpriteSheet(cupPos,Content.Load<Texture2D>("cup"), new Dictionary<string, (int, int, float)> { { "null", (0, 0, 0) }, { "default", (1, 5, 100f) } }, 16, 16, 1);
            cup.setCurrentAnim("default");
            player.cuprec = new Rectangle((int)LevelManager.Level_0map.ObjectGroups["cup"].Objects[0].X, (int)LevelManager.Level_0map.ObjectGroups["cup"].Objects[0].Y, 16, 16);
            player.traffic = traffic;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(LevelManager.currentLevel == 0)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed) 
                {
                    Debug.WriteLine("jtdjcjf");
                        Debug.WriteLine(Mouse.GetState().Position.X);
                    if (Mouse.GetState().Position.X >= 78 * holder.scaleMultiplier.X && Mouse.GetState().Position.X <= 239 * holder.scaleMultiplier.X && Mouse.GetState().Position.Y>= 125 * holder.scaleMultiplier.Y && Mouse.GetState().Position.Y <= 180 * holder.scaleMultiplier.Y)
                    {
                        LevelManager.LoadMap(1, player);
                    }
                }
            }
            
            // TODO: Add your update logic here
            UpdateAllInOne(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (LevelManager.currentLevel > 0)
            {
                DrawAllObjects();


                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null);
                spriteBatch.Draw(objectRender, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scaleMult, SpriteEffects.None, 0.1f);
                spriteBatch.Draw(tileRender, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scaleMult, SpriteEffects.None, 0.2f);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null);
                LevelManager.menu.Draw(SpriteEffects.None, holder.scaleMultiplier.X);
               
                spriteBatch.End();
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        void UpdateAllInOne(GameTime gameTime)
        {
            player.Update(gameTime);
            particleSystem.Update(gameTime);
            
            SpriteSheetManager.Update(gameTime);
        }

        public void DrawTilemapOnRenderer(TileMapManager tileMapManager, Texture2D background)
        {

            GraphicsDevice.SetRenderTarget(tileRender);
            GraphicsDevice.Clear(Color.LightBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.End();
            tileMapManager.Draw();
           
            GraphicsDevice.SetRenderTarget(null);

        }
        void DrawAllObjects()
        {
            GraphicsDevice.SetRenderTarget(objectRender);
            GraphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
            player.vObject.Draw(holder.player);
            particleSystem.Draw(spriteBatch);
            cup.Draw();
            traffic.Draw();
            spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);

        }
        public void setTraffic(string name)
        {
            traffic.setCurrentAnim(name);
        }
    }
}
