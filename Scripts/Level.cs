using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace platformer
{
    class Level
    {
        private TileMapManager tileMapManager;
        public int index;
        public Texture2D background;
        public Level(TileMapManager pTileMapManager, int pIndex, Texture2D pBackground)
        {
            tileMapManager = pTileMapManager;
            index = pIndex;
            background = pBackground;
        }
        public void LoadLevel(Game1 game, Player player)
        {
            game.DrawTilemapOnRenderer(tileMapManager, background);
            List<Rectangle> collision = new List<Rectangle>();
            foreach (var o in tileMapManager.map.ObjectGroups["collision"].Objects)
            {
                collision.Add(new Rectangle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height));
            }


            List<Rectangle> kill = new List<Rectangle>();
            foreach (var o in tileMapManager.map.ObjectGroups["kill"].Objects)
            {
                kill.Add(new Rectangle((int)o.X, (int)o.Y, (int)o.Width, (int)o.Height));
            }

            player.vObject.CollisionObjects = collision;
            player.vObject.KillObjects = kill;
            player.entry = new Vector2((float)tileMapManager.map.ObjectGroups["Entry"].Objects[0].X, (float)tileMapManager.map.ObjectGroups["Entry"].Objects[0].Y);
            player.vObject.pos = player.entry;

            player.stopWhenNewLevel = true;
            player.vObject.spriteSheet.setCurrentAnim("default");

            game.setTraffic("oneStop");

            player.cup.setCurrentAnim("default");  
            player.cup.startPos = new Vector2((float)tileMapManager.map.ObjectGroups["cup"].Objects[0].X, (float)tileMapManager.map.ObjectGroups["cup"].Objects[0].Y);
            player.cuprec = new Rectangle((int)tileMapManager.map.ObjectGroups["cup"].Objects[0].X, (int)tileMapManager.map.ObjectGroups["cup"].Objects[0].Y, 16, 16);

        }
    }
}
