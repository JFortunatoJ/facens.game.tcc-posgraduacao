using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.UI
{
    public class UI_SlotBehaviour : MonoBehaviour
    {
        public SlotBehaviour slot;
        [Space] [SerializeField] private TextMeshProUGUI miningTime;
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private CanvasGroup coinsCanvasGroup;
        [SerializeField] private Image waterIcon;
        [SerializeField] private Image buffIcon;
        [SerializeField] private Image selectedIndicator;

        public double RemainingSeconds
        {
            set
            {
                TimeSpan time = TimeSpan.FromSeconds(value);
                miningTime.text = $"{time.Minutes}:{time.Seconds}";
            }
        }

        public bool HasWater
        {
            get => slot.HasWater;
            set => waterIcon.enabled = value;
        }
        
        public bool HasBuff
        {
            get => slot.HasBuff;
            set => buffIcon.enabled = value;
        }

        public bool IsSelected
        {
            set => selectedIndicator.enabled = value;
        }

        public int Coins
        {
            set => coinsText.text = value.ToString();
        }

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            SlotsManager.SelectSlot(this);
        }

        public void SetCoinsVisibilityStatus(bool status)
        {
            coinsCanvasGroup.DOFade(status ? 1 : 0, .2f);
        }
    }
}
