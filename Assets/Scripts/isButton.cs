using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isButton : MonoBehaviour
{
    public int colorIndex; // Practice3¿¡¼­ ÇÒ´çµÊ
    public Button button;
    public int color;
    //private List<int> list = new List<int>();
    //public static List<int> result;


    public void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        Debug.Log(colorIndex);
        GameManager.list.Add(colorIndex);
    }

}

