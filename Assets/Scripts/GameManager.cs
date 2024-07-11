using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    GameObject fadeToBlack;
    public GameObject player;

    GameObject pauseMenu;
    int deathCount = 0;

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
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        /*player = GameObject.Find("Player");
        pauseMenu = GameObject.Find("PauseMenu");
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
        deathCount = PlayerPrefs.GetInt("deathCount", 0);*/
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        fadeToBlack = GameObject.Find("FadeToBlack");
        player = GameObject.Find("Player");
        pauseMenu = GameObject.Find("PauseMenu");
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
        deathCount = PlayerPrefs.GetInt("deathCount", 0);
    }

    public void SavePlayerPrefs(int hp, int leafPoint)
    {
        PlayerPrefs.SetInt("stage", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("hp", hp);
        PlayerPrefs.SetInt("leafPoint", leafPoint);
    }


    public void ChangeScene(int newSceneIndex)
    {
        if (newSceneIndex < SceneManager.sceneCountInBuildSettings && newSceneIndex > 0)
            SceneManager.LoadScene(newSceneIndex);
    }

    public void NextScene()
    {
        ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayerIsDead()
    {
        deathCount++;
        PlayerPrefs.SetInt("deathCount", deathCount);
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
         if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
