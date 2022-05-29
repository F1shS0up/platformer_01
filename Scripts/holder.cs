using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace platformer
{
    public static class holder
    {
        public static SpriteBatch spriteBatch;

        public static Vector2 scaleMultiplier;

        public static SpriteEffects player = SpriteEffects.None;

        public static double jumpsec;
    }
}
