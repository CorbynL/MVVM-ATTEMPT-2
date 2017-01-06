using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Engine.Model
{
   public class Quest : INotifyPropertyChanged
    {
        private bool _isCompleted;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GoldReward { get; set; }
        public int ExperienceReward { get; set; }
        public Item[] RewardItems { get; set; }
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged("IsCompleted");
                if (IsCompleted)  onQuestComplete(); 
            }
        }
        public bool IsAvailable { get; set; }
        public Monster QuestMonster { get; set; }
        public UnitObjective a { get; set; }

        public EventHandler QuestCompleted;
        public event PropertyChangedEventHandler PropertyChanged;


        public Quest(string name = "", string description = "", int goldReward = 0, int experienceReward = 0, bool isCompleted = false, bool isAvailable = false, int id = 0)
        {
            Name = name;
            Description = description;
            GoldReward = goldReward;
            ExperienceReward = experienceReward;
            IsCompleted = isCompleted;
            IsAvailable = isAvailable;
            ID = id;
            a = new UnitObjective();
        }
        public Quest()
        {

        }

        private void onQuestComplete()
        {
            QuestCompleted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class UnitObjective : INotifyPropertyChanged
    {

        string Description { get; set; }
        int[] UnitRequirements { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public UnitObjective()
        {

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
