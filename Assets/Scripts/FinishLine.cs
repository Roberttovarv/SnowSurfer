using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    float DelayTime = 1f;
    ParticleSystem particles;

    void Awake()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }
    
    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collider.gameObject.layer == layerIndex)
        {
            particles.Play();
            Invoke("LoadScene", DelayTime);
        }
    }
}
