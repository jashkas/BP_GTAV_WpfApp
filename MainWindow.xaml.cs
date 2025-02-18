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

            // Отображение сохранившихся данных
            dateField.Text = "Дата: " + data.Date;
            //bpField.Text = "BP: " + NumberFormater.FormatNumberWithMask(Bp.ToString());
            bpField.Text = "BP: " + (Bp + data.BpCounter.Somewhere).ToString();
            countMailTextBox.Text = data.BpDoing.Postman.ToString();
            countGymTextBox.Text = data.BpDoing.Gym.ToString();
            countFarmTextBox.Text = data.BpDoing.Farm.ToString();
            countFireFighteTextBox.Text = data.BpDoing.FireFighter.ToString();
            countLotteryTicketTextBox.Text = data.BpDoing.Lottery.ToString();
            movieStudioCheckBox.IsChecked = data.BpDoing.MovieStudio;
            movieTheaterCheckBox.IsChecked = data.BpDoing.MovieTheater;
            zerosCasinoDoneCheckBox.IsChecked = data.BpDoing.ZerosCasinoDone;
            zerosCasinoAttemptTextBlock.Text = data.BpDoing.ZerosCasinoAttempt.ToString() + " нули в казино";
            treasureCheckBox.IsChecked = data.BpDoing.TreasureDone >= 1;
            treasureTextBlock.Text = data.BpDoing.TreasureAttempt.ToString() + " найти сокровище";
            shootingRangeCheckBox.IsChecked = data.BpDoing.ShootingRange >= 1;
            countMineTextBox.Text = data.BpDoing.Mine.ToString();
            countConstructionTextBox.Text = data.BpDoing.Construction.ToString();
            countPortTextBox.Text = data.BpDoing.Port.ToString();
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
        private void AddBp_Click(object sender, EventArgs e)
        {
            data.BpCounter.Somewhere += byte.Parse(bpFieldAddTextBox.Text);
        }
        private void SaveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // подсчет бипишек на основе действий
            // data.BpCounter.SetBpByDoing(data.BpDoing);

            file.Write();
        }
        private void PinMenuItem_Click(Object sender, RoutedEventArgs e)
        {
            this.Topmost = !this.Topmost;
        }
        public void RefreshBp_Click(object sender, RoutedEventArgs e)
        {
            //file.Change(data);
            //file.Write();
            //file = new BpFile();  // для чтения имеющегося количества бипишек
            //data.Bp = file.data.Last().Bp + data.BpCounter.GetAmount();
            bpField.Text = (data.Bp + data.BpCounter.Somewhere + data.BpCounter.GetAmount()).ToString();
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
            data.BpCounter.Postman = data.BpDoing.Postman;
        }
        private void MinusMailButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Postman -= 1;
            countMailTextBox.Text = data.BpDoing.Postman.ToString();
            data.BpCounter.Postman = data.BpDoing.Postman;
        }

        private void PlusGymButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Gym += 1;
            countGymTextBox.Text = data.BpDoing.Gym.ToString();
            data.BpCounter.Gym = data.BpDoing.Gym;
        }

        private void MinusGymButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Gym -= 1;
            countGymTextBox.Text = data.BpDoing.Gym.ToString();
            data.BpCounter.Gym = data.BpDoing.Gym;
        }

        private void PlusFarmButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Farm += 1;
            countFarmTextBox.Text = data.BpDoing.Farm.ToString();
            data.BpCounter.Farm = data.BpDoing.Farm;
        }

        private void MinusFarmButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Farm -= 1;
            countFarmTextBox.Text = data.BpDoing.Farm.ToString();
            data.BpCounter.Farm = data.BpDoing.Farm;
        }

        private void PlusFireFighteButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.FireFighter += 1;
            countFireFighteTextBox.Text = data.BpDoing.FireFighter.ToString();
            data.BpCounter.FireFighter = data.BpDoing.FireFighter;
        }

        private void MinusFireFighteButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.FireFighter -= 1;
            countFireFighteTextBox.Text = data.BpDoing.FireFighter.ToString();
            data.BpCounter.FireFighter = data.BpDoing.FireFighter;
        }

        private void PlusLotteryTicketButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Lottery += 1;
            countLotteryTicketTextBox.Text = data.BpDoing.Lottery.ToString();
            data.BpCounter.Lottery = data.BpDoing.Lottery;
        }
        private void MinusLotteryTicketButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Lottery -= 1;
            countLotteryTicketTextBox.Text = data.BpDoing.Lottery.ToString();
            data.BpCounter.Lottery = data.BpDoing.Lottery;
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
            data.BpCounter.MovieStudio = data.BpDoing.MovieStudio;
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
            data.BpCounter.MovieTheater = data.BpDoing.MovieTheater;
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
            data.BpCounter.ZerosCasinoDone = data.BpDoing.ZerosCasinoDone;
        }
        private void PlusTreasureButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.TreasureAttempt += 1;
            treasureTextBlock.Text = data.BpDoing.TreasureAttempt.ToString() + " найти сокровище";
        }
        private void MinusTreasureButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.TreasureAttempt -= 1;
            treasureTextBlock.Text = data.BpDoing.TreasureAttempt.ToString() + " найти сокровище";
        }
        private void TreasureCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (treasureCheckBox.IsChecked == true)
            {
                data.BpDoing.TreasureDone = 1;
            }
            else
            {
                data.BpDoing.TreasureDone = 0;
            }
            data.BpCounter.Treasure = data.BpDoing.TreasureDone;
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
            data.BpCounter.ShootingRange = data.BpDoing.ShootingRange;
        }

        private void PlusMineButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Mine += 1;
            countMineTextBox.Text = data.BpDoing.Mine.ToString();
            data.BpCounter.Mine = data.BpDoing.Mine;
        }
        private void MinusMinelButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Mine -= 1;
            countMineTextBox.Text = data.BpDoing.Mine.ToString();
            data.BpCounter.Mine = data.BpDoing.Mine;
        }
        private void PlusConstructionButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Construction += 1;
            countConstructionTextBox.Text = data.BpDoing.Construction.ToString();
            data.BpCounter.Construction = data.BpDoing.Construction;
        }
        private void MinusConstructionlButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Construction -= 1;
            countConstructionTextBox.Text = data.BpDoing.Construction.ToString();
            data.BpCounter.Construction = data.BpDoing.Construction;
        }
        private void PlusPortButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Port += 1;
            countPortTextBox.Text = data.BpDoing.Port.ToString();
            data.BpCounter.Port = data.BpDoing.Port;
        }
        private void MinusPortlButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Port -= 1;
            countPortTextBox.Text = data.BpDoing.Port.ToString();
            data.BpCounter.Port = data.BpDoing.Port;
        }
    }
}
