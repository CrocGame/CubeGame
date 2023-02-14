using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class PanelShop : MonoBehaviour
{
    [SerializeField] protected int _cost;
    [SerializeField] protected Button _button;
    [SerializeField] protected TMP_Text _text;

    public int Id;
    public bool IsPurchase;

    private void Start()
    {
        StartAction();
    }

    private void OnEnable()
    {
        StartAction();
    }

    private void StartAction()
    {
        CheckPurchase();
        if (!IsPurchase)
            _text.text = _cost.ToString();
        else
        {
            _text.text = DictionaryLanguage.Instance.GetString(StaticWords.Use);
            _button.enabled = true;
        }
        CheckActive();
    }

    public void SetUse()
    {
        _text.text = DictionaryLanguage.Instance.GetString(StaticWords.Use);
        _button.enabled = true;
    }
    public abstract void Buy();
    public abstract void CheckPurchase();
    public abstract void CheckActive();
    public abstract void Save();

    
}
