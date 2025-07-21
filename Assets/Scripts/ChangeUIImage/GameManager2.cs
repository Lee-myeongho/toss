using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static List<int> list = new();
    public static List<ButtonImage> buttonObjList = new();
    public static List<Vector2Int> matList = new();

    public static bool successObj;
    private int score;

    public RandomCreate randomCreateRef;

    void Start()
    {
        if (randomCreateRef == null)
            randomCreateRef = FindAnyObjectByType<RandomCreate>();
    }

    void Update()
    {
        CheckAnswer();

        if (CanCheckRemainingSequences())
        {
            randomCreateRef.InitializeCurrentActiveGrid();

            if (randomCreateRef.HasNoRemainingSequences())
            {
                Debug.Log("�� �̻� ���� ������ ����. ���� ���� �Ǵ� �� ��� ����!");
                // TODO: ���� ���� ó�� or ��� �����
            }
        }
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
