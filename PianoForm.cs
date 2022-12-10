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
using System.Buffers;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;
using NAudio;
using NAudio.Wave;
using NAudio.FileFormats;
using NAudio.CoreAudioApi;

namespace Piano
{
    public partial class PianoForm : Form
    {
        SoundPlayer soundDo = new SoundPlayer(@"Notes\C.wav");
        SoundPlayer soundRe = new SoundPlayer(@"Notes\D.wav");
        SoundPlayer soundMi = new SoundPlayer(@"Notes\E.wav");
        SoundPlayer soundFa = new SoundPlayer(@"Notes\F.wav");
        SoundPlayer soundSol = new SoundPlayer(@"Notes\G.wav");
        SoundPlayer soundLa = new SoundPlayer(@"Notes\A.wav");
        SoundPlayer soundSi = new SoundPlayer(@"Notes\B.wav");

        Button buttDo = new Button();
        Button buttRe = new Button();
        Button buttMi = new Button();
        Button buttFa = new Button();
        Button buttSol = new Button();
        Button buttLa = new Button();
        Button buttSi = new Button();

        private WaveFileReader reader;
        private WaveOut waveOut;

        long StartDuration = 0;//начало записи
        long EndDuration = 0;//конец записи
        long CurrendDuration = 0;//итоговое значение
        private Stopwatch duration = new Stopwatch();
        bool isRecord = false;
        bool isNextDuration = false;
        //======================================================
        WaveIn waveIn;//Класс для записи в файл
        WaveFileWriter writer;//Имя файла для записи
        string outputFilename = "Music/Music1.wav";
        public PianoForm()
        {
            InitializeComponent();
            
            /*
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.A) play_Sound(0); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.S) play_Sound(1); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.D) play_Sound(2); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.F) play_Sound(3); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.G) play_Sound(4); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.H) play_Sound(5); };
            KeyDown += (s, e) => { if (e.KeyValue == (char)Keys.J) play_Sound(6); };


            KeyUp += (s, e) => { if (e.KeyValue == (char)Keys.A) soundDo.Stop(); };
            KeyUp += (s, e) => { if (e.KeyValue == (char)Keys.S) soundRe.Stop(); };
            KeyUp += (s, e) => { if (e.KeyValue == (char)Keys.D) soundMi.Stop(); };
            KeyUp += (s, e) => { if (e.KeyValue == (char)Keys.F) soundFa.Stop(); };
            KeyUp += (s, e) => { if (e.KeyValue == (char)Keys.G) soundSol.Stop(); };
            KeyUp += (s, e) => { if (e.KeyValue == (char)Keys.H) soundLa.Stop(); };
            KeyUp += (s, e) => { if (e.KeyValue == (char)Keys.J) soundSi.Stop(); };
             
             */

            Init();
        }

        public PianoForm(Form f)
        {
            InitializeComponent();
            Init();
            if (ClassNote.isEmpty == true)
            {
                Button buttPlay = new Button();
                buttPlay.Text = ("Играть!");
                buttPlay.Size = new Size(500, 50);
                buttPlay.Location = new Point(270, 12);
                buttPlay.BackColor = Color.LightGoldenrodYellow;
                buttPlay.Click += new EventHandler(ClickPlay);
                this.Controls.Add(buttPlay);
            }
        }

