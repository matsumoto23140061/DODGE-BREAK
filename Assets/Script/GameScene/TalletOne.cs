using UnityEngine;

public class TalletOne : MonoBehaviour
{
    public GameObject balletPrefab;

    public TalletManager talletManager;
    public float force;
    void Start()
    {
        Vector3 targetPos = talletManager.player.transform.position;
        Vector3 thisPos = this.gameObject.transform.position;
        GameObject balletObject = Instantiate(balletPrefab);
        balletObject.transform.position = thisPos;
        Rigidbody2D rb = balletObject.GetComponent<Rigidbody2D>();
        rb.linearVelocity =(targetPos-thisPos).normalized*force;
        Destroy(this.gameObject);
    }
}
