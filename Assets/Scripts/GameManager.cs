using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<int> list = new List<int>();
    private void Start()
    {
        InvokeRepeating("A", 1f, 3f);
    }
    void A()
    {
        Debug.Log("result ����Ʈ ��: " + string.Join(", ", list));
    }

    public void TieColor(int color)
    {
        

        if (list.Count != 0 || list[list.Count - 1] + 1 != list[list.Count])
        {
            list = new List<int>();
        }

        //else if (list.Count >= 3 || ���� ������)
        //{
        //    ����ȹ��, ��ưfalse
        //}
    }
}
