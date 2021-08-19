using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnSeconds;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnSeconds);
            Instantiate(_template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint);
        }
    }
}
