using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float moveSpeed = 3.5f;
    [SerializeField]
    private float rotationSpeed = 180f;

    private float shipBoundRadius = 0.5f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is MORE PREFERED when dealing with USER INPUT
	void Update ()
    {
        // Getting user input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        //////ROTATION//////
        // Getting our current rotation
        Quaternion rot = transform.rotation;
        // Getting the z angle
        float z = rot.eulerAngles.z;
        // Changin the z angle
        z -= horizontal * rotationSpeed * Time.deltaTime;
        // Making the desired rotation set
        rot = Quaternion.Euler(0, 0, z);
        // Updating transform to NEW rotation
        transform.rotation = rot;

        //////FORWARD MOVEMENT//////
        // Getting our current position
        Vector3 pos = transform.position;
        // Creating our desired position change
        Vector3 velocity = new Vector3(0, vertical * moveSpeed * Time.deltaTime, 0);
        // Chaning our position based on rotation
        pos += rot * velocity;

        
        //////SCREEN BOUNDARIES//////
        // Top bound
        if (pos.y + shipBoundRadius > Camera.main.orthographicSize)
        {
            pos.y = Camera.main.orthographicSize - shipBoundRadius;
        }
        // Bottom bound
        if (pos.y - shipBoundRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + shipBoundRadius;
        }
        // Getting screen dimensions (to calculate for horizontal bounds(since x axis is dynamic))
        float screenRatio = (float)Screen.width / (float)Screen.height; // Casting float since Screen w & h are ints
        float widthOrtho = Camera.main.orthographicSize * screenRatio;
        // Right Bound
        if (pos.x + shipBoundRadius > widthOrtho)
        {
            pos.x = widthOrtho - shipBoundRadius;
        }
        // Left bound
        if (pos.x - shipBoundRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + shipBoundRadius;
        }

        // Updating transform to NEW position
        transform.position = pos;
    }
}
