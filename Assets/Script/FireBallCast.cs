using UnityEngine;

public class FireBallCast : MonoBehaviour
{

    public GameObject fireBallPrefab;
    public Transform TargetPoint;

    public float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.2f)
        {
            Shot();
            timer = 0;
        }

    }

    void Shot()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(fireBallPrefab, TargetPoint.position, TargetPoint.rotation);
        }
    }
}
