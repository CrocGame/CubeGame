using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonAction : MonoBehaviour
{
    [SerializeField] private TMP_Text _maxScore;
    [SerializeField] private TMP_Text _coins;


    

    private void Start()
    {
        UpdateView();

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void UpdateView()
    {
        _maxScore.text =  DictionaryLanguage.Instance.GetString(StaticWords.MaxScore)+ ": " + Progress.Instance.playerStat.MaxScore;
        _coins.text = DictionaryLanguage.Instance.GetString(StaticWords.Coins) + ": " + Progress.Instance.playerStat.CountCoins;
    }
}
