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
using Engine.ViewModel;
using Engine.Model;
using System.ComponentModel;


namespace aGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private GameSession _gameSession;
        private StartingMenu startingMenu;
        private BattleScreen battleScreen;
        private List<Monster> _locationMonsters;

        public List<Monster> LocationMonsters
        {
            get { return _locationMonsters; }
            set
            {
                _locationMonsters = value;
                OnPropertyChanged("LocationMonsters");
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            _gameSession = new GameSession();
            startingMenu = new StartingMenu();
            battleScreen = new BattleScreen();

            DataContext = _gameSession;

            this.Visibility = Visibility.Hidden;
            startingMenu.Show();
            battleScreen.Visibility = Visibility.Hidden;

            startingMenu.Start.Click += OnGameStart;
            battleScreen.BattleScreenOpened += _gameSession.HandleBattleScreenOpened;
            _gameSession.PlayerAttacking += HandlePlayerAttacking;
            battleScreen.PlayerAttacking += _gameSession.HandleMonsterAttacked;
            battleScreen.PlayerAttacked += HandlePlayerAttacked;
            battleScreen.IsVisibleChanged += HandleBattleScreenClosed;
            _gameSession.MessagePublished += HandleMessagePublished;

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void CreatePlayer()
        {
            _gameSession.CurrentPlayer.Name = startingMenu.NameChoiceTxt.Text;
            _gameSession.CurrentPlayer.PlayerClass = (string)startingMenu.ClassSelection.SelectedItem;
            _gameSession.CurrentPlayer.CurrentQuests.Add(_gameSession.CurrentWorld.GameQuests[0]);
            _gameSession.CurrentPlayer.PlayerAbilities.Add(new Ability("sdf", "asd", 20, 19, 1));
        }

        
        private void OnGameStart(object sender, EventArgs e)
        {
            CreatePlayer();
            startingMenu.Close();
            this.Show();

        }
        private void ActionButton_Clicked(object sender, RoutedEventArgs e)
        {
            if((string)ActionButton.Content == "Fight")
            {
                IsEnabled = false;

                battleScreen.Visibility = Visibility.Visible;
                battleScreen.CloseButton.Visibility = Visibility.Hidden;

                battleScreen.AttackButton.IsEnabled = true;
                battleScreen.UseButton.IsEnabled = true;

                battleScreen.OnBattleScreenOpened();
                battleScreen.PlayerAbilities.ItemsSource = _gameSession.CurrentPlayer.PlayerAbilities;
                _gameSession.CurrentMonster.MonsterKilled += HandleMonsterKilled;

                battleScreen.BattleLog.Clear();
            }

            if((string)ActionButton.Content == "Travel")
            {
                _gameSession.OnLocationChanged();
            }
            
        }
        private void CLearButtonClick(object sender, RoutedEventArgs e)
        {
            ScreenLocations.SelectedIndex = -1;
            ScreenMonsters.SelectedIndex = -1;
            ScreenQuests.SelectedIndex = -1;
            
        }
        private void HandleMonsterKilled(object sender, EventArgs e)
        {
            if (ScreenMonsters.Items.Count != 0)
            {
                battleScreen.CloseButton.Visibility = Visibility.Visible;
                battleScreen.AttackButton.IsEnabled = false;
                battleScreen.UseButton.IsEnabled = false;
                battleScreen.BattleLog.AppendText("DEFEATED IT THE MONSTER");
            }
        }
        private void HandlePlayerAttacked(object sender, EventArgs e)
        {
            ScreenMonsters.Items.Refresh();  
        }
        private void HandlePlayerAttacking(object sender, EventArgs e)
        {
            battleScreen.BattleLog.AppendText(string.Format("You hit the {0} for {1} Damage" + "\n", _gameSession.CurrentMonster.Name, _gameSession.DamageDone));
        }
        private void HandleBattleScreenClosed(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.IsEnabled = true;
        }
        private void HandleMessagePublished(object sender, EventArgs e)
        {
            EventBox.AppendText(_gameSession.Message + "\n");
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
