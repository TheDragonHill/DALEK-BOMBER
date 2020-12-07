
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deconstruct : MonoBehaviour
{
    public float timer = 0;

    void Update()
    {
		//Destroy Objects after some time
        if (timer == 80f && gameObject.tag == "Explosion")
        {
            Destroy(this.gameObject);
        }
        else if (timer == 800f && gameObject.tag == "Corpse")
        {
            Destroy(this.gameObject);
        }

        timer++;
    }
}
