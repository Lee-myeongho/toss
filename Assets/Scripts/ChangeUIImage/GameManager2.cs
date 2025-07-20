using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static List<int> list = new List<int>();
    public static List<ButtonImage> buttonObjList = new List<ButtonImage>();

    public static bool successObj;
    private int score;


    public static List<Vector2Int> matList = new List<Vector2Int>();


    public RandomCreate randomCreateRef; // RandomCreate ��ũ��Ʈ ���� �߰�

    void Start()
    {
        // RandomCreate �ν��Ͻ��� ã�� ����
        if (randomCreateRef == null)
        {
            randomCreateRef = FindAnyObjectByType<RandomCreate>();
        }
    }

    private void Update()
    {
        CkeckAnswer(); // ���� ����

        // ���� ���, �巡�װ� ���� �Ŀ� ���� �������� �ִ��� Ȯ��
        if (!PointDown.isDragging && !GameManager2.successObj) // ���� ó�� �� ���µ� ���¿��� Ȯ��
        {
            if (randomCreateRef != null && list.Count == 0) // ���� �巡�� �������� ����ְ�, ���� ���°� �ƴ� ���
            {
                // ���� Ȱ��ȭ�� ��ư��� �׸��带 ������Ʈ
                randomCreateRef.InitializeCurrentActiveGrid();

                if (randomCreateRef.HasNoRemainingSequences())
                {
                    Debug.Log("�� �̻� 3�� �̻��� �������� �������� �������� �ʽ��ϴ�! ���� ���� �Ǵ� ���ο� ��� ����!");
                    // ���⿡ ���� ���� ���� �Ǵ� ���ο� ��� ���� ������ �߰��ϼ���.
                }
            }
        }
    }

    //Ʋ������ ����Ʈ �ʱ�ȭ
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
                    Debug.Log("3�� ����");
                    Success();
                    break;
                case 4:
                    Debug.Log("4�� ����");
                    score = score + 80;
                    Success();
                    break;
                case 5:
                    Debug.Log("5�� ����");
                    score = score + 130;
                    Success();
                    break;
                case 6:
                    Debug.Log("6�� ����");
                    score = score + 200;
                    Success();
                    break;
                case 7:
                    Debug.Log("7�� ����");
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
        //Debug.Log($"matList ��ü: [{joined}]");
        Debug.Log($"���� ������ {score}�� �Դϴ�");
        matList.Clear();
    }

}
