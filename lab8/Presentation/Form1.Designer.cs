namespace Presentation
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.batondisplayallinfo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_side_length = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_color = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_edit = new System.Windows.Forms.Button();
            this.baton_add = new System.Windows.Forms.Button();
            this.comboBox_p = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(653, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(265, 28);
            this.comboBox1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(653, 125);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(776, 384);
            this.listBox1.TabIndex = 1;
            // 
            // batondisplayallinfo
            // 
            this.batondisplayallinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.batondisplayallinfo.Location = new System.Drawing.Point(282, 329);
            this.batondisplayallinfo.Name = "batondisplayallinfo";
            this.batondisplayallinfo.Size = new System.Drawing.Size(235, 79);
            this.batondisplayallinfo.TabIndex = 2;
            this.batondisplayallinfo.Text = "Показать всю информцию";
            this.batondisplayallinfo.UseVisualStyleBackColor = true;
            this.batondisplayallinfo.Click += new System.EventHandler(this.batondisplayallinfo_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(22, 430);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(235, 79);
            this.button1.TabIndex = 3;
            this.button1.Text = "Вывести отсортированный массив";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(282, 430);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(235, 79);
            this.button2.TabIndex = 4;
            this.button2.Text = "Вывести периметры всех красных прямоугольных треугольников";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_side_length
            // 
            this.textBox_side_length.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_side_length.Location = new System.Drawing.Point(21, 125);
            this.textBox_side_length.Name = "textBox_side_length";
            this.textBox_side_length.Size = new System.Drawing.Size(481, 26);
            this.textBox_side_length.TabIndex = 5;
            this.textBox_side_length.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Длины сторон многоугольника (вводить через пробел):";
            this.label1.Visible = false;
            // 
            // textBox_color
            // 
            this.textBox_color.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_color.Location = new System.Drawing.Point(21, 206);
            this.textBox_color.Name = "textBox_color";
            this.textBox_color.Size = new System.Drawing.Size(481, 26);
            this.textBox_color.TabIndex = 7;
            this.textBox_color.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Цвет многоугольника:";
            this.label2.Visible = false;
            // 
            // button_edit
            // 
            this.button_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_edit.Location = new System.Drawing.Point(22, 329);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(235, 79);
            this.button_edit.TabIndex = 9;
            this.button_edit.Text = "Редактировать запись";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Visible = false;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // baton_add
            // 
            this.baton_add.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baton_add.Location = new System.Drawing.Point(152, 244);
            this.baton_add.Name = "baton_add";
            this.baton_add.Size = new System.Drawing.Size(235, 79);
            this.baton_add.TabIndex = 10;
            this.baton_add.Text = "Добавить запись";
            this.baton_add.UseVisualStyleBackColor = true;
            this.baton_add.Visible = false;
            this.baton_add.Click += new System.EventHandler(this.baton_add_Click);
            // 
            // comboBox_p
            // 
            this.comboBox_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_p.FormattingEnabled = true;
            this.comboBox_p.Location = new System.Drawing.Point(22, 44);
            this.comboBox_p.Name = "comboBox_p";
            this.comboBox_p.Size = new System.Drawing.Size(265, 28);
            this.comboBox_p.TabIndex = 11;
            this.comboBox_p.Visible = false;
            this.comboBox_p.SelectedIndexChanged += new System.EventHandler(this.comboBox_p_SelectedIndexChanged_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 582);
            this.Controls.Add(this.comboBox_p);
            this.Controls.Add(this.baton_add);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_color);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_side_length);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.batondisplayallinfo);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button batondisplayallinfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_side_length;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_color;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button baton_add;
        private System.Windows.Forms.ComboBox comboBox_p;
    }
}

