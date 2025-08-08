using UnityEngine;
using UnityEngine.EventSystems;

public class PointDown : MonoBehaviour
{
    public static bool isDragging;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began: //��ġ ����������
                    isDragging = true;
                    break;

                case TouchPhase.Moved: //��ġ���϶�
                    isDragging = true;
                    break;

                case TouchPhase.Ended: //��ġ ������
                    isDragging = false;
                    break;
            }
        }
    }
}