using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button gameStartButton;
    public GameObject gameBackground;
    public GameObject manager;

    private void Start()
    {
        gameStartButton.onClick.AddListener(PlayGameStart);
    }

    void PlayGameStart()
    {
        gameBackground.SetActive(true);
        manager.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
