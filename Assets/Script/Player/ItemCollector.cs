using UnityEngine;
using UnityEngine.Events;

public class ItemCollector : MonoBehaviour
{
    private int _coin;

    public event UnityAction<int> CountChanged;

    public void IncreaseCoins()
    {
        _coin++;
        CountChanged?.Invoke(_coin);
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
