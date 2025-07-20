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
                Debug.Log("�� �̻� ���ӵ� 3�� �̻��� �������� �����ϴ�. ���� ���� ����.");
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

            // ���� 3 �̻� ������ �������� �����ϸ� true
            if (DFS(button, allButtons, visited, 1))
                return true;
        }

        return false; // ������ ����
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

            visitedGlobal.Add(node.mat); // ��ŷ�ؼ� �ߺ� ��� ����
        }

        return false;
    }

    private static List<ButtonImage> GetAdjacentButtons(ButtonImage target, List<ButtonImage> allButtons)
    {
        List<ButtonImage> neighbors = new List<ButtonImage>();
        Vector2Int[] directions = new Vector2Int[]
        {
            new Vector2Int(0, 1), // ������
            new Vector2Int(0, -1), // ����
            new Vector2Int(1, 0), // �Ʒ�
            new Vector2Int(-1, 0) // ��
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
