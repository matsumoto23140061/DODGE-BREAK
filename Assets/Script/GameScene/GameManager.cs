using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public bool isDead = false;
    public TextMeshProUGUI countdownText;
    public bool isGameStarted = false;
    public GameObject ball;
    
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        score = 0;
        StartCoroutine(StartCountdown());
    }
    IEnumerator StartCountdown()
    {
        ball.SetActive(false);
        isGameStarted = false;
        countdownText.gameObject.SetActive(true);
        countdownText.text = "Ready";
        yield return new WaitForSeconds(1f);

        countdownText.text = "Start";
        yield return new WaitForSeconds(0.5f);

        countdownText.gameObject.SetActive(false);
        ball.SetActive(true);
        isGameStarted = true;
    }
    public void GoScore()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("ScoreScene");
    }
}
