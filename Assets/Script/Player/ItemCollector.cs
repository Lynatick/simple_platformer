using UnityEngine;
using UnityEngine.Events;

public class ItemCollector : MonoBehaviour
{
    private int _coinCount;

    public event UnityAction<int> CountChanged;

    public void IncreaseCoins()
    {
        _coinCount++;
        CountChanged?.Invoke(_coinCount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            IncreaseCoins();
            Destroy(collision.gameObject);
        }
    }
}
