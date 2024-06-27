using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float damage = 250;
    public float maxSize = 5;
    public float speed = 1;

    void Start()
    {
        transform.localScale= Vector3.zero;
    }

    void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * speed;
        if(transform.localScale.z > maxSize)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        var playerHelath = other.GetComponent<PlayerHealth>();
        if (playerHelath != null)
        {
            playerHelath.DealDamaged(damage);
        }

        var enemyHelath = other.GetComponent<EnemyHealth>();
        if (enemyHelath != null)
        {
            enemyHelath.DealDamaged(damage);
        }
    }
}
