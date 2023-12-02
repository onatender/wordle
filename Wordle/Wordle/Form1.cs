using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Media;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Wordle
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string word = string.Empty;

        string ch;

        void PlaceChars()
        {
            ch = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                ch += Convert.ToChar(h[i].Text);
            }
        }

        List<char> YellowChars = new List<char>();

        TextBox[] h = new TextBox[5];
        private void button1_Click(object sender, EventArgs e)
        {

        }

        void CheckGuess()
        {
            guessCount++;
            PlaceChars();

            foreach (TextBox t in h)
            {
                t.Text = t.Text.Trim().ToUpper();
            }
            string guess = string.Empty;
            foreach (TextBox t in h)
            {
                guess += t.Text;
            }
            foreach (TextBox t in h)
            {
                t.BackColor=Color.Gray;
            }
            CheckExistence();
            Check();

            YellowChars.Clear();

            if (word == ch) { MBShow(guessCount+" tahminde bildiniz!", "Wordle"); DisableOldOnes(); SetGreen(); label1.Focus(); isGameEnded=true; return; }
            else if (guessCount == 6) { MBShow("Kelime : "+word, "Wordle"); DisableOldOnes(); SetGreen(); label1.Focus(); isGameEnded=true; return; }

            DisableOldOnes();
            EnableNewOnes();
            PassChar();
        }


        bool isGameEnded = false;

        void SetGreen()
        {
            label1.ForeColor = Color.Lime;

        }

        void DisableOldOnes()
        {
            for (int i = (guessCount-1)*5; i < ((guessCount-1)*5)+5; i++)
            {
                h[i%5].ReadOnly = true;
            }
        }

        void EnableNewOnes()
        {
            for (int i = (guessCount-1)*5; i < ((guessCount-1)*5)+5; i++)
            {
                try
                {
                    h[i%5] = allTextBoxes[i+5];
                }
                catch
                {
                }

                h[i%5].Enabled = true;
                h[i%5].ReadOnly = false;
            }
        }

        int guessCount = 0;

        List<char> ToList(char[] list)
        {

            List<char> chars = new List<char>();
            foreach (char c in list)
            {
                chars.Add(c);
            }
            return chars;
        }

        int HowManyInTheList(List<char> chlist, char ch)
        {
            int t = 0;
            foreach (char c in chlist)
            {
                if (c == ch)
                {
                    t++;
                }
            }
            return t;
        }

        int Correct(string str1, string str2, char ch)
        {
            int count = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == str2[i] && str1[i] == ch) count++;
            }
            return count;
        }

        void CheckExistence()
        {
            for (int i = 0; i < 5; i++)
            {

                TextBox tb = h[i];
                char let = ch[i];

                if (!word.Contains(let.ToString())) { continue; }
                if (HowManyInTheList(YellowChars, let) >= HowManyInTheList(ToList(word.ToCharArray()), let) - Correct(word, ch, let)) { continue; }
                if (word[i] == let) { continue; }


                tb.BackColor = Color.Goldenrod;
                YellowChars.Add(let);
            }
        }

        void Check()
        {
            for (int i = 0; i < 5; i++)
            {
                if (word[i] == Convert.ToChar(h[i].Text))
                {
                    h[i].BackColor = Color.Green;
                }
            }
        }

        void MakeGray()
        {
            foreach (TextBox t in h)
            {
                t.ForeColor = Color.White;
            }
        }

        void wordle()
        {
            isGameEnded = false;
            guessCount = 0;
            pickRandomWord();
            h[0] = h1; h[1] = h2; h[2] = h3; h[3] = h4; h[4] = h5;
            foreach (TextBox t in allTextBoxes)
            {
                t.ReadOnly = true;
                t.Enabled = false;
                t.BackColor = Color.FromArgb(30, 30, 30);
                t.Text = string.Empty;
            }

            foreach (TextBox t in h)
            {
                t.Enabled = true;
                t.ReadOnly = false;
            }

            h[0].Focus();
        }

        void MBShow(string text, string program)
        {
            MessageBoxKST form1 = new MessageBoxKST(text, program);
            form1.StartPosition = FormStartPosition.CenterScreen;
            form1.ShowDialog();
        }

        TextBox[] allTextBoxes;
        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            FontSettings();
            Task.Run(() => ChangeColor());

            pickRandomWord();
            timer1.Start();

            timer2.Start();
            

            h[0] = h1; h[1] = h2; h[2] = h3; h[3] = h4; h[4] = h5;
            allTextBoxes = new TextBox[] { h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, h11, h12, h13, h14, h15, h16, h17, h18, h19, h20, h21, h22, h23, h24, h25, h26, h27, h28, h29, h30 };

        }



        private void ChangeColor()
        {
            int t = 40;
            while (true)
            {
                if (isGameEnded)
                {
                    label1.ForeColor=Color.Red;
                    System.Threading.Thread.Sleep(t);
                }
                if (isGameEnded)
                {
                    label1.ForeColor=Color.Orange;
                    System.Threading.Thread.Sleep(t);
                }
                if (isGameEnded)
                {
                    label1.ForeColor=Color.Yellow;
                    System.Threading.Thread.Sleep(t);
                }
                if (isGameEnded)
                {
                    label1.ForeColor=Color.Green;
                    System.Threading.Thread.Sleep(t);
                }
                if (isGameEnded)
                {
                    label1.ForeColor=Color.Blue;
                    System.Threading.Thread.Sleep(t);
                }
                if (isGameEnded)
                {
                    label1.ForeColor=Color.Purple;
                    System.Threading.Thread.Sleep(t);
                }
                else if (!isGameEnded && !(label1.ForeColor == Color.White || label1.ForeColor==Color.Lime))
                {
                    label1.ForeColor=Color.White;
                }
            }
        }

        private void pickRandomWord()
        {
            word = string.Empty;
            List<string> words = new List<string>();
            string db = File.ReadAllText("Wordle.db");
            foreach (string line in db.Split('\r'))
            {
                if (line.Trim().Length == 5)
                    words.Add(line.Trim().ToUpper());
            }


            int T = 0;
            foreach (string line in words)
            {
                if (line.Length==5) T++;
            }


            if (T>0) T = 1;
            if (!Convert.ToBoolean(T))
            {
                MBShow("Kelime bulunamadığı için uygulama başlatılamıyor.", "Wordle");
                this.Close();
                Application.Exit();
                return;
            }
            

            while (word.Length != 5)
            {
                int rnd = Random.Next(words.Count);
                word = words[rnd].ToUpper();
            }
        }

        static Random Random = new Random();

        void Format()
        {
            foreach (TextBox t in h)
            {
                t.Text = t.Text.Trim().ToUpper();
                string alphanumeric = "abcdefghijklmnopqrstuvwxyzçıöşü";
                alphanumeric += alphanumeric.ToUpper();
                if (!alphanumeric.Contains(t.Text))
                {
                    t.Text = string.Empty;
                }
                continue;
            }
            MakeGray();

            
        }

        int GetActiveTextBoxIndex()
        {
            for (int i = 0; i < 30; i++)
            {
                if (string.IsNullOrEmpty(allTextBoxes[i].Text))
                {
                    if (allTextBoxes[i].Enabled)
                        return i;
                    else return i-1;
                }
            }
            return allTextBoxes.Length-1;
        }

        private void h1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (TextBox t in h)
                {
                    if (string.IsNullOrEmpty(t.Text)) return;
                }

                CheckGuess();
            }

            if (e.KeyCode == Keys.Back)
            {
                if (string.IsNullOrEmpty(allTextBoxes[GetActiveTextBoxIndex()].Text))
                {
                    if (GetActiveTextBoxIndex()-1 >= 0 && !allTextBoxes[GetActiveTextBoxIndex()-1].ReadOnly) allTextBoxes[GetActiveTextBoxIndex()-1].Text = string.Empty;
                    if (GetActiveTextBoxIndex()-1 >= 0 && !allTextBoxes[GetActiveTextBoxIndex()-1].ReadOnly) allTextBoxes[GetActiveTextBoxIndex()-1].Focus();
                }

            }
        }



        private void h30_TextChanged(object sender, EventArgs e)
        {
            Format();
            PassChar();
        }

        void PassChar()
        {
            if (GetActiveTextBoxIndex() == -1)
            {
                return;
            }
            allTextBoxes[GetActiveTextBoxIndex()].Focus();
        }

        private void h30_Enter(object sender, EventArgs e)
        {
            try
            {
                allTextBoxes[GetActiveTextBoxIndex()].Focus();
                allTextBoxes[GetActiveTextBoxIndex()].ScrollToCaret();
            }
            catch { }

        }
        
        void FontSettings()
        {
            PrivateFontCollection font = new PrivateFontCollection();
            font.AddFontFile("g.ttf");

            PrivateFontCollection font2 = new PrivateFontCollection();
            font2.AddFontFile("gb.ttf");

            foreach (Control item in this.Controls)
            {
                item.Font = new Font(font.Families[0], 24, FontStyle.Regular);
            }
            foreach (Control item in panel2.Controls)
            {
                item.Font = new Font(font.Families[0], 24, FontStyle.Regular);
            }
            label1.Font = new Font(font.Families[0], 24, FontStyle.Bold);
            label2.Font = new Font(font.Families[0], 8, FontStyle.Regular);
            button1.Font = new Font(font.Families[0], 8, FontStyle.Regular);
            button2.Font = new Font(font.Families[0], 8, FontStyle.Regular);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isGameEnded)
            {
                int i = GetActiveTextBoxIndex();
                allTextBoxes[i].SelectionStart = allTextBoxes[i].Text.Length;
                allTextBoxes[i].ScrollToCaret();
            }
           
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close(); 
        }



        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormLocation;

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
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

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = Cursor.Position.X - lastCursorPos.X;
                int deltaY = Cursor.Position.Y - lastCursorPos.Y;

                this.Location = new Point(lastFormLocation.X + deltaX, lastFormLocation.Y + deltaY);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            allTextBoxes[GetActiveTextBoxIndex()].Focus();
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {

        }

        private void label1_Enter(object sender, EventArgs e)
        {


        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            if (isGameEnded) return;
            if (isGameEnded && label1.ForeColor == Color.Lime) { label1.ForeColor = Color.Lime; return; }
            label1.ForeColor = Color.White;
        }





        private void label1_MouseEnter(object sender, EventArgs e)
        {
            if (isGameEnded) return;
            label1.ForeColor = Color.Lime;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (guessCount == 0) { return; }
            wordle();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            timer2.Start(); timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            allTextBoxes[GetActiveTextBoxIndex()].Focus();
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (!isGameEnded)
                allTextBoxes[GetActiveTextBoxIndex()].Focus();
            else label1.Focus();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            timer2.Stop(); timer1.Stop();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            timer2.Stop(); timer1.Stop();
        }
    }
}
