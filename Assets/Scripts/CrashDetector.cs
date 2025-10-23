using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    float DelayTime = .3f;
    ParticleSystem particles;

    void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
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
            Invoke("LoadScene", DelayTime);
        }
    }

    void OnCollisionEnter2D(Collision2D table)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (table.gameObject.layer == layerIndex)
        {
            particles.Play();
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            particles.Stop();
        }
    }
}
