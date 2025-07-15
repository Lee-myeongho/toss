using UnityEngine;
using System.Collections.Generic;

public class RandomCreate : MonoBehaviour
{
    private const int ROWS = 15;
    private const int COLS = 10;
    private const int PATH_LENGTH = 7;
    private const int PATH_COUNT = 7;

    private int[,] grid = new int[ROWS, COLS];
    private bool[,] used = new bool[ROWS, COLS];

    public GameObject[] colorButtonList = new GameObject[7];
    private int ranColor;


    public void InColorButton()
    {
        float cellWidth = 100f;
        float cellHeight = 100f;

        // 전체 그리드의 가로/세로 크기 계산
        float totalWidth = COLS * cellWidth;
        float totalHeight = ROWS * cellHeight;

        // 부모 UI(RectTransform)의 크기 기준
        RectTransform parentRect = GetComponent<RectTransform>();
        float maxWidth = parentRect.rect.width;
        float maxHeight = parentRect.rect.height;

        // 자동 축소 비율 계산 (1보다 커지지 않도록 제한)
        float scaleX = maxWidth / totalWidth;
        float scaleY = maxHeight / totalHeight;
        float finalScale = Mathf.Min(scaleX, scaleY, 1f);

        // 시작 좌표를 부모의 기준으로 (0, 0)
        Vector2 startPosition = new Vector2(-270f, 420f);

        for (int r = 0; r < ROWS; r++)
        {
            for (int c = 0; c < COLS; c++)
            {
                // 색상 선택
                if (grid[r, c] == 1)
                {
                    ranColor = Random.Range(0, 7);
                }
                else
                {
                    ranColor = Mathf.Clamp(grid[r, c] - 2, 0, colorButtonList.Length - 1);
                }
                GameObject prefab = colorButtonList[ranColor];
                GameObject child = Instantiate(prefab, this.transform);

                RectTransform rect = child.GetComponent<RectTransform>();
                if (rect != null)
                {
                    // 🟩 왼쪽 위 기준 좌표로 배치
                    float x = startPosition.x + c * cellWidth * finalScale;
                    float y = startPosition.y - r * cellHeight * finalScale;
                    rect.anchoredPosition = new Vector2(x, y);

                    // 크기 조절
                    rect.localScale = Vector3.one * finalScale;
                }
                // 색상 값 전달
                ButtonImage colorValue = child.GetComponent<ButtonImage>();
                if (colorValue != null)
                {
                    colorValue.colorValue = ranColor;

                    colorValue.mat = new Vector2Int(r,c); //행
                }
            }
        }
    }






    void Start()
    {
        InitializeGrid();
        GeneratePaths(PATH_COUNT, PATH_LENGTH);
        PrintGrid();
        InColorButton();
    }

    void InitializeGrid()
    {
        for (int r = 0; r < ROWS; r++)
            for (int c = 0; c < COLS; c++)
                grid[r, c] = 1;
    }

    void GeneratePaths(int totalPaths, int pathLength)
    {
        int pathId = 2;
        int maxTotalAttempts = 5000;
        int totalAttempts = 0;

        while (pathId < 2 + totalPaths && totalAttempts < maxTotalAttempts)
        {
            int startRow = Random.Range(0, ROWS);
            int startCol = Random.Range(0, COLS);

            if (used[startRow, startCol])
            {
                totalAttempts++;
                continue;
            }

            List<Vector2Int> path = new List<Vector2Int>();
            bool[,] visited = new bool[ROWS, COLS];

            if (DFS(startRow, startCol, pathLength, path, visited))
            {
                for (int i = 0; i < path.Count; i++)
                {
                    var cell = path[i];
                    grid[cell.x, cell.y] = 2 + i;
                    used[cell.x, cell.y] = true;
                }
                pathId++;
            }

            totalAttempts++;
        }

        if (pathId < 2 + totalPaths)
        {
            Debug.LogWarning($"Only {pathId - 2} paths generated out of {totalPaths} requested.");
        }
    }

    bool DFS(int row, int col, int remaining, List<Vector2Int> path, bool[,] visited)
    {
        if (row < 0 || row >= ROWS || col < 0 || col >= COLS)
            return false;

        if (visited[row, col] || used[row, col])
            return false;

        visited[row, col] = true;
        path.Add(new Vector2Int(row, col));

        if (remaining == 1)
            return true;

        List<Vector2Int> directions = new List<Vector2Int>
        {
            new Vector2Int(-1, 0),
            new Vector2Int(1, 0),
            new Vector2Int(0, -1),
            new Vector2Int(0, 1)
        };

        Shuffle(directions);

        foreach (var dir in directions)
        {
            int nextRow = row + dir.x;
            int nextCol = col + dir.y;

            if (DFS(nextRow, nextCol, remaining - 1, path, visited))
                return true;
        }

        visited[row, col] = false;
        path.RemoveAt(path.Count - 1);
        return false;
    }

    void Shuffle(List<Vector2Int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            Vector2Int temp = list[i];
            list[i] = list[rnd];
            list[rnd] = temp;
        }
    }

    void PrintGrid()
    {
        string output = "";
        for (int r = 0; r < ROWS; r++)
        {
            for (int c = 0; c < COLS; c++)
            {
                output += grid[r, c].ToString().PadLeft(2) + " ";
            }
            output += "\n";
        }

        Debug.Log(output);
    }
}
