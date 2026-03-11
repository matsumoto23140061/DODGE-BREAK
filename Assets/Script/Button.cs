using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    public GameObject firstButton;
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
    public void ReStart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void GoTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void GameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
