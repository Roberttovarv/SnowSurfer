using UnityEngine;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider) {
        int layerIndex = LayerMask.NameToLayer("Player");

        if (collider.gameObject.layer == layerIndex)
        {
            Debug.Log("The player jas won");
        }
    }
}
