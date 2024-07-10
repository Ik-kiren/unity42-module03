using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public GameObject fadeToBlack;
    GameObject player;

    GameObject pauseMenu;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
            /*QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 30;*/
        }
    }

    void Start()
    {
        player = GameObject.Find("Player");
        pauseMenu = GameObject.Find("PauseMenu");
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
    }

    void ChangeScene(GameObject newScene)
    {
        SceneManager.LoadScene(newScene.name);
    }

    public void ChangeScene(int newSceneIndex)
    {
        if (newSceneIndex < SceneManager.sceneCountInBuildSettings && newSceneIndex > 0)
            SceneManager.LoadScene(newSceneIndex);
    }

    public void QuitToTitle(Player player)
    {
        SavePlayerPrefs(player.currentHp, player.leafCount);
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

    void SavePlayerPrefs(int hp, int leafPoint)
    {
        PlayerPrefs.SetInt("stage", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("hp", hp);
        PlayerPrefs.SetInt("leafPoint", leafPoint);
    }

    public void NextScene()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayerIsDead()
    {
        fadeToBlack.GetComponent<Animator>().SetTrigger("fade");
    }

    public void PlayerRespawn()
    {
        fadeToBlack.GetComponent<Animator>().SetTrigger("fadeBack");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf == false)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}
