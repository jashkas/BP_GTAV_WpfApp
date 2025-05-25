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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BP_GTAV_WpfApp
{
    /// <summary>
    /// Логика взаимодействия для WithFriend_BP.xaml
    /// </summary>
    public partial class WithFriend_BP : Window
    {
        private static WithFriend_BP _currentInstance;  // текущий экземпляр окна

        private WithFriendDoing WithFriendDoing { get; set; }
        private MainWindow mainWindow;  // ссылка на MainWindow

        private WithFriend_BP(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.WithFriendDoing = mainWindow.withFriend;

            this.Closed += (sender, e) => _currentInstance = null; // Очищаем ссылку при закрытии
            this.Closed += WithFriend_BP_Closed;

            plusClubButton.Content = WithFriendDoing.Club;
            plusClubFriendButton.Content = WithFriendDoing.ClubFriend;
            kartingCheckBox.IsChecked = WithFriendDoing.Karting;
            kartingFriendCheckBox.IsChecked = WithFriendDoing.KartingFriend;
            streetRaceCheckBox.IsChecked = WithFriendDoing.StreetRace;
            streetRaceFriendCheckBox.IsChecked = WithFriendDoing.StreetRaceFriend;
            trainingComplexButton.Content = WithFriendDoing.TrainingComplex;
            trainingComplexFriendButton.Content = WithFriendDoing.TrainingComplexFriend;
            arenaRaceCheckBox.IsChecked = WithFriendDoing.Arena;
            arenaFriendRaceCheckBox.IsChecked = WithFriendDoing.ArenaFriend;
        }

        // Статический метод для открытия окна
        public static void ShowSingleInstance(MainWindow mainWindow)
        {
            if (_currentInstance == null)
            {
                _currentInstance = new WithFriend_BP(mainWindow);
                _currentInstance.Show();
            }
            else
            {
                // Если окно уже открыто, активируем его (переводим на передний план)
                _currentInstance.Activate();

                // Если окно было свернуто, разворачиваем
                if (_currentInstance.WindowState == WindowState.Minimized)
                    _currentInstance.WindowState = WindowState.Normal;
            }
        }

        private void WithFriend_BP_Closed(object sender, EventArgs e)
        {
            // При закрытии окна обновляем статическое поле в MainWindow
            mainWindow.withFriend = this.WithFriendDoing;
        }

        private void PlusClubButton_Click(object sender, RoutedEventArgs e)
        {
            WithFriendDoing.Club += 1;
        }

        private void PlusClubFriendButton_Click(object sender, RoutedEventArgs args)
        {
            WithFriendDoing.ClubFriend += 1;
        }
        private void KartingCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (kartingCheckBox.IsChecked == true)
            {
                WithFriendDoing.Karting = true;
            }
            else
            {
                WithFriendDoing.Karting = false;
            }
        }

        private void KartingFriendCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (kartingFriendCheckBox.IsChecked == true)
            {
                WithFriendDoing.KartingFriend = true;
            }
            else
            {
                WithFriendDoing.KartingFriend = false;
            }
        }
        private void StreetRaceCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (streetRaceCheckBox.IsChecked == true)
            {
                WithFriendDoing.StreetRace = true;
            }
            else
            {
                WithFriendDoing.StreetRace = false;
            }
        }

        private void StreetRaceFriendCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (streetRaceFriendCheckBox.IsChecked == true)
            {
                WithFriendDoing.StreetRaceFriend = true;
            }
            else
            {
                WithFriendDoing.StreetRaceFriend = false;
            }
        }

        private void PlusTrainingComplexButton_Click(Object sender, RoutedEventArgs args)
        {
            WithFriendDoing.TrainingComplex += 1;
        }

        private void PlusTrainingComplexFriendButton_Click(object sender, RoutedEventArgs args) 
        {
            WithFriendDoing.TrainingComplexFriend += 1;
        }

        private void ArenaRaceCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (arenaRaceCheckBox.IsChecked == true)
            {
                WithFriendDoing.Arena = true;
            }
            else
            {
                WithFriendDoing.Arena = false;
            }
        }

        private void ArenaFriendRaceCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (arenaFriendRaceCheckBox.IsChecked == true)
            {
                WithFriendDoing.ArenaFriend = true;
            }
            else
            {
                WithFriendDoing.ArenaFriend = false;
            }
        }
    }
}
