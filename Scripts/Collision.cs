using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace platformer
{
    class Collision
    {
        public Rectangle R, L, D, U;
        public Object obj;
        
        
        public Collision(Texture pTexture, Object pObj)
        {
            
            obj = pObj;
            R = new Rectangle((int)obj.pos.X + obj.sizeX - 1 + obj.originX, (int)obj.pos.Y + obj.originY +1, 1, obj.sizeY-2);
            L = new Rectangle((int)obj.pos.X + obj.originX, (int)obj.pos.Y + obj.originY+1, 1, obj.sizeY-2);
            U = new Rectangle((int)obj.pos.X + obj.originX, (int)obj.pos.Y + obj.originY, obj.sizeX, 1);
            D = new Rectangle((int)obj.pos.X + obj.originX, (int)obj.pos.Y + obj.sizeY - 1 + obj.originY, obj.sizeX, 1);
            
            
        }
        
        public void Update()
        {
            R.X = (int)obj.pos.X + obj.sizeX - 1 + obj.originX;
            R.Y = (int)obj.pos.Y + obj.originY;

            L.X = (int)obj.pos.X + obj.originX;
            L.Y = (int)obj.pos.Y + obj.originY;

            U.X = (int)obj.pos.X + obj.originX;
            U.Y = (int)obj.pos.Y + obj.originY;

            D.X = (int)obj.pos.X + obj.originX;
            D.Y = (int)obj.pos.Y + obj.sizeY - 1 + obj.originY;
        }
        public bool CheckCol(List<Rectangle> kill)
        {
            
            foreach(Rectangle r in kill)
            {
                if (r.Intersects(D))
                {
                    return true;
                }
                if (r.Intersects(U))
                {
                    return true;
                }
                if (r.Intersects(R))
                {
                    return true;
                }
                if (r.Intersects(L))
                {
                    return true;
                }
            }
                return false;
            
        }
        public bool CheckCol(Rectangle r)
        {

           
                if (r.Intersects(D))
                {
                    return true;
                }
                if (r.Intersects(U))
                {
                    return true;
                }
                if (r.Intersects(R))
                {
                    return true;
                }
                if (r.Intersects(L))
                {
                    return true;
                }
            
            return false;

        }
        public (bool, int) CheckCollisionD()
        {
            int i = 0;
            foreach (Rectangle a in obj.CollisionObjects)
            {

                if (D.Intersects(a))
                {
                    return (true, i);
                }
                i++;
            }
            return (false, 0);
        }
        public (bool, int) CheckCollisionD(Rectangle Dbeffore)
        {
            int i = 0;
            foreach (Rectangle a in obj.CollisionObjects)
            {

                if (D.Intersects(a) && Dbeffore.Bottom - 1 <= a.Top)
                {
                    return (true, i);
                }
                i++;
            }
            return (false, 0);
        }
        public (bool, int) CheckCollisionU()
        {
            int i = 0;
            foreach (Rectangle a in obj.CollisionObjects)
            {

                if (U.Intersects(a))
                {
                    return (true, i);
                }
                i++;
            }
            return (false, 0);
        }
        public (bool, int) CheckCollisionU(Rectangle Ubeffore)
        {
            int i = 0;
            foreach (Rectangle a in obj.CollisionObjects)
            {

                if (U.Intersects(a) && Ubeffore.Top + 1 >= a.Bottom)
                {
                    return (true, i);
                }
                i++;
            }
            return (false, 0);
        }
        public (bool, int) CheckCollisionR()
        {
            int i = 0;
            foreach (Rectangle a in obj.CollisionObjects)
            {

                if (R.Intersects(a))
                {
                    return (true, i);
                }
                i++;
            }
            return (false, 0);

        }
        public (bool, int) CheckCollisionR(Rectangle R)
        {
            int i = 0;
            foreach (Rectangle a in obj.CollisionObjects)
            {

                if (R.Intersects(a))
                {
                    return (true, i);
                }
                i++;
            }
            return (false, 0);

        }
        public (bool, int) CheckCollisionL()
        {
            int i = 0;
            foreach (Rectangle a in obj.CollisionObjects)
            {

                if (L.Intersects(a))
                {
                    return (true, i);
                }
                i++;
            }
            return (false, 0);
        }
        public (bool, int) CheckCollisionL(Rectangle L)
        {
            int i = 0;
            foreach (Rectangle a in obj.CollisionObjects)
            {

                if (L.Intersects(a))
                {
                    return (true, i);
                }
                i++;
            }
            return (false, 0);
        }
    }
}
