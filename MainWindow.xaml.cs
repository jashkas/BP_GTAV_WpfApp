using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using BP_GTAV_WpfApp.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace BP_GTAV_WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BpData data;
        BpFile file;
        internal int Bp { get; set; } = 0;  // Для редактирования из окна BpFieldEditor_Window

        public MainWindow()
        {
            InitializeComponent();

            // Закрепляем окно поверх всех окон
            this.Topmost = true;

            file = new BpFile();  // для чтения имеющегося количества бипишек
            data = file.data.Last();

            Bp = data.Bp;
            ColorX2Button();
            ColorVipButton();

            dateField.Text = "Дата: " + data.Date;
            bpField.Text = "BP: " + NumberFormater.FormatNumberWithMask(Bp.ToString());
        }
        private void ColorX2Button()
        {
            if (data.BpCounter.X2)
            {
                x2Button.Foreground = new SolidColorBrush(Color.FromRgb(96, 222, 31));
            }
            else
            {
                x2Button.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }
        private void ColorVipButton()
        {
            if (data.BpCounter.Vip)
            {
                vipButton.Foreground = new SolidColorBrush(Color.FromRgb(96, 222, 31));
            }
            else
            {
                vipButton.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }
        // commit галочка с випкой без виппки и нет вывода всех бипишек
        private void BpField_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Topmost = false;
            BpFieldEditor_Window window = new BpFieldEditor_Window();

            // Подписываемся на событие Closed
            window.Closed += BpFieldEditorWindow_Closed;

            window.Show();
        }
        private void BpFieldEditorWindow_Closed(object sender, EventArgs e)
        {
            this.Topmost = true;
            // Обработка после закрытия окна BpFieldEditor_Window
            bpField.Text = "BP: " + NumberFormater.FormatNumberWithMask(Bp.ToString());
            // Сохранение переданного bp в BpData data
            data.Bp = Bp;
        }
        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // подсчет бипишек на основе действий
            data.BpCounter.SetBpByDoing(data.BpDoing);

            //BpFile file = new BpFile();
            file.Add(data);
            file.Write();
        }
        private void VipButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpCounter.Vip = !data.BpCounter.Vip;
            ColorVipButton();
        }
        private void X2Button_Click(object sender, RoutedEventArgs e)
        {
            data.BpCounter.X2 = !data.BpCounter.X2;
            ColorX2Button();
        }
        private void PlusMailButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Postman += 1;
            countMailTextBox.Text = data.BpDoing.Postman.ToString();
        }
        private void MinusMailButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Postman -= 1;
            countMailTextBox.Text = data.BpDoing.Postman.ToString();
        }

        private void PlusGymButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Gym += 1;
            countGymTextBox.Text = data.BpDoing.Gym.ToString();
        }

        private void MinusGymButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Gym -= 1;
            countGymTextBox.Text = data.BpDoing.Gym.ToString();
        }

        private void PlusFarmButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Farm += 1;
            countFarmTextBox.Text = data.BpDoing.Farm.ToString();
        }

        private void MinusFarmButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Farm -= 1;
            countFarmTextBox.Text = data.BpDoing.Farm.ToString();
        }

        private void PlusFireFighteButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.FireFighter += 1;
            countFireFighteTextBox.Text = data.BpDoing.FireFighter.ToString();
        }

        private void MinusFireFighteButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.FireFighter -= 1;
            countFireFighteTextBox.Text = data.BpDoing.FireFighter.ToString();
        }

        private void LotteryTicketCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (lotteryTicketCheckBox.IsChecked == true)
            {
                data.BpDoing.Lottery = 1;
            }
            else
            {
                data.BpDoing.Lottery = 0;
            }
        }

        private void MovieStudioCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (movieStudioCheckBox.IsChecked == true)
            {
                data.BpDoing.MovieStudio = true;
            }
            else
            {
                data.BpDoing.MovieStudio = false;
            }
        }

        private void MovieTheaterCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (movieTheaterCheckBox.IsChecked == true)
            {
                data.BpDoing.MovieTheater = true;
            }
            else
            {
                data.BpDoing.MovieTheater = false;
            }
        }

        private void PlusZerosCasinoAttemptButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.ZerosCasinoAttempt += 1;
            zerosCasinoAttemptTextBlock.Text = data.BpDoing.ZerosCasinoAttempt.ToString() + " нули в казино";
        }

        private void MinusZerosCasinoAttemptButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.ZerosCasinoAttempt -= 1;
            zerosCasinoAttemptTextBlock.Text = data.BpDoing.ZerosCasinoAttempt.ToString() + " нули в казино";
        }

        private void ZerosCasinoCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (zerosCasinoDoneCheckBox.IsChecked == true)
            {
                data.BpDoing.ZerosCasinoDone = true;
            }
            else
            {
                data.BpDoing.ZerosCasinoDone = false;
            }
        }

        private void TreasureCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (treasureCheckBox.IsChecked == true)
            {
                data.BpDoing.Treasure = 1;
            }
            else
            {
                data.BpDoing.Treasure = 0;
            }
        }

        private void ShootingRangeCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (shootingRangeCheckBox.IsChecked == true)
            {
                data.BpDoing.ShootingRange = 1;
            }
            else
            {
                data.BpDoing.ShootingRange = 0;
            }
        }

        private void PlusMineButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Mine += 1;
            countMineTextBox.Text = data.BpDoing.Mine.ToString();
        }
        private void MinusMinelButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Mine -= 1;
            countMineTextBox.Text = data.BpDoing.Mine.ToString();
        }
        private void PlusConstructionButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Construction += 1;
            countConstructionTextBox.Text = data.BpDoing.Construction.ToString();
        }
        private void MinusConstructionlButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Construction -= 1;
            countConstructionTextBox.Text = data.BpDoing.Construction.ToString();
        }
        private void PlusPortButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Port += 1;
            countPortTextBox.Text = data.BpDoing.Port.ToString();
        }
        private void MinusPortlButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Port -= 1;
            countPortTextBox.Text = data.BpDoing.Port.ToString();
        }
    }
}
