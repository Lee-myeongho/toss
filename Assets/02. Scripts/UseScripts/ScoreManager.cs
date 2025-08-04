using UnityEngine;
using TMPro;

public class ScoreManger : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOverScoreText;
    private GameManager2 gameManager;


    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager2>();
    }

    void Update()
    {
        scoreText.text = "Score: " + gameManager.score;
        GameOverScoreText.text = "Á¡¼ö: " + gameManager.score;
    }
}

