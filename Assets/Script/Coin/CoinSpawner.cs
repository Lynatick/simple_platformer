using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _seconds;

    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _seconds)
        {
            _elapsedTime = 0;
            Instantiate(_template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint);
        }
    }
}
