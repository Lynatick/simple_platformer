using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _player.CoinChanged += OnCoinChanged;
    }

    private void OnDisable()
    {
        _player.CoinChanged -= OnCoinChanged;
    }

    private void OnCoinChanged(int coin)
    {
        _text.text = coin.ToString();
    }
}
