using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{
    [SerializeField] public float jumpForce = 7f;
    public float HeroWalkSpeed = 6f;
    public Rigidbody2D rigidBody;
    float horizontalInput;
    private bool isGrounded = true;
    public float axisValue = 1f;
    public Animator anims;
    public Transform FirePoint;
    public GameObject GunBullet;
    public float BulletSpeed = 30f;
    public int heroHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        FirePoint.localPosition = new Vector3(3f, -0.91f, 0);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            axisValue = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            axisValue = -1f;
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            if (!PauseMenu.isPaused)
            {
                Instantiate(GunBullet, FirePoint.position, FirePoint.rotation);
                anims.SetFloat("Shoot", 1f);
                Invoke("shootEnd", 0.5f);
            }
        }
        
    }
    
    void FixedUpdate()
    {
        transform.position += new Vector3(horizontalInput * HeroWalkSpeed * Time.deltaTime, 0, 0);
        
        anims.SetFloat("Horizontal", axisValue);
        
        anims.SetFloat("speed", horizontalInput * horizontalInput);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            FindObjectOfType<AudioManager>().Play("jump");
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anims.SetFloat("Force", 1f);
            isGrounded = false;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            FindObjectOfType<AudioManager>().Play("jump");
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anims.SetFloat("Force", 1f);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anims.SetFloat("Force", 0f);
        }
    }

    

    public int OnHitEnemy(int HeroDamage)
    {
        heroHealth -= HeroDamage;
        if (heroHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            anims.SetFloat("HeroDie", 1f);
            FindObjectOfType<AudioManager>().Play("gameover1");
            Invoke("HeroDieEnd", 0.5f);
        }
        else
        {
            transform.position = new Vector2(-8.46f, -3.98f);
            anims.SetFloat("HeroHurt", 0.4f);
            FindObjectOfType<AudioManager>().Play("hit");
            Invoke("HeroHurtEnd", 0.5f);
        }
        return heroHealth;
    }

    void HeroDieEnd()
    {
        anims.SetFloat("HeroDie", 2f);
        FindObjectOfType<AudioManager>().Play("gameover2");
        Invoke("gameover", 3f);
    }
    void gameover()
    {
        SceneManager.LoadScene("YouLost");
    }
    void HeroHurtEnd()
    {
        anims.SetFloat("Hero", 0.5f);
    }

    private void shootEnd()
    {
        anims.SetFloat("Shoot", 0f);
    }

}
