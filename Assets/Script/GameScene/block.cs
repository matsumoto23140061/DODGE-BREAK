using UnityEngine;

public class block : MonoBehaviour
{
    public blockSpawner blockSpawner;
    public TalletManager TalletManager;
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ball")) {
            blockSpawner.spawnPosition.Enqueue(this.transform.position);
            TalletManager.TalletSpawn(this.transform.position);
            GameManager.Instance.score++;
            Destroy(this.gameObject);
        }
    }
}
