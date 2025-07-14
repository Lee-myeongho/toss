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
            hasClicked = true; // �� �� ����Ǿ����� ǥ��
            if (buttonOnMouse && GameManager2.successObj )
            {
                Debug.Log("����");
                this.gameObject.SetActive(false);
            }
        }
    }
}
