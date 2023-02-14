using System.Collections;
using UnityEngine;

public class WaveStage : Stage
{
    [SerializeField] private float _speedWave;
    private void OnEnable()
    {
        _cubeFloors = _mapCreate._cubeFloors;
        lenX = _cubeFloors.GetLength(0);
        lenY = _cubeFloors.GetLength(1);
        _timer = _time;
        ChooseWave();
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            ChooseWave();
            _timer = _time;
        }
    }

    private void ChooseWave()
    {
        switch (Random.Range(0, 2))
        {
            case 0:
                StartCoroutine(BigWave(Random.Range(1, ((lenY - 1) / 2)) - 1));
                break;
            case 1:
                StartCoroutine(RainWave(Random.Range(2, 6)));
                break;
            default:
                break;
        }
    }
    IEnumerator BigWave(int length)
    {
        for (int i = 0; i < lenX; i++)
        {
            for (int j = 0; j < length; j++)
            {
                _cubeFloors[i, j].SetStay();

            }
            for (int j = lenY-1; j > lenY-1-length; j--)
            {
                _cubeFloors[i, j].SetStay();
            }
            yield return new WaitForSeconds(_speedWave);
        }
    }
    IEnumerator RainWave(int step)
    {
        for (int i = 0; i < lenX; i++)
        {
            if (i % step == 0)
                for (int j = 0; j < lenY; j++)
                {
                    _cubeFloors[i, j].SetStay();
                }
            yield return new WaitForSeconds(_speedWave);
        }
    }
}
