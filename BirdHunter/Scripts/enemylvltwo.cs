using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class enemylvltwo : parentEnemy
{

    public parentEnemy script;
    [SerializeField]
    //private float BatMoveSpeed = 3f;
    public int EnemyBatHealth = 100;
    public int HeroHealth = 100;
    public Animator BatAnims;
    public Rigidbody2D RB;
    
    //private int i;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    //private void Movement()
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, FollowPoints[i].transform.position, BatMoveSpeed * Time.deltaTime);

    //    if (transform.position == FollowPoints[i].transform.position)
    //    {
    //        i++;
    //    }
    //    if (i == FollowPoints.Length)
    //    {
    //        i = 0;
    //    }

    //    if (i >= 6)
    //    {

    //        transform.eulerAngles = new Vector3(0f, 180f, 0f);

    //    }
    //    if (i >= 12 || i < 5)
    //    {
    //        transform.eulerAngles = new Vector3(0f, 0f, 0f);
    //    }


    //}

    public void OnHitBullet(int BulletDamage)
    {
        if (EnemyBatHealth > 0)
        {
            EnemyBatHealth -= BulletDamage;
            if (EnemyBatHealth <= 0)
            {
                FindObjectOfType<AudioManager>().Play("deathbird");
                RB.gravityScale = 2;
                BatAnims.SetFloat("Die", 0.9f);
                Invoke("DieEnd", 0.5f);
                FindObjectOfType<AudioManager>().Play("yes");
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("hitbird");
                BatAnims.SetFloat("Hurt", 1f);
                Invoke("HurtEnd", 0.25f);
            }
        }
    }

    public void HurtEnd()
    {
        BatAnims.SetFloat("Hurt", 0f);
    }
    public void DieEnd()
    {
        script.enemyNumbers--;
        BatAnims.SetFloat("Die", 2f);
    }
    //  void FinishGame()
    //  {
    //        Invoke("Finished", 3f);
    //  }
    //  void Finished()
    //   {
    //      if (SceneManager.GetActiveScene().buildIndex + 1 <= 3)
    //          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //       else
    //      {
    //          FindObjectOfType<AudioManager>().Play("victorylast");
    //         Debug.Log("Congradulations! you won!");
    //     }
    //   }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.GetComponent<hero>() != null)
        {
            hero Hr = collision.GetComponent<hero>();
            HeroHealth = Hr.OnHitEnemy(40);
        }
    }
}
