using UnityEngine;

public class TalletTwo : MonoBehaviour
{
    public GameObject balletPrefab;

    public TalletManager talletManager;
    public float force;
    float theta;
    Vector3 centerVec;
    void Start()
    {
        Vector3 targetPos = talletManager.player.transform.position;
        Vector3 thisPos = this.gameObject.transform.position;
        centerVec = (targetPos - thisPos).normalized;
        theta = Mathf.Atan2(centerVec.y , centerVec.x);

        for(int i = -1; i < 2; i++)
        {
            GameObject balletObject = Instantiate(balletPrefab);
            balletObject.transform.position = thisPos;
            Rigidbody2D rb = balletObject.GetComponent<Rigidbody2D>();
            Vector3 targetVec = new Vector3(Mathf.Cos(theta + (15*Mathf.Deg2Rad * i)), Mathf.Sin(theta + (15 * Mathf.Deg2Rad * i)), 0);
            rb.linearVelocity = targetVec.normalized*force;
        }
        Destroy(this.gameObject);
    }
}
