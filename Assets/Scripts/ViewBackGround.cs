using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewBackGround : MonoBehaviour
{
    [SerializeField] private Image _image;
    private void OnEnable()
    {
        UpdateViewBackGround();
    }
    public void UpdateViewBackGround()
    {
        _image.sprite = Progress.Instance.SelectBackGrouns;
    }
}
