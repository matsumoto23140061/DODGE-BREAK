using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }
    void Update()
    {
        scoreText.text = "Score" + GameManager.Instance.score.ToString();
    }
}
