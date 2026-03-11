using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }
    void Update()
    {
        scoreText.text = GameManager.Instance.score.ToString();
    }
}
