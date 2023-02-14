using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using FMODUnity;

public class PlayerManager : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(string name,int value);

    [DllImport("__Internal")]
    private static extern void ShowAdw();
    [DllImport("__Internal")]
    private static extern void ReviweAdw();

    [SerializeField] private int _score;
    [SerializeField] private int _countCoins;
    [SerializeField] private Player _player;

    [SerializeField] private GameObject _DiedPanel;
    [SerializeField] private GameObject _panelReviwe;


    public int Score => _score;

    [SerializeField] private TMP_Text _scoreView;
    [SerializeField] private TMP_Text _coinsView;

    [SerializeField] private EventReference _coinUp;

    private bool CheckRevive = true;





    private void OnEnable()
    {
        _player.onMove += UpScore;
        _player.onPickUpCoin += UpCoin;
        _player.onDead += Riviwe;

        _scoreView.text = DictionaryLanguage.Instance.GetString(StaticWords.Score) + ": 0";
        _coinsView.text = DictionaryLanguage.Instance.GetString(StaticWords.Coins) + ": 0";
    }
    private void OnDisable()
    {
        _player.onMove -= UpScore;
        _player.onPickUpCoin -= UpCoin;
        _player.onDead -= Riviwe;
    }

    private void UpScore()
    {
        _score++;
        _scoreView.text = DictionaryLanguage.Instance.GetString(StaticWords.Score) + ": " + _score;
    }
    private void UpCoin()
    {
        _countCoins++;
        FMODUnity.RuntimeManager.PlayOneShot(_coinUp);
        _coinsView.text = DictionaryLanguage.Instance.GetString(StaticWords.Coins) + ": " + _countCoins;
    }
    public void SaveScore()
    {
        _DiedPanel.SetActive(true);
        bool save = false;
        ViewBigAds();
        if (Progress.Instance.playerStat.MaxCoins < _countCoins)
        {
            Progress.Instance.playerStat.MaxCoins = _countCoins;
            StartCoroutine(Deley());
            save = true;
        }
        if (_score > Progress.Instance.playerStat.MaxScore)
        {
            Progress.Instance.playerStat.MaxScore = _score;
            SetToLeaderboard("MaxScore",_score);
            save = true;
        }
        Progress.Instance.playerStat.CountCoins += _countCoins;
        if (_countCoins > 0 || save)
        {
            Progress.Instance.SaveStat();
        }
    }
    IEnumerator Deley()
    {
        yield return new WaitForSeconds(2);
        SetToLeaderboard("Coins",_countCoins);
    }

    private void ViewBigAds()
    {
        if (AdwCheck.Instance.TimeAds <= 0)
        {
            ShowAdw();
            AdwCheck.Instance.TimeAds = 300;
            AdwCheck.Instance.ButtonTimeCoins = true;
        }
    }
    private void Riviwe()
    {
        if (CheckRevive)
        {
            CheckRevive = false;
            _panelReviwe.SetActive(true);
        }
        else
        {
            SaveScore();
        }
    }
    public void StartAdwReviwe()
    {
        ReviweAdw();        
    }
    public void Reviwe()
    {       
        _player.PlayerRevive();
    }
}