        public void Init()
        {
            
            //====================КЛАВИШИ======================
            //ДО
          //  pianoButt[0] = new Button();
           // Button buttDo = new Button();
            buttDo.Size = new Size(93, 147);
            buttDo.Location = new Point(54, 173);
            buttDo.BackColor = Color.LightGray;
            buttDo.Text = ("до");
            buttDo.MouseUp += new MouseEventHandler(ButtonUpDo);
            buttDo.MouseDown += new MouseEventHandler(ButtonDownDo);
            this.Controls.Add(buttDo); //добавляем кнопку
           // pianoButt[0] = buttDo;

            //РЕ
          //  pianoButt[1] = new Button();
            //Button buttRe = new Button();
            buttRe.Size = new Size(93, 147);
            buttRe.Location = new Point(153, 173);
            buttRe.BackColor = Color.LightGray;
            buttRe.Text = ("ре"); 
            buttRe.MouseUp += new MouseEventHandler(ButtonUpRe);
            buttRe.MouseDown += new MouseEventHandler(ButtonDownRe);
            this.Controls.Add(buttRe); //добавляем кнопку
           // pianoButt[1] = buttRe;

            //МИ
           // pianoButt[2] = new Button();
           // Button buttMi = new Button();
            buttMi.Size = new Size(93, 147);
            buttMi.Location = new Point(252, 173);
            buttMi.BackColor = Color.LightGray;
            buttMi.Text = ("ми");
            buttMi.MouseUp += new MouseEventHandler(ButtonUpMi);
            buttMi.MouseDown += new MouseEventHandler(ButtonDownMi);
            this.Controls.Add(buttMi); //добавляем кнопку
           // pianoButt[2] = buttMi;

            //ФА
           // pianoButt[3] = new Button();
            //Button buttFa = new Button();
            buttFa.Size = new Size(93, 147);
            buttFa.Location = new Point(351, 173);
            buttFa.BackColor = Color.LightGray;
            buttFa.Text = ("фа");
            buttFa.MouseUp += new MouseEventHandler(ButtonUpFa);
            buttFa.MouseDown += new MouseEventHandler(ButtonDownFa);
            this.Controls.Add(buttFa); //добавляем кнопку
           // pianoButt[3] = buttFa;

            //СОЛЬ
           // pianoButt[4] = new Button();
            //Button buttSol = new Button();
            buttSol.Size = new Size(93, 147);
            buttSol.Location = new Point(450, 173);
            buttSol.BackColor = Color.LightGray;
            buttSol.Text = ("соль");
            buttSol.MouseUp += new MouseEventHandler(ButtonUpSol);
            buttSol.MouseDown += new MouseEventHandler(ButtonDownSol);
            this.Controls.Add(buttSol); //добавляем кнопку
            //pianoButt[4] = buttSol;

            //ЛЯ
           // pianoButt[1] = new Button();
            //Button buttLa = new Button();
            buttLa.Size = new Size(93, 147);
            buttLa.Location = new Point(549, 173);
            buttLa.BackColor = Color.LightGray;
            buttLa.Text = ("ля");
            buttLa.MouseUp += new MouseEventHandler(ButtonUpLa);
            buttLa.MouseDown += new MouseEventHandler(ButtonDownLa);
            this.Controls.Add(buttLa); //добавляем кнопку
           // pianoButt[5] = buttLa;

            //СИ
          //  pianoButt[1] = new Button();
            //Button buttSi = new Button();
            buttSi.Size = new Size(93, 147);
            buttSi.Location = new Point(648, 173);
            buttSi.BackColor = Color.LightGray;
            buttSi.Text = ("си");
            buttSi.MouseUp += new MouseEventHandler(ButtonUpSi);
            buttSi.MouseDown += new MouseEventHandler(ButtonDownSi);
            this.Controls.Add(buttSi); //добавляем кнопку
           // pianoButt[6] = buttSi;



            //==================Текст=============
            Label Do = new Label();
            Do.Size = new Size(25, 25);
            Do.Location = new Point(88, 323);
            Do.Text = ("A");
            this.Controls.Add(Do);

            Label Re = new Label();
            Re.Size = new Size(25, 25);
            Re.Location = new Point(187, 323);
            Re.Text = ("S");
            this.Controls.Add(Re);

            Label Mi = new Label();
            Mi.Size = new Size(25, 25);
            Mi.Location = new Point(286, 323);
            Mi.Text = ("D");
            this.Controls.Add(Mi);

            Label Fa = new Label();
            Fa.Size = new Size(25, 25);
            Fa.Location = new Point(385, 323);
            Fa.Text = ("F");
            this.Controls.Add(Fa);

            Label Sol = new Label();
            Sol.Size = new Size(25, 25);
            Sol.Location = new Point(484, 323);
            Sol.Text = ("G");
            this.Controls.Add(Sol);

            Label La = new Label();
            La.Size = new Size(25, 25);
            La.Location = new Point(583, 323);
            La.Text = ("H");
            this.Controls.Add(La);

            Label Si = new Label();
            Si.Size = new Size(25, 25);
            Si.Location = new Point(682, 323);
            Si.Text = ("S");
            this.Controls.Add(Si);
            //==========клавиатура==========
          
            //===========файл нот===========
            //дефолтный файл записи нот очищаем
            //File.WriteAllText(@"Music\music.txt", string.Empty);
            //загружаем .wav файлы
            soundDo.LoadAsync();
            soundRe.LoadAsync();
            soundMi.LoadAsync();
            soundFa.LoadAsync();
            soundSol.LoadAsync();
            soundLa.LoadAsync();
            soundSi.LoadAsync();
        }

