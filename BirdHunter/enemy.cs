using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] FollowPoints;

    [SerializeField]
    public bool flag = false;
    bool died = false;
    private float BatMoveSpeed = 3f;
    public int EnemyBatHealth = 100;
    public int HeroHealth = 100;
    public Animator BatAnims;
    public Rigidbody2D RB;
    public bool levelComplete = false;

    private int i;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = FollowPoints[i].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyBatHealth > 0 && HeroHealth > 0) {
            Movement();
        }
        
    }

    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, FollowPoints[i].transform.position,BatMoveSpeed * Time.deltaTime);
        
        if (transform.position == FollowPoints[i].transform.position)
        {
            i++;
        }
        if (i == FollowPoints.Length)
        {
            i = 0;
        }

        if (i >= 6)
        {
            
                transform.eulerAngles = new Vector3(0f, 180f, 0f);

        }
        if(i >= 12 || i < 5)
        {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        
    }

    public void OnHitBullet(int BulletDamage)
    {
        EnemyBatHealth -= BulletDamage;
        if (EnemyBatHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("deathbird");
            RB.gravityScale = 2;
            BatAnims.SetFloat("Die", 0.9f);
            Invoke("DieEnd", 3f);
            if (flag == false)
            {
                FindObjectOfType<AudioManager>().Play("yes");
                FindObjectOfType<AudioManager>().Play("victory");
                flag = true;
            }
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("hitbird");
            BatAnims.SetFloat("Hurt", 1f);
            Invoke("HurtEnd", 0.25f);
        }
    }
    void OnFinish()
    {

    }
    void HurtEnd()
    {
        BatAnims.SetFloat("Hurt", 0f);
    }
    void DieEnd()
    {
        Destroy(this);
        BatAnims.SetFloat("Die", 2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.GetComponent<hero>() != null)
        {
            hero Hr = collision.GetComponent<hero>();
            HeroHealth = Hr.OnHitEnemy(40);
        }
    }
}
