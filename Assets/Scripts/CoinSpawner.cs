using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin[] _coins;
    [SerializeField] protected MapCreate _mapCreate;


    private CubeFloor[,] _cubeFloors;
    private int lenX, lenY;

    [SerializeField] private float _time;
    private float _timer;

    private int _countCoin;
    private Rotation _rotation;
    private Vector3 _startPoint;

    private void Start()
    {
        _cubeFloors = _mapCreate._cubeFloors;
        lenX = _cubeFloors.GetLength(0);
        lenY = _cubeFloors.GetLength(1);
    }
    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            _countCoin = Random.Range(3, 10);
            _rotation = ChoseRotation();
            _startPoint = StartSpawnPoint();
            StartCoroutine(ActivCoin(_rotation, _countCoin));
            _timer = _time;
        }
    }
    private Rotation ChoseRotation()
    {
        int num = Random.Range(0, 5);
        return (Rotation)num;
    }
    IEnumerator ActivCoin(Rotation rotation, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Coin coin = GetCoin();
            coin._rotation = rotation;
            coin.transform.position = _startPoint;
            NextSpawnPoint();
            coin.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
        }
    }
    private Vector3 StartSpawnPoint()
    {
        switch (_rotation)
        {
            case Rotation.Right:
                return Vector3.left;
            case Rotation.Left:
                return Vector3.right * lenX;
            case Rotation.Up:
                return Vector3.back;
            case Rotation.Down:
                return Vector3.forward* lenY;
            case Rotation.Drop:
                return new Vector3(Random.Range(0, lenX), 5, Random.Range(0, lenY));
        }
        return Vector3.zero;
    }
    private void NextSpawnPoint()
    {
        switch (_rotation)
        {
            case Rotation.Right:
                _startPoint += Vector3.forward * (lenY/ _countCoin);
                break;
            case Rotation.Left:
                _startPoint += Vector3.forward * (lenY / _countCoin);
                break;
            case Rotation.Up:
                _startPoint += Vector3.right * (lenX / _countCoin);
                break;
            case Rotation.Down:
                _startPoint += Vector3.right * (lenX / _countCoin);
                break;
            case Rotation.Drop:
                _startPoint = new Vector3(Random.Range(0, lenX), 5, Random.Range(0, lenY));
                break;
        }
    }
    private Coin GetCoin()
    {
        foreach (var item in _coins)
        {
            if (item.gameObject.activeSelf == false)
            {
                
                return item;
            }
        }
        return null;
    }
}
