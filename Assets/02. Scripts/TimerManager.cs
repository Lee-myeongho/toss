using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private GameManager3 gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager3>();
    }

    void Update()
    {
        if (gameManager != null && !gameManager.isGameOver)
            timerText.text = "Time: " + Mathf.CeilToInt(gameManager.timeLeft);
    }
}
