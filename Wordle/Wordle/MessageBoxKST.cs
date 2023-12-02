using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Reflection.Emit;

namespace Wordle
{
    public partial class MessageBoxKST : Form
    {
        public MessageBoxKST(string mesaj,string program)
        {
            this.mesaj = mesaj;
            this.program = program;
            InitializeComponent();
        }
        string mesaj;
        string program;
        public static bool result = false;

        private void MessageBoxKST_Load(object sender, EventArgs e)
        {
            FontSettings();
            baslik.Text = program;
            yazi.Text = mesaj;
        }

        void FontSettings()
        {
            PrivateFontCollection font = new PrivateFontCollection();
            font.AddFontFile("g.ttf");

            PrivateFontCollection font2 = new PrivateFontCollection();
            font2.AddFontFile("gb.ttf");

            baslik.Font = new Font(font.Families[0], 8, FontStyle.Regular);
            yazi.Font = new Font(font.Families[0], 14, FontStyle.Regular);
            
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = Cursor.Position;
                lastFormLocation = this.Location;
            }
        }

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormLocation;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = Cursor.Position.X - lastCursorPos.X;
                int deltaY = Cursor.Position.Y - lastCursorPos.Y;

                this.Location = new Point(lastFormLocation.X + deltaX, lastFormLocation.Y + deltaY);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
