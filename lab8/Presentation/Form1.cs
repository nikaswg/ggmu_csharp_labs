using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PolygonManagerLibrary;

namespace Presentation
{
    public partial class Form1 : Form
    {
        private PolygonManager manager;
        private bool drawBlackText = false; // Флаг для черного текста

        public Form1()
        {
            InitializeComponent();
            manager = new PolygonManager(); // Инициализация manager
            manager.LoadFromFile(); // Загрузка данных из файла
            InitializePolygonComboBox();
            HideAllControls();
            comboBox1.Items.AddRange(new string[]
            {
                "Добавить многоугольник",
                "Редактировать многоугольник",
                "Показать всю информацию (каждая строка выводится тем цветом, который указан в графе цвет)",
                "Вывести отсортированный массив в порядке возрастания площадей",
                "Вывести периметры всех прямоугольных треугольников красного цвета"
            });
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;

            // Установить режим рисования для listBox1
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            listBox1.DrawItem += listBox1_DrawItem;
        }

        private void HideAllControls()
        {
            batondisplayallinfo.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            listBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false; 
            textBox_color.Visible = false;
            textBox_side_length.Visible = false;
            baton_add.Visible = false;  
            button_edit.Visible = false;    
            comboBox_p.Visible = false; 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            HideAllControls();
            switch (comboBox1.SelectedItem.ToString())
            {
                case "Добавить многоугольник":
                    CleanList();
                    label1.Visible = true;
                    label2.Visible = true;  
                    baton_add.Visible = true;
                    textBox_side_length.Visible = true;
                    textBox_color.Visible = true;   
                    break;
                case "Редактировать многоугольник":
                    CleanList();
                    label1.Visible = true;
                    label2.Visible = true;
                    button_edit.Visible = true;
                    textBox_side_length.Visible = true;
                    textBox_color.Visible = true;
                    comboBox_p.Visible = true;
                    break;
                case "Показать всю информацию (каждая строка выводится тем цветом, который указан в графе цвет)":
                    CleanList();
                    batondisplayallinfo.Visible = true;
                    break;
                case "Вывести отсортированный массив в порядке возрастания площадей":
                    button1.Visible = true;
                    break;
                case "Вывести периметры всех прямоугольных треугольников красного цвета":
                    CleanList();
                    button2.Visible = true;
                    break;
            }
        }

        private void CleanList()
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CleanList();
            drawBlackText = false; // Установить флаг для черного текста на false
            var listinfo = manager.CalculateRedRightTrianglePerimeters();
            foreach (var item in listinfo)
            {
                listBox1.Items.Add(item);
            }
            listBox1.Visible = true;
            listBox1.BackColor = Color.Black;
            listBox1.ForeColor = Color.White; // Установить цвет текста в белый
        }

        private void batondisplayallinfo_Click(object sender, EventArgs e)
        {
            CleanList();
            var listinfo = manager.GetPolygonInfo();
            foreach (var item in listinfo)
            {
                listBox1.Items.Add(item);
            }
            listBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CleanList();
            var listinfo = manager.SortAndDisplay();
            foreach (var item in listinfo)
            {
                listBox1.Items.Add(item);
            }
            listBox1.Visible = true;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            // Установите цвет текста на белый, если фон черный
            Color itemColor = (listBox1.BackColor == Color.Black) ? Color.White : Color.FromName(listBox1.Items[e.Index].ToString().Split('-')[0].Trim());

            using (Brush brush = new SolidBrush(itemColor))
            {
                // Нарисовать текст с отступом
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, brush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        private void InitializePolygonComboBox()
        {
            comboBox_p.Items.Clear(); // Очищаем предыдущие элементы
            foreach (var polygon in manager.Polygons)
            {
                comboBox_p.Items.Add(polygon.GetInfo()); // Добавляем информацию о многоугольниках
            }
            if (comboBox_p.Items.Count > 0)
                comboBox_p.SelectedIndex = 0; // Выбор первого элемента по умолчанию
        }

        private void baton_add_Click(object sender, EventArgs e)
        {
            var sides = textBox_side_length.Text.Split(',')
                                                .Select(double.Parse)
                                                .ToArray();
            var color = textBox_color.Text;

            try
            {
                manager.AddPolygon(sides, color);
                InitializePolygonComboBox(); // Обновляем comboBox после добавления
                MessageBox.Show("Многоугольник добавлен успешно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (comboBox_p.SelectedIndex < 0) return;

            var sides = textBox_side_length.Text.Split(',')
                                                 .Select(double.Parse)
                                                 .ToArray();
            var color = textBox_color.Text;

            try
            {
                manager.EditPolygon(comboBox_p.SelectedIndex, sides, color);
                InitializePolygonComboBox(); // Обновляем comboBox после редактирования
                MessageBox.Show("Многоугольник отредактирован успешно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void comboBox_p_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox_p.SelectedIndex >= 0)
            {
                var selectedPolygon = manager.Polygons[comboBox_p.SelectedIndex];
                textBox_side_length.Text = string.Join(", ", selectedPolygon.GetSides()); // Заносим стороны в textBox
                textBox_color.Text = selectedPolygon.Color; // Заносим цвет в textBox
            }
        }
    }
}