using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float normalSpeed = 4.5f;
    public float stealthSpeed = 2.5f;

    [HideInInspector] public bool isInShadow = false;
    [HideInInspector] public bool isStealth = false;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(x, y).normalized;

        isStealth = Input.GetKey(KeyCode.LeftShift);
    }

    void FixedUpdate()
    {
        float speed = isStealth ? stealthSpeed : normalSpeed;
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}