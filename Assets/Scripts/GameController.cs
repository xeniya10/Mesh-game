using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private MeshCell _cellPrefab;
    [SerializeField] private MeshManager _meshManager;
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private Transform _cellParent;

    private List<MeshCell> _cellList = new List<MeshCell>();
    private List<char> _charList = new List<char>();

    private int _totalGeneratedCells = 900;

    private void Awake()
    {
        GenerateCellPool();
        _UIManager.GenerateMeshEvent += GenerateMeshField;
        _UIManager.JumbleCellEvent += JumbleMeshField;
    }

    private void GenerateCellPool()
    {
        for (int i = 0; i < _totalGeneratedCells; i++)
        {
            var cell = Instantiate(_cellPrefab, _cellParent);
            cell.Hide();
            _cellList.Add(cell);
        }
    }

    private void GenerateMeshField()
    {
        var height = _UIManager.Height;
        var width = _UIManager.Width;
        var totalCells = height * width;
        var maxSide = _meshManager.FindMaxSide(width, height);

        ResetMeshField();

        for (int i = 0; i < totalCells; i++)
        {
            var randomChar = CharGenerator.Generate();
            _charList.Add(randomChar);

            _cellList[i].Char = randomChar;
            _cellList[i].SetFontSize(maxSide);
            _cellList[i].Show();

            _meshManager.SetCellSize(maxSide);
            _meshManager.SetColumn(width);

        }
    }

    private void JumbleMeshField()
    {
        var random = new Random();
        var newCharList = _charList.OrderBy(a => random.Next());
        _charList = newCharList.ToList();

        for (int i = 0; i < _charList.Count; i++)
        {
            _cellList[i].Char = _charList[i];
        }
    }

    private void ResetMeshField()
    {
        _charList.Clear();

        for (int i = 0; i < _cellList.Count; i++)
        {
            _cellList[i].Hide();
        }
    }
}
