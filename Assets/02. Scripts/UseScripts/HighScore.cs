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
        // ������ �� ����� �ְ� ���� �ҷ�����
        gameManager = FindAnyObjectByType<GameManager2>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }
    void Update()
    {
        currentScore = gameManager.score;
        if (gameManager.isGameOver)
        {
            // ���� ������ �ְ� ������ �Ѿ����� Ȯ��
            if (currentScore > highScore)
            {
                highScore = currentScore;
                highScoreText.text = "High Score: " + highScore;

                // �ְ� ���� ����
                PlayerPrefs.SetInt("HighScore", highScore);
                PlayerPrefs.Save();
            }
        }
    }
}
