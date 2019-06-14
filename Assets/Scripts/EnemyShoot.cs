using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    [SerializeField]
    private Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    private float fireDelay = 0.5f;
    private float cooldown = 0f;

    void Update()
    {
        // Reduce cooldown
        cooldown -= Time.deltaTime;
        /* We wont use GetButtonDown as it requires rapid tap on 
        Fire button. GetButton Checks for button held down or not. */
        if (cooldown <= 0)
        {
            // Reset cooldown
            cooldown = fireDelay;
            // Offset the position we shoot from
            Vector3 offset = transform.rotation * bulletOffset;
            // Fire Laser/Bullet (from specified position and rotation)
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}
