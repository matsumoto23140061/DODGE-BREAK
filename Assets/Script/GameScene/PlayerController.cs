using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float jumpMinusForce = 0.5f;
    public float size = 0.4f;

    float moveInput;
    bool isGround;

    public Transform groundCheckLeft;
    public Transform groundCheckCenter;
    public Transform groundCheckRight;
    public float groundCheckDistance = 0.1f;
    public LayerMask BanperLayer;

    banper currentPlatform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void OnMoveLeft(InputAction.CallbackContext ctx)
    {
        if (ctx.started || ctx.performed)
        {
            moveInput = -1f;
        }
        else if (ctx.canceled)
        {
            moveInput = 0;
        }
    }
    public void OnMoveRight(InputAction.CallbackContext ctx)
    {
        if (ctx.started || ctx.performed)
        {
            moveInput = 1f;
        }
        else if (ctx.canceled)
        {
            moveInput = 0;
        }
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (isGround && (ctx.started || ctx.performed))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        else if (ctx.canceled && rb.linearVelocity.y>0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y*jumpMinusForce);
        }
    }

    void Update()
    {
        if (!GameManager.Instance.isGameStarted)
        {
            moveInput = 0;
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            return;
        }
        isGround = CheckGround();

        anim.SetFloat("speed", Mathf.Abs(rb.linearVelocity.x));
        anim.SetBool("isGround", isGround);

        if (moveInput > 0)
            transform.localScale = new Vector3(size, size, size);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-size, size, size);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void LateUpdate()
    {
        if (currentPlatform != null)
            transform.position += currentPlatform.deltaMove();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out banper platform))
            currentPlatform = platform;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out banper platform))
        {
            if (currentPlatform == platform)
                currentPlatform = null;
        }
    }

    bool CheckGround()
    {
        return
            Physics2D.Raycast(groundCheckLeft.position, Vector2.down, groundCheckDistance, BanperLayer) ||
            Physics2D.Raycast(groundCheckCenter.position, Vector2.down, groundCheckDistance, BanperLayer) ||
            Physics2D.Raycast(groundCheckRight.position, Vector2.down, groundCheckDistance, BanperLayer);
    }
}
