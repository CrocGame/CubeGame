using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private GameObject _model;

    public GameObject ViewModel;

    private void Awake()
    {
        _model= Progress.Instance.SelectModel;
        CreateModel();
    }
    public void CreateModel()
    {
        ViewModel = Instantiate(_model, transform);
    }
}
