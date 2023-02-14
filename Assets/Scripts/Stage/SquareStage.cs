using System.Collections.Generic;
using UnityEngine;

public class SquareStage : Stage
{

    private List<CubeFloor> _square1 = new List<CubeFloor>();
    private List<CubeFloor> _square2 = new List<CubeFloor>();
    private List<CubeFloor> _square3 = new List<CubeFloor>();
    private List<CubeFloor> _square4 = new List<CubeFloor>();
    private List<List<CubeFloor>> _squares = new List<List<CubeFloor>>();

    private int _lastSquare;
    private void OnEnable()
    {
        _cubeFloors = _mapCreate._cubeFloors;
        lenX = _cubeFloors.GetLength(0);
        lenY = _cubeFloors.GetLength(1);
        _timer = _time;
        DownCross();
        GetSquare();
    }

    private void GetSquare()
    {

        for (int i = 0; i < lenX; i++)
        {
            for (int j = 0; j < lenY; j++)
            {
                if (i < (lenX - 1) / 2 && j < (lenY - 1) / 2)
                    _square1.Add(_cubeFloors[i, j]);
                if (i > (lenX - 1) / 2 && j < (lenY - 1) / 2)
                    _square2.Add(_cubeFloors[i, j]);
                if (i > (lenX - 1) / 2 && j > (lenY - 1) / 2)
                    _square3.Add(_cubeFloors[i, j]);
                if (i < (lenX - 1) / 2 && j > (lenY - 1) / 2)
                    _square4.Add(_cubeFloors[i, j]);
            }
        }
        _squares.Add(_square1);
        _squares.Add(_square2);
        _squares.Add(_square3);
        _squares.Add(_square4);
    }

    private void DownCross()
    {
        for (int i = 0; i < lenX; i++)
        {
            _cubeFloors[i, (lenY - 1) / 2].SetNoActive();
        }
        for (int i = 0; i < lenY; i++)
        {
            _cubeFloors[ (lenX - 1) / 2, i].SetNoActive();
        }
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            DownSquare();
            _timer = _time;
        }
    }
    private void DownSquare()
    {
        int num = Random.Range(0, 4);
        while (num==_lastSquare)
        {
            num = Random.Range(0, 4);
        }
        _lastSquare = num;
        foreach (var item in _squares[num])
        {
            item.SetStay();
        }
    }

}
