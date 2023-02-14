using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessStage : Stage
{
    private void OnEnable()
    {
        _cubeFloors = _mapCreate._cubeFloors;
        lenX = _cubeFloors.GetLength(0);
        lenY = _cubeFloors.GetLength(1);
        _timer = _time;
        for (int i = 0; i < lenX; i++)
        {
            for (int j = 0; j < lenY; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    _cubeFloors[i, j].SetNoActive();
                }
            }
        }
    }
}
