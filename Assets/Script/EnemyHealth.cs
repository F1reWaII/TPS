using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float healthValue = 1000;

    // Update is called once per frame
    public void DealDamaged(float damage)
    {
        healthValue -= damage;

        if (healthValue <= 0)
        {
            Destroy(gameObject);
        }
    }
}
