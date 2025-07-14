using UnityEngine;
using UnityEngine.EventSystems;

// UI Ŭ�� �� �巡�� ������ ��ũ��Ʈ (�������� ����)
public class PointDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public static bool isDragging = false;

    // Ŭ�� ����
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = false;
    }

    // �巡�� ��
    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;  
    }

    // Ŭ�� ����
    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;

    }
}
