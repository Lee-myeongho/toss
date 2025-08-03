using UnityEngine;
using UnityEngine.EventSystems;

public class PointDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public static bool isDragging;
    public RectTransform boundaryPanel;

    void Update()
    {
        if (isDragging)
        {
            // 마우스 포인터가 영역 밖에 있는지 확인
            if (!RectTransformUtility.RectangleContainsScreenPoint(boundaryPanel, Input.mousePosition, null))
                CancelDrag();
        }
    }
    public void OnPointerDown(PointerEventData eventData) => isDragging = true;
    public void OnDrag(PointerEventData eventData) => isDragging = true;

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        GameManager2.matList.Clear();
    }
    private void CancelDrag()
    {
        isDragging = false;

        GameManager2.list.Clear();
        GameManager2.buttonObjList.Clear();
        GameManager2.matList.Clear();
    }
}
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class PointDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
//{
//    public static bool isDragging;

//    public void OnPointerDown(PointerEventData eventData) => isDragging = true;
//    public void OnDrag(PointerEventData eventData) => isDragging = true;

//    public void OnPointerUp(PointerEventData eventData)
//    {
//        isDragging = false;
//        Debug.Log("false");
//        GameManager2.matList.Clear();
//    }
//}
