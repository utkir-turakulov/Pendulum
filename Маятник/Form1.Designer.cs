namespace Маятник
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SinusoidPanel = new System.Windows.Forms.Panel();
            this.PendulumPanel = new System.Windows.Forms.Panel();
            this.CirclePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.speed = new System.Windows.Forms.Label();
            this.angle = new System.Windows.Forms.Label();
            this.radius = new System.Windows.Forms.Label();
            this.baseX = new System.Windows.Forms.Label();
            this.baseY = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Lime;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(407, 664);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Старт";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(599, 664);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Стоп";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SinusoidPanel
            // 
            this.SinusoidPanel.BackColor = System.Drawing.Color.White;
            this.SinusoidPanel.Location = new System.Drawing.Point(861, 187);
            this.SinusoidPanel.Name = "SinusoidPanel";
            this.SinusoidPanel.Size = new System.Drawing.Size(377, 223);
            this.SinusoidPanel.TabIndex = 2;
            // 
            // PendulumPanel
            // 
            this.PendulumPanel.BackColor = System.Drawing.Color.White;
            this.PendulumPanel.Location = new System.Drawing.Point(341, 127);
            this.PendulumPanel.Name = "PendulumPanel";
            this.PendulumPanel.Size = new System.Drawing.Size(487, 380);
            this.PendulumPanel.TabIndex = 3;
            // 
            // CirclePanel
            // 
            this.CirclePanel.BackColor = System.Drawing.Color.White;
            this.CirclePanel.Location = new System.Drawing.Point(12, 187);
            this.CirclePanel.Name = "CirclePanel";
            this.CirclePanel.Size = new System.Drawing.Size(305, 282);
            this.CirclePanel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Скорость";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Угловое отклонение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Радиус";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "X0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Y0";
            // 
            // speed
            // 
            this.speed.AutoSize = true;
            this.speed.Location = new System.Drawing.Point(151, 9);
            this.speed.Name = "speed";
            this.speed.Size = new System.Drawing.Size(0, 13);
            this.speed.TabIndex = 10;
            // 
            // angle
            // 
            this.angle.AutoSize = true;
            this.angle.Location = new System.Drawing.Point(151, 38);
            this.angle.Name = "angle";
            this.angle.Size = new System.Drawing.Size(0, 13);
            this.angle.TabIndex = 11;
            // 
            // radius
            // 
            this.radius.AutoSize = true;
            this.radius.Location = new System.Drawing.Point(151, 66);
            this.radius.Name = "radius";
            this.radius.Size = new System.Drawing.Size(0, 13);
            this.radius.TabIndex = 12;
            // 
            // baseX
            // 
            this.baseX.AutoSize = true;
            this.baseX.Location = new System.Drawing.Point(151, 93);
            this.baseX.Name = "baseX";
            this.baseX.Size = new System.Drawing.Size(0, 13);
            this.baseX.TabIndex = 13;
            // 
            // baseY
            // 
            this.baseY.AutoSize = true;
            this.baseY.Location = new System.Drawing.Point(151, 116);
            this.baseY.Name = "baseY";
            this.baseY.Size = new System.Drawing.Size(0, 13);
            this.baseY.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1250, 736);
            this.Controls.Add(this.baseY);
            this.Controls.Add(this.baseX);
            this.Controls.Add(this.radius);
            this.Controls.Add(this.angle);
            this.Controls.Add(this.speed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CirclePanel);
            this.Controls.Add(this.PendulumPanel);
            this.Controls.Add(this.SinusoidPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(1266, 775);
            this.MinimumSize = new System.Drawing.Size(1266, 775);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel SinusoidPanel;
        private System.Windows.Forms.Panel PendulumPanel;
        private System.Windows.Forms.Panel CirclePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label speed;
        private System.Windows.Forms.Label angle;
        private System.Windows.Forms.Label radius;
        private System.Windows.Forms.Label baseX;
        private System.Windows.Forms.Label baseY;
    }
}

