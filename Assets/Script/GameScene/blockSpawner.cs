using UnityEngine;
using System.Collections.Generic;

public class blockSpawner : MonoBehaviour
{
    public GameObject blockPrafab;
    public Queue<Vector3> spawnPosition = new Queue<Vector3>();
    public GameObject talletManager;
    void Start()
    {
        for(int i = 0; i < 6; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                GameObject blockObject = Instantiate(blockPrafab);

                block blockScript = blockObject.GetComponent<block>();
                blockScript.blockSpawner = this;
                TalletManager tmScript = talletManager.GetComponent<TalletManager>();
                blockScript.TalletManager = tmScript;

                float x = (float)((9.5 / 6.0) * i - (47.5 / 12.0));
                float y = (float)(4.1 - 0.7 * j);
                blockObject.transform.position = new Vector3(x, y, 0);
            }
        }
    }

    void Update()
    {
        if (spawnPosition.Count > 15)
        {
            Vector3 temp = spawnPosition.Dequeue();
            GameObject blockObject = Instantiate(blockPrafab);
            block blockScript = blockObject.GetComponent<block>();
            blockScript.blockSpawner = this;
            TalletManager tmScript = talletManager.GetComponent<TalletManager>();
            blockScript.TalletManager = tmScript;
            blockObject.transform.position = temp;
        }
    }
}
