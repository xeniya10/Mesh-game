using UnityEngine;
using UnityEngine.UI;

public class MeshManager : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _gridLayot;
    private const int _fixedMeshWidth = 900;

    public int FindMaxSide(int width, int height)
    {
        return height > width ? height : width;
    }

    public void SetCellSize(int maxSize)
    {
        float sizeCell = (float)_fixedMeshWidth / maxSize;
        _gridLayot.cellSize = new Vector2(sizeCell, sizeCell);
    }

    public void SetColumn(int width)
    {
        _gridLayot.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayot.constraintCount = width;
    }
}
