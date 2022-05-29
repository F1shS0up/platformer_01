using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using TiledSharp;
namespace platformer
{
    static class LevelManager
    {


        public static Player player;

        public static SpriteSheet menu;

        public static Game1 game;

        static Texture2D Level_0set;
        public static TileMapManager level_0mapManager;
        public static TmxMap Level_0map;
        public static Level level_0;

        static Texture2D Level_1set;
        public static TileMapManager level_1mapManager;
        public static TmxMap Level_1map;
        public static Level level_1;

        static Texture2D Level_2set;
        public static TileMapManager level_2mapManager;
        public static TmxMap Level_2map;
        public static Level level_2 ;

        static Texture2D Level_3set;
        public static TileMapManager level_3mapManager;
        public static TmxMap Level_3map;
        public static Level level_3;

        static Texture2D Level_4set;
        public static TileMapManager level_4mapManager;
        public static TmxMap Level_4map;
        public static Level level_4;

        static Texture2D Level_5set;
        public static TileMapManager level_5mapManager;
        public static TmxMap Level_5map;
        public static Level level_5;

        static Texture2D Level_6set;
        public static TileMapManager level_6mapManager;
        public static TmxMap Level_6map;
        public static Level level_6;


        private static Dictionary<int, Level> levelMap = new Dictionary<int, Level>();
        static public int currentLevel = 0;
        public static void LoadContent(ContentManager Content)
        {
            menu = new SpriteSheet(Vector2.Zero, Content.Load<Texture2D>("menu"), new Dictionary<string, (int, int, float)> { { "null", (0, 0, 0) }, { "default", (1, 49, 100f) } }, 320, 180, 3);
            menu.setCurrentAnim("default");
            Level_0set = Content.Load<Texture2D>("level_0set");
            Level_0map = new TmxMap("Content/mapTestUwU.tmx");
            level_0mapManager = new TileMapManager(Level_0map, Level_0set, Level_0set.Width / Level_0map.Tilesets[0].TileWidth, Level_0map.Tilesets[0].TileWidth, Level_0map.Tilesets[0].TileHeight);
            level_0 = new Level(level_0mapManager, 0, Content.Load<Texture2D>("background_0"));
            levelMap.Add(1, level_0);

            Level_1set = Content.Load<Texture2D>("level_0set");
            Level_1map = new TmxMap("Content/level_1map.tmx");
            level_1mapManager = new TileMapManager(Level_1map, Level_1set, Level_1set.Width / Level_1map.Tilesets[0].TileWidth, Level_1map.Tilesets[0].TileWidth, Level_1map.Tilesets[0].TileHeight);
            level_1 = new Level(level_1mapManager, 0, Content.Load<Texture2D>("background_0"));
            levelMap.Add(2, level_1);

            Level_2set = Content.Load<Texture2D>("level_0set");
            Level_2map = new TmxMap("Content/level_2map.tmx");
            level_2mapManager = new TileMapManager(Level_2map, Level_2set, Level_2set.Width / Level_2map.Tilesets[0].TileWidth, Level_2map.Tilesets[0].TileWidth, Level_2map.Tilesets[0].TileHeight);
            level_2 = new Level(level_2mapManager, 0, Content.Load<Texture2D>("background_0"));
            levelMap.Add(3, level_2);

            Level_3set = Content.Load<Texture2D>("level_0set");
            Level_3map = new TmxMap("Content/level_4map.tmx");
            level_3mapManager = new TileMapManager(Level_3map, Level_3set, Level_3set.Width / Level_3map.Tilesets[0].TileWidth, Level_3map.Tilesets[0].TileWidth, Level_3map.Tilesets[0].TileHeight);
            level_3 = new Level(level_3mapManager, 0, Content.Load<Texture2D>("background_0"));
            levelMap.Add(4, level_3);

            Level_4set = Content.Load<Texture2D>("level_1set");
            Level_4map = new TmxMap("Content/level_3map.tmx");
            level_4mapManager = new TileMapManager(Level_4map, Level_4set, Level_4set.Width / Level_4map.Tilesets[0].TileWidth, Level_4map.Tilesets[0].TileWidth, Level_4map.Tilesets[0].TileHeight);
            level_4 = new Level(level_4mapManager, 0, Content.Load<Texture2D>("background_0"));
            levelMap.Add(5, level_4);

            Level_5set = Content.Load<Texture2D>("level_1set");
            Level_5map = new TmxMap("Content/level_5map.tmx");
            level_5mapManager = new TileMapManager(Level_5map, Level_5set, Level_5set.Width / Level_5map.Tilesets[0].TileWidth, Level_5map.Tilesets[0].TileWidth, Level_5map.Tilesets[0].TileHeight);
            level_5 = new Level(level_5mapManager, 0, Content.Load<Texture2D>("background_0"));
            levelMap.Add(6, level_5);

            Level_6set = Content.Load<Texture2D>("level_1set");
            Level_6map = new TmxMap("Content/level_6map.tmx");
            level_6mapManager = new TileMapManager(Level_6map, Level_6set, Level_6set.Width / Level_6map.Tilesets[0].TileWidth, Level_6map.Tilesets[0].TileWidth, Level_6map.Tilesets[0].TileHeight);
            level_6 = new Level(level_6mapManager, 0, Content.Load<Texture2D>("background_0"));
            levelMap.Add(7, level_6);



        }
        public static void LoadMap(int index, Player player)
        {
            if(index > 0)
            {
                levelMap[index].LoadLevel(game, player);
                
            }
           currentLevel = index;
        }
        public static void LoadNext(Player player)
        {
            levelMap[currentLevel + 1].LoadLevel(game, player);
            currentLevel++;
        }

    }
}
