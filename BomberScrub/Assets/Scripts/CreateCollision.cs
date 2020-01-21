using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateCollision : MonoBehaviour
{
    public float delayTime = 3f;
    public void OnParticleCollision(GameObject other)
    {
        if(other.tag == "crate")
        {
            Destroy(other, 2f);
        }
        if (other.tag == "player1")
        {
            Destroy(other, 2f);
            Invoke("DelayedAction", delayTime);
        }
    }
    void DelayedAction()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene("Menu");

    }

}
