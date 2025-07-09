using UnityEngine;
using System.Collections.Generic;

public class Practice3 : MonoBehaviour
{
    // ��(row)�� ��(column) �� ����
    private const int ROWS = 15;
    private const int COLS = 10;

    // �� ����� ���̿� ��ü ��� �� ����
    private const int PATH_LENGTH = 7;
    private const int PATH_COUNT = 7;

    // ����(grid): ��� ���� �⺻������ 1�� ������
    private int[,] grid = new int[ROWS, COLS];

    // ��ΰ� ����� ���� �����ϱ� ���� �迭
    private bool[,] used = new bool[ROWS, COLS];




    //--------------------------------------------------------------------------------------------------
    [SerializeField] private GameObject[] colorButtonList = new GameObject[7];






    public void InColorButton()
    {
        for (int r = 0; r < ROWS; r++)
        {
            for (int c = 0; c < COLS; c++)
            {
                if (grid[r,c] == 1)
                {
                    int ranColor = Random.Range(0, 7);
                    GameObject prefab = colorButtonList[ranColor];
                    GameObject child = Instantiate(prefab, this.transform);
                    child.transform.parent = this.transform;
                }
                else
                {
                    GameObject prefab = colorButtonList[grid[r, c] - 2];
                    GameObject child = Instantiate(prefab, this.transform);
                    child.transform.parent = this.transform;
                }
            }
            
        }

        
    }









    //--------------------------------------------------------------------------------------------------



    void Start()
    {
        InitializeGrid();                    // ���� �ʱ�ȭ
        GeneratePaths(PATH_COUNT, PATH_LENGTH); // ��� ����
        PrintGrid();                         // ��� ���
        InColorButton();
    }

    // ���ڸ� ��� 1�� �ʱ�ȭ (�� ����)
    void InitializeGrid()
    {
        for (int r = 0; r < ROWS; r++)
            for (int c = 0; c < COLS; c++)
                grid[r, c] = 1;
    }

    // ��θ� ���� �� �����ϴ� �Լ�
    void GeneratePaths(int totalPaths, int pathLength)
    {
        int pathId = 2; // ��� ��ȣ (2���� �����ؼ� 2, 3, ..., 8)
        int maxTotalAttempts = 5000;
        int totalAttempts = 0;

        while (pathId < 2 + totalPaths && totalAttempts < maxTotalAttempts)
        {
            // ������ ������ ����
            int startRow = Random.Range(0, ROWS);
            int startCol = Random.Range(0, COLS);

            // �̹� ���� ���� ��ŵ
            if (used[startRow, startCol])
            {
                totalAttempts++;
                continue;
            }

            List<Vector2Int> path = new List<Vector2Int>();      // ��� ����
            bool[,] visited = new bool[ROWS, COLS];              // DFS �ߺ� ������

            // DFS�� ��ȿ�� ��� ã��
            if (DFS(startRow, startCol, pathLength, path, visited))
            {
                for (int i = 0; i < path.Count; i++)
                {
                    var cell = path[i];
                    grid[cell.x, cell.y] = 2 + i;      // 2~8�� ���� ä��
                    used[cell.x, cell.y] = true;
                }
                pathId++; // ��� ID�� ����������, ���� ���� ä���� ������ ����
            }

            totalAttempts++;
        }

        // ��� ��� (7���� �� ������� ���)
        if (pathId < 2 + totalPaths)
        {
            Debug.LogWarning($"Only {pathId - 2} paths generated out of {totalPaths} requested.");
        }
    }

    // DFS: ���� ������ �����ؼ� ���ϴ� ���̸�ŭ ����� ��� ã��
    bool DFS(int row, int col, int remaining, List<Vector2Int> path, bool[,] visited)
    {
        // ���� ����ų� �̹� �湮��/���� ���� ����
        if (row < 0 || row >= ROWS || col < 0 || col >= COLS)
            return false;

        if (visited[row, col] || used[row, col])
            return false;

        // ���� �� �߰�
        visited[row, col] = true;
        path.Add(new Vector2Int(row, col));

        // ��� ���̸� ��� ä�� ���
        if (remaining == 1)
            return true;

        // �����¿� ���� ����
        List<Vector2Int> directions = new List<Vector2Int>
        {
            new Vector2Int(-1, 0), // ��
            new Vector2Int(1, 0),  // �Ʒ�
            new Vector2Int(0, -1), // ����
            new Vector2Int(0, 1)   // ������
        };

        Shuffle(directions); // ������ ���� ������ Ž��

        // �� �������� DFS ���
        foreach (var dir in directions)
        {
            int nextRow = row + dir.x;
            int nextCol = col + dir.y;

            if (DFS(nextRow, nextCol, remaining - 1, path, visited))
                return true;
        }

        // ��� Ž�� ���� �� �ǵ����� (��Ʈ��ŷ)
        visited[row, col] = false;
        path.RemoveAt(path.Count - 1);
        return false;
    }

    // ���� ������ �������� ���� �Լ�
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

    // ���� ����� �ֿܼ� ��� (Debug.Log)
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

        Debug.Log(output); // Unity �ֿܼ� ���
    }
}