        //================поднимаем кнопку мыши===================
        public void ButtonUpDo(object sender, MouseEventArgs e)
        {
            buttDo.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("c");
            }
        }
        public void ButtonUpRe(object sender, MouseEventArgs e)
        {
            buttRe.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("d");
            }
        }
        public void ButtonUpMi(object sender, MouseEventArgs e)
        {
            buttMi.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("e");
            }
        }
        public void ButtonUpFa(object sender, MouseEventArgs e)
        {
            buttFa.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("f");
            }
        }
        public void ButtonUpSol(object sender, MouseEventArgs e)
        {
            buttSol.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("g");
            }
        }
        public void ButtonUpLa(object sender, MouseEventArgs e)
        {
            buttLa.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("a");
            }
        }
        public void ButtonUpSi(object sender, MouseEventArgs e)
        {
            buttSi.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("b");
            }
        }
        //============функция записи музыки в файл по умолчанию===========
        
        public void funcRecordMusic(string str)
        {
            string path1 = @"Music\music.txt";
            FileStream file1 = new FileStream(path1, FileMode.OpenOrCreate);
            file1.Seek(0, SeekOrigin.End);
            StreamWriter stream1 = new StreamWriter(file1);
            stream1.Write(str + "-");
            stream1.Close();
            file1.Close();
        }
        public void funcRecordMusic(long d)
        {
            string path1 = @"Music\music.txt";
            FileStream file1 = new FileStream(path1, FileMode.OpenOrCreate);
            file1.Seek(0, SeekOrigin.End);
            StreamWriter stream1 = new StreamWriter(file1);
            stream1.WriteLine(Convert.ToString(CurrendDuration));
            stream1.Close();
            file1.Close();
        }
        //==============опускаем кнопку мыши=================
        public void ButtonDownDo(object sender, MouseEventArgs e)
        {
            
            buttDo.BackColor = Color.LightPink;
            play_Sound('c');
            if (isRecord == true)
            {
                if (isNextDuration == true)
                {
                    EndDuration = (long)duration.ElapsedMilliseconds;
                    duration.Stop();
                    CurrendDuration = EndDuration - StartDuration;
                    funcRecordMusic(CurrendDuration);
                }
                duration.Start();
                isNextDuration = true;
                StartDuration = (long)duration.ElapsedMilliseconds;
            }
        }
        public void ButtonDownRe(object sender, MouseEventArgs e)
        {
            buttRe.BackColor = Color.LightPink;
            play_Sound('d');
            if (isRecord == true)
            {
                if (isNextDuration == true)
                {
                    EndDuration = (long)duration.ElapsedMilliseconds;
                    duration.Stop();
                    CurrendDuration = EndDuration - StartDuration;
                    funcRecordMusic(CurrendDuration);
                }
                duration.Start();
                isNextDuration = true;
                StartDuration = (long)duration.ElapsedMilliseconds;
            }
        }
        public void ButtonDownMi(object sender, MouseEventArgs e)
        {
            buttMi.BackColor = Color.LightPink;
            play_Sound('e');
            if (isRecord == true)
            {
                if (isNextDuration == true)
                {
                    EndDuration = (long)duration.ElapsedMilliseconds;
                    duration.Stop();
                    CurrendDuration = EndDuration - StartDuration;
                    funcRecordMusic(CurrendDuration);
                }
                duration.Start();
                isNextDuration = true;
                StartDuration = (long)duration.ElapsedMilliseconds;
            }
        }
        public void ButtonDownFa(object sender, MouseEventArgs e)
        {
            buttFa.BackColor = Color.LightPink;
            play_Sound('f');
            if (isRecord == true)
            {
                if (isNextDuration == true)
                {
                    EndDuration = (long)duration.ElapsedMilliseconds;
                    duration.Stop();
                    CurrendDuration = EndDuration - StartDuration;
                    funcRecordMusic(CurrendDuration);
                }
                duration.Start();
                isNextDuration = true;
                StartDuration = (long)duration.ElapsedMilliseconds;
            }
        }
        public void ButtonDownSol(object sender, MouseEventArgs e)
        {
            buttSol.BackColor = Color.LightPink;
            play_Sound('g');
            if (isRecord == true)
            {
                if (isNextDuration == true)
                {
                    EndDuration = (long)duration.ElapsedMilliseconds;
                    duration.Stop();
                    CurrendDuration = EndDuration - StartDuration;
                    funcRecordMusic(CurrendDuration);
                }
                duration.Start();
                isNextDuration = true;
                StartDuration = (long)duration.ElapsedMilliseconds;
            }
        }
        public void ButtonDownLa(object sender, MouseEventArgs e)
        {
            buttLa.BackColor = Color.LightPink;
            play_Sound('a');
            if (isRecord == true)
            {
                if (isNextDuration == true)
                {
                    EndDuration = (long)duration.ElapsedMilliseconds;
                    duration.Stop();
                    CurrendDuration = EndDuration - StartDuration;
                    funcRecordMusic(CurrendDuration);
                }
                duration.Start();
                isNextDuration = true;
                StartDuration = (long)duration.ElapsedMilliseconds;
            }
        }
        public void ButtonDownSi(object sender, MouseEventArgs e)
        {
            buttSi.BackColor = Color.LightPink;
            play_Sound('b');
            if (isRecord == true)
            {
                if (isNextDuration == true)
                {
                    EndDuration = (long)duration.ElapsedMilliseconds;
                    duration.Stop();
                    CurrendDuration = EndDuration - StartDuration;
                    funcRecordMusic(CurrendDuration);
                }
                duration.Start();
                isNextDuration = true;
                StartDuration = (long)duration.ElapsedMilliseconds;
            }
        }
        /*
        public void ButtonUp(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            switch (pressedButton.Location.X)
            {
                case 54:
                    sound_Do();
                    break;

                case 153:
                    sound_Re();
                    break;

                case 252:
                    sound_Mi();
                    break;

                case 351:
                    sound_Fa();
                    break;

                case 450:
                    sound_Sol();
                    break;

                case 549:
                    sound_La();
                    break;

                case 648:
                    sound_Si();
                    break;


            }
        }

        //    public System.Windows.Media.MediaPlayer 
        //public char[] melody = new char[100]; //массив, куда будет записана очередность кнопок
        //int i = 0; //для обращения к элементам массива
        /*
            воспроизводить из файла
           добавить продолжительностьь нажатия на кнопку
         
        public void play_Sound(string notePath)
        {
            SoundPlayer sound = new SoundPlayer(notePath);
            sound.Play();
        }
        */

        //======воспроизведением звука=============
        public void play_Sound(char nota)
        {
            try
            {
                switch (nota)
                {
                    case 'c':
                        soundDo.Play();
                        break;
                    case 'd':
                        soundRe.Play();
                        break;
                    case 'e':
                        soundMi.Play();
                        break;
                    case 'f':
                        soundFa.Play();
                        break;
                    case 'g':
                        soundSol.Play();
                        break;
                    case 'a':
                        soundLa.Play();
                        break;
                    case 'b':
                        soundSi.Play();
                        break;
                }
            }
            catch (Exception ex)
            {
                funcException(ex);
            }
        }

        //=======функция обработки исключений========
        public void funcException(Exception ex)
        {
            string path = @"Errors\Exception.txt";
            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            file.Seek(0, SeekOrigin.End);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(ex.Message + "\n" + ex.StackTrace);
            file.Close();
            sw.Close();
        }
        /*
         public void sound_Do()
        {
            play_Sound(0);
        }

        public void sound_Re()
        {
            play_Sound(1);
        }

        public void sound_Mi()
        {
            play_Sound(2);
        }

        public void sound_Fa()
        {
            play_Sound(3);
        }

        public void sound_Sol()
        {
            play_Sound(4);
        }

        public void sound_La()
        {
            play_Sound(5);
        }

        public void sound_Si()
        {
            play_Sound(6);
            //play_Sound(@"Notes\B.wav");
        }
        /*
        private void Piano_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a') 
            {
                //soundDo.Play();
               play_Sound(0);
                //play_Sound(@"Notes\C.wav");
            }
            if (e.KeyChar == 's') 
            {
                play_Sound(1);
                //play_Sound(@"Notes\D.wav");
            }
            if (e.KeyChar == 'd') 
            {
                play_Sound(2);
                //play_Sound(@"Notes\E.wav");
            }
            if (e.KeyChar == 'f') 
            {
                play_Sound(3);
                //play_Sound(@"Notes\F.wav");
            }
            if (e.KeyChar == 'g') 
            {
                play_Sound(4);
                //play_Sound(@"Notes\G.wav");
            }
            if (e.KeyChar == 'h') 
            {
                play_Sound(5);
                //play_Sound(@"Notes\A.wav");
            }
            if (e.KeyChar == 'j')
            {
                play_Sound(6);
                //play_Sound(@"Notes\B.wav");
            }


        }
        */

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler<WaveInEventArgs>(waveIn_DataAvailable), sender, e);
            }
            else
            {
                //Записываем данные из буфера в файл
                writer.Write(e.Buffer, 0, e.BytesRecorded);
            }
        }

        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(waveIn_RecordingStopped), sender, e);
            }
            else
            {
                waveIn.Dispose();
                waveIn = null;
                writer.Close();
                writer = null;
            }
        }

        void StopRecording()
        {
            MessageBox.Show("Запись остановлена");
            try
            {
                waveIn.StopRecording();
                MessageBox.Show("Файл сохранен!");
            }
            catch(Exception ex)
            {
                funcException(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                
                isRecord = true;
            }
            try
            {
                File.WriteAllText(@"Music\music.txt", string.Empty);
                MessageBox.Show("Запись началась");
                waveIn = new WaveIn();
                waveIn.DeviceNumber = 0;
                //Прикрепляем к событию DataAvailable обработчик, возникающий при наличии записываемых данных
                waveIn.DataAvailable += waveIn_DataAvailable;
                //Прикрепляем обработчик завершения записи
                waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);
                //Формат wav-файла - принимает параметры - частоту дискретизации и количество каналов(здесь mono)
                waveIn.WaveFormat = new WaveFormat(8000, 1);
                //Инициализируем объект WaveFileWriter
                writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);
                //Начало записи
                waveIn.StartRecording();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled == true)
            {
                if (isNextDuration == true)
                {
                    EndDuration = (long)duration.ElapsedMilliseconds;
                    duration.Stop();
                    CurrendDuration = EndDuration - StartDuration;
                    funcRecordMusic(CurrendDuration);
                    isNextDuration = false;
                }
                timer1.Enabled = false;
                timer1.Dispose();
                isRecord = false;
                
            }
            if (waveIn != null)
            {
                StopRecording();
            }
        }

        private void ClickPlay(object sender, EventArgs e)
        {
            waveOut = new WaveOut();
            waveOut.PlaybackStopped += waveOut_PlaybackStopped;
            reader = new WaveFileReader(ClassNote.path);
            waveOut.Init(reader);
            waveOut.Play();
        }
        
        private void waveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            reader.Dispose();
            waveOut.Dispose();
        }

        private void PianoForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 'a' || e.KeyChar == 'ф')
            {
                play_Sound('c');
            }
            else if (e.KeyChar == 's' || e.KeyChar == 'ы')
            {
                play_Sound('d');
            }
            else if (e.KeyChar == 'd' || e.KeyChar == 'в')
            {
                play_Sound('e');
            }
            else if (e.KeyChar == 'f' || e.KeyChar == 'а')
            {
                play_Sound('f');
            }
            else if (e.KeyChar == 'g' || e.KeyChar == 'п')
            {
                play_Sound('g');
            }
            else if (e.KeyChar == 'h' || e.KeyChar == 'р')
            {
                play_Sound('a');
            }
            else if (e.KeyChar == 'j' || e.KeyChar == 'о')
            {
                play_Sound('b');
            }

        }
    }
}
