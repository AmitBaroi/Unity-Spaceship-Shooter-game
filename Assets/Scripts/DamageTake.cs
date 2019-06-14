using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTake : MonoBehaviour {

    [SerializeField]
    private int health = 1;

    private float invulTimer = 0f;
    [SerializeField]
    private float invulnerabilityDuration = 0f;

    private int startLayer;

    void Start()
    {
        // Default layer of object
        startLayer = gameObject.layer;
    }

    // When Collider is triggered
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Decrease health
        health--;
        // Give invulnerability for a duration
        invulTimer = invulnerabilityDuration;
        // Change Layer to Invulnerable (Layer 10)
        gameObject.layer = 10;

        if (gameObject.name == "PlayerShip") Debug.Log(gameObject.name + " HIT! Health: " + health);
    }

    void Update()
    {
        invulTimer -= Time.deltaTime;
        
        // When invulnerability time ends
        if (invulTimer < 0.0f)
        {
            // Go back to default layer
            gameObject.layer = startLayer;
        }
        // Death condition
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
