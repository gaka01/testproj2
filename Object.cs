using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalInvaders
{
    class Object
    {
        public int type;// types:
                        // 0 -> player controlled object
                        // 1 -> projectiles (firndly?)
                        // 2(non-friendly projectiles?),3,... -> other
        public Drawable draw;
        public float x;
        public float y;
        public float width;
        public float height;
        public float speedx;
        public float speedy;
        public float speed;

        public Object(int type, Texture tex, float x, float y, float sizex, float sizey, float speed = 0f, float speedx = 0f, float speedy = 0f)
        {
            this.type = type;
            this.x = x;
            this.y = y;
            this.width = sizex;
            this.height = sizey;
            this.speedx = speedx;
            this.speedy = speedy;
            this.speed = speed / 1000f;
            this.draw = new Drawable(tex, x, y, sizex, sizey);
        }

        private void updateDrawable()
        {
            this.draw.setx(this.x);
            this.draw.sety(this.y);
            this.draw.setSizex(this.width);
            this.draw.setSizey(this.height);
        }

        public void move()
        {
            this.x+=this.speedx;
            this.y+=this.speedy;
            this.updateDrawable();
        }

        public void unmove()
        {
            this.x -= this.speedx;
            this.y -= this.speedy;
            this.updateDrawable();
        }

        public void setSpeed(float speedx, float speedy = 0f)
        {
            this.speedx = speedx;
            this.speedy = speedy;
        }

        //public void accelerate(float speedx, float speedy = 0f)
        //{
        //    this.speedx += speedx;
        //    this.speedy += speedy;
        //}

        public void setDefaultSpeed(float speed)
        {
            this.speed = speed / 1000f;
        }

    }
}
