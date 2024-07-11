using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeScene(String name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitToTitle(Player player)
    {
        GameManager.Instance.SavePlayerPrefs(player.currentHp, player.totalLeafPoint);
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleMenuScene");
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Stage1");
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("stage"));
    }

    public void SetUIActive(GameObject UI)
    {
        UI.SetActive(true);
    }
    public void SetUIDeactive(GameObject UI)
    {
        UI.SetActive(false);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }
}
