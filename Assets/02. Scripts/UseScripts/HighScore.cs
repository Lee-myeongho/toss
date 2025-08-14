using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public TextMeshProUGUI highScoreText;

    private int highScore;
    private GameManager2 gameManager;

    void Start()
    {
        // 시작할 때 저장된 최고 점수 불러오기
        gameManager = FindAnyObjectByType<GameManager2>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }
    void Update()
    {
        currentScore = gameManager.score;
        if (gameManager.isGameOver)
        {
            // 현재 점수가 최고 점수를 넘었는지 확인
            if (currentScore > highScore)
            {
                highScore = currentScore;
                highScoreText.text = "High Score: " + highScore;

                // 최고 점수 저장
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
            }
        }
    }
}
