using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianaController : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            anim.SetTrigger("attack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
