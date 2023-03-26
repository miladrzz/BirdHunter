using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class parentEnemy : MonoBehaviour
{
    public int enemyNumbers;
    public bool endgame = false;
    // Start is called before the first frame update
    void Update()
    {
        if (enemyNumbers == 0 && endgame == false)
        {
            endgame = true;
            onFinish();
        }
    }
    void onFinish()
    {
        FindObjectOfType<AudioManager>().Play("victory");
        if(SceneManager.GetActiveScene().buildIndex==6)
        {
            FindObjectOfType<AudioManager>().Play("victorylast");
        }
        Invoke("Finished", 3f);
    }
    void Finished()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 <= 6)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
        {
            SceneManager.LoadScene("YouWon");
        }
    }
}
