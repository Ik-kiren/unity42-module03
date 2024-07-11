using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 2;
    public int totalLeafPoint = 0;
    public int leafCount = 0;
    public float jumpPower = 2;
    Rigidbody2D rb;
    Animator anim;
    bool isJumping = false;
    public bool isDead = false;
    public AudioClip takeDamageSound;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip respawnSound;

    public Transform startTransform;

    public Slider hpSlider;

    public int maxHp = 3;
    public int currentHp;
    void Start()
    {
        currentHp = maxHp;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.position = startTransform.position;
        totalLeafPoint = PlayerPrefs.GetInt("leafPoint", 0);
    }

    void SetPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("hp") && PlayerPrefs.HasKey("leafpoint"))
        {
            currentHp = PlayerPrefs.GetInt("hp");
            leafCount = PlayerPrefs.GetInt("leafPoint");
        }
    }

    public void TakeDamage()
    {
        anim.SetTrigger("takeDamage");
        GetComponent<AudioSource>().PlayOneShot(takeDamageSound);
        currentHp--;
        if (currentHp == 0)
        {
            GameManager.Instance.PlayerIsDead();
            isDead = true;
            anim.SetBool("isDead", true);
            return;
        }
        hpSlider.gameObject.SetActive(true);
        hpSlider.value = currentHp;
        PlayerPrefs.GetInt("hp", currentHp);
    }

    public void HideHp()
    {
        hpSlider.gameObject.SetActive(false);
    }

    void PlayRespawnSound()
    {
        GetComponent<AudioSource>().PlayOneShot(respawnSound);
    }

    void PlayDeathSond()
    {
        GetComponent<AudioSource>().PlayOneShot(deathSound);
    }

    void SetRespawnBool()
    {
        GameManager.Instance.PlayerRespawn();
        anim.SetBool("isDead", false);
        anim.SetBool("isRespawning", true);
        transform.position = startTransform.position;
        isDead = false;
        currentHp = maxHp;
    }

    void FixedUpdate()
    {
        if (!isDead)
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
            gameObject.transform.Translate(new Vector3(xVel, 0, 0) * Time.deltaTime * speed);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Trap"))
            anim.SetTrigger("takeDamage");
        isJumping = false;
        anim.SetBool("isJumping", isJumping);
    }

    void OnCollisionStay2D()
    {
        isJumping = false;
        anim.SetBool("isJumping", isJumping);
    }

    void OnCollisionExit2D()
    {
        isJumping = true;
        anim.SetBool("isJumping", isJumping);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isDead)
        {
            GetComponent<AudioSource>().PlayOneShot(jumpSound);
            rb.AddForce(new Vector3(0, 150, 0) * jumpPower);
            //isJumping = true;
            //anim.SetBool("isJumping", isJumping);
        }
        hpSlider.gameObject.transform.position = transform.position;
    }
}
