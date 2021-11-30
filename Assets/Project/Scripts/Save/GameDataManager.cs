using System;
using Blazewing.DataEvent;
using Liga.IO;
using Project.API.Models;
using UnityEngine;

namespace Project.Scripts.Save
{
    public class GameDataManager : SingletonBehaviour<GameDataManager>
    {
        private const string PROFILE_SAVE_KEY = "PROFILE";
        
        [SerializeField] private PlayerProfile m_profile;

        public int Coins
        {
            get => Profile.coins;
            set
            {
                m_profile.coins = value;
                DataEvent.Notify(new CoinsStruct(value));
            }
        }
        
        public PlayerProfile Profile
        {
            get
            {
                if (m_profile == null)
                {
                    SetupProfileData();
                }

                return m_profile;
            }
        }
        
        public void SaveProfile()
        {
            FileManager.SaveFile(m_profile, PROFILE_SAVE_KEY);
            string value = JsonController.Serialize(m_profile);

            //TODO Subir na API
        }
        
        private void SetupProfileData()
        {
            m_profile = new PlayerProfile();

            if (FileManager.FileExists(PROFILE_SAVE_KEY))
                FileManager.LoadFile<PlayerProfile>(PROFILE_SAVE_KEY, loadedProfile => m_profile = loadedProfile);
            else
            {
                LoadDefaultProfile();
                FileManager.SaveFile(m_profile, PROFILE_SAVE_KEY);
            }

            Coins = m_profile.coins;
        }
        
        private void LoadDefaultProfile()
        {
            m_profile = new PlayerProfile("Player");
        }

        public void AddItem(So_Item item)
        {
            ItemModel inventoryItem = Profile.GetItemById(item.id);
            if (inventoryItem != null)
            {
                inventoryItem.amount++;
                return;
            }
            
            Profile.items.Add(new ItemModel(Guid.NewGuid().ToString(), item.id, 1));
            
            SaveProfile();
        }

        public void RemoveItem(string itemId, int amount = 1)
        {
            ItemModel item = Profile.GetItemById(itemId);
            if(item == null) return;

            item.amount -= amount;
            if (item.amount <= 0)
            {
                Profile.items.Remove(item);
            }
            
            SaveProfile();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
            {
                SaveProfile();
            }
        }
    }
}
