using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelShopBackGround : PanelShop
{
    public Sprite SpriteBackGround;


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
            Progress.Instance.SelectBackGrouns = SpriteBackGround;
            gameObject.GetComponentInParent<Shop>().UpdateButtonBackGround(Progress.Instance.playerStat.NumActivBackGround);
            Progress.Instance.playerStat.NumActivBackGround = Id;
            Progress.Instance.SaveStat();
        }
    }

    public override void CheckPurchase()
    {
        IsPurchase = Progress.Instance.PlayerInfo.StoryShopBackGround[Id];
    }
    public override void CheckActive()
    {
        if (Id == Progress.Instance.playerStat.NumActivBackGround)
        {
            _text.text = DictionaryLanguage.Instance.GetString(StaticWords.Selected);
            _button.enabled = false;
        }
    }

    public override void Save()
    {
        Progress.Instance.PlayerInfo.StoryShopBackGround[Id] = true;
        Progress.Instance.Save();
    }
}
