using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{

    void Start()
    {
        if (PlayerPrefs.GetInt(gameObject.name, 1) == 0)
            gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Player>().leafCount += 5;
            PlayerPrefs.SetInt(gameObject.name, 0);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
