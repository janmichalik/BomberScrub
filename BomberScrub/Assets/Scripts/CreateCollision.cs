using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCollision : MonoBehaviour
{

    public void OnParticleCollision(GameObject other)
    {
        if(other.tag == "crate")
        {
            Destroy(other, 2f);
        }
    }

}
