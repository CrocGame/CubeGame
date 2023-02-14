using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PanelShopDonation : PanelShop
{
    [DllImport("__Internal")]
    private static extern void BuyItem(string data, int id);


    [SerializeField] private PanelShop[] _panelShops;

    [SerializeField] private string _idItem;
     public string IdItem=>_idItem;

    public override void Buy()
    {
        BuyItem(_idItem, Id);
    }
    
    public void Purchased()
    {
        IsPurchase = true;
        foreach (var item in _panelShops) 
        {
            item.IsPurchase = true;
            item.Buy();
            item.Save();
        }
        CheckPurchase();
    }
    public override void CheckPurchase()
    {
        if (IsPurchase)
        {
            Disable();
        }
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }
    public override void CheckActive()
    {
        bool activ = false;
        foreach (var item in _panelShops)
        {
            if (item.IsPurchase == false)
            {
                activ = true;
                break;
            }
        }
        gameObject.SetActive(activ);

        CheckPurchase();
        if (!IsPurchase)
            _text.text = _cost.ToString();
    }

    public override void Save()
    {
        //не используется
    }
}
