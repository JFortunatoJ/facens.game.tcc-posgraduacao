using Project.API.Models;
using Project.Scripts.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Inventory
{
    public class UI_InventoryItem : MonoBehaviour
    {
        //[SerializeField] protected TextMeshProUGUI itemNameText;
        [SerializeField] protected TextMeshProUGUI amountText;
        [SerializeField] protected Image iconImage;
        //[Space] [SerializeField] private Image selectedIndicator;
        
        public ItemModel ProfileData
        {
            get;
            private set;
        }

        public So_Item Data
        {
            get;
            private set;
        }
        
        /*
        public bool IsSelected
        {
            set => selectedIndicator.enabled = value;
        }
        */

        protected UI_SlotInteractions _inventory;
        
        public virtual void Init(ItemModel profileData, UI_SlotInteractions inventory)
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
            
            _inventory = inventory;
            ProfileData = profileData;

            Data = ItemsHelper.GetItemById(profileData.itemId);
            //itemNameText.text = Data.name;
            amountText.text = $"x{profileData.amount}";
            iconImage.sprite = Data.icon;

            //IsSelected = false;
        }

        protected void OnClick()
        {
            _inventory.SelectItem(this);
        }
    }
}
