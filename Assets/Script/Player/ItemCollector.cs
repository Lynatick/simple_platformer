using UnityEngine;
using UnityEngine.Events;

public class ItemCollector : MonoBehaviour
{
    private int _coin;
    private string[] _itemsToCollect = { "Coin" };

    public event UnityAction<int> CoinChanged;

    public void IncreaseCoins()
    {
        _coin++;
        CoinChanged?.Invoke(_coin);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var value in _itemsToCollect)
            if (collision.gameObject.name == value + "(Clone)")
            {
                IncreaseCoins();
                Destroy(collision.gameObject);
            }
    }
}
