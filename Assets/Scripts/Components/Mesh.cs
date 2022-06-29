using UnityEngine;
using UnityEngine.UI;

public class Mesh : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _mainGridLayout;
    [SerializeField] private GridLayoutGroup _bufferGridLayout;

    private const int _fixedMeshWidth = 950;

    public int FindMaxSide(int width, int height)
    {
        return height > width ? height : width;
    }

    public void SetCellSize(int maxSize)
    {
        float sizeCell = (float)_fixedMeshWidth / maxSize;
        _mainGridLayout.cellSize = new Vector2(sizeCell, sizeCell);
        _bufferGridLayout.cellSize = new Vector2(sizeCell, sizeCell);
    }

    public void SetColumn(int width)
    {
        _mainGridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _mainGridLayout.constraintCount = width;
        _bufferGridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _bufferGridLayout.constraintCount = width;
    }
}