using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using OpenTK.Input;
using System.Threading;
using System.Drawing.Imaging;
using System.IO;

namespace _3D_cube
{
    class Program : GameWindow
    {
        const float rotation_speed = 150.0f;
        float angle;
        float[] var = new float[2] { -1.0f, 1.0f };
        int sens = 1;
        KeyboardState lastkey;
        bool control = true;
        MouseState a;
        private Point mousePos;
        public int[] textures = new int[6];
        public Program() : base(1200, 650, new OpenTK.Graphics.GraphicsMode(32, 23, 0, 8), "3D_cube")
        {
            VSync = VSyncMode.On;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
            LoadTextures();
        }
        public void LoadTextures()
        {
            GL.GenTextures(textures.Length, textures);
            LoadTexture(textures[0], @"Data\1.jpg");
            LoadTexture(textures[1], @"Data\2.jpg");
            LoadTexture(textures[2], @"Data\3.jpg");
            LoadTexture(textures[3], @"Data\4.jpg");
            LoadTexture(textures[4], @"Data\5.jpg");
            LoadTexture(textures[5], @"Data\6.jpg");
        }

        private void LoadTexture(int textureID, string fileName)
        {
            Bitmap btm = new Bitmap(fileName);
            BitmapData data = btm.LockBits(new Rectangle(0, 0, btm.Width, btm.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, btm.Width, btm.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            btm.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            double aspect_ratio = Width / (double)Height;

            OpenTK.Matrix4 perspective = OpenTK.Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            var keyboard = OpenTK.Input.Keyboard.GetState();
            var mouse = OpenTK.Input.Mouse.GetState();

            if (keyboard[OpenTK.Input.Key.Escape])
            {
                this.Exit();
                return;
            }

            lastkey = keyboard;
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);
            GL.Enable(EnableCap.ColorMaterial);
            Matrix4 lookat = Matrix4.LookAt(0, 5, 5, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);
            ControlCubMouse(e, sens, control);
            DrawCube(textures[0], textures[1], textures[2], textures[3], textures[4], textures[5]);

            this.SwapBuffers();
            Thread.Sleep(1);
        }

        protected void ControlCubMouse(FrameEventArgs e, int a, bool da)
        {
            if (da)
            {
                mousePos = new Point(Mouse.X, Mouse.Y);
                GL.Rotate(mousePos.X, 0, 1, 0);
                GL.Rotate(mousePos.Y, 1, 0, 0);
            }
        }
        public void da1(object sender, MouseEventArgs e)
        {
            mousePos = new Point(e.X, e.Y);
        }

        private void DrawCube(int textura, int textura2, int textura3, int textura4, int textura5, int textura6)
        {
            GL.BindTexture(TextureTarget.Texture2D, textura);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1);
            GL.Vertex3(-1.3f, -1.3f, -1.3f); GL.TexCoord2(1, 1);
            GL.Vertex3(-1.3f, 1.3f, -1.3f); GL.TexCoord2(1, 0);
            GL.Vertex3(1.3f, 1.3f, -1.3f); GL.TexCoord2(0, 0);
            GL.Vertex3(1.3f, -1.3f, -1.3f);
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, textura2);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1);
            GL.Vertex3(-1.3f, -1.3f, -1.3f); GL.TexCoord2(1, 1);
            GL.Vertex3(1.3f, -1.3f, -1.3f); GL.TexCoord2(1, 0);
            GL.Vertex3(1.3f, -1.3f, 1.3f); GL.TexCoord2(0, 0);
            GL.Vertex3(-1.3f, -1.3f, 1.3f); GL.End();

            GL.BindTexture(TextureTarget.Texture2D, textura3);
            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0, 1);
            GL.Vertex3(-1.3f, -1.3f, -1.3f); GL.TexCoord2(1, 1);
            GL.Vertex3(-1.3f, -1.3f, 1.3f); GL.TexCoord2(1, 0);
            GL.Vertex3(-1.3f, 1.3f, 1.3f); GL.TexCoord2(0, 0);
            GL.Vertex3(-1.3f, 1.3f, -1.3f);
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, textura4);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1);
            GL.Vertex3(-1.3f, -1.3f, 1.3f); GL.TexCoord2(1, 1);
            GL.Vertex3(1.3f, -1.3f, 1.3f); GL.TexCoord2(1, 0);
            GL.Vertex3(1.3f, 1.3f, 1.3f); GL.TexCoord2(0, 0);
            GL.Vertex3(-1.3f, 1.3f, 1.3f); GL.End();

            GL.BindTexture(TextureTarget.Texture2D, textura5);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1);
            GL.Vertex3(-1.3f, 1.3f, -1.3f); GL.TexCoord2(1, 1);
            GL.Vertex3(-1.3f, 1.3f, 1.3f); GL.TexCoord2(1, 0);
            GL.Vertex3(1.3f, 1.3f, 1.3f); GL.TexCoord2(0, 0);
            GL.Vertex3(1.3f, 1.3f, -1.3f); GL.End();

            GL.BindTexture(TextureTarget.Texture2D, textura6);
            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 1);
            GL.Vertex3(1.3f, -1.3f, -1.3f); GL.TexCoord2(1, 1);
            GL.Vertex3(1.3f, 1.3f, -1.3f); GL.TexCoord2(1, 0);
            GL.Vertex3(1.3f, 1.3f, 1.3f); GL.TexCoord2(0, 0);
            GL.Vertex3(1.3f, -1.3f, 1.3f); GL.End();

        }
        static void Main(string[] args)
        {
            using (Program p = new Program())
            {

                p.Run(30.0, 0.0);
            }
        }
    }
}