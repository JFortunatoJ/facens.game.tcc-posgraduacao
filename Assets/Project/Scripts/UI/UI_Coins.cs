using Blazewing.DataEvent;
using TMPro;
using UnityEngine;

namespace Project.Scripts.UI
{
    public class UI_Coins : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinsText;

        private void OnEnable()
        {
            DataEvent.Register<CoinsStruct>(OnCoinsUpdated);
        }

        private void OnDisable()
        {
            DataEvent.Unregister<CoinsStruct>(OnCoinsUpdated);
        }

        private void OnCoinsUpdated(CoinsStruct coins)
        {
            coinsText.text = coins.amount.ToString();
        }
    }
}
