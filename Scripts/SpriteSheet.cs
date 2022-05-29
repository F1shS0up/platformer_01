using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace platformer
{
    class SpriteSheet
    {
        public Object obj = null;
        public Dictionary<string,(int, int, float)> tag;
        public int oneBlockWidth;
        public int oneBlockHeight;
        public int specialSizeX, specialSizeY, originX, originY;
        public Texture2D texture;
        public int index;
        public string currrentAnim;
        public int currentSprite;
        float time;
        public Vector2 startPos;
        bool doWhenEnd = false;
        Player player = null;
        public bool makeItHalfTransparent = false;

        public SpriteSheet(Vector2 startpos,Texture2D pTexture, Dictionary<string, (int, int, float)>pTag, int pOneBlockWidth, int pOneBlockHeight, int pIndex, int pSpecialSizeX = 0, int pSpecialSizeY = 0, int pOriginX = 0, int pOriginY = 0)
        {
            startPos = startpos;
            time = 0;
            texture = pTexture;
            tag = pTag;
            index = pIndex;
            oneBlockWidth = pOneBlockWidth;
            oneBlockHeight = pOneBlockHeight;
            if (pSpecialSizeX == 0)
            {
                specialSizeX = oneBlockWidth;
            }
            else { specialSizeX = pSpecialSizeX; }

            if (pSpecialSizeY == 0)
            {
                specialSizeY = oneBlockHeight;
            }
            else { specialSizeY = pSpecialSizeY; }
            originX = pOriginX;
            originY = pOriginY;
            SpriteSheetManager.spriteSheets.Add(this);
        }
        public void setCurrentAnim(string anim, Player  player = null)
        {
            currrentAnim = anim;
            currentSprite = tag[currrentAnim].Item1;
            Debug.WriteLine(anim);
            time = 0;
            this.player = player;
            if(anim == "drink")
            {
                doWhenEnd = true;
            }
        }
      
        public void Update(GameTime gameTime)
        {
            if(time > tag[currrentAnim].Item3)
            {
                
                currentSprite++;
                if(currentSprite > tag[currrentAnim].Item2)
                {
                    if (doWhenEnd)
                    {
                        Do();
                        doWhenEnd=false;
                    }
                    
                    currentSprite = tag[currrentAnim].Item1;
                }
                time = 0;
            }
            else
            {
                time = time + (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                
            }
        }
        public void Do()
        {
            player.doWhencupend = true;
        }
        public void Draw(SpriteEffects spriteEffects = SpriteEffects.None, float scale = 1)
        {
            Rectangle x = new Rectangle(oneBlockWidth * (currentSprite - 1) , 0, oneBlockWidth, oneBlockHeight);
            if (obj != null)
            { //current sprite - 1 because if the sprite was the first the index is not 1 but 0
                holder.spriteBatch.Draw(texture, obj.pos, x, Color.White, 0f, Vector2.Zero, scale, spriteEffects, 0f);
            }
            else if (!makeItHalfTransparent)
            {
                holder.spriteBatch.Draw(texture, startPos, x, Color.White, 0f, Vector2.Zero, scale, spriteEffects, 0f);
            }
            else
            {
                holder.spriteBatch.Draw(texture, startPos, x, new Color(150, 150, 150, 80), 0f, Vector2.Zero, scale, spriteEffects, 0f);
            }
        }

        //plan: do something that will hold theese vars: texture,oneTextureWidth, oneTextureHeight and maybe already create rectangle with these parameters. OPTIONAL: List of type <int, int> that is spliting the sprite sheet, it will be in spritemanager function drawSplited
    }
}
