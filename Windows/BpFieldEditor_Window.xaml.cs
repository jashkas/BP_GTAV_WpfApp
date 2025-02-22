using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BP_GTAV_WpfApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для BpFieldEditor_Window.xaml
    /// </summary>
    public partial class BpFieldEditor_Window : Window
    {
        public BpFieldEditor_Window(int bp)
        {
            InitializeComponent();
            bpFieldTextBox.Text = bp.ToString();
        }
        public BpFieldEditor_Window()
        {
            InitializeComponent();
        }
        private void BpFieldTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Проверяем, является ли вводимое значение числом
            e.Handled = !Regex.IsMatch(e.Text, @"^\d$");
        }

        private void BpFieldTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Убираем курсор, чтобы избежать мерцания
            int caretIndex = textBox.CaretIndex;

            // Удаляем пробелы и форматируем заново
            string digitsOnly = Regex.Replace(textBox.Text, @"\s+", ""); // Убираем пробелы
            //string formatted = NumberFormater.FormatNumberWithMask(digitsOnly);

            textBox.Text = digitsOnly;

            // Восстанавливаем позицию курсора
            textBox.CaretIndex = caretIndex > textBox.Text.Length ? textBox.Text.Length : caretIndex;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            // Получаем ссылку на MainWindow
            MainWindow mainWindow = Application.Current.Windows
                .OfType<MainWindow>()
                .FirstOrDefault();

            if (mainWindow != null) // Проверяем, нашлось ли окно
            {
                // Устанавливаем свойство Bp в MainWindow
                mainWindow.Bp = Convert.ToInt32(bpFieldTextBox.Text.Replace(" ", ""));
            }
            this.Close();
        }
    }
}
