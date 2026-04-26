using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldOfView : MonoBehaviour
{
    [Header("FOV Settings")]
    public float radius = 6f;
    [Range(0, 360)] public float angle = 90f;
    public LayerMask obstacleMask;

    private Transform player;
    private PlayerController playerController;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            player = p.transform;
            playerController = p.GetComponent<PlayerController>();
        }
    }

    void Update()
    {
        if (player == null) return;
        DetectPlayer();
    }

    void DetectPlayer()
    {
        float dist = Vector2.Distance(transform.position, player.position);
        if (dist > radius) return;

        Vector2 dirToPlayer = (player.position - transform.position).normalized;
        float angleToPlayer = Vector2.Angle(transform.up, dirToPlayer);

        if (angleToPlayer > angle / 2f) return;

        bool hidden = playerController.isInShadow && playerController.isStealth;
        if (!hidden)
            GameOver();
    }

    void GameOver()
    {
        Debug.Log("ВИЯВЛЕНО! Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0.2f, 0.1f, 0.4f);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}