using System.Collections.Generic;
using System.Linq;
using Project.Scripts.Enums;

namespace Project.API.Models
{
    [System.Serializable]
    public class PlayerProfile
    {
        public string id;
        public string name;
        public string email;
        public int coins;
        public List<SlotModel> slots;
        public List<ItemModel> items;

        public PlayerProfile(string name)
        {
            this.name = name;
            email = string.Empty;
            coins = 50;
            slots = new List<SlotModel>
            {
                new SlotModel(TerrainType.Stone),
                new SlotModel(TerrainType.Coal),
                new SlotModel(TerrainType.Iron),
                new SlotModel(TerrainType.Gold)
            };

            items = new List<ItemModel>();
        }

        public PlayerProfile()
        {
            slots = new List<SlotModel>();
            items = new List<ItemModel>();
        }

        public ItemModel GetItemById(string id)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].itemId == id) return items[i];
            }

            return null;
        }
    }
}
