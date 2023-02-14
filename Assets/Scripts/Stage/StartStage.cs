using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStage : MonoBehaviour
{
    [SerializeField] private Stage[] _stages;
    [SerializeField] private Player _player;

    [SerializeField] private Stage _startStage;
    [SerializeField] private CoinSpawner _coinSpawner;


    
    
    private WaitForSeconds wait = new WaitForSeconds(1);
    private Stage _currentStages;

    private int _timeStage;
    private int Sum=0;
    private void OnEnable()
    {
        _player.onDead += EndGame;
    }
    private void OnDisable()
    {
        _player.onDead -= EndGame;
    }
    private void Start()
    {
        StartCoroutine(StartGame());
        foreach (var item in _stages)
        {
            Sum += item._weight;
        }
        


    }
    IEnumerator StartGame()
    {
        yield return wait;
        _player.gameObject.SetActive(true);
        yield return wait;
        ActiveStage(_startStage);
        yield return new WaitForSeconds(5);
        if(_coinSpawner!=null)
        _coinSpawner.enabled = true;
    }
    IEnumerator TimerStage()
    {
        yield return new WaitForSeconds(_timeStage);
        _currentStages.enabled = false;
        NextStage();
    }

    private void ActiveStage(Stage stage)
    {
        _currentStages = stage;
        _currentStages.enabled = true;
        _timeStage = _currentStages._timeStage;
        StartCoroutine(TimerStage());
    }

    private void NextStage()
    {       
        int check = Random.Range(0, Sum);
        foreach (var item in _stages)
        {
            if(check>item._weight)
            check -= item._weight;
            else
            {
                ActiveStage(item);
                break;
            }
        }
    }
    private void EndGame()
    {
           
    }
}
