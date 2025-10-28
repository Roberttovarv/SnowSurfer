using UnityEngine;

public class CharSelector : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject dinoSprite;
    [SerializeField] GameObject froggySprite;

    void Start()
    {
        Time.timeScale = 0;
        scoreCanvas.SetActive(false);
        dinoSprite.SetActive(false);
        froggySprite.SetActive(false);

    }

    void BeginGame()
    {
        Time.timeScale = 1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseDino()
    {
        dinoSprite.SetActive(true);
        BeginGame();
    }
    public void ChooseFroggy()
    {
        froggySprite.SetActive(true);
        BeginGame();
    }

}
