using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    private float delay = 3;

    public GameObject ExplosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", delay);
    }

    void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(ExplosionPrefab);
        explosion.transform.position= transform.position;   
    }
}
