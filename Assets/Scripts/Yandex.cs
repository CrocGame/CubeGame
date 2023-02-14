using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class Leaderbords {

    public List<entries> entries;
    public int userRank;
}
[System.Serializable]
public class player {

    public string publicName;

}
[System.Serializable]
public class entries
{

    public int score;
    public int rank;
    public player player;
}


public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Rate();
    [DllImport("__Internal")]
    private static extern void GiveMoneyAdw();
    [DllImport("__Internal")]
    private static extern void Authenticator();
    [DllImport("__Internal")]
    private static extern void ViewLeaderboards();

    [SerializeField] private ButtonAction _buttonAction;
    [SerializeField] private GameObject _buttonAuth;
    [SerializeField] private GameObject _ButtonAdwCoins;

    private PlayerControls inputActions;

    public Leaderbords leaderbordsData;
    [SerializeField] private LeaderPanel _leaderPanel;
    [SerializeField] private GameObject _leaderbords;
    private void Awake()
    {
        ViewLeaderboards();
        //inputActions = new PlayerControls();
        //inputActions.Enable();
        //inputActions.Interface.AddMoney.performed += ctx => GiveMoneyRate();
    }
    private void Start()
    {
        _buttonAuth.SetActive(Progress.Instance.Autorization);
        _ButtonAdwCoins.SetActive(AdwCheck.Instance.ButtonTimeCoins);

    }

        
        //_test.text = Progress.Instance.playerStat.NumActivModel + "\n" +
        //    Progress.Instance.playerStat.NumActivBackGround + "\n" +
        //    Progress.Instance.playerStat.NumActivFloorBlock + "\n" +
        //    Progress.Instance.playerStat.NumActivDiedZone;
    
    public void getLeader(string value)
    {
        leaderbordsData = JsonUtility.FromJson<Leaderbords>(value);
        _leaderbords.SetActive(true);
        foreach (var item in leaderbordsData.entries)
        {
            LeaderPanel panel = Instantiate(_leaderPanel,_leaderbords.transform);
            panel.Rank.text = item.rank.ToString();
            panel.Name.text = item.player.publicName;
            panel.Score.text = item.score.ToString();
        }
    }

    public void ButtonAuth()
    {       
        Authenticator();
    }

    public void RateGameButton()
    {
        Authenticator();
        Rate();
    }
    public void GiveMoneyButton()
    {
        GiveMoneyAdw();
        AdwCheck.Instance.ButtonTimeCoins = false;
        AdwCheck.Instance.MusicOff();
    }

    public void GiveMoneyRate()
    {
        Progress.Instance.playerStat.CountCoins += 1000;
        _buttonAction.UpdateView();
        Progress.Instance.SaveStat();
    }
    public void GiveMoney()
    {
        Progress.Instance.playerStat.CountCoins += 100;
        AdwCheck.Instance.MusicOn();
        _buttonAction.UpdateView();
        Progress.Instance.SaveStat();
    }
}
