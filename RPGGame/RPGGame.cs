using Engine;
using System.Diagnostics;

namespace RPGGame
{
    public partial class RPGGame : Form
    {
        private Player _player;
        private Monster _currentMonster;
        private bool playerHasQuest = false;
        private bool playerCompletedQuest = false;
        public RPGGame()
        {
            InitializeComponent();
            _player = new Player(10, 10, 20, 0, 1);
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            _player.Inventory.Add(new InventoryItem(World.ItemByID(World.ITEM_ID_RUSTY_SWORD),1));

            UpdateLabelInUI();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToNorth);
        }

        private void btnEast_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToEast);
        }

        private void btnSouth_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToSouth);
        }

        private void btnWest_Click(object sender, EventArgs e)
        {
            MoveTo(_player.CurrentLocation.LocationToWest);
        }

        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            //Get the selected weapon
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;
            
            //Get a random possible damage
            int currentDamage = RandomNumberGenerator.NumberBetween(currentWeapon.MinDamage, currentWeapon.MaxDamage);

            //Damage made to the monster
            _currentMonster.CurrentHitPoints -= currentDamage;

            // Display message
            rtbMessages.Text += "You hit the " + _currentMonster.Name + " for " + currentDamage.ToString() + " points." + Environment.NewLine;

            if(_currentMonster.CurrentHitPoints <= 0)
            {
                //Display message the monster is dead
                rtbMessages.Text += Environment.NewLine;
                rtbMessages.Text += "You defeated: " + _currentMonster.Name + Environment.NewLine;

                //Add experience points for killing the monster.
                _player.AddExpPoints(_currentMonster.RewardExpPoints);
                rtbMessages.Text += "You receive: " + _currentMonster.RewardExpPoints.ToString() + " experience points" + Environment.NewLine;

                if (_player.PlayerLevelUp())
                {
                    rtbMessages.Text += "Level Up!" + Environment.NewLine;
                }

                //Add gold for killing the monster
                _player.AddGold(_currentMonster.RewardGold);
                rtbMessages.Text += "You receive " + _currentMonster.RewardGold.ToString() + " gold" + Environment.NewLine;

                List<InventoryItem> lootedItems = _player.ChooseItemReward(_currentMonster);

                foreach (InventoryItem item in lootedItems)
                {
                    _player.AddItemToInventory(item.Details);

                    if (item.Quantity == 1)
                    {
                        rtbMessages.Text += "You loot " + item.Quantity.ToString() + " " + item.Details.Name + Environment.NewLine;
                    }
                    else
                    {
                        rtbMessages.Text += "You loot " + item.Quantity.ToString() + " " + item.Details.NamePlural + Environment.NewLine;
                    }

                    //Update the info of the player in the UI

                    UpdateLabelInUI();
                    UpdateInventoryListInUI();
                    UpdateWeaponListInUI();
                    UpdatePotionListInUI();

                    // Add a blank line to the messages box, just for appearance.
                    rtbMessages.Text += Environment.NewLine;

                    // Move player to current location (to heal player and create a new monster to fight)
                    MoveTo(_player.CurrentLocation);
                }
            }
            else
            {
                //Monster still alive.

                MonsterAttackTurn();
            }
        }

        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            //Get the current potion from the combo box
            HealingPotion healingPotion = (HealingPotion)cboPotions.SelectedItem;

            _player.CurrentHitPoints += healingPotion.AmountToHeal;

            //The current hit points cannot exceed the maximum hit points
            if (_player.CurrentHitPoints > _player.MaxHitPoints)
            {
                _player.CurrentHitPoints = _player.MaxHitPoints;
            }
            //Remove the potion from player inventory
            foreach (InventoryItem item in _player.Inventory)
            {
                if (healingPotion.ID == item.Details.ID)
                {
                    item.Quantity--;
                    break;
                }
            }
            // Display message
            rtbMessages.Text += "You drink a " + healingPotion.Name + Environment.NewLine;

            MonsterAttackTurn();

            // Refresh player data in UI
            UpdateLabelInUI();
            UpdateInventoryListInUI();
            UpdatePotionListInUI();

        }

        public void MonsterAttackTurn()
        {
            //Determinate the damage the monster does to the player
            int monsterDamage = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaxDamage);

            //Display message
            rtbMessages.Text += "The " + _currentMonster.Name + " did " + monsterDamage.ToString() + " points of damage." + Environment.NewLine;

            //Substract the damage from player's life
            _player.CurrentHitPoints -= monsterDamage;

            //Refresh player data in UI
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();

            //When player dies
            if (_player.CurrentHitPoints <= 0)
            {
                //Display
                rtbMessages.Text += "The " + _currentMonster.Name + " killed you." + Environment.NewLine;

                //Return the player back home and heal the player
                MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            }
        }

        private void MoveTo(Location newLocation)
        {
            //Does the location have any required items
            if (!_player.HasRequiredItemToEnterThisLocation(newLocation))
            {
                rtbMessages.Text += "You must have a " + newLocation.ItemRequiredToEnter.Name + " to enter this location." + Environment.NewLine;
                return;
            }

            // Update the player's current location
            _player.CurrentLocation = newLocation;

            // Show/hide available movement buttons
            btnNorth.Visible = (newLocation.LocationToNorth != null);
            btnEast.Visible = (newLocation.LocationToEast != null);
            btnSouth.Visible = (newLocation.LocationToSouth != null);
            btnWest.Visible = (newLocation.LocationToWest != null);

            // Display current location name and description
            rtbLocation.Text = newLocation.Name + Environment.NewLine;
            rtbLocation.Text += newLocation.Description + Environment.NewLine;

            // Completely heal the player
            _player.CurrentHitPoints = _player.MaxHitPoints;

            // Update Hit Points in UI
            UpdateLabelInUI();

            // Does the location have a quest?
            if (newLocation.QuestAvailableHere != null)
            {
                // See if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = _player.HasThisQuest(newLocation.QuestAvailableHere);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(newLocation.QuestAvailableHere);

                // See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        // See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            rtbMessages.Text += Environment.NewLine;
                            rtbMessages.Text += "You complete the '" + newLocation.QuestAvailableHere.Name + "' quest." + Environment.NewLine;

                            // Remove quest items from inventory
                            _player.RemoveQuestCompletionItems(newLocation.QuestAvailableHere);

                            // Give quest rewards
                            rtbMessages.Text += "You receive: " + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardExperiencePoints.ToString() + " experience points" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardGold.ToString() + " gold" + Environment.NewLine;
                            rtbMessages.Text += newLocation.QuestAvailableHere.RewardItem.Name + Environment.NewLine;
                            rtbMessages.Text += Environment.NewLine;

                            //Add the exp from the quest
                            _player.AddExpPoints(newLocation.QuestAvailableHere.RewardExperiencePoints);

                            //Add the gold from the quest
                            _player.AddGold(newLocation.QuestAvailableHere.RewardGold);

                            //Level up?
                            _player.PlayerLevelUp();

                            // Add the reward item to the player's inventory
                            _player.AddItemToInventory(newLocation.QuestAvailableHere.RewardItem);

                            // Mark the quest as completed
                            _player.MarkQuestCompleted(newLocation.QuestAvailableHere);

                            //Update the UI
                            UpdateLabelInUI();
                        }
                    }
                }
                else
                {
                    //The player doesn't already have the quest

                    // Display the messages
                    rtbMessages.Text += "You receive the " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;
                    rtbMessages.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                    rtbMessages.Text += "To complete it, return with:" + Environment.NewLine;
                    foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            rtbMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                        }
                    }
                    rtbMessages.Text += Environment.NewLine;

                    // Add the quest to the player's quest list
                    _player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
                }
            }

            // Does the location have a monster?
            if (newLocation.MonsterLivingHere != null)
            {
                rtbMessages.Text += "You see a " + newLocation.MonsterLivingHere.Name + Environment.NewLine;

                // Make a new monster, using the values from the standard monster in the World.Monster list
                Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                _currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaxDamage,
                    standardMonster.RewardExpPoints, standardMonster.RewardGold, standardMonster.CurrentHitPoints, standardMonster.MaxHitPoints);

                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(lootItem);
                }

                cboWeapons.Visible = true;
                cboPotions.Visible = true;
                btnUseWeapon.Visible = true;
                btnUsePotion.Visible = true;
            }
            else
            {
                _currentMonster = null;

                cboWeapons.Visible = false;
                cboPotions.Visible = false;
                btnUseWeapon.Visible = false;
                btnUsePotion.Visible = false;
            }

            // Refresh player's inventory list
            UpdateInventoryListInUI();

            // Refresh player's quest list
            UpdateQuestListInUI();

            // Refresh player's weapons combobox
            UpdateWeaponListInUI();

            // Refresh player's potions combobox
            UpdatePotionListInUI();
        }

        private void UpdateInventoryListInUI()
        {
            dgvInventory.RowHeadersVisible = false;

            dgvInventory.ColumnCount = 2;
            dgvInventory.Columns[0].Name = "Name";
            dgvInventory.Columns[0].Width = 197;
            dgvInventory.Columns[1].Name = "Quantity";

            dgvInventory.Rows.Clear();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dgvInventory.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                }
            }
        }

        private void UpdateQuestListInUI()
        {
            dgvQuests.RowHeadersVisible = false;

            dgvQuests.ColumnCount = 2;
            dgvQuests.Columns[0].Name = "Name";
            dgvQuests.Columns[0].Width = 197;
            dgvQuests.Columns[1].Name = "Done?";

            dgvQuests.Rows.Clear();

            foreach (PlayerQuest playerQuest in _player.Quests)
            {
                dgvQuests.Rows.Add(new[] { playerQuest.Details.Name, playerQuest.IsCompleted.ToString() });
            }
        }

        private void UpdateWeaponListInUI()
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                cboWeapons.Visible = false;
                btnUseWeapon.Visible = false;
            }
            else
            {
                cboWeapons.DataSource = weapons;
                cboWeapons.DisplayMember = "Name";
                cboWeapons.ValueMember = "ID";

                cboWeapons.SelectedIndex = 0;
            }
        }

        private void UpdatePotionListInUI()
        {
            List<HealingPotion> healingPotions = new List<HealingPotion>();

            foreach (InventoryItem inventoryItem in _player.Inventory)
            {
                if (inventoryItem.Details is HealingPotion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        healingPotions.Add((HealingPotion)inventoryItem.Details);
                    }
                }
            }

            if (healingPotions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
                cboPotions.Visible = false;
                btnUsePotion.Visible = false;
            }
            else
            {
                cboPotions.DataSource = healingPotions;
                cboPotions.DisplayMember = "Name";
                cboPotions.ValueMember = "ID";

                cboPotions.SelectedIndex = 0;
            }
        }

        private void UpdateLabelInUI()
        {
            lblHitPoints.Text = _player.CurrentHitPoints.ToString();
            lblGold.Text = _player.Gold.ToString();
            lblExp.Text = _player.ExperiencePoints.ToString();
            lblLevel.Text = _player.Level.ToString();
        }

    }
}