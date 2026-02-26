using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const float Delay = 0.4f;

    [SerializeField] private Transform[] _spawnPoint;
    [SerializeField] private Coin _coin;

    private WaitForSeconds _wait = new WaitForSeconds(Delay);

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private void DestroyObject(Coin coin)
    {
        Destroy(coin.gameObject);
    }

    private IEnumerator SpawnObject()
    {
        for (int i = 0; i < _spawnPoint.Length; i++)
        {
            Coin coin = Instantiate(_coin, _spawnPoint[i].position, Quaternion.identity);
            coin.CoinSelected += DestroyObject;

            yield return _wait;
        }
    }
}