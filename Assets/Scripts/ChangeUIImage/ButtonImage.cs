using System.Collections.Generic;
using UnityEngine;


// 이 스크립트는 UI 요소(Image 등)에 붙여서
// 사용자가 클릭하거나 드래그할 때 한 번만 실행되는 기능을 구현합니다.
public class ButtonImage : MonoBehaviour
{
    public int colorValue; // 클릭 시 GameManager에 전달할 값
    private bool hasClicked;
    public bool buttonOnMouse;
    public bool uiOnMouse;

    private RectTransform rectTransform; // 이 UI 오브젝트의 RectTransform

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // 마우스가 이 UI 위에 있는지 검사
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition))
        {
            buttonOnMouse = true;
        }
        else
        {
            buttonOnMouse = false;
        }

        MouseDrage();
        objfalse();
    }

    public void MouseDrage()
    {
        uiOnMouse = PointDown.isDragging;
        if(buttonOnMouse && uiOnMouse)
        {
            TryAddColor();
        }
        else
        {
            hasClicked = false;
        }
    }


    private void TryAddColor()
    {
        if (!hasClicked)
        {
            GameManager2.list.Add(colorValue); // GameManager2에 값 추가
            GameManager2.buttonObjList.Add(this);
            hasClicked = true; // 한 번 실행되었음을 표시
        }
    }

    private void objfalse()
    {
        if (buttonOnMouse && GameManager2.successObj && PointDown.isDragging == false)
        {
            foreach (ButtonImage button in GameManager2.buttonObjList)
            {
                //Debug.Log("dkdk");
                button.gameObject.SetActive(false);
            }
            GameManager2.successObj = false;
            //GameManager2.list = new List<int>();
            GameManager2.list.Clear();
            GameManager2.buttonObjList.Clear();
        }
    }
}
