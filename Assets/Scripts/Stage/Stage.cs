using UnityEngine;

public class Stage : MonoBehaviour
{
    public int _weight;
    public int _timeStage;



    [SerializeField] protected float _time;
    [SerializeField] protected MapCreate _mapCreate;

    protected float _timer;
    protected CubeFloor[,] _cubeFloors;
    protected int lenX, lenY;


    private void OnDisable()
    {
        foreach (var item in _cubeFloors)
        {
            if (item._stay == Stay.NoActive && item != null)
                item.SetDefault();
        }
    }
}
