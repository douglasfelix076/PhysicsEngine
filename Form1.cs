using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Numerics;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Physics
{
    public partial class Form1 : Form
    {
        private readonly Timer timer = new Timer();
        private static DateTime time1 = DateTime.Now;
        private static DateTime time2 = DateTime.Now;
        private static float DeltaTime; // tempo desde o ultimo quadro em segundos
        private const int fps = 120;

        private readonly PhysicsWorld world;
        private float ObjectSize = 1f;
        public static Form1 main;
        
        public Form1()
        {
            main = this;

            InitializeComponent();
            TextBoxSize.Text = ObjectSize.ToString();
            world = new PhysicsWorld(new Vector2(Canvas.Width / 2, Canvas.Height / 2), 9.81f * 10, Math.Min(Canvas.Width, Canvas.Height) / 2);

            // quadros por segundos
            timer.Interval = 1000 / fps;
            timer.Tick += UpdateTick;
            timer.Start();
        }

        // atualização do simulador
        private void UpdateTick(object sender, EventArgs e)
        {
            UpdateDeltaTime();
            world.Update(DeltaTime);
            world.position = new Vector2(Location.X, Location.Y);
            BodyCount.Text = "Nº Objetos: " + world.BodyCount;
            Canvas.Invalidate();
        }

        private void UpdateDeltaTime()
        {
            time1 = DateTime.Now;
            DeltaTime = (time1.Ticks - time2.Ticks) / 10000000f;
            time2 = time1;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            world.Draw(g);
        }

        /*
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!ValidateSize())
            {
                TextBoxSize.Clear();
            }
        }
         */

        private void ButtonClearAll_Click(object sender, EventArgs e)
        {
            world.Clear();
        }

        private void ButtonCreateCircle_Click(object sender, EventArgs e)
        {
            if (!ValidateSize())
            {
                return;
            }

            var random = new Random();
            world.AddBody(new CircleBody(ObjectSize * 10), new Vector2(random.Next(-150, 150), random.Next(-150, 150)));
        }

        private void ButtonCreateBox_Click(object sender, EventArgs e)
        {
            if (!ValidateSize())
            {
                return;
            }

            var random = new Random();
            world.AddBody(new BoxBody(ObjectSize * 20), new Vector2(random.Next(-150, 150), random.Next(-150, 150)));
        }

        // valida o tamanho colocado
        private bool ValidateSize()
        {
            if (float.TryParse(TextBoxSize.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out ObjectSize) && ObjectSize >= 0.1f && ObjectSize <= 20f)
            {
                return true;
            }

            MessageBox.Show("Tamanho invalido (0.1-20).");
            return false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            world.OnResize(Math.Min(Canvas.Width, Canvas.Height) / 2);
        }
    }
}
