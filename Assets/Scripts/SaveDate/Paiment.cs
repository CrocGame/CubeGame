using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;


[System.Serializable]
public class Pursing
{
    public List<purchaseData> purchaseData;
}
[System.Serializable]
public class purchaseData
{
    public string productID;
    public string purchaseToken;
}

public class Paiment : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void ChecBuyItem();

    [SerializeField] private GameObject _container;

    private PanelShopDonation[] _panelShopDonations;
    private Pursing _purs;

    private void Start()
    {
        _panelShopDonations =_container.GetComponentsInChildren<PanelShopDonation>();
        ChecBuyItem();
    }
    public void Buy(int id)
    {
        _panelShopDonations[id].Purchased();
    }
    public void CheckBuy(string value)
    {
        _purs = JsonUtility.FromJson<Pursing>("{\"purchaseData\":" + value + "}");

        foreach (var key in _purs.purchaseData)
        {
            foreach (var item in _panelShopDonations)
            {
                if (item.IdItem == key.productID)
                {
                    item.Disable();
                }
            }
        }
    }


}
