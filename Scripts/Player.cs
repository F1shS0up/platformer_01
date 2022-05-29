using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
namespace platformer
{
    class Player
    {
        public SpriteSheet traffic;
        public Object vObject;
        private float speed = 100;
        public bool doWhencupend = false;
        public SoundEffect jump;
        public SoundEffect hurt;

        public float delay = 1000f;

        public Vector2 entry;
        public ParticleSystem particle;
        public Rectangle cuprec;
        bool disableOtherAnim = false;
        public SpriteSheet cup;
        public bool stopWhenNewLevel = true;
        public Player(Object pObject, ParticleSystem pParticle, SoundEffect pJump, SoundEffect pHurt)
        {
            vObject = pObject;
            jump = pJump;
            hurt = pHurt;
            particle = pParticle;
            vObject.spriteSheet.setCurrentAnim("default");
        }

        public void Update(GameTime gameTime)
        {
           
            Vector2 initial = vObject.pos;
            vObject.Update(gameTime);
            keyboard.GetState();
            if (keyboard.HasBeenPressed(Keys.Space) )
            {
                if (!disableOtherAnim) 
                {
                    vObject.spriteSheet.setCurrentAnim("walk");
                }
            }
           
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && !disableOtherAnim)
            {
                holder.player = SpriteEffects.FlipHorizontally;

                vObject.velocity.X = Vector2.Lerp(vObject.velocity, Vector2.One * -speed, 0.1f).X;
                (bool collided, int index) = vObject.collision.CheckCollisionL();
                if(collided)
                {
                    vObject.velocity.X = 0;

                }
                else if(vObject.collision.L.X <= 0)
                {
                    vObject.velocity.X = 0;
                }
                else if (vObject.collision.L.X >= 320)
                {
                    vObject.velocity.X = 0;
                }
                if (stopWhenNewLevel)
                {
                    traffic.setCurrentAnim("default");
                }
                stopWhenNewLevel = false;
            }
            
            else if (!disableOtherAnim && !stopWhenNewLevel)
            {
                
                holder.player = SpriteEffects.None;

                vObject.velocity.X = Vector2.Lerp(vObject.velocity,Vector2.One * speed,0.1f).X;

                (bool collided, int index) = vObject.collision.CheckCollisionR();
                if (collided)
                {
                    
                    vObject.velocity.X = 0;

                }
            }
            
            if(vObject.pos.Y > 180 && delay == -10)
            {
                if (vObject.pos.X - 160 > -190 && vObject.pos.X - 160 <= -90)
                {
                    hurt.Play(1f, 0, -1f);
                }
                else if (vObject.pos.X - 160 > -90 && vObject.pos.X - 160 <= -20)
                {
                    hurt.Play(1f, 0, -0.5f);
                }
                else if (vObject.pos.X - 160 > -20 && vObject.pos.X - 160 < 20)
                {
                    hurt.Play(1f, 0, 0);
                }
                else if (vObject.pos.X - 160 >= 20 && vObject.pos.X - 160 < 90)
                {
                    hurt.Play(1f, 0, 0.5f);
                }
                else
                {
                    hurt.Play(1f, 0, 1f);

                }
                particle.EmitterLocation = new Vector2(vObject.pos.X + vObject.spriteSheet.oneBlockWidth / 2, vObject.pos.Y + vObject.spriteSheet.oneBlockHeight / 2);
                particle.color = new Color(122, 72, 65);
                particle.LoadMoreParticles(100);
                vObject.spriteSheet.setCurrentAnim("null");
                disableOtherAnim = true;
                delay = 1000;
            }
            else     if (vObject.collision.CheckCol(vObject.KillObjects) && delay == -10)
            {
                 
                if (vObject.pos.X - 160 > -190 && vObject.pos.X - 160 <= -90)
                {
                    hurt.Play(1f, 0, -1f);
                }
                else if (vObject.pos.X - 160 > -90 && vObject.pos.X - 160 <= -20)
                {
                    hurt.Play(1f, 0, -0.5f);
                }
                else if (vObject.pos.X - 160 > -20 && vObject.pos.X - 160 < 20)
                {
                    hurt.Play(1f, 0, 0);
                }
                else if (vObject.pos.X - 160 >= 20 && vObject.pos.X - 160 < 90)
                {
                    hurt.Play(1f, 0, 0.5f);
                }
                else
                {
                    hurt.Play(1f , 0, 1f);

                }
                particle.EmitterLocation = new Vector2(vObject.pos.X +vObject.spriteSheet.oneBlockWidth / 2, vObject.pos.Y + vObject.spriteSheet.oneBlockHeight / 2);
                particle.color = new Color(122, 72, 65);
                particle.LoadMoreParticles(100);
                vObject.spriteSheet.setCurrentAnim("null");
                disableOtherAnim = true;
                delay = 1000;
            }
            if(delay > 0)
            {
                delay -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
            else if(delay != -10)
            {
                disableOtherAnim=false;
                vObject.spriteSheet.setCurrentAnim("walk");
                vObject.pos = entry;
                delay = -10; 
            }
           

            if (traffic.currentSprite == 6 &&  !disableOtherAnim)
            {
                vObject.velocity.Y -= 300;
                if(vObject.pos.X - 160 > -190 && vObject.pos.X - 160 <= -90)
                {
                    jump.Play(0.7f, 0, -1f);
                }
                else if(vObject.pos.X - 160 > -90 && vObject.pos.X - 160 <= -20)
                {
                    jump.Play(0.7f, 0, -0.5f);
                }
                else if (vObject.pos.X - 160 > -20 && vObject.pos.X - 160 < 20)
                {
                    jump.Play(0.7f, 0, 0);
                }
                else if(vObject.pos.X - 160 >= 20 && vObject.pos.X - 160 < 90)
                {
                    jump.Play(0.7f, 0, 0.5f);
                }
                else
                {
                    jump.Play(0.7f, 0, 1f);

                }
               
                vObject.disableCollide = true;
                particle.color = new Color(122, 72, 65);
                particle.EmitterLocation = new Vector2(vObject.pos.X + vObject.spriteSheet.originX + vObject.spriteSheet.specialSizeX / 2, vObject.pos.Y + vObject.spriteSheet.originY + vObject.spriteSheet.specialSizeY);
                particle.LoadMoreParticles(100);
                traffic.currentSprite = 1;
              
            }
           
          
                
            
            if (vObject.collision.CheckCol(cuprec) && !disableOtherAnim)
            {
                disableOtherAnim = true;
                vObject.velocity.X = 0;
                vObject.spriteSheet.setCurrentAnim("drink", this);
                cup.setCurrentAnim("null");
            }
            if (doWhencupend)
            {
                if (LevelManager.currentLevel < 6)
                {
                    LevelManager.LoadNext(this);
                }
                else
                {
                    LevelManager.LoadMap(1, this);
                }
                doWhencupend = false;
                disableOtherAnim = false;
                vObject.spriteSheet.setCurrentAnim("walk");
                
            }
            
            if(vObject.pos.X < 20 && vObject.pos.Y > traffic.startPos.Y)
            {
                traffic.makeItHalfTransparent = true;
            }
            else
            {
                traffic.makeItHalfTransparent = false;
            }



          
        }
        
        public void Draw()
        {
            vObject.Draw();
        }
    }
}
