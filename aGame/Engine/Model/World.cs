using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace Engine.Model
{
   public class World
    {            
        public  Location[] GameLocations;
        public  Monster[] GameMonsters;
        public  Item[] GameItems;
        public  Quest[] GameQuests;
        public Ability[] GameAbilities;

        public const int ITEM_ID_WOODEN_STAFF = 1;
        public const int ITEM_ID_HEALINGPOTION = 2;
        public const int ITEM_ID_RAT_TAIL = 3;
        public const int ITEM_ID_FATHERS_MAGE_STAFF = 4;

        public const int QUEST_ID_PROTECT_HOME = 1;
        public const int QUEST_ID_GO_TO_TOWN = 2;

        public const int MONSTER_ID_GOBLIN = 1;
        public const int MONSTER_ID_RAT = 2;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_TOWN = 1;

        public World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopluateLocations();            
        }

        private void PopulateAbilities()
        {
           
        }

        private void PopulateItems()
        {
            GameItems = new Item[] {new Weapon("Wooden staff", "Beginner mage staff", "Mage", 4, 3, ITEM_ID_WOODEN_STAFF),
                                    new HealingPotion("Minor Healing Potion", "A potion that heals 10HP", 10, ITEM_ID_HEALINGPOTION),
                                    new LootItem("Rat Tail", "A tail once beloing to a rat", 1, 100, ITEM_ID_RAT_TAIL),
                                    new Weapon("Father's Mage Staff", "A staff handed down to you by your father", "Mage", 7, 5, ITEM_ID_FATHERS_MAGE_STAFF)
                                    };
        }

        private void PopulateQuests()
        {
            GameQuests = new Quest[] {new Quest("Protect home", "A monster has invaded your home, you must kill it", 0, 10, false, true, QUEST_ID_PROTECT_HOME),
                                      new Quest("Go to town", "Time for some shopping", 10, 5, false, true, QUEST_ID_GO_TO_TOWN)};

            GameQuests[0].RewardItems = new InventoryItem[] {new InventoryItem(GetItemByID(ITEM_ID_FATHERS_MAGE_STAFF), 1) };
            GameQuests[0].QuestMonster = GetMonsterByID(1);

            GameQuests[1].QuestMonster = GameMonsters[1];
        }

        private void PopulateMonsters()
        {
            GameMonsters = new Monster[] {new Monster("Goblin", 7, 7, 2, 5, 5, 5, "Green thing", MONSTER_ID_GOBLIN ),
                                          new Monster("Rat", 9, 9, 4, 2, 10, 10, "Dirty rat", MONSTER_ID_RAT)};
        }

        private void PopluateLocations()
        {
            GameLocations = new Location[] { new Location("Home", "Home sweet home", LOCATION_ID_HOME  ),
                                             new Location("Town", "Area of people and stuff", LOCATION_ID_TOWN) };

            GameLocations[0].LocationMonsters.Add(GetMonsterByID(1));
            GameLocations[0].CurrentDirections = new Location[] { GameLocations[1] };

            GameLocations[1].LocationMonsters.Add(GetMonsterByID(1));
            GameLocations[1].CurrentDirections = new Location[] { GameLocations[0] };

            GetLocationByID(LOCATION_ID_HOME).CanEnter = true;
        }

        private Item GetItemByID(int id)
        {
            foreach(Item item in GameItems)
            {
                if(id == item.ID) { return item; }
            }
            return null;
        }

        private Location GetLocationByID(int id)
        {
            foreach(Location location in GameLocations)
            {
                if (location.ID == id) return location; 
            }

            return new Location();
        }

        private Monster GetMonsterByID(int id)
        {
            foreach(Monster monster in GameMonsters)
            {
                if (monster.ID == id) return monster;                                   
            }
            return null;
        }

        private Quest GetQuestByID(int id)
        {
            foreach(Quest quest in GameQuests)
            {
                if (quest.ID == id) return quest;
            }
            return null;
        }
    }
}
