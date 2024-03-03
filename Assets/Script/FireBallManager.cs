using UnityEngine;

public class FireBallManager : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float damage;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Invoke("DestroyFireInTheHole", lifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        EnemyDamaged(collision);
        
        DestroyFireInTheHole();
    }

    void EnemyDamaged(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamaged(damage);
        }
    }

    private void DestroyFireInTheHole() 
    {
        Destroy(gameObject);
    }

}
