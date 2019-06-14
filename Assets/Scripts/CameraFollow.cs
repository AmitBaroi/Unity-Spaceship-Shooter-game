using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform myTarget;

	void Update ()
    {
	    if(myTarget != null)
        {
            // Getting targets position
            Vector3 targPos = myTarget.position;
            // Setting camera z axis constant
            targPos.z = transform.position.z;
            // Updating to target position
            transform.position = targPos;
        }
	}
}
