using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;
    [SerializeField] private Mesh _mesh;
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private CellAnimation _cellAnimation;
    [SerializeField] private Transform _mainCellParent;
    [SerializeField] private Transform _bufferCellParent;

    private List<Cell> _mainCellList = new List<Cell>();
    private List<Cell> _bufferCellList = new List<Cell>();
    private List<char> _sortingCharList = new List<char>();

    private int _heightInput;
    private int _widthInput;
    private int _totalCells;

    private int _totalGeneratedCells = 400;

    private void Awake()
    {
        GenerateCellPool();
        _UIManager.GenerateMeshEvent += CheckInputValues;
        _UIManager.JumbleCellEvent += JumbleMeshField;
    }

    private void GenerateCellPool()
    {
        for (int i = 0; i < _totalGeneratedCells; i++)
        {
            var cell = Instantiate(_cellPrefab, _mainCellParent);
            cell.Hide();
            _mainCellList.Add(cell);

            var bufferCell = Instantiate(_cellPrefab, _bufferCellParent);
            bufferCell.Hide();
            _bufferCellList.Add(bufferCell);
        }
    }

    private void GenerateMeshField()
    {
        _heightInput = _UIManager.Height;
        _widthInput = _UIManager.Width;
        _totalCells = _heightInput * _widthInput;

        var maxSide = _mesh.FindMaxSide(_widthInput, _heightInput);

        ResetMeshField();

        for (int i = 0; i < _totalCells; i++)
        {
            var randomChar = CharGenerator.Generate();
            _mainCellList[i].Char = randomChar;
            _bufferCellList[i].SetFontSize(maxSide);
            _mainCellList[i].SetFontSize(maxSide);
            _mainCellList[i].Show();

            _mesh.SetCellSize(maxSide);
            _mesh.SetColumn(_widthInput);
            _bufferCellList[i].BecomeTransparent();
            _bufferCellList[i].Show();
        }
    }

    private void JumbleMeshField()
    {
        _heightInput = _UIManager.Height;
        _widthInput = _UIManager.Width;
        _totalCells = _heightInput * _widthInput;

        ResetSortingList();
        CopyCharValue();
        SortMainList();

        _cellAnimation.Move(_mainCellList, _bufferCellList);
    }

    private void ResetSortingList()
    {
        _sortingCharList.Clear();
    }

    private void CopyCharValue()
    {
        for (int i = 0; i < _totalCells; i++)
        {
            _bufferCellList[i].Char = _mainCellList[i].Char;
            _bufferCellList[i].BecomeVisible();
            _bufferCellList[i].Show();
            _sortingCharList.Add(_mainCellList[i].Char);
        }
    }

    private void SortMainList()
    {
        var random = new Random();

        _sortingCharList = _sortingCharList.OrderBy(ch => random.Next()).ToList();

        for (int i = 0; i < _sortingCharList.Count; i++)
        {
            _mainCellList[i].Char = _sortingCharList[i];
            _mainCellList[i].Hide();
        }
    }

    private void ResetMeshField()
    {
        for (int i = 0; i < _mainCellList.Count; i++)
        {
            _mainCellList[i].Hide();
        }
    }

    private void CheckInputValues()
    {
        _heightInput = _UIManager.Height;
        _widthInput = _UIManager.Width;

        if (_heightInput <= 0 || _widthInput <= 0)
        {
            _UIManager.SetWarningSmallValue();
            return;
        }

        if (_heightInput > 20 || _widthInput > 20)
        {
            _UIManager.SetWarningBigValue();
            return;
        }

        _UIManager.ResetWarningText();
        GenerateMeshField();
    }
}
