using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static List<int> list = new List<int>();
    public static List<ButtonImage> buttonObjList = new List<ButtonImage>();

    public static bool successObj;


    private void Start()
    {
        InvokeRepeating("A", 1f, 1f);
    }

    private void Update()
    {;
        CkeckAnswer();
    }

    void A()
    {
        Debug.Log(string.Join(", ", list));
    }


    //Ʋ������ ����Ʈ �ʱ�ȭ
    void CkeckAnswer()
    {
        if (list.Count > 2 && list[list.Count - 2] + 1 != list[list.Count - 1])
        {
            //list = new List<int>();
            list.Clear();
            buttonObjList.Clear();
    }
        else if (list.Count > 2 && !PointDown.isDragging)
        {
            int point = list.Count;
            switch (point)
            {
                case 3:
                    Success();
                    Debug.Log("3�� ����");
                    break;
                case 4:
                    Success();
                    Debug.Log("4�� ����");
                    break;
                case 5:
                    Success();
                    Debug.Log("5�� ����");
                    break;
                case 6:
                    Success();
                    Debug.Log("6�� ����");
                    break;
                case 7:
                    Success();
                    Debug.Log("7�� ����");
                    break;
            }
        }
        else if (list.Count <= 2 && !PointDown.isDragging)
        {
            //list = new List<int>();
            list.Clear();
            buttonObjList.Clear();
        }
    }

    void Success()
    {
        successObj = true;
    }

}
