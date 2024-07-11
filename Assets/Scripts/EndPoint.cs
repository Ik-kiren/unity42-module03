using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public TMP_Text textEnoughPoint;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && col.gameObject.GetComponent<Player>().leafCount >= 25)
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
            PlayerPrefs.SetInt("stage", SceneManager.GetActiveScene().buildIndex + 1);
            GameManager.Instance.NextScene();
        }
        else
        {
           textEnoughPoint.gameObject.SetActive(true); 
        }
    }

    void OnTriggerExit2D()
    {
        textEnoughPoint.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
