﻿using System;
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
        private readonly BpCounter bpCounter;

        BpFile file;
        internal int Bp { get; set; } = 0;  // Для редактирования из окна BpFieldEditor_Window

        public MainWindow()
        {
            InitializeComponent();

            // Закрепляем окно поверх всех окон
            this.Topmost = true;

            bpCounter = new BpCounter();
            file = new BpFile();  // для чтения имеющегося количества бипишек
            data = file.data.Last();

            Bp = data.Bp;
            ColorX2Button();
            ColorVipButton();

            // Отображение сохранившихся данных
            dateField.Text = "Дата: " + data.Date;
            //bpField.Text = "BP: " + NumberFormater.FormatNumberWithMask(Bp.ToString());
            bpField.Text = "BP: " + (Bp + bpCounter.Somewhere).ToString();
            countMailTextBox.Text = data.BpDoing.Postman.ToString();
            countGymTextBox.Text = data.BpDoing.Gym.ToString();
            countFireFighteTextBox.Text = data.BpDoing.FireFighter.ToString();
            countLotteryTicketTextBox.Text = data.BpDoing.Lottery.ToString();
            movieStudioCheckBox.IsChecked = data.BpDoing.MovieStudio;
            movieTheaterCheckBox.IsChecked = data.BpDoing.MovieTheater;
            zerosCasinoDoneCheckBox.IsChecked = data.BpDoing.ZerosCasinoDone;
            zerosCasinoAttemptButton.Content = data.BpDoing.ZerosCasinoAttempt.ToString();
            treasureCheckBox.IsChecked = data.BpDoing.TreasureDone >= 1;
            treasureButton.Content = data.BpDoing.TreasureAttempt.ToString();
            shootingRangeCheckBox.IsChecked = data.BpDoing.ShootingRange >= 1;
            countMineTextBox.Text = data.BpDoing.Mine.ToString();
        }
        private void SetGreenText(Button sender)
        {
            sender.Foreground = new SolidColorBrush(Color.FromRgb(96, 222, 31));
        }
        private void SetBlackText(Button sender)
        {
            sender.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }
        private void ColorX2Button()
        {
            if (bpCounter.X2)
            {
                SetGreenText(x2Button);
            }
            else
            {
                SetBlackText(x2Button);
            }
        }
        private void ColorVipButton()
        {
            if (bpCounter.Vip)
            {
                SetGreenText(vipButton);
            }
            else
            {
                SetBlackText(vipButton);
            }
        }
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
            // bpCounter.SetBpByDoing(data.BpDoing);

            file.Write();
        }
        private void PinMenuItem_Click(Object sender, RoutedEventArgs e)
        {
            this.Topmost = !this.Topmost;
        }
        private void VipButton_Click(object sender, RoutedEventArgs e)
        {
            bpCounter.Vip = !bpCounter.Vip;
            ColorVipButton();
        }
        private void X2Button_Click(object sender, RoutedEventArgs e)
        {
            bpCounter.X2 = !bpCounter.X2;
            ColorX2Button();
        }
        private void PlusMailButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Postman += 1;
            countMailTextBox.Text = data.BpDoing.Postman.ToString();
            bpCounter.Postman = data.BpDoing.Postman;
        }
        private void MinusMailButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Postman -= 1;
            countMailTextBox.Text = data.BpDoing.Postman.ToString();
            bpCounter.Postman = data.BpDoing.Postman;
        }

        private void PlusGymButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Gym += 1;
            countGymTextBox.Text = data.BpDoing.Gym.ToString();
            bpCounter.Gym = data.BpDoing.Gym;
        }

        private void MinusGymButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Gym -= 1;
            countGymTextBox.Text = data.BpDoing.Gym.ToString();
            bpCounter.Gym = data.BpDoing.Gym;
        }

        private void FarmButtonCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (farmButtonCheckBox.IsChecked == true)
            {
                data.BpDoing.Farm = 10;
            }
            else
            {
                data.BpDoing.Farm = 0;
            }
            bpCounter.Farm = data.BpDoing.Farm;
        }
        private void PlusFireFighteButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.FireFighter += 1;
            countFireFighteTextBox.Text = data.BpDoing.FireFighter.ToString();
            bpCounter.FireFighter = data.BpDoing.FireFighter;
        }

        private void MinusFireFighteButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.FireFighter -= 1;
            countFireFighteTextBox.Text = data.BpDoing.FireFighter.ToString();
            bpCounter.FireFighter = data.BpDoing.FireFighter;
        }
        private void PlusLotteryTicketButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Lottery += 1;
            countLotteryTicketTextBox.Text = data.BpDoing.Lottery.ToString();
            bpCounter.Lottery = data.BpDoing.Lottery;
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
            bpCounter.MovieStudio = data.BpDoing.MovieStudio;
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
            bpCounter.MovieTheater = data.BpDoing.MovieTheater;
        }

        private void PlusZerosCasinoAttemptButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.ZerosCasinoAttempt += 1;
            zerosCasinoAttemptButton.Content = data.BpDoing.ZerosCasinoAttempt.ToString();
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
            bpCounter.ZerosCasinoDone = data.BpDoing.ZerosCasinoDone;
        }
        private void PlusTreasureButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.TreasureAttempt += 1;
            treasureButton.Content = data.BpDoing.TreasureAttempt.ToString();
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
            bpCounter.Treasure = data.BpDoing.TreasureDone;
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
            bpCounter.ShootingRange = data.BpDoing.ShootingRange;
        }

        private void PlusMineButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Mine += 1;
            countMineTextBox.Text = data.BpDoing.Mine.ToString();
            bpCounter.Mine = data.BpDoing.Mine;
        }
        private void PlusConstructionButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Construction = 25;
            bpCounter.Construction = data.BpDoing.Construction;
            SetGreenText(constructionButton);
        }
        private void PlusPortButton_Click(object sender, RoutedEventArgs e)
        {
            data.BpDoing.Port = 25;
            bpCounter.Port = data.BpDoing.Port;
            SetGreenText(portButton);
        }
    }
}
