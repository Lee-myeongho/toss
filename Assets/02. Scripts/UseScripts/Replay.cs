using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
    public Button resetButton;
    public RandomCreate randomCreateRef;
    public GameObject gameOver;
    private GameManager2 gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager2>();
        resetButton.onClick.AddListener(GameReset);
    }

    private void GameReset() //���� �ٽ��ϱ�
    {
        randomCreateRef.ResetGrid();
        GameManager2.list.Clear();
        gameManager.isGameOver = false;
        gameManager.score = 0;
        gameManager.timeLeft = 120f;
        Time.timeScale = 1f;
        gameOver.SetActive(false);
    }
}
