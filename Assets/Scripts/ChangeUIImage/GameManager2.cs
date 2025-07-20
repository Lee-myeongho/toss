using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static List<int> list = new List<int>();
    public static List<ButtonImage> buttonObjList = new List<ButtonImage>();

    public static bool successObj;
    private int score;


    public static List<Vector2Int> matList = new List<Vector2Int>();


    public RandomCreate randomCreateRef; // RandomCreate 스크립트 참조 추가

    void Start()
    {
        // RandomCreate 인스턴스를 찾아 참조
        if (randomCreateRef == null)
        {
            randomCreateRef = FindAnyObjectByType<RandomCreate>();
        }
    }

    private void Update()
    {
        CkeckAnswer(); // 기존 로직

        // 예를 들어, 드래그가 끝난 후에 남은 시퀀스가 있는지 확인
        if (!PointDown.isDragging && !GameManager2.successObj) // 성공 처리 후 리셋된 상태에서 확인
        {
            if (randomCreateRef != null && list.Count == 0) // 현재 드래그 시퀀스가 비어있고, 성공 상태가 아닌 경우
            {
                // 현재 활성화된 버튼들로 그리드를 업데이트
                randomCreateRef.InitializeCurrentActiveGrid();

                if (randomCreateRef.HasNoRemainingSequences())
                {
                    Debug.Log("더 이상 3개 이상의 연속적인 시퀀스가 남아있지 않습니다! 게임 오버 또는 새로운 블록 생성!");
                    // 여기에 게임 오버 로직 또는 새로운 블록 생성 로직을 추가하세요.
                }
            }
        }
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
