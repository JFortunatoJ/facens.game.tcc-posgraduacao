using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Store
{
    public class UI_StoreItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemNameText;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private Image iconImage;
        [Space] [SerializeField] private Image selectedIndicator;

        public So_Item Data
        {
            get;
            private set;
        }
        
        private StoreManager _store;

        public bool IsSelected
        {
            set => selectedIndicator.enabled = value;
        }
    
        public void Init(So_Item data, StoreManager store)
        {
            _store = store;
            Data = data;
            itemNameText.text = Data.name;
            priceText.text = Data.price.ToString();
            iconImage.sprite = Data.icon;
        
            GetComponent<Button>().onClick.AddListener(OnClick);
            IsSelected = false;
        }

        private void OnClick()
        {
            _store.SelectItem(this);
        }
    }
}
