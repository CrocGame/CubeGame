using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapCreate : MonoBehaviour
{
    [SerializeField] private Vector2Int _mapSize;

    private CubeFloor _cubeFloor;
    private GameObject _deathCube;

    public CubeFloor[,] _cubeFloors;

    private void Awake()
    {
        _cubeFloor = Progress.Instance.SelectFloorBlock;
        _deathCube = Progress.Instance.SelectDiedZone;
        _deathCube=Instantiate(_deathCube,transform);
        _cubeFloors = new CubeFloor[_mapSize.x, _mapSize.y];
        for (int i = 0; i < _mapSize.x; i++)
        {
            for (int j = 0; j < _mapSize.y; j++)
            {
                _cubeFloors[i,j]=Instantiate(_cubeFloor, new Vector3(i, 0, j), Quaternion.identity,transform);
            }
        }
        _deathCube.transform.localScale = new Vector3(_mapSize.x+20, 0.5f, _mapSize.y + 10);
        _deathCube.transform.position = new Vector3(_mapSize.x/2, -2f, _mapSize.y/2);
    }
}
