using UnityEngine;
using UnityEngine.InputSystem;
public class banper : MonoBehaviour
{
    public GameObject ball;
    float moveInput;
    public float speed;
    Rigidbody2D rb;
    Vector3 startPos;
    Vector3 latePos;
    Vector2 delta;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>().x;
    }
    void Update()
    {
        startPos = transform.position;
        rb.linearVelocity = new Vector2(moveInput * speed, 0);
    }
    void LateUpdate()
    {
        latePos = transform.position;   
    }
    public Vector3 deltaMove()
    {
        delta = startPos - latePos;
        return delta;
    }
}
