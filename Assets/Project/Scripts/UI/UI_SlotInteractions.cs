using System;
using System.Collections.Generic;
using DG.Tweening;
using Project.API.Models;
using Project.Scripts.Inventory;
using Project.Scripts.Save;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class UI_SlotInteractions : MonoBehaviour
    {
        [SerializeField] private Button collectCoinsButton;
        [Space]
        [SerializeField] private UI_InventoryItem itemPrefab;
        [SerializeField] private Transform holder;
        [Space] [SerializeField] private CanvasGroup canvasGroup;

        public Action<ItemModel> onItemSelected;

        private UI_InventoryItem _currentItem;
        private List<UI_InventoryItem> _itemsList = new List<UI_InventoryItem>();

        private void Start()
        {
            collectCoinsButton.onClick.AddListener(OnCollectCoinsButtonClick);
            
            Refresh();
        }

        public void Refresh()
        {
            if (_itemsList.Count > 0)
            {
                for (int i = 0; i < _itemsList.Count; i++)
                {
                    Destroy(_itemsList[i].gameObject);
                }
                
                _itemsList.Clear();
            }
            
            List<ItemModel> playerItems = GameDataManager.Instance.Profile.items;
            for (int i = 0; i < playerItems.Count; i++)
            {
                UI_InventoryItem newItem = Instantiate(itemPrefab, holder);
                newItem.Init(playerItems[i], this);
                _itemsList.Add(newItem);
            }
        }

        public void SelectItem(UI_InventoryItem item)
        {
            onItemSelected?.Invoke(item.ProfileData);
        }

        public void Show(bool showCollectButton)
        {
            collectCoinsButton.gameObject.SetActive(showCollectButton);
            
            canvasGroup.DOFade(1, .15f);
            canvasGroup.blocksRaycasts = true;
        }

        public void Hide()
        {
            canvasGroup.DOFade(0, .15f);
            canvasGroup.blocksRaycasts = false;
        }
        
        private void OnCollectCoinsButtonClick()
        {
            SlotsManager.CollectCoins();
        }
    }
}