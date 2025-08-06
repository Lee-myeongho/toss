using UnityEngine;
using UnityEngine.UI;

public class ButtonImage : MonoBehaviour
{
    public int colorValue;
    public Vector2Int mat;
    public Image buttonBackground;
    private Image buttonBackgroundValue;
    private Color originalColor;

    public bool hasClicked;
    private bool sideCheck = true;

    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        buttonBackgroundValue = buttonBackground.GetComponent<Image>();
        originalColor = buttonBackgroundValue.color;
    }

    void Update()
    {
        bool isMouseOver = RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition);

        if (PointDown.isDragging)
        {
            if (isMouseOver && !hasClicked)
            {
                buttonBackground.color = new Color(100/255, 100/255, 100/255, 1);
                TryAddColor();
            }
        }
        else if(!PointDown.isDragging)
        {
            buttonBackground.color = originalColor;
            hasClicked = false;
        }
        else
        {
            hasClicked = false;
        }

        if (GameManager2.successObj && !PointDown.isDragging)
        {
            foreach (var btn in GameManager2.buttonObjList)
                btn.gameObject.SetActive(false);

            GameManager2.successObj = false;
            GameManager2.list.Clear();
            GameManager2.buttonObjList.Clear();
            GameManager2.matList.Clear();
        }
    }

    private void TryAddColor()
    {

        GameManager2.list.Add(colorValue);
        GameManager2.buttonObjList.Add(this);
        GameManager2.matList.Add(mat);
        hasClicked = true;
        CheckSide();

        if (!sideCheck || GameManager2.list[0] != 0)
        {
            GameManager2.list.Clear();
            GameManager2.buttonObjList.Clear();
            GameManager2.matList.Clear();
        }
    }

    private void CheckSide()
    {
        sideCheck = true;
        var matList = GameManager2.matList;

        for (int i = 1; i < matList.Count; i++)
        {
            Vector2Int a = matList[i - 1];
            Vector2Int b = matList[i];

            if (!(Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) == 1))
            {
                sideCheck = false;
                break;
            }
        }
    }
}
