using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelShopCubeFloor : PanelShop
{
    public CubeFloor cubeFloor;

    public override void Buy()
    {
        if (Progress.Instance.playerStat.CountCoins >= _cost && !IsPurchase)
        {
            Progress.Instance.playerStat.CountCoins -= _cost;
            IsPurchase = true;
            Save();    
        }
        if (IsPurchase)
        {
            _text.text = DictionaryLanguage.Instance.GetString(StaticWords.Selected);
            _button.enabled = false;
            Progress.Instance.SelectFloorBlock = cubeFloor;
            gameObject.GetComponentInParent<Shop>().UpdateButtonFloorBlock(Progress.Instance.playerStat.NumActivFloorBlock);
            Progress.Instance.playerStat.NumActivFloorBlock = Id;
            Progress.Instance.SaveStat();
        }
    }

    public override void CheckPurchase()
    {
        IsPurchase = Progress.Instance.PlayerInfo.StoryShopfloorBlock[Id];
    }
    public override void CheckActive()
    {
        if (Id == Progress.Instance.playerStat.NumActivFloorBlock)
        {
            _text.text = DictionaryLanguage.Instance.GetString(StaticWords.Selected);
            _button.enabled = false;
        }
    }

    public override void Save()
    {
        Progress.Instance.PlayerInfo.StoryShopfloorBlock[Id] = true;
        Progress.Instance.Save();
    }
}
