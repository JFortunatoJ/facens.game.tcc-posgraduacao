using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Inventory
{
    /// <summary>
    /// Classe responsável por armazenar todos os itens.
    /// </summary>
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
