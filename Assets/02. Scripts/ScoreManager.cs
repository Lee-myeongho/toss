using UnityEngine;
using TMPro;

public class ScoreManger : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private GameManager3 gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager3>();
    }

    void Update()
    {
        scoreText.text = "Score: " + gameManager.score;
    }
}

