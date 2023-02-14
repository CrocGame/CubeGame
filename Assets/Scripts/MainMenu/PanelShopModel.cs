using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelShopModel : PanelShop
{
    public GameObject Model;

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
            Progress.Instance.SelectModel = Model;
            gameObject.GetComponentInParent<Shop>().UpdateButtonModel(Progress.Instance.playerStat.NumActivModel);
            Progress.Instance.playerStat.NumActivModel = Id;
            Progress.Instance.SaveStat();
        }
    }


    public override void CheckPurchase()
    {
        IsPurchase = Progress.Instance.PlayerInfo.StoryShopModel[Id];
    }
    public override void CheckActive()
    {
        if (Id == Progress.Instance.playerStat.NumActivModel)
        {
            _text.text = DictionaryLanguage.Instance.GetString(StaticWords.Selected);
            _button.enabled = false;
        }
    }

    public override void Save()
    {
        Progress.Instance.PlayerInfo.StoryShopModel[Id] = true;
        Progress.Instance.Save();
    }
}
