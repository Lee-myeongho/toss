﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager2 : MonoBehaviour
{
    public static List<int> list = new();
    public static List<ButtonImage> buttonObjList = new();
    public static List<Vector2Int> matList = new();

    public static bool successObj;
    public int score;
    public float timeLeft = 120f;
    public bool isGameOver = false;
    public GameObject gameOverPanel;
    public GameObject outroBackground;
    public GameObject gameBackgound;


    public RandomCreate randomCreateRef;
    public GameObject randomCreatePrefab;   // 프리팹 참조 (Inspector에서 넣기)
    private GameObject randomCreateInstance;

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
                //Debug.Log("리셋 로직 실행");
                randomCreateRef.ResetGrid();
            }
        }
    }

    private bool CanCheckRemainingSequences()
    {
        return !PointDown.isDragging && !successObj && randomCreateRef != null && list.Count == 0;
    }

    void CheckAnswer()
    {

        if (list.Count >= 2 && list[^2] + 1 != list[^1]) //틀리면 clear
        {
            list.Clear();
            buttonObjList.Clear();
        }
        else if (list.Count < 7 && !PointDown.isDragging) //6개 이하로 클릭했을때 clear
        {
            list.Clear();
            buttonObjList.Clear();
        }
        else if (list.Count == 7 && !PointDown.isDragging) //점수획득
        {
            score += 10;

            Debug.Log($"현재 점수: {score}");
            Success();
        }
    }

    void Success()
    {
        successObj = true;
        matList.Clear();
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
        outroBackground.SetActive(true);
        gameBackgound.SetActive(false);
        Time.timeScale = 0f;
        Debug.Log("GameOver");
    }

    

}
