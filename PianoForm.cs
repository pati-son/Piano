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
        
        private WaveFileReader reader;
        private WaveOut waveOut;

        //начало записи
        long StartDuration = 0;
        //конец записи
        long EndDuration = 0;
        //итоговое значение
        long CurrendDuration = 0;
        //таймер
        private Stopwatch duration = new Stopwatch();

        bool isRecord = false;
        bool isNextDuration = false;

        //Класс для записи в файл
        WaveIn waveIn;
        WaveFileWriter writer;//Имя файла для записи
        string outputFilename = "Music/music.wav";
        public PianoForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Init();
        }

        public PianoForm(Form f)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Init();
            if (ClassNote.isEmpty == true)
            {
                Button buttPlay = new Button();
                buttPlay.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(buttPlay);
                buttPlay.Text = ("Играть мелодию!");
                buttPlay.Font = new Font("Sergio", 14);
                buttPlay.Size = new Size(500, 50);
                buttPlay.BackColor = Color.LightGoldenrodYellow;
                buttPlay.Click += new EventHandler(ClickPlay);
                //this.Controls.Add(buttPlay);
            }
        }

        public void Init()
        {
            //загружаем .wav файлы
            soundDo.LoadAsync();
            soundRe.LoadAsync();
            soundMi.LoadAsync();
            soundFa.LoadAsync();
            soundSol.LoadAsync();
            soundLa.LoadAsync();
            soundSi.LoadAsync();
        }

       
        //============функция записи музыки в файл по умолчанию===========
        
        //запись конкретной ноты
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
        
        //запись длительности
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


        //=====воспроизведением звука=====
        public async void play_Sound(char nota)
        {
            await Task.Run(() =>
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
            });
        }

        //=====функция обработки исключений=====
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
      

        //======получение данных из буфера=====
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

        //====обрабатываем данные при завершении записи====
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

        //останавливаем запись
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

        //кнопка начала записи
        private void button1_Click(object sender, EventArgs e)
        {
            
            //если таймер выключен - включаем
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
            {
                MessageBox.Show(ex.Message);
            }

        }

        //кнопка окончания записи
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
        bool isPlaying = false;
        //кнопка проигрывания мелодии
        private void ClickPlay(object sender, EventArgs e)
        {
            playMelody();
        }
        private async void playMelody()
        {
            await Task.Run(() =>
            {
                waveOut = new WaveOut();
                waveOut.PlaybackStopped += waveOut_PlaybackStopped;
                reader = new WaveFileReader(ClassNote.path);
                waveOut.Init(reader);

                if (isPlaying == false)
                {
                    isPlaying = true;
                    waveOut.Play();
                }
            });
        }
        
        //очищаем потоки при окончании проигрывания
        private void waveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            reader.Dispose();
            waveOut.Dispose();
            isPlaying = false;
        }

        //реагирование на нажатии кнопок клавиатуры
        private async void PianoForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            await Task.Run(() =>
            {
                if (e.KeyChar == 'a' || e.KeyChar == 'ф')
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
            });

        }

        //отжатие кнопки до
        private void buttDo_MouseUp(object sender, MouseEventArgs e)
        {
            buttDo.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("c");
            }
        }


        //нажатие на кнопку до
        private void buttDo_MouseDown(object sender, MouseEventArgs e)
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

        //отжатие кнопки ре
        private void buttRe_MouseUp(object sender, MouseEventArgs e)
        {
            buttRe.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("d");
            }
        }

        //нажатие на кнопку ре
        private void buttRe_MouseDown(object sender, MouseEventArgs e)
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

        //отжатие кнопки ми
        private void buttMi_MouseUp(object sender, MouseEventArgs e)
        {
            buttMi.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("e");
            }
        }

        //нажатие на кнопку ми
        private void buttMi_MouseDown(object sender, MouseEventArgs e)
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

        //отжатие кнопки фа
        private void buttFa_MouseUp(object sender, MouseEventArgs e)
        {
            buttFa.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("f");
            }
        }

        //ннажатие на кнопку фа
        private void buttFa_MouseDown(object sender, MouseEventArgs e)
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

        //отжатие кнопки соль
        private void buttSol_MouseUp(object sender, MouseEventArgs e)
        {
            buttSol.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("g");
            }
        }

        //нажатие на кнопк соль
        private void buttSol_MouseDown(object sender, MouseEventArgs e)
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

        //отжатие кнопки ля
        private void buttLa_MouseUp(object sender, MouseEventArgs e)
        {
            buttLa.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("a");
            }
        }

        //нажатие на кнопку ля
        private void buttLa_MouseDown(object sender, MouseEventArgs e)
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

        //отжатие кнопки си
        private void buttSi_MouseUp(object sender, MouseEventArgs e)
        {
            buttSi.BackColor = Color.LightGray;
            if (isRecord == true)
            {
                funcRecordMusic("b");
            }
        }

        //нажатие на кнопку си
        private void buttSi_MouseDown(object sender, MouseEventArgs e)
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
    }
}
