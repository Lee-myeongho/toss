using UnityEngine;
using UnityEngine.UI;

public class isButton : MonoBehaviour
{
    public int colorIndex; // Practice3���� �Ҵ��
    public Button button;

    public void Start()
    {
        button.onClick.AddListener(Write);
    }

    public void Write()
    {
        Debug.Log(colorIndex);
    }
}

