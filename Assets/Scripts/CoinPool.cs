using UnityEngine;
using System.Collections.Generic;

public class CoinPool : MonoBehaviour
{
    public static CoinPool Instance;

    public GameObject coinPrefab;
    public int poolSize = 3;

    private List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.SetActive(false);
            pool.Add(coin);
        }
    }

    public GameObject GetCoin()
    {
        foreach (GameObject coin in pool)
        {
            if (!coin.activeInHierarchy)
                return coin;
        }
        return null;
    }

    public void ReturnCoin(GameObject coin)
    {
        coin.SetActive(false);
    }
}