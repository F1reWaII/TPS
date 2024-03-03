using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float healthValue = 1000;

    public RectTransform ValueRectTransform;

    public GameObject playerUI;
    public GameObject gameOverUI;

    private float _maxHealthValue;

    private void Start()
    {
        _maxHealthValue = healthValue;
        DrawHealthBar();
    }

    // Update is called once per frame
    public void DealDamaged(float damage)
    {
        healthValue -= damage;

        if (healthValue <= 0)
        {

            PlayerIsDead();

        }

        DrawHealthBar();
    }

    private void PlayerIsDead()
    {
        playerUI.SetActive(false);
        gameOverUI.SetActive(true);
        GetComponent<Player>().enabled= false;
        GetComponent<FireBallCast>().enabled = false;
        GetComponent<CameraController>().enabled = false;
    }

    void DrawHealthBar()
    {
        ValueRectTransform.anchorMax = new Vector2(healthValue / _maxHealthValue, 1);
    }
}

