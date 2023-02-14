using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HoleStage : Stage
{
    private int _timeOffset = 0;
    private int StageMode = 0;
    private int maxLength = 0;
    
    private void OnEnable()
    {
        _cubeFloors = _mapCreate._cubeFloors;
        lenX = _cubeFloors.GetLength(0);
        lenY = _cubeFloors.GetLength(1);
        maxLength=((lenY+1)/2)-2;

        _timeOffset = 0;
        _timer = _time;
        int length = Random.Range(0, maxLength);
        StartCoroutine(DownFrame(length));
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            StageMode = Random.Range(0, 2);
            int length = Random.Range(maxLength-2, maxLength);
            if (StageMode == 0)
            {
                _timeOffset = length;
            }
            else
            {
                _timeOffset = 0;
            }
            StartCoroutine(DownFrame(length));
            _timer = _time;
        }
    }
    IEnumerator DownFrame(int length)
    {
        for (int l = 0; l < length; l++)
        {
            for (int i = _timeOffset; i < lenX - _timeOffset; i++)
            {
                if (i == _timeOffset)
                {
                    for (int j = _timeOffset; j < lenY - _timeOffset; j++)
                    {

                        _cubeFloors[i, j].SetStay();
                        _cubeFloors[lenX - 1 - i, j].SetStay();
                    }
                }
                else
                {
                    _cubeFloors[i, lenY - 1 - _timeOffset].SetStay();
                    _cubeFloors[i, _timeOffset].SetStay();
                }
            }
            _timeOffset++;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
