using UnityEngine;

public class CactusController : MonoBehaviour
{
    public GameObject projectile;
    public bool rightSide = false;

    Animator anim;

    public float projectilePower = 9;

    void LaunchProjectile()
    {
        GameObject clone;
        clone = Instantiate(projectile);
        clone.transform.position = transform.position;
        if (!rightSide)
        {
            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.left * projectilePower);
            clone.GetComponent<Animator>().SetTrigger("left");
        }
        else
        {
            clone.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector3.right * projectilePower);
            clone.GetComponent<Animator>().SetTrigger("right");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") && !col.gameObject.GetComponent<Player>().isDead)
        {
            anim.SetTrigger("attackLeft");
        }
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
