﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TiledSharp;

namespace platformer
{
    public class TileMapManager
    {
       
        public TmxMap map;
        public Texture2D tileset;
        int tilesetTilesWide;
        int tileWidth;
        int tileHeight;

        public TileMapManager( TmxMap _map, Texture2D _tileset, int _tilesetTilesWide, int _tileWidth, int _tileHeight)

        {
            
            map = _map;
            tileset = _tileset;
            tilesetTilesWide = _tilesetTilesWide;
            tileWidth = _tileWidth;
            tileHeight = _tileHeight;
        }

        public void Draw()
        {
            holder.spriteBatch.Begin(
                SpriteSortMode.Deferred,
                samplerState: SamplerState.PointClamp,
                effect: null,
                blendState: null,
                rasterizerState: null,
                depthStencilState: null);

            for (var i = 0; i < map.TileLayers.Count; i++)
            {
                for (var j = 0; j < map.TileLayers[i].Tiles.Count; j++)
                {
                    int gid = map.TileLayers[i].Tiles[j].Gid; //id
                    if (gid == 0)
                    {
                        //do nothing
                    }
                    else
                    {
                        int tileFrame = gid - 1;
                        int column = tileFrame % tilesetTilesWide;
                        int row = (int)Math.Floor((double)tileFrame / (double)tilesetTilesWide);
                        float x = (j % map.Width) * map.TileWidth;
                        float y = (float)Math.Floor(j / (double)map.Width) * map.TileHeight;
                        Rectangle tilesetRec = new Rectangle((tileWidth) * column, (tileHeight) * row, tileWidth, tileHeight);
                        holder.spriteBatch.Draw(tileset, new Rectangle((int)x, (int)y, tileWidth, tileHeight), tilesetRec, Color.White);
                    }
                }
            }
            holder.spriteBatch.End();
        }
    }
}