using UnityEngine;

public class EndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && col.gameObject.GetComponent<Player>().leafCount >= 25)
            GameManager.Instance.NextScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
