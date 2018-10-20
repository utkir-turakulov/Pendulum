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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1250, 736);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel SinusoidPanel;
        private System.Windows.Forms.Panel PendulumPanel;
        private System.Windows.Forms.Panel CirclePanel;
    }
}

