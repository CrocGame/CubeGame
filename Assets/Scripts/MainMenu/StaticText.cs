using UnityEngine;
using TMPro;

public class StaticText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private StaticWords _staticWords;
    
    private void Start()
    {
        _text.text = DictionaryLanguage.Instance.GetString(_staticWords);
    }
}
