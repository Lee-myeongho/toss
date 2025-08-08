using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Button gameStartButton;
    public GameObject gameBackground;
    public GameObject manager;
    public GameObject introBackground;

    private void Start()
    {
        gameStartButton.onClick.AddListener(PlayGameStart);
    }

    void PlayGameStart()
    {
        gameBackground.SetActive(true);
        manager.SetActive(true);
        introBackground.SetActive(false);
        this.gameObject.SetActive(false);
        
    }
}
