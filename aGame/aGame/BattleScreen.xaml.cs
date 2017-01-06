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
using System.Windows.Shapes;
using Engine.Model;
using Engine.ViewModel;
using System.ComponentModel;

namespace aGame
{
    /// <summary>
    /// Interaction logic for BattleScreen.xaml
    /// </summary>
    public partial class BattleScreen : Window
    {
        //Events

        public EventHandler BattleScreenOpened;
        public event EventHandler PlayerAttacking;
        public event EventHandler PlayerAttacked;

        public BattleScreen()
        {
            InitializeComponent();

            PlayerAbilities.DisplayMemberPath = "Name";
            PlayerAbilities.SelectedValuePath = "Name";
            PlayerAbilities.SelectedItem = "Ability";

            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;

        }

        public void UpdateBattleLog(object sender, EventArgs e)
        {

        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            onPlayerAttacking();
            onPlayerAttacked();
        }
        private void HandleMonsterIsAttacked(object sender, EventArgs e)
        {

        }
        private void HandleMonsterKilled(object sender, EventArgs e)
        {
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
        public void OnBattleScreenOpened()
        {
            BattleScreenOpened?.Invoke(this, EventArgs.Empty);
        }
        public void onPlayerAttacking()
        {
            PlayerAttacking?.Invoke(this, EventArgs.Empty);
        }
        public void onPlayerAttacked()
        {
            PlayerAttacked?.Invoke(this, EventArgs.Empty);
        }
    }

  
}
