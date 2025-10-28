using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    float DelayTime = 1f;
    bool isTouchingFloor;
    public bool IsTouchingFloor => isTouchingFloor;

    ParticleSystem particles;
    PlayerController playerController;

    void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        playerController = Object.FindFirstObjectByType<PlayerController>();
        print("My player is: " + playerController);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (other.gameObject.layer == layerIndex)
        {
            playerController.DisableControls();
            Invoke("LoadScene", DelayTime);
        }
    }

    void OnCollisionEnter2D(Collision2D table)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (table.gameObject.layer == layerIndex)
        {
            particles.Play();
            isTouchingFloor = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            particles.Stop();
            isTouchingFloor = false;
        }
    }
}
