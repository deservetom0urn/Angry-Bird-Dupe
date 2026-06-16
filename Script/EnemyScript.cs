using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{   
    public float hitVelocityLimit = 10f;
    public GameObject deathEffect;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {   
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude>hitVelocityLimit)
        {
            Die();
        }
    }
    void Die()
    {   
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        gameManager.EnemyDie();
    }
}
