
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace platformer
{
    class Object
    {
        public Texture texture;
        public int sizeX, sizeY, originX, originY;
        public SpriteSheet spriteSheet;
        private float weight;
        public Vector2 pos;
        public Vector2 velocity;
        private float rotation;
        private Color color;
        private bool applyGravity;
        public List<Rectangle> CollisionObjects;
        public List<Rectangle> KillObjects;
        public Collision collision;
        public bool disableCollide = false;
        bool player = false;
        public Vector2? lastCollisionPos = null;
        public bool killing = false;
        public bool collided;
        public Object(Texture pTexture, float pWeight, Vector2 startPos, float pRotation, Color pColor, bool pApplyGravity, List<Rectangle> pCollisionObjects, List<Rectangle> killObjects)
        {
            texture = pTexture;
            sizeX = pTexture.width;
            sizeY = pTexture.height;
            originX = pTexture.originX;
            originY = pTexture.originY;
            weight = pWeight;
            pos = startPos;
            rotation = pRotation;
            color = pColor;
            applyGravity = pApplyGravity;
            CollisionObjects = pCollisionObjects;

            collision = new Collision(texture, this);

            spriteSheet = null;
            KillObjects = killObjects;

        }
        public Object(bool pplayer, SpriteSheet pSpriteSheet, float pWeight, Vector2 startPos, float pRotation, Color pColor, bool pApplyGravity, List<Rectangle> pCollisionObjects, List<Rectangle> killObjects)
        {
            spriteSheet = pSpriteSheet;
            spriteSheet.obj = this;
            sizeX = pSpriteSheet.specialSizeX;
            sizeY = pSpriteSheet.specialSizeY;
            originX= pSpriteSheet.originX;
            originY= pSpriteSheet.originY;
            weight = pWeight;
            pos = startPos;
            rotation = pRotation;
            color = pColor;
            applyGravity = pApplyGravity;
            CollisionObjects = pCollisionObjects;
            player = pplayer;
            collision = new Collision(texture, this);
            texture = null;
            spriteSheet.setCurrentAnim("default");
            KillObjects = killObjects;


        }
        public void Update(GameTime gameTime)
        {
            
            if (applyGravity)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space) && velocity.Y > 0)
                {
                    velocity.Y += 3f * weight;
                }
                else
                {
                    velocity.Y += 9.8f * weight;
                }
            }

            Rectangle D = collision.D;
            Rectangle U = collision.U;
            collision.Update();
          
            
            pos += velocity * ((float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000);
            int index;
            (collided,index) = collision.CheckCollisionD(D);
            if (collided && !disableCollide)
            {
                
                lastCollisionPos = pos;
                if (!killing)
                {
                    pos.Y = CollisionObjects[index].Top - sizeY + 1 - originY;
                    velocity.Y = 0;
                }
                else
                {
                    killing = false;
                }
            }
            else if (disableCollide)
            {
                disableCollide = false;
            }
           
           
            if (collision.CheckCollisionU(U).Item1)
            {
                velocity.Y = 0;
            }


            

        }
        public void Draw(SpriteEffects spriteEffects = SpriteEffects.None)
        {
            if (texture == null)
            {
                spriteSheet.Draw(spriteEffects);
            }
            else
            {
                texture.Draw(pos, 0f, Color.White);
            }

            Debug.WriteLine("Nope");
            
            
        }


    }
}
