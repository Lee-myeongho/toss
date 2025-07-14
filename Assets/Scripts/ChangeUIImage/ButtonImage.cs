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
            hasClicked = true; // �� �� ����Ǿ����� ǥ��
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
