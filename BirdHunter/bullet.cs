using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    public float BulletSpeed = 30f;
    public Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody.velocity = transform.right * BulletSpeed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Scene Name: " + SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name.ToLower().Trim() == "level 4")
        {
            if (collision.GetComponent<enemylvltwo>() != null)
            {
                enemylvltwo Bat = collision.GetComponent<enemylvltwo>();
                Bat.OnHitBullet(30);
            }
        }
        else if (SceneManager.GetActiveScene().name.ToLower().Trim() == "level 3")
        {
            if (collision.GetComponent<enemylvltwo>() != null)
            {
                enemylvltwo Bat = collision.GetComponent<enemylvltwo>();
                Bat.OnHitBullet(30);
            }
        }
        else if (SceneManager.GetActiveScene().name.ToLower().Trim() == "level 2")
        {
            if (collision.GetComponent<enemylvltwo>() != null)
            {
                enemylvltwo Bat = collision.GetComponent<enemylvltwo>();
                Bat.OnHitBullet(30);
            }
        }else if (SceneManager.GetActiveScene().name.ToLower().Trim() == "level 1")
        {
            if (collision.GetComponent<enemy>() != null)
            {
                enemy Bat = collision.GetComponent<enemy>();
                Bat.OnHitBullet(30);
            }
        }
        if (collision.GetComponent<enemy>() != null)
        {
            enemy Bat = collision.GetComponent<enemy>();
            Bat.OnHitBullet(30);
        }
        if (gameObject != null)
        {
            Destroy(gameObject);
        }


    }
}
