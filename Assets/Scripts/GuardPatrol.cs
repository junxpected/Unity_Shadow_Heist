using UnityEngine;
using System.Collections;

public class GuardPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 1.5f;
    public float waitTime = 1.5f;

    private int current = 0;
    private bool isWaiting = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (waypoints.Length == 0 || isWaiting) return;

        Vector2 target = waypoints[current].position;
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(rb.position, target) < 0.1f)
            StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        current = (current + 1) % waypoints.Length;
        isWaiting = false;
    }
}