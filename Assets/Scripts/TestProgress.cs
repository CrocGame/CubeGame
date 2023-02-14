using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestProgress : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _text2;

    private void Start()
    {
        foreach (var item in Progress.Instance.PlayerInfo.StoryShopModel)
        {
            _text2.text += item.ToString()+"\n";
        }
    }

    private void Update()
    {
        _text.text = Progress.Instance.playerStat.CountCoins + "\n" + Progress.Instance.playerStat.MaxScore + "\n" + Progress.Instance.playerStat.MaxCoins;
    }
}
