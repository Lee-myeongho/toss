using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static List<int> list = new List<int>();

    private void Start()
    {
        InvokeRepeating("A", 1f, 3f);
    }

    private void Update()
    {
        CkeckAnswer();
    }

    void A()
    {
        Debug.Log(string.Join(", ", list));
    }

    void CkeckAnswer()
    {
        if(list.Count >= 2  && list[list.Count - 2] + 1 != list[list.Count - 1])
        {
            list = new List<int>();
        }
    }

}
