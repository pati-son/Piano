
namespace Piano
{
    partial class PianoForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttDo = new System.Windows.Forms.Button();
            this.buttRe = new System.Windows.Forms.Button();
            this.buttMi = new System.Windows.Forms.Button();
            this.buttFa = new System.Windows.Forms.Button();
            this.buttSol = new System.Windows.Forms.Button();
            this.buttLa = new System.Windows.Forms.Button();
            this.buttSi = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PaleGreen;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 94);
            this.button1.TabIndex = 0;
            this.button1.Text = "Начать запись";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PaleGreen;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(138, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 94);
            this.button2.TabIndex = 1;
            this.button2.Text = "Остановить";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            // 
            // buttDo
            // 
            this.buttDo.BackColor = System.Drawing.Color.LightGray;
            this.buttDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttDo.Location = new System.Drawing.Point(3, 3);
            this.buttDo.Name = "buttDo";
            this.buttDo.Size = new System.Drawing.Size(125, 269);
            this.buttDo.TabIndex = 0;
            this.buttDo.Text = "ДО";
            this.buttDo.UseVisualStyleBackColor = false;
            this.buttDo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttDo_MouseDown);
            this.buttDo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttDo_MouseUp);
            // 
            // buttRe
            // 
            this.buttRe.BackColor = System.Drawing.Color.LightGray;
            this.buttRe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttRe.Location = new System.Drawing.Point(134, 3);
            this.buttRe.Name = "buttRe";
            this.buttRe.Size = new System.Drawing.Size(125, 269);
            this.buttRe.TabIndex = 2;
            this.buttRe.Text = "РЕ";
            this.buttRe.UseVisualStyleBackColor = false;
            this.buttRe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttRe_MouseDown);
            this.buttRe.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttRe_MouseUp);
            // 
            // buttMi
            // 
            this.buttMi.BackColor = System.Drawing.Color.LightGray;
            this.buttMi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttMi.Location = new System.Drawing.Point(265, 3);
            this.buttMi.Name = "buttMi";
            this.buttMi.Size = new System.Drawing.Size(125, 269);
            this.buttMi.TabIndex = 3;
            this.buttMi.Text = "МИ";
            this.buttMi.UseVisualStyleBackColor = false;
            this.buttMi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttMi_MouseDown);
            this.buttMi.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttMi_MouseUp);
            // 
            // buttFa
            // 
            this.buttFa.BackColor = System.Drawing.Color.LightGray;
            this.buttFa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttFa.Location = new System.Drawing.Point(396, 3);
            this.buttFa.Name = "buttFa";
            this.buttFa.Size = new System.Drawing.Size(125, 269);
            this.buttFa.TabIndex = 4;
            this.buttFa.Text = "ФА";
            this.buttFa.UseVisualStyleBackColor = false;
            this.buttFa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttFa_MouseDown);
            this.buttFa.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttFa_MouseUp);
            // 
            // buttSol
            // 
            this.buttSol.BackColor = System.Drawing.Color.LightGray;
            this.buttSol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttSol.Location = new System.Drawing.Point(527, 3);
            this.buttSol.Name = "buttSol";
            this.buttSol.Size = new System.Drawing.Size(125, 269);
            this.buttSol.TabIndex = 5;
            this.buttSol.Text = "СОЛЬ";
            this.buttSol.UseVisualStyleBackColor = false;
            this.buttSol.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttSol_MouseDown);
            this.buttSol.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttSol_MouseUp);
            // 
            // buttLa
            // 
            this.buttLa.BackColor = System.Drawing.Color.LightGray;
            this.buttLa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttLa.Location = new System.Drawing.Point(658, 3);
            this.buttLa.Name = "buttLa";
            this.buttLa.Size = new System.Drawing.Size(125, 269);
            this.buttLa.TabIndex = 6;
            this.buttLa.Text = "ЛЯ";
            this.buttLa.UseVisualStyleBackColor = false;
            this.buttLa.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttLa_MouseDown);
            this.buttLa.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttLa_MouseUp);
            // 
            // buttSi
            // 
            this.buttSi.BackColor = System.Drawing.Color.LightGray;
            this.buttSi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttSi.Location = new System.Drawing.Point(789, 3);
            this.buttSi.Name = "buttSi";
            this.buttSi.Size = new System.Drawing.Size(130, 269);
            this.buttSi.TabIndex = 7;
            this.buttSi.Text = "СИ";
            this.buttSi.UseVisualStyleBackColor = false;
            this.buttSi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttSi_MouseDown);
            this.buttSi.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttSi_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(928, 561);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(922, 106);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(270, 100);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.Controls.Add(this.buttDo, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttSi, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttRe, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttLa, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttMi, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttSol, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttFa, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 283);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(922, 275);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // PianoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(928, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(822, 506);
            this.Name = "PianoForm";
            this.Text = "Piano";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PianoForm_KeyPress);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttDo;
        private System.Windows.Forms.Button buttRe;
        private System.Windows.Forms.Button buttMi;
        private System.Windows.Forms.Button buttFa;
        private System.Windows.Forms.Button buttSol;
        private System.Windows.Forms.Button buttLa;
        private System.Windows.Forms.Button buttSi;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}

