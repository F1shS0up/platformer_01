using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace platformer
{
    static class SpriteSheetManager
    {
        public static List<SpriteSheet> spriteSheets = new List<SpriteSheet>();
        public static void Update(GameTime gameTime)
        {
            foreach(var spriteSheet in spriteSheets)
            {
                spriteSheet.Update(gameTime);
            }
        }
       
        
    }
}
