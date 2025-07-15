using System.Collections.Generic;
using UnityEngine;


// �� ��ũ��Ʈ�� UI ���(Image ��)�� �ٿ���
// ����ڰ� Ŭ���ϰų� �巡���� �� �� ���� ����Ǵ� ����� �����մϴ�.
public class ButtonImage : MonoBehaviour
{
    public int colorValue; // Ŭ�� �� GameManager�� ������ ��
    private bool hasClicked;
    public bool buttonOnMouse;
    public bool uiOnMouse;
    public Vector2Int mat;
    private bool sideCheck = true;

    private RectTransform rectTransform; // �� UI ������Ʈ�� RectTransform

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // ���콺�� �� UI ���� �ִ��� �˻�
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
            GameManager2.list.Add(colorValue); // GameManager2�� �� �߰�
            GameManager2.buttonObjList.Add(this);
            GameManager2.matList.Add(mat);
            hasClicked = true; // �� �� ����Ǿ����� ǥ��
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
