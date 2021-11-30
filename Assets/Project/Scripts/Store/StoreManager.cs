using System;
using System.Collections.Generic;
using Project.Scripts.Save;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Project.Scripts.Store
{
    public class StoreManager : MonoBehaviour
    {
        [SerializeField] private UI_StoreItem itemPrefab;
        [SerializeField] private Transform holder;
        [Space] [SerializeField] private List<So_Item> itemsList;
        [Space] [SerializeField] private Button buyItemButton;
        [SerializeField] private Button closeButton;
        
        private UI_StoreItem _currentItem;
        private static Action _callback;

        public static void Show(Action callback)
        {
            _callback = callback;
            SceneManager.LoadScene("Store", LoadSceneMode.Additive);
        }

        public static void Hide()
        {
            SceneManager.UnloadSceneAsync("Store");
        }
        
        private void Start()
        {
            closeButton.onClick.AddListener(OnCloseButtonClick);
            buyItemButton.onClick.AddListener(OnBuyItemButtonClick);
            buyItemButton.gameObject.SetActive(false);
            
            InstantiateItems();
        }

        private void OnCloseButtonClick()
        {
            _callback?.Invoke();
        }

        private void OnBuyItemButtonClick()
        {
            if(_currentItem == null) return;
            
            if(_currentItem.Data.price > GameDataManager.Instance.Coins) return;

            GameDataManager.Instance.Coins -= _currentItem.Data.price;
            GameDataManager.Instance.AddItem(_currentItem.Data);
        }

        private void InstantiateItems()
        {
            for (int i = 0; i < itemsList.Count; i++)
            {
                UI_StoreItem newItem = Instantiate(itemPrefab, holder);
                newItem.Init(itemsList[i], this);
            }
        }

        public void SelectItem(UI_StoreItem item)
        {
            if (_currentItem == item)
            {
                _currentItem.IsSelected = false;
                _currentItem = null;
                
                buyItemButton.gameObject.SetActive(false);
                
                return;
            }

            if (_currentItem != null)
            {
                _currentItem.IsSelected = false;
            }

            _currentItem = item;
            _currentItem.IsSelected = true;
            
            buyItemButton.gameObject.SetActive(true);
        }
    }
}
