using System;
using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerInfo
{  

    public bool[] StoryShopModel;
    public bool[] StoryShopBackGround;
    public bool[] StoryShopfloorBlock;
    public bool[] StoryShopDiedZone;
}
[System.Serializable]
public class PlayerStat
{
    public int MaxScore;
    public int CountCoins;
    public int MaxCoins;
   
    public int NumActivModel;
    public int NumActivBackGround;
    public int NumActivFloorBlock;
    public int NumActivDiedZone;
}


public class Progress : MonoBehaviour
{
    
    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);
    [DllImport("__Internal")]
    private static extern void LoadExtern();
    [DllImport("__Internal")]
    private static extern void CheckAuth();

    [DllImport("__Internal")]
    private static extern void SaveStatExtern(string data);
    [DllImport("__Internal")]
    private static extern void LoadStatExtern();

    public PlayerInfo PlayerInfo;
    public PlayerStat playerStat;

    public GameObject SelectModel;
    public Sprite SelectBackGrouns;
    public CubeFloor SelectFloorBlock;
    public GameObject SelectDiedZone;


    public bool Autorization=false;
    private bool WaitingLoad=false;

    public static Progress Instance;


    //private PlayerControls inputActions;

    [SerializeField] private GameObject _LoadPanel;


    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;

            //inputActions = new PlayerControls();
            //inputActions.Enable();

            LoadExtern();
            LoadStatExtern();

        }
        else
        {
            Destroy(gameObject);
        }       
    }


    private void OnEnable()
    {
        //inputActions.Interface.ClearSave.performed += ctx => RemoveSave();
        
        //inputActions.Interface.SaveNewClass.performed += ctx => SaveStat();
        //inputActions.Interface.Load.performed += ctx => LoadStatExtern();
        //inputActions.Interface.Plus.performed += ctx => Plus();
        //inputActions.Interface.Minus.performed += ctx => Minus();
        //inputActions.Interface.Incr.performed += ctx => IncrStat();

        StartCoroutine(AuthCheckButton());
    }

    IEnumerator AuthCheckButton()
    {
        CheckAuth();
        yield return new WaitForSeconds(5);
            while (Autorization)
            {           
                WaitingLoad = true;
                CheckAuth();
                yield return new WaitForSeconds(5);
            }

    }
    public void AuthCheck(string str)
    {
        Autorization = (str=="lite");
        if (!Autorization && WaitingLoad)
        {
            Load();
        }
    }



    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
        SaveExtern(jsonString);       
    }
    public void Load()
    {
        LoadExtern();
    }
    
    public void SetPlayerInfo(string value)
    {
        Progress.Instance.PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);        
        if (WaitingLoad)
        {
            WaitingLoad = false;
            StartCoroutine(Deley());
        }        
    }
    IEnumerator Deley()
    {      
        _LoadPanel.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
        _LoadPanel.SetActive(false);
    }

    public void RemoveSave()
    {
        PlayerInfo Clear = new PlayerInfo();
        string jsonString = JsonUtility.ToJson(Clear);
        SaveExtern(jsonString);
        string jsonString1 = JsonUtility.ToJson(Progress.Instance.playerStat);
        SaveStatExtern(jsonString1);
        LoadStatExtern();
        LoadExtern();
    }

    public void LoadStat(string value)
    {
        Progress.Instance.playerStat = JsonUtility.FromJson<PlayerStat>(value);

    }
    public void SaveStat()
    {

        string jsonString = JsonUtility.ToJson(Progress.Instance.playerStat);
        SaveStatExtern(jsonString);
    }


}
