using TMPro;
using UnityEngine;

public class CoinCountView : MonoBehaviour
{
    [SerializeField] private ItemCollector _items;
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
