using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager3 : MonoBehaviour
{
    public static List<int> list = new();
    public static List<ButtonImage> buttonObjList = new();
    public static List<Vector2Int> matList = new();

    public static bool successObj;
    public int score;
    public float timeLeft = 120f;
    public bool isGameOver = false;
    public GameObject gameOverPanel;

    public RandomCreate randomCreateRef;
    //public Button resetButton;
    public GameObject randomCreatePrefab;   // ������ ���� (Inspector���� �ֱ�)
    private GameObject randomCreateInstance;
    //private bool resetTrigger;

    void Start()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;

        if (randomCreateRef == null)
        {
            randomCreateRef = FindAnyObjectByType<RandomCreate>();

            if (randomCreateRef == null && randomCreatePrefab != null)
            {
                randomCreateInstance = Instantiate(randomCreatePrefab);
                randomCreateRef = randomCreateInstance.GetComponent<RandomCreate>();
            }
        }
        //resetButton.onClick.AddListener(() => resetTrigger = true);
    }

    void Update()
    {
        if (isGameOver) return;
        UpdateTimer();

        CheckAnswer();

        if (CanCheckRemainingSequences())
        {
            randomCreateRef.InitializeCurrentActiveGrid();

            if (randomCreateRef.HasNoRemainingSequences())
            {
                Debug.Log("���� ���� ����");
                randomCreateRef.ResetGrid();
            }
            //else if (randomCreateRef.HasNoRemainingSequences())
            //{
            //    Debug.Log("���� ��ư�� �����ּ���");
            //}
        }
    }

    void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            timeLeft = 0;
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("GameOver");
    }

    private bool CanCheckRemainingSequences()
    {
        return !PointDown.isDragging && !successObj && randomCreateRef != null && list.Count == 0;
    }

    void CheckAnswer()
    {
        if (list.Count > 2 && list[^2] + 1 != list[^1])
        {
            list.Clear();
            buttonObjList.Clear();
        }
        else if (list.Count > 2 && !PointDown.isDragging)
        {
            int point = list.Count;
            score += point switch
            {
                3 => 50,
                4 => 80,
                5 => 130,
                6 => 200,
                7 => 300,
                _ => 0
            };

            Debug.Log($"{point}�� ����! ���� ����: {score}");
            Success();
        }
        else if (list.Count <= 2 && !PointDown.isDragging)
        {
            list.Clear();
            buttonObjList.Clear();
        }
    }

    void Success()
    {
        successObj = true;
        matList.Clear();
    }



}
