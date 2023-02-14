using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public enum StaticWords
{  
    Score,
    MaxScore,
    Coins,
    StartGame,
    Setting,
    Pause,
    Exit,
    Music,
    Effects,
    Selected,
    Use,
    Shop,
    YouLose,
    Next,
    Restart,
    Menu,
    Loading,
    Donating,
    Model,
    BackGround,
    Blocks,
    DiedZone,
    Reviwe
}
public class DictionaryLanguage : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string LanguageExtern();

    public int LanguageNum;
    private Dictionary<string, int> Language = new Dictionary<string, int>();

    public string[] Score;
    public string[] MaxScore;
    public string[] Coins;
    public string[] StartGame;
    public string[] Setting;
    public string[] Pause;
    public string[] Exit;
    public string[] Music;
    public string[] Effects;
    public string[] Selected;
    public string[] Use;
    public string[] Shop;
    public string[] YouLose;
    public string[] Next;
    public string[] Restart;
    public string[] Menu;
    public string[] Loading;
    public string[] Donating;
    public string[] Model;
    public string[] BackGround;
    public string[] Blocks;
    public string[] DiedZone;
    public string[] Reviwe;


    public static DictionaryLanguage Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            Language.Add("en", 0);
            Language.Add("ru", 1);
            Language.Add("tr", 2);
            LanguageNum = (Language[LanguageExtern()]);
        }
        else
        {
            Destroy(gameObject);
        }
       
    }

    public string GetString(StaticWords staticWords)
    {
        switch (staticWords)
        {
            case StaticWords.Score:
                return Score[LanguageNum];
            case StaticWords.MaxScore:
                return MaxScore[LanguageNum];
            case StaticWords.Coins:
                return Coins[LanguageNum];
            case StaticWords.StartGame:
                return StartGame[LanguageNum];
            case StaticWords.Setting:
                return Setting[LanguageNum];
            case StaticWords.Pause:
                return Pause[LanguageNum];
            case StaticWords.Exit:
                return Exit[LanguageNum];
            case StaticWords.Music:
                return Music[LanguageNum];
            case StaticWords.Effects:
                return Effects[LanguageNum];
            case StaticWords.Selected:
                return Selected[LanguageNum];
            case StaticWords.Use:
                return Use[LanguageNum];
            case StaticWords.Shop:
                return Shop[LanguageNum];
            case StaticWords.YouLose:
                return YouLose[LanguageNum];
            case StaticWords.Next:
                return Next[LanguageNum];
            case StaticWords.Restart:
                return Restart[LanguageNum];
            case StaticWords.Menu:
                return Menu[LanguageNum];
            case StaticWords.Loading:
                return Loading[LanguageNum];
            case StaticWords.Donating:
                return Donating[LanguageNum];
            case StaticWords.Model:
                return Model[LanguageNum];
            case StaticWords.BackGround:
                return BackGround[LanguageNum];
            case StaticWords.Blocks:
                return Blocks[LanguageNum];
            case StaticWords.DiedZone:
                return DiedZone[LanguageNum];
            case StaticWords.Reviwe:
                return Reviwe[LanguageNum];
            default:
                return "Error";
        }
    }

}
