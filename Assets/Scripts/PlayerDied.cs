using System.Collections;

using UnityEngine;

public class PlayerDied : MonoBehaviour
{

    [SerializeField] private Player _player;
    [SerializeField] private PlayerModel _playerModel;

    private Destroer _deathCube;
    private GameObject _modelCube;

    private void Start()
    {
        GetModel();
    }
    private void OnEnable()
    {
        _player.onReviwe += Reviwe;
    }
    private void OnDisable()
    {
        _player.onReviwe -= Reviwe;
    }
    private void GetModel()
    {
        _modelCube = _playerModel.ViewModel;
        _deathCube = _playerModel.GetComponentInChildren<Destroer>();
    }
    private void Reviwe()
    {
        _playerModel.CreateModel();
        GetModel();
    }
    private void Dead()
    {
        _deathCube.Active();
        _deathCube.transform.parent = null;
        Destroy(_modelCube);

        _player.onDead?.Invoke();
        _player.enabled = false;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DeathCube deathCube))
        {
            Dead();
        }
    }

}
