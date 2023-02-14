using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelShopDiedZone : PanelShop
{
    public GameObject DiedZone;
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
            Progress.Instance.SelectDiedZone = DiedZone;
            gameObject.GetComponentInParent<Shop>().UpdateButtonDiedZone(Progress.Instance.playerStat.NumActivDiedZone);
            Progress.Instance.playerStat.NumActivDiedZone = Id;
            Progress.Instance.SaveStat();
        }
    }

    public override void CheckPurchase()
    {
        IsPurchase = Progress.Instance.PlayerInfo.StoryShopDiedZone[Id];
    }
    public override void CheckActive()
    {
        if (Id == Progress.Instance.playerStat.NumActivDiedZone)
        {
            _text.text = DictionaryLanguage.Instance.GetString(StaticWords.Selected);
            _button.enabled = false;
        }
    }

    public override void Save()
    {
        Progress.Instance.PlayerInfo.StoryShopDiedZone[Id] = true;
        Progress.Instance.Save();
    }
}
