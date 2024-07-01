using UnityEngine.AI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 2;
    Rigidbody2D rb;
    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float xVel = Input.GetAxis("Horizontal");
        if (xVel != 0)
        {
            if (xVel > 0)
                anim.SetFloat("X", 1);
            else
                anim.SetFloat("X", -1);
            anim.SetBool("isWalking", true);
        }
        else if (xVel == 0)
        {
            anim.SetBool("isWalking", false);
        }
         Debug.Log(anim.GetFloat("X"));
        gameObject.transform.Translate(new Vector3(xVel, 0, 0) * Time.deltaTime * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 150, 0));
        }
    }
}
