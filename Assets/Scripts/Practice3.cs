using UnityEngine;
using System.Collections.Generic;

public class Practice3 : MonoBehaviour
{
    // 행(row)과 열(column) 수 정의
    private const int ROWS = 15;
    private const int COLS = 10;

    // 각 경로의 길이와 전체 경로 수 정의
    private const int PATH_LENGTH = 7;
    private const int PATH_COUNT = 7;

    // 격자(grid): 모든 셀은 기본적으로 1로 설정됨
    private int[,] grid = new int[ROWS, COLS];

    // 경로가 사용한 셀을 추적하기 위한 배열
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
        InitializeGrid();                    // 격자 초기화
        GeneratePaths(PATH_COUNT, PATH_LENGTH); // 경로 생성
        PrintGrid();                         // 결과 출력
        InColorButton();
    }

    // 격자를 모두 1로 초기화 (빈 상태)
    void InitializeGrid()
    {
        for (int r = 0; r < ROWS; r++)
            for (int c = 0; c < COLS; c++)
                grid[r, c] = 1;
    }

    // 경로를 여러 개 생성하는 함수
    void GeneratePaths(int totalPaths, int pathLength)
    {
        int pathId = 2; // 경로 번호 (2부터 시작해서 2, 3, ..., 8)
        int maxTotalAttempts = 5000;
        int totalAttempts = 0;

        while (pathId < 2 + totalPaths && totalAttempts < maxTotalAttempts)
        {
            // 무작위 시작점 선택
            int startRow = Random.Range(0, ROWS);
            int startCol = Random.Range(0, COLS);

            // 이미 사용된 셀은 스킵
            if (used[startRow, startCol])
            {
                totalAttempts++;
                continue;
            }

            List<Vector2Int> path = new List<Vector2Int>();      // 경로 저장
            bool[,] visited = new bool[ROWS, COLS];              // DFS 중복 방지용

            // DFS로 유효한 경로 찾기
            if (DFS(startRow, startCol, pathLength, path, visited))
            {
                for (int i = 0; i < path.Count; i++)
                {
                    var cell = path[i];
                    grid[cell.x, cell.y] = 2 + i;      // 2~8로 순차 채움
                    used[cell.x, cell.y] = true;
                }
                pathId++; // 경로 ID는 증가하지만, 실제 숫자 채움은 위에서 고정
            }

            totalAttempts++;
        }

        // 경고 출력 (7개를 못 만들었을 경우)
        if (pathId < 2 + totalPaths)
        {
            Debug.LogWarning($"Only {pathId - 2} paths generated out of {totalPaths} requested.");
        }
    }

    // DFS: 현재 셀에서 시작해서 원하는 길이만큼 연결된 경로 찾기
    bool DFS(int row, int col, int remaining, List<Vector2Int> path, bool[,] visited)
    {
        // 범위 벗어나거나 이미 방문한/사용된 셀은 무시
        if (row < 0 || row >= ROWS || col < 0 || col >= COLS)
            return false;

        if (visited[row, col] || used[row, col])
            return false;

        // 현재 셀 추가
        visited[row, col] = true;
        path.Add(new Vector2Int(row, col));

        // 경로 길이를 모두 채운 경우
        if (remaining == 1)
            return true;

        // 상하좌우 방향 정의
        List<Vector2Int> directions = new List<Vector2Int>
        {
            new Vector2Int(-1, 0), // 위
            new Vector2Int(1, 0),  // 아래
            new Vector2Int(0, -1), // 왼쪽
            new Vector2Int(0, 1)   // 오른쪽
        };

        Shuffle(directions); // 무작위 방향 순서로 탐색

        // 각 방향으로 DFS 재귀
        foreach (var dir in directions)
        {
            int nextRow = row + dir.x;
            int nextCol = col + dir.y;

            if (DFS(nextRow, nextCol, remaining - 1, path, visited))
                return true;
        }

        // 경로 탐색 실패 → 되돌리기 (백트래킹)
        visited[row, col] = false;
        path.RemoveAt(path.Count - 1);
        return false;
    }

    // 방향 순서를 랜덤으로 섞는 함수
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

    // 최종 결과를 콘솔에 출력 (Debug.Log)
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

        Debug.Log(output); // Unity 콘솔에 출력
    }
}