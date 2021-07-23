using TMPro;
using UnityEngine;

public class ViewCountCoins : MonoBehaviour
{
    [SerializeField] private CollectionOfItems _items;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _items.CoinChanged += OnCoinChanged;
    }

    private void OnDisable()
    {
        _items.CoinChanged -= OnCoinChanged;
    }

    private void OnCoinChanged(int coin)
    {
        _text.text = coin.ToString();
    }
}
