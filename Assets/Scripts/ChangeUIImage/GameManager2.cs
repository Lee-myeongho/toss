using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static List<int> list = new List<int>();
    public static bool successObj;


    private void Start()
    {
        InvokeRepeating("A", 1f, 3f);
    }

    private void Update()
    {
        //successObj = false;
        CkeckAnswer();
    }

    void A()
    {
        Debug.Log(string.Join(", ", list));
    }


    //Ʋ������ ����Ʈ �ʱ�ȭ
    void CkeckAnswer()
    {
        if (list.Count >= 2 && list[list.Count - 2] + 1 != list[list.Count - 1])
        {
            list = new List<int>();
        }
        else if (list.Count >= 2 && !PointDown.isDragging)
        {
            int point = list.Count;
            switch (point)
            {
                case 3:
                    Debug.Log("3�� ����");
                    Success();
                    break;
                case 4:
                    Debug.Log("4�� ����");
                    Success();
                    break;
                case 5:
                    Debug.Log("5�� ����");
                    Success();
                    break;
                case 6:
                    Debug.Log("6�� ����");
                    Success();
                    break;
            }
        }
    }

    void Success()
    {
        successObj = true;
        list = new List<int>();
    }

}
