using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using System.Drawing;

namespace MusicalInvaders
{
    class Texture
    {
        public Bitmap bitmap;
        public int width;
        public int height;
        public int id;

        public Texture(Bitmap image)
        {
            this.bitmap = image;
            this.width = image.Width;
            this.height = image.Height;
        }

        public Texture(string path)
        {
            this.bitmap = new Bitmap(path);
            this.genSize();
        }

        public void setId(int texid)
        {
            this.id = texid;
            this.bitmap.Dispose();
        }


        private void genSize()
        {
            this.width = this.bitmap.Width;
            this.height = this.bitmap.Height;
        }



    }
}
