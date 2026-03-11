using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ExplainPanel : MonoBehaviour
{
    public GameObject rule;
    public GameObject sousa;
    public GameObject rulePanel;
    public GameObject sousaPanel;
    public bool ruleActive = true;
    void Start()
    {
        if (ruleActive)
        {
            rule.GetComponent<Image>().color = Color.gray5;
            rulePanel.SetActive(true);
            sousaPanel.SetActive(false);
        }
        else
        {
            sousa.GetComponent<Image>().color = Color.gray5;
            rulePanel.SetActive(false);
            sousaPanel.SetActive(true);
        }
    }
    public void Setumei()
    {
        SceneManager.LoadScene("ExplainScene");
    }
    public void BackButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void RuleExplain()
    {
        if (!ruleActive)
        {
            ruleActive = true;
            sousa.GetComponent<Image>().color = Color.white;
            rule.GetComponent<Image>().color = Color.gray5;
            rulePanel.SetActive(true);
            sousaPanel.SetActive(false);
        }
    }
    public void SousaExplain()
    {
        if (ruleActive)
        {
            ruleActive = false;
            rule.GetComponent<Image>().color = Color.white;
            sousa.GetComponent<Image>().color = Color.gray5;
            rulePanel.SetActive(false);
            sousaPanel.SetActive(true);
        }
    }
}
