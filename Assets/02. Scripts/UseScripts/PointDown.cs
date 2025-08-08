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
                case TouchPhase.Began: //터치 시작했을때
                    isDragging = true;
                    break;

                case TouchPhase.Moved: //터치중일때
                    isDragging = true;
                    break;

                case TouchPhase.Ended: //터치 끝날때
                    isDragging = false;
                    break;
            }
        }
    }
}