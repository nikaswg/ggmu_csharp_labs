namespace EPApp
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
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.buttonEditEvent = new System.Windows.Forms.Button();
            this.buttonViewEvents = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxEvents = new System.Windows.Forms.ComboBox();
            this.baton = new System.Windows.Forms.Button();
            this.baton1 = new System.Windows.Forms.Button();
            this.baton3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTitle.Location = new System.Drawing.Point(39, 126);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(278, 26);
            this.textBoxTitle.TabIndex = 0;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker.Location = new System.Drawing.Point(39, 189);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(278, 26);
            this.dateTimePicker.TabIndex = 1;
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Location = new System.Drawing.Point(633, 69);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(742, 28);
            this.comboBoxMode.TabIndex = 2;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLocation.Location = new System.Drawing.Point(40, 258);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(277, 26);
            this.textBoxLocation.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDescription.Location = new System.Drawing.Point(39, 319);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(278, 26);
            this.textBoxDescription.TabIndex = 4;
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddEvent.Location = new System.Drawing.Point(39, 403);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(250, 83);
            this.buttonAddEvent.TabIndex = 5;
            this.buttonAddEvent.Text = "Добавить мероприятие";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click_1);
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 20;
            this.listBoxEvents.Location = new System.Drawing.Point(633, 163);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(742, 304);
            this.listBoxEvents.TabIndex = 6;
            this.listBoxEvents.SelectedIndexChanged += new System.EventHandler(this.listBoxEvents_SelectedIndexChanged);
            // 
            // buttonEditEvent
            // 
            this.buttonEditEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditEvent.Location = new System.Drawing.Point(295, 403);
            this.buttonEditEvent.Name = "buttonEditEvent";
            this.buttonEditEvent.Size = new System.Drawing.Size(250, 83);
            this.buttonEditEvent.TabIndex = 7;
            this.buttonEditEvent.Text = "Редактировать мероприятие";
            this.buttonEditEvent.UseVisualStyleBackColor = true;
            this.buttonEditEvent.Click += new System.EventHandler(this.buttonEditEvent_Click);
            // 
            // buttonViewEvents
            // 
            this.buttonViewEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonViewEvents.Location = new System.Drawing.Point(39, 505);
            this.buttonViewEvents.Name = "buttonViewEvents";
            this.buttonViewEvents.Size = new System.Drawing.Size(250, 83);
            this.buttonViewEvents.TabIndex = 8;
            this.buttonViewEvents.Text = "Просмотреть данные о всех мероприятиях";
            this.buttonViewEvents.UseVisualStyleBackColor = true;
            this.buttonViewEvents.Click += new System.EventHandler(this.buttonViewEvents_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(36, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Название мероприятия:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(36, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Дата проведения мероприятия:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(36, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Место проведения мероприятия:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(36, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Описание мероприятия:";
            // 
            // comboBoxEvents
            // 
            this.comboBoxEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxEvents.FormattingEnabled = true;
            this.comboBoxEvents.Location = new System.Drawing.Point(40, 60);
            this.comboBoxEvents.Name = "comboBoxEvents";
            this.comboBoxEvents.Size = new System.Drawing.Size(168, 28);
            this.comboBoxEvents.TabIndex = 13;
            this.comboBoxEvents.SelectedIndexChanged += new System.EventHandler(this.comboBoxEvents_SelectedIndexChanged);
            // 
            // baton
            // 
            this.baton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baton.Location = new System.Drawing.Point(295, 505);
            this.baton.Name = "baton";
            this.baton.Size = new System.Drawing.Size(250, 83);
            this.baton.TabIndex = 14;
            this.baton.Text = "Просмотреть мероприятия в заданный день";
            this.baton.UseVisualStyleBackColor = true;
            this.baton.Click += new System.EventHandler(this.baton_Click);
            // 
            // baton1
            // 
            this.baton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baton1.Location = new System.Drawing.Point(564, 505);
            this.baton1.Name = "baton1";
            this.baton1.Size = new System.Drawing.Size(250, 83);
            this.baton1.TabIndex = 15;
            this.baton1.Text = "Показать даты мероприятия после указанной даты";
            this.baton1.UseVisualStyleBackColor = true;
            this.baton1.Click += new System.EventHandler(this.baton1_Click);
            // 
            // baton3
            // 
            this.baton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.baton3.Location = new System.Drawing.Point(839, 505);
            this.baton3.Name = "baton3";
            this.baton3.Size = new System.Drawing.Size(250, 83);
            this.baton3.TabIndex = 16;
            this.baton3.Text = "Вывести среднее количество мероприятий по каждому дню недели ";
            this.baton3.UseVisualStyleBackColor = true;
            this.baton3.Click += new System.EventHandler(this.baton3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1421, 600);
            this.Controls.Add(this.baton3);
            this.Controls.Add(this.baton1);
            this.Controls.Add(this.baton);
            this.Controls.Add(this.comboBoxEvents);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonViewEvents);
            this.Controls.Add(this.buttonEditEvent);
            this.Controls.Add(this.listBoxEvents);
            this.Controls.Add(this.buttonAddEvent);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.comboBoxMode);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.textBoxTitle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.Button buttonEditEvent;
        private System.Windows.Forms.Button buttonViewEvents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxEvents;
        private System.Windows.Forms.Button baton;
        private System.Windows.Forms.Button baton1;
        private System.Windows.Forms.Button baton3;
    }
}

