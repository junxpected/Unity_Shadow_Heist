using UnityEngine;
using UnityEngine.SceneManagement;

public class DiamondPickup : MonoBehaviour
{
    public GameObject exitZone;
    public float pickupRadius = 1.5f;

    private bool hasDiamond = false;
    private GameObject diamond;

    void Start()
    {
        diamond = GameObject.FindGameObjectWithTag("Diamond");
    }

    void Update()
    {
        if (!hasDiamond && diamond != null)
        {
            float dist = Vector2.Distance(transform.position, diamond.transform.position);
            if (dist < pickupRadius && Input.GetKeyDown(KeyCode.E))
            {
                hasDiamond = true;
                diamond.SetActive(false);
                if (exitZone != null) exitZone.SetActive(true);
                Debug.Log("Діамант підібрано! Іди до виходу.");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exit") && hasDiamond)
        {
            Debug.Log("Рівень пройдено!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}