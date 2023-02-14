using UnityEngine;

public class RandomStage : Stage
{
    private int x, y;
    private void OnEnable()
    {
        _cubeFloors = _mapCreate._cubeFloors;
        lenX = _cubeFloors.GetLength(0);
        lenY = _cubeFloors.GetLength(1);
        for (int i = 0; i < 4; i++)
        {
            ChoiseRandom();
        }
        _timer = _time;
    }
    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {

            for (int i = 0; i < 4; i++)
            {
                ChoiseRandom();
            }
            _timer = _time;
        }
    }
    private void ChoiseRandom()
    {
        x = Random.Range(0, lenX);
        y = Random.Range(0, lenY);
        _cubeFloors[x, y].SetNoActive();
    }


}
