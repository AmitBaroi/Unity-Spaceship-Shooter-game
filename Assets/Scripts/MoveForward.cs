using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 5;

	// Update is called once per frame
	void Update ()
    {
        // Getting our current position
        Vector3 pos = transform.position;
        // Creating our desired position change
        Vector3 velocity = new Vector3(0, moveSpeed * Time.deltaTime, 0);
        // Chaning our position based on rotation
        pos += transform.rotation * velocity;
        // Updating to new position
        transform.position = pos;
    }
}
