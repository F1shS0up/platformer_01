using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace platformer
{
    class Texture
    {

        public Texture2D texture;

        private float layer;

        public int width, height;

        public int originX, originY;
        public Texture(Texture2D pTexture, float pLayer)
        {
            texture = pTexture;

            layer = pLayer;

            width = texture.Width;
            height = texture.Height;
            Debug.WriteLine(height);

            originX = 0;
            originY = 0;
        }
        public Texture(Texture2D pTexture, float pLayer, int pWidth, int pHeight)
        {
            texture = pTexture;

            layer = pLayer;

            width=pWidth;
            height=pHeight;

            originX = 0;
            originY = 0;
        }
        public Texture(Texture2D pTexture, float pLayer, int pWidth, int pHeight, int pOriginX, int pOriginY)
        {
            texture = pTexture;

            layer = pLayer;

            width = pWidth;
            height = pHeight;

            originX = pOriginX;
            originY = pOriginY;
        }

        public void Draw(Vector2 position, float rotation, Color color)
        {
            holder.spriteBatch.Draw(texture, position, null, color, rotation, Vector2.Zero, 1f, SpriteEffects.None, layer);
        }
    }
}
