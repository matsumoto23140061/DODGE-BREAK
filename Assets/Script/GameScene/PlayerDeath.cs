using UnityEngine;
public class PlayerDeath : MonoBehaviour
{
    public GameObject ball;
    Animator anim;
    Rigidbody2D prb;
    Collider2D pcol;
    Rigidbody2D brb;
    Collider2D bcol;
    void Start()
    {
        anim = GetComponent<Animator>();
        prb = GetComponent<Rigidbody2D>();
        pcol = GetComponent<BoxCollider2D>();
        brb = ball.GetComponent<Rigidbody2D>();
        bcol = ball.GetComponent<CircleCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("ball")) ||(collision.gameObject.CompareTag("Enemy")))
        {
            Die();
        }
    }
    public void Die()
    {
        GameManager.Instance.isDead = true;
        anim.SetTrigger("Dead");

        prb.linearVelocity = Vector2.zero;
        prb.simulated = false;
        pcol.enabled = false;

        brb.linearVelocity = Vector2.zero;
        brb.simulated = false;
        bcol.enabled = false;
        GameManager.Instance.GoScore();
    }
    public void OnDeadEnd()
    {
        Destroy(gameObject);
    }
}
