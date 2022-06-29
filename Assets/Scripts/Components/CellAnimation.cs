using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CellAnimation : MonoBehaviour
{
    private List<Cell> _animatedCells = new List<Cell>();
    private float _targetTimeInSec = 2f;

    public void Move(List<Cell> mainList, List<Cell> bufferList)
    {
        var activeCellNumber = CountActiveCell(bufferList);

        for (int i = 0; i < activeCellNumber; i++)
        {
            for (int j = 0; j < activeCellNumber; j++)
            {
                if (!_animatedCells.Contains(mainList[j]) &&
                !_animatedCells.Contains(bufferList[i]) &&
                bufferList[i].Char == mainList[j].Char)
                {
                    _animatedCells.Add(mainList[j]);
                    _animatedCells.Add(bufferList[i]);

                    StartCoroutine(MoveToCellPosition(mainList[j], bufferList[i]));
                    break;
                }
            }
        }

        _animatedCells.Clear();
    }


    public IEnumerator MoveToCellPosition(Cell mainCell, Cell bufferCell)
    {
        float timeCounter = 0f;
        var startBufferCellPos = bufferCell.transform.position;

        while (timeCounter < _targetTimeInSec)
        {
            bufferCell.transform.position = Vector3.Lerp(startBufferCellPos, mainCell.transform.position, timeCounter / _targetTimeInSec);
            timeCounter += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        bufferCell.Hide();
        mainCell.Show();
    }

    private int CountActiveCell(List<Cell> bufferList)
    {
        int counter = 0;

        foreach (var cell in bufferList)
        {
            if (cell.gameObject.activeSelf)
                counter++;
        }

        return counter;
    }
}
