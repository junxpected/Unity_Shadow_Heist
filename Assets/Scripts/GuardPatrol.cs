using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 1.5f;
    private int current = 0;

    void Update()
    {
        if (waypoints.Length == 0) return;
        Transform target = waypoints[current];
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
            current = (current + 1) % waypoints.Length;
    }
}