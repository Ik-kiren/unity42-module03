using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{
    public TMP_Text leafPointText;
    public TMP_Text deathCountText;
    
    void Start()
    {
        leafPointText.text = PlayerPrefs.GetInt("leafPoint", 0).ToString();
        deathCountText.text = PlayerPrefs.GetInt("deathCount", 0).ToString();
        if (PlayerPrefs.GetInt("Stage1", 0) == 1 || PlayerPrefs.GetInt("Stage2", 0) == 1 || PlayerPrefs.GetInt("Stage3", 0) == 1)
            gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        if (PlayerPrefs.GetInt("Stage2", 0) == 1 || PlayerPrefs.GetInt("Stage3", 0) == 1)
            gameObject.transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        if (PlayerPrefs.GetInt("Stage3", 0) == 1)
            gameObject.transform.GetChild(2).GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
