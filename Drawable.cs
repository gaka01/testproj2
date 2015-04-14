using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalInvaders
{
    class Drawable
    {
        public float x;
        public float y;
        public float sizex;
        public float sizey;
        public Texture texture;

        public float glx1;
        public float gly1;
        public float glx2;
        public float gly2;

        public Drawable(Texture tex, float texx, float texy, float texsizex, float texsizey)
        {
            this.init(tex, texx, texy, texsizex, texsizey);
        }

        public Drawable(string path, float texx, float texy, float texsizex, float texsizey)
        {
            Texture tex = new Texture(path);
            this.init(tex, texx, texy, texsizex, texsizey);
        }

        private void init(Texture tex, float texx, float texy, float texsizex, float texsizey)
        {
            this.texture = tex;
            this.x = texx;
            this.y = texy;
            this.sizex = texsizex;
            this.sizey = texsizey;

            this.updateGlCoords();
        }

        private void updateGlCoords()
        {
            this.glx1 = this.x - 1f - this.sizex / 2f;
            this.gly1 = this.y * (-1) + 1f - this.sizey / 2f;
            this.glx2 = this.glx1 + this.sizex;
            this.gly2 = this.gly1 + this.sizey;
        }

        public void setx(float newx)
        {
            this.x = newx;
            this.updateGlCoords();
        }

        public void sety(float newy)
        {
            this.y = newy;
            this.updateGlCoords();
        }

        public void setSizex(float newsize)
        {
            this.sizex = newsize;
            this.updateGlCoords();
        }

        public void setSizey(float newsize)
        {
            this.sizey = newsize;
            this.updateGlCoords();
        }


    }
}
