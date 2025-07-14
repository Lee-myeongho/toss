using UnityEngine;
using UnityEngine.EventSystems;

// UI 클릭 및 드래그 감지용 스크립트 (움직이지 않음)
public class PointDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public static bool isDragging = false;

    // 클릭 시작
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = false;
    }

    // 드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;  
    }

    // 클릭 종료
    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;

    }
}
