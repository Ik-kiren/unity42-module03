using UnityEngine;

public class LianaController : MonoBehaviour
{
    Animator anim;
    public AudioClip lianaAttackSound;
    public bool rightSide = false;
    GameObject playerInRange = null;
    float cooldownAttack;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void LianaAttack()
    {
        GetComponent<AudioSource>().PlayOneShot(lianaAttackSound);
        if (playerInRange != null)
        {
            Debug.Log(playerInRange);
            playerInRange.GetComponent<Player>().TakeDamage();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            playerInRange = col.gameObject;
        if (col.gameObject.CompareTag("Player") && !col.gameObject.GetComponent<Player>().isDead && cooldownAttack >= 2)
        {
            if (!rightSide)
                anim.SetTrigger("attackLeft");
            else
                anim.SetTrigger("attackRight");
            cooldownAttack = 0;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            playerInRange = null; 
    }

    // Update is called once per frame
    void Update()
    {
        cooldownAttack += Time.deltaTime;
    }
}
