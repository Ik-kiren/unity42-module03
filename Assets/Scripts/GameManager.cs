using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public GameObject fadeToBlack;
    public List<GameObject> leafsInStage;

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
        GetLeafInStage();
    }

    public void GetLeafInStage()
    {
        for (int i = 0; i < leafsInStage.Count; i++)
        {
            if (PlayerPrefs.HasKey(leafsInStage[i].name) && PlayerPrefs.GetInt(leafsInStage[i].name) == 1)
                leafsInStage[i].SetActive(true);
            else if (PlayerPrefs.HasKey(leafsInStage[i].name))
                leafsInStage[i].SetActive(false);  
        }
    }

    public void SaveLeafInStage()
    {
        for (int i = 0; i < leafsInStage.Count; i++)
        {
            if (leafsInStage[i].activeSelf)
                PlayerPrefs.SetInt(leafsInStage[i].name, 1);   
            else
                PlayerPrefs.SetInt(leafsInStage[i].name, 0);  
        }
    }

    public void ChangeScene(int newSceneIndex)
    {
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        if (newSceneIndex < SceneManager.sceneCountInBuildSettings && newSceneIndex > 0)
            SceneManager.LoadScene(newSceneIndex);
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

    }
}
