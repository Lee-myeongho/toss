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
    public Vector2Int mat;
    private bool sideCheck = true;

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
            GameManager2.matList.Add(mat);
            hasClicked = true; // 한 번 실행되었음을 표시
            K();
            
            if (!sideCheck)
            {
                GameManager2.list.Clear();
                GameManager2.buttonObjList.Clear();
                GameManager2.matList.Clear();
            }
            sideCheck = true;
        }
    }

    private void objfalse()
    {
        if (buttonOnMouse && GameManager2.successObj && PointDown.isDragging == false)
        {
            foreach (ButtonImage button in GameManager2.buttonObjList)
            {
                button.gameObject.SetActive(false);
            }
            GameManager2.successObj = false;
            GameManager2.list.Clear();
            GameManager2.buttonObjList.Clear();
            GameManager2.matList.Clear();
        }
    }

    private void K()
    {
        if (GameManager2.matList.Count >= 2)
        {
            for (int i = 1; i < GameManager2.matList.Count; i++ )
            {
                Vector2Int X1 = GameManager2.matList[i - 1];
                Vector2Int X2 = GameManager2.matList[i];

                if (X1.x + 1 == X2.x && X1.y == X2.y)
                    sideCheck = true;
                else if (X1.x - 1 == X2.x && X1.y == X2.y)
                    sideCheck = true;
                else if (X1.x == X2.x && X1.y + 1 == X2.y)
                    sideCheck = true;

                else if (X1.x == X2.x && X1.y - 1 == X2.y)
                    sideCheck = true;
                else
                {
                    sideCheck = false;
                    break;
                }
            }
        }
        else
            return;
    }
}
