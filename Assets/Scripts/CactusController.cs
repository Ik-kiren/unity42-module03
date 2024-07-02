using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusController : MonoBehaviour
{
    public GameObject projectile;

    Animator anim;

    public float projectilePower = 9;

    void LaunchProjectile()
    {
        GameObject clone;
        clone = Instantiate(projectile);
        clone.transform.position = transform.position;
        clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.left * projectilePower);
    }

    void OnTriggerEnter2D()
    {
        anim.SetTrigger("attack");
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
