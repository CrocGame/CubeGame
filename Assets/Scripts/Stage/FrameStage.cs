using UnityEngine;

public class FrameStage : Stage
{
    private int _timeOffset=0;
    private void OnEnable()
    {
        _cubeFloors = _mapCreate._cubeFloors;
        lenX = _cubeFloors.GetLength(0);
        lenY = _cubeFloors.GetLength(1);
        _timeOffset = 0;
        _timer = _time;
        FrameDown();
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            FrameDown();
            _timer = _time;
        }
    }
    private void FrameDown()
    {

        for (int i = _timeOffset; i < lenX - _timeOffset; i++)
        {
            if (i == _timeOffset)
            {
                for (int j = _timeOffset; j < lenY - _timeOffset; j++)
                {

                    _cubeFloors[i, j].SetNoActive();
                    _cubeFloors[lenX - 1 - i, j].SetNoActive();
                }
            }
            else
            {
                _cubeFloors[i, lenY - 1 - _timeOffset].SetNoActive();
                _cubeFloors[i, _timeOffset].SetNoActive();
            }
        }
        _timeOffset++;
    }

}
