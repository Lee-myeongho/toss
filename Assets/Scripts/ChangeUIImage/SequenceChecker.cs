using System.Collections.Generic;
using UnityEngine;

public class SequenceChecker : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!SequenceChecker.HasValidSequence(GameManager2.buttonObjList))
            {
                Debug.Log("더 이상 연속된 3개 이상의 시퀀스가 없습니다. 게임 종료 가능.");
            }
        }
    }

    public static bool HasValidSequence(List<ButtonImage> allButtons)
    {
        HashSet<Vector2Int> visited = new HashSet<Vector2Int>();

        foreach (var button in allButtons)
        {
            if (!button.gameObject.activeSelf || visited.Contains(button.mat))
                continue;

            // 길이 3 이상 가능한 시퀀스가 존재하면 true
            if (DFS(button, allButtons, visited, 1))
                return true;
        }

        return false; // 시퀀스 없음
    }

    private static bool DFS(ButtonImage current, List<ButtonImage> allButtons, HashSet<Vector2Int> visitedGlobal, int length)
    {
        Stack<(ButtonImage, int, HashSet<Vector2Int>)> stack = new Stack<(ButtonImage, int, HashSet<Vector2Int>)>();
        stack.Push((current, length, new HashSet<Vector2Int> { current.mat }));

        while (stack.Count > 0)
        {
            var (node, count, visitedLocal) = stack.Pop();

            if (count >= 3)
                return true;

            var neighbors = GetAdjacentButtons(node, allButtons);

            foreach (var neighbor in neighbors)
            {
                if (!neighbor.gameObject.activeSelf || visitedLocal.Contains(neighbor.mat))
                    continue;

                if (neighbor.colorValue == node.colorValue + 1)
                {
                    var newVisited = new HashSet<Vector2Int>(visitedLocal);
                    newVisited.Add(neighbor.mat);
                    stack.Push((neighbor, count + 1, newVisited));
                }
            }

            visitedGlobal.Add(node.mat); // 마킹해서 중복 계산 줄임
        }

        return false;
    }

    private static List<ButtonImage> GetAdjacentButtons(ButtonImage target, List<ButtonImage> allButtons)
    {
        List<ButtonImage> neighbors = new List<ButtonImage>();
        Vector2Int[] directions = new Vector2Int[]
        {
            new Vector2Int(0, 1), // 오른쪽
            new Vector2Int(0, -1), // 왼쪽
            new Vector2Int(1, 0), // 아래
            new Vector2Int(-1, 0) // 위
        };

        foreach (var dir in directions)
        {
            Vector2Int checkPos = target.mat + dir;
            foreach (var button in allButtons)
            {
                if (button.mat == checkPos)
                {
                    neighbors.Add(button);
                    break;
                }
            }
        }

        return neighbors;
    }
}
