using UnityEngine;

public class FreeStage : Stage
{
    private void Start()
    {
        _cubeFloors = _mapCreate._cubeFloors;
        lenX = _cubeFloors.GetLength(0);
        lenY = _cubeFloors.GetLength(1);
        _timer = _time;
    }

}
