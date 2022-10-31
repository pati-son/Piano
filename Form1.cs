using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Piano
{
    public partial class Piano : Form
    {
        public Piano()
        {
            InitializeComponent();
            KeyPreview = true;
            /*
              var threadParameters = new System.Threading.ThreadStart(delegate { KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.S) button2_Click(button2, null); }; });
              var thread1 = new System.Threading.Thread(threadParameters);
              thread1.Start();
              добавить одновременное нажатие на кнопки!!
             
             */
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.A) button1_Click(button1, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.S) button2_Click(button2, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.D) button3_Click(button3, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.F) button4_Click(button4, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.G) button5_Click(button5, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.H) button6_Click(button6, null); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.J) button7_Click(button7, null); }; 

        }
        public char[] melody = new char[100]; //массив, куда будет записана очередность кнопок
        int i = 0; //для обращения к элементам массива
        /*
         * добавить запись в файл
           добавить продолжительностьь нажатия на кнопку
         */
        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer nota = new SoundPlayer(@"C:\Users\User\Projects\(3 курс) C#_C++_Assembler\kursovaya\Piano\Resources\C.wav");
            nota.Play();
            melody[i] = 'C';
            i++;;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SoundPlayer nota = new SoundPlayer(@"C:\Users\User\Projects\(3 курс) C#_C++_Assembler\kursovaya\Piano\Resources\D.wav");
            nota.Play();
            melody[i] = 'D';
            i++;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SoundPlayer nota = new SoundPlayer(@"C:\Users\User\Projects\(3 курс) C#_C++_Assembler\kursovaya\Piano\Resources\E.wav");
            nota.Play();
            melody[i] = 'E'; 
            i++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SoundPlayer nota = new SoundPlayer(@"C:\Users\User\Projects\(3 курс) C#_C++_Assembler\kursovaya\Piano\Resources\F.wav");
            nota.Play();
            melody[i] = 'F';
            i++;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SoundPlayer nota = new SoundPlayer(@"C:\Users\User\Projects\(3 курс) C#_C++_Assembler\kursovaya\Piano\Resources\G.wav");
            nota.Play();
            melody[i] = 'G';
            i++;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SoundPlayer nota = new SoundPlayer(@"C:\Users\User\Projects\(3 курс) C#_C++_Assembler\kursovaya\Piano\Resources\A.wav");
            nota.Play();
            melody[i] = 'A';
            i++;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SoundPlayer nota = new SoundPlayer(@"C:\Users\User\Projects\(3 курс) C#_C++_Assembler\kursovaya\Piano\Resources\B.wav");
            nota.Play();
            melody[i] = 'B';
            i++;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
