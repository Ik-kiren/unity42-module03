using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GetComponent<Animator>().SetTrigger("Push");
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 150, 0) * 6);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
