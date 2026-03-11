using UnityEngine;
public class ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float force;
    public PlayerDeath PlayerDeath;
    
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        int rl = Random.Range(0, 2)*2-1;
        float theta = Random.Range(45f, 60f);
        float rad = theta * Mathf.Deg2Rad;
        float x = rl * Mathf.Cos(rad) * force;
        float y = Mathf.Sin(rad) * force;
        this.rb.linearVelocity = new Vector2(x, y);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = rb.linearVelocity.normalized * force;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("banper"))
        {
            float hitPos =
                (transform.position.x - col.transform.position.x)
                / col.collider.bounds.size.x;

            Vector2 dir = new Vector2(hitPos, 1f).normalized;
            rb.linearVelocity = dir * force;
        }
        if (col.gameObject.name == "lowwerWall")
        {
            PlayerDeath.Die();
        }
    }
}
