using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] PowerUp powerUp;
    PlayerController player;
    SpriteRenderer sprite;
    float timeLeft;
    bool picked;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        player = Object.FindFirstObjectByType<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
        timeLeft = powerUp.GetTime();
    }

    void Update()
    {
        CountDown();
    }

    void OnTriggerEnter2D(Collider2D box)
    {
        if (picked) return;

        int layerIndex = LayerMask.NameToLayer("Player");

        if (box.gameObject.layer == layerIndex)
        {
            sprite.enabled = false;
            player.ActivatePowerUp(powerUp);
            picked = true;
        }
    }

    void CountDown()
    {
        if (sprite.enabled == false)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft <= 0)
                {
                    player.DeactivatePowerUp(powerUp);
                    picked = false;
                }
            }
        }
    }
}
