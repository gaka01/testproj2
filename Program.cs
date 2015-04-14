using System;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using System.Drawing;
using System.Drawing.Imaging;

using System.Threading;

using OpenTK;
using OpenTK.Graphics.OpenGL; 
using OpenTK.Graphics;
using OpenTK.Input; 


namespace MusicalInvaders
{
    class Screen : GameWindow
    {
        public List<Texture> textures = new List<Texture>();
        public GameLogic logic = new GameLogic(5);
        //public EventHandler handler = new EventHandler();
        public Thread logicThread;

        public Screen()
            : base(480, 700, GraphicsMode.Default, "OpenTK Quick Start Sample")
        {
            VSync = VSyncMode.On;
        }

        public void DrawTexture(int texid, int x, int y, int width, int height)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            this.logicThread = new Thread(new ThreadStart(logic.tick));
            this.logicThread.Start();
            logic.handler.setLogicRef(ref logic);
            foreach (Object obj in this.logic.objects)
            {
                this.textures.Add(obj.draw.texture);
            }

            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            foreach (Texture tex in textures)
            {
                LoadTexture(tex);
            }
        }

        private void LoadTexture(Texture texture)
        {
            int id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, id);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            BitmapData bmp_data = texture.bitmap.LockBits(new Rectangle(0, 0, texture.width, texture.height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp_data.Width, bmp_data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp_data.Scan0);

            texture.bitmap.UnlockBits(bmp_data);
            texture.setId(id);
        }



        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 0.4);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            var keyboard = OpenTK.Input.Keyboard.GetState();
            if (keyboard[Key.Escape])
            {
                this.logicThread.Abort();
                this.Exit();
            }
            //this.handler.setKeyboard(keyboard);
            //this.handler.tick();

            //this.logic.tick();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            Thread.Sleep(1);
            foreach (Object obj in this.logic.objects)
            {
                Drawable draw = obj.draw;
                int tid = draw.texture.id;
                GL.BindTexture(TextureTarget.Texture2D, tid);
                GL.Begin(PrimitiveType.Quads);

                GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(draw.glx2, draw.gly2);
                GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(draw.glx1, draw.gly2);
                GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(draw.glx1, draw.gly1);
                GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(draw.glx2, draw.gly1);
                GL.End();
            }
            SwapBuffers();
        }


        [STAThread]
        static void Main()
        {
            // The 'using' idiom guarantees proper resource cleanup.
            // We request 30 UpdateFrame events per second, and unlimited
            // RenderFrame events (as fast as the computer can handle).
            using (Screen game = new Screen())
            {
                game.Run(60.0);
            }
        }
    }
}