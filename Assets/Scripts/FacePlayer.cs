using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

    private Transform player;

    private float rotSpeed = 180f;

	void Update ()
    {
        // Look for Player object
		if(player == null)
        {
            GameObject go = GameObject.Find("PlayerShip");

            // Take players position as target
            if(go != null)
            {
                player = go.transform;
            }
        }

        // Found player of doesnt exist
        if (player == null) return;
        
        // FOUND PLAYER for certain
        // Position to aim for
        Vector3 dir = player.position - transform.position;
        dir.Normalize();    // Flattening Vector
        // Determining Z rotation angle
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        // Desired rotation to turn to
        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        // Updating rotation based on turn speed
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
    }
}
