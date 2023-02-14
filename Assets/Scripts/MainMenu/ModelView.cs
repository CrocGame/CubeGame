using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelView : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private Shop _shop;
    private GameObject _chooseModel;
    private GameObject _viewModel;
    private void Start()
    {
        _shop.GetActivModels();
        UpdateModelView();
    }
    void Update()
    {
        transform.Rotate(0, _speedMove * Time.deltaTime, 0);
    }
    public void UpdateModelView()
    {
        _chooseModel = Progress.Instance.SelectModel;
        if (_viewModel != null)
            Destroy(_viewModel);
        _viewModel = Instantiate(_chooseModel, transform);
    }
}
