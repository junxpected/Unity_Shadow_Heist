using UnityEngine;

public class Coin : MonoBehaviour
{
    public float lifetime = 3f;
    private float timer;

    void OnEnable()
    {
        timer = lifetime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
            CoinPool.Instance.ReturnCoin(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Guard"))
            CoinPool.Instance.ReturnCoin(gameObject);
    }
}