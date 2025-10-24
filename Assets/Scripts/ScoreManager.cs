using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    PlayerController player;

    void Awake()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
        player = Object.FindFirstObjectByType<PlayerController>();
    }

    void Update()
    {
        int score = player.GetFlipsScore();

        scoreText.text = $"Score: {score}";
    }
}
