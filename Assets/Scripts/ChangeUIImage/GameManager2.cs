using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static List<int> list = new List<int>();
    public static List<ButtonImage> buttonObjList = new List<ButtonImage>();

    public static bool successObj;
    private int score;


    public static List<Vector2Int> matList = new List<Vector2Int>();


    private void Update()
    {;
        CkeckAnswer();
    }

    //틀렸을때 리스트 초기화
    void CkeckAnswer()
    {
        if (list.Count > 2 && list[list.Count - 2] + 1 != list[list.Count - 1])
        {
            list.Clear();
            buttonObjList.Clear();
    }
        else if (list.Count > 2 && !PointDown.isDragging)
        {
            int point = list.Count;
            switch (point)
            {
                case 3:
                    score = score + 50;
                    Debug.Log("3개 성공");
                    Success();
                    break;
                case 4:
                    Debug.Log("4개 성공");
                    score = score + 80;
                    Success();
                    break;
                case 5:
                    Debug.Log("5개 성공");
                    score = score + 130;
                    Success();
                    break;
                case 6:
                    Debug.Log("6개 성공");
                    score = score + 200;
                    Success();
                    break;
                case 7:
                    Debug.Log("7개 성공");
                    score = score + 300;
                    Success();
                    break;
            }
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
        //string joined = string.Join(", ", matList);
        //Debug.Log($"matList 전체: [{joined}]");
        Debug.Log($"현제 점수는 {score}점 입니다");
        matList.Clear();
    }

}
