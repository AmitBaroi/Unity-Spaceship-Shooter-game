using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    [SerializeField]
    private float timer = 3f;
    	
	void Update ()
    {
        // Reduce timer
        timer -= Time.deltaTime;
        // When timer hits 0
        if(timer <= 0)
        {
            // Remove object from game
            Destroy(gameObject);
        }

    }
}
