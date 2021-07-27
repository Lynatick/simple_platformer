using TMPro;
using UnityEngine;

public class CoinCountView : MonoBehaviour
{
    [SerializeField] private ItemCollector _items;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _items.CountChanged += OnCountChanged;
    }

    private void OnDisable()
    {
        _items.CountChanged -= OnCountChanged;
    }

    private void OnCountChanged(int coin)
    {
        _text.text = coin.ToString();
    }
}
