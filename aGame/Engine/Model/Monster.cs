using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Model
{
   public class Monster : LivingCreature      
    {
        private int _currentHP;
        private int _maxHP;
        private int _id;
        private int _maxDamage;
        private int _minDamage;
        private int _experienceReward;
        private int _goldReward;
        private string _description;
        private Item[] _lootItems;
        private List<Ability> _monsterAbilities;

        public event EventHandler MonsterKilled;
        public EventHandler isAttacked;

        #region Properties

    public string ActionString { get; set; }
    public override int CurrentHP
        {
            get { return _currentHP; }
            set
            {
                _currentHP = value;
                OnPropertyChanged("CurrentHP");
                if (_currentHP <= 0)
                { onMonsterKilled(); }
            }
        }
    public override int MaxHP
        {
            get { return _maxHP; }
            set
            {
                _maxHP = value;
                OnPropertyChanged("MaxHP");
            }
        }
    public int MinDamage
    {
        get { return _minDamage; }
        set
        {
            _minDamage = value;
            OnPropertyChanged("MinDamage");
        }
    }
    public int MaxDamage
        {
            get { return _maxDamage; }
            set
            {
                _maxDamage = value;
                OnPropertyChanged("MaxDamage");
            }
        }
    public int ExperienceReward
    {
        get { return _experienceReward; }
        set
        {
            _experienceReward = value;
            OnPropertyChanged("ExperienceReward");
        }
    }
    public int GoldReward
    {
        get { return _goldReward; }
        set
        {
            _goldReward = value;
            OnPropertyChanged("GoldReward");
        }
    }
    public string Description
    {
        get { return _description; }
        set
        {
            _description= value;
            OnPropertyChanged("Description");
        }
    }
    public Item[] LootItems
    {
        get { return _lootItems; }
        set
        {
            _lootItems = value;
            OnPropertyChanged("LootItems");
        }
    }
    public List<Ability> MonsterAbilities
        {
            get { return _monsterAbilities; }
            set
            {
                _monsterAbilities = value;
                OnPropertyChanged("MonsterAbilites");
            }
        }
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }
        #endregion

        public Monster(string name , int maxHP, int currentHP, int maxDamage, int minDamage, int experienceReward, int goldReward, string description, int id ) :
            base(name, maxHP, currentHP)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            ExperienceReward = experienceReward;
            GoldReward = goldReward;
            Description = description;            
            ID = id;
            MonsterAbilities = new List<Ability>();
            ActionString = "Fight";
        }
        public Monster()
        {

        }
        public void onMonsterKilled()
        {
            MonsterKilled?.Invoke(this, EventArgs.Empty);
        }
        public void onMonsterAttacked()
        {
            isAttacked?.Invoke(this, EventArgs.Empty);
        }

    }
}
