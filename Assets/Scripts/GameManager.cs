using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public GameObject fadeToBlack;

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
