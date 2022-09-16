using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Engine
{
    public class Player : LivingCreature
    {
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }
        public Location CurrentLocation { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }

        public Player(int currentHitPoints, int maximumHitPoints, int gold, int experiencePoints, int level) : base(currentHitPoints, maximumHitPoints)
        {
            Gold = gold;
            ExperiencePoints = experiencePoints;
            Level = level;

            Inventory = new List<InventoryItem>();
            Quests = new List<PlayerQuest>();
        }

        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                //There is no required item for this location, so return "true"
                return true;
            }

            //See if the player has the required item in their inventory
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == location.ItemRequiredToEnter.ID)
                {
                    //We found the required item, so return "true"
                    return true;
                }
            }

            //We didn't find the required item in their inventory, so return "false"
            return false;
        }

        public bool HasThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CompletedThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsCompleted;
                }
            }

            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                bool foundItemInPlayersInventory = false;

                // Check each item in the player's inventory, to see if they have it, and enough of it
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID) // The player has the item in their inventory
                    {
                        foundItemInPlayersInventory = true;

                        if (ii.Quantity < qci.Quantity) // The player does not have enough of this item to complete the quest
                        {
                            return false;
                        }
                    }
                }

                // The player does not have any of this quest completion item in their inventory
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }

            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                foreach (InventoryItem ii in Inventory)
                {
                    if (ii.Details.ID == qci.Details.ID)
                    {
                        // Subtract the quantity from the player's inventory that was needed to complete the quest
                        ii.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            foreach (InventoryItem ii in Inventory)
            {
                if (ii.Details.ID == itemToAdd.ID)
                {
                    //They have the item in their inventory, so increase the quantity by one
                    ii.Quantity++;

                    return; //We added the item, so we are done here
                }
            }

            //They didn't have the item, so add one to the inventory
            Inventory.Add(new InventoryItem(itemToAdd, 1));
        }

        public void MarkQuestCompleted(Quest quest)
        {
            // Find the quest in the player's quest list
            foreach (PlayerQuest pq in Quests)
            {
                if (pq.Details.ID == quest.ID)
                {
                    // Mark it as completed
                    pq.IsCompleted = true;

                    return; // We found the quest, and marked it complete, so get out of this function
                }
            }
        }

        public void AddExpPoints(int exp)
        {
            ExperiencePoints += exp;
        }

        public void AddGold(int gold)
        {
            Gold += gold;
        }

        public bool PlayerLevelUp()
        {
            if (ExperiencePoints >= 10 && ExperiencePoints < 25 && Level == 1)
            {
                Level = 2;
                MaxHitPoints = 15;
                CurrentHitPoints = MaxHitPoints;
                return true;
            }
            else if(ExperiencePoints >= 25 && ExperiencePoints < 50 && Level == 2)
            {
                Level = 3;
                MaxHitPoints = 20;
                CurrentHitPoints = MaxHitPoints;
                return true;
            }
            else if (ExperiencePoints >= 50 && ExperiencePoints < 100 && Level == 3)
            {
                Level = 4;
                MaxHitPoints = 25;
                CurrentHitPoints = MaxHitPoints;
                return true;
            }
            else if(ExperiencePoints >= 100 && Level == 4)
            {
                Level = 5;
                MaxHitPoints = 30;
                CurrentHitPoints = MaxHitPoints;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<InventoryItem> ChooseItemReward(Monster monster)
        {
            List<InventoryItem> items = new List<InventoryItem>();

            foreach (LootItem lootItem in monster.LootTable)
            {
                if (RandomNumberGenerator.NumberBetween(1, 100) <= lootItem.DropPercentage)
                {
                    items.Add(new InventoryItem(lootItem.Details, 1));
                }
            }

            if (items.Count == 0)
            {
                foreach (LootItem lootItem in monster.LootTable)
                {
                    if (lootItem.IsDefaultItem)
                    {
                        items.Add(new InventoryItem(lootItem.Details, 1));
                    }
                }
            }

            return items;
        }


    }
}
