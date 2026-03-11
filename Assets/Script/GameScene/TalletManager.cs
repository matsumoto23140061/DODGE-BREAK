using UnityEngine;

public class TalletManager : MonoBehaviour
{
    public GameObject[] talletPrefabs = new GameObject[2];
    public GameObject player;

    public void TalletSpawn(Vector3 spawnPos)
    {
        GameObject tallet=null;
        if (GameManager.Instance.score < 15)
        {
            tallet = Instantiate(talletPrefabs[0]);
            TalletOne tOneScript = tallet.GetComponent<TalletOne>();
            TalletManager tmScript = this.gameObject.GetComponent<TalletManager>();
            tOneScript.talletManager = tmScript;
        }
        else if(GameManager.Instance.score < 30)
        {
            tallet = Instantiate(talletPrefabs[1]);
            TalletTwo tTwoScript = tallet.GetComponent<TalletTwo>();
            TalletManager tmScript = this.gameObject.GetComponent<TalletManager>();
            tTwoScript.talletManager = tmScript;
        }
        else
        {
            tallet = Instantiate(talletPrefabs[2]);
            TalletThree tThreeScript = tallet.GetComponent<TalletThree>();
            TalletManager tmScript = this.gameObject.GetComponent<TalletManager>();
            tThreeScript.talletManager = tmScript;
        }
        tallet.transform.position = spawnPos;
    }
}
