using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Inventory
{
    public class ItemsHelper : MonoBehaviour
    {
        private static ItemsHelper _instance;

        [SerializeField] private List<So_Item> itemsList;

        private void Awake()
        {
            _instance = this;
        }

        public static So_Item GetItemById(string id)
        {
            return _instance.itemsList.Find(item => item.id == id);
        }
    }
}
