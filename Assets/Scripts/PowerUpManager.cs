using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [SerializeField] PowerUp powerUp;
    PlayerController player;

    void Start()
    {
        player = Object.FindFirstObjectByType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D box)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        
        if (box.gameObject.layer == layerIndex)
        {
            player.ActivatePowerUp(powerUp);
        }
    }
}
