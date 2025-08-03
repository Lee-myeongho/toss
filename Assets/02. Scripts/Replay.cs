using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
    public Button resetButton;
    private GameManager2 gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager2>();
        resetButton.onClick.AddListener(GameReset);
    }

    private void GameReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
