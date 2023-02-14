using FMODUnity;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Joystick _joystick;
    private float speedTimer = 0;
    private Vector2 _derection;

    public UnityAction onDead;
    public UnityAction onReviwe;
    public UnityAction onPickUpCoin;
    public UnityAction onMove;

    public PlayerControls inputActions;



    [SerializeField] private EventReference PlayerMove;


    private void Awake()
    {
        inputActions = new PlayerControls();
        inputActions.Enable();
    }

    private void Update()
    {    
        if (speedTimer>0)
        {
            speedTimer -= Time.deltaTime;
        }
        else
        {
            _derection = inputActions.Player.Move.ReadValue<Vector2>();
            if(Mathf.Abs(_joystick.Horizontal)>0.5f || Mathf.Abs(_joystick.Vertical)>0.5f)
            _derection = new Vector2(_joystick.Horizontal, _joystick.Vertical);
            if (_derection!=Vector2.zero && _rigidbody.position.y>-0.5f)
                Move();
            
        }
    }
    private void Move()
    {
        FMODUnity.RuntimeManager.PlayOneShot(PlayerMove);
        speedTimer = _speed;
        _rigidbody.position = _rigidbody.position +  Vector3.right * Mathf.Round(_derection.x)+ Vector3.forward * Mathf.Round(_derection.y);
        onMove?.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coin.PickUp();
            onPickUpCoin?.Invoke();
        }
    }

    public void PlayerRevive()
    {
        onReviwe?.Invoke();
        _rigidbody.useGravity = false;
        _rigidbody.position = new Vector3(_rigidbody.position.x, 3, _rigidbody.position.z);
        _rigidbody.velocity = Vector3.zero;
        this.enabled = true;
        onMove += CheckMove;
    }
    private void CheckMove()
    {
        onMove -= CheckMove;
        StartCoroutine(DeleyRevive());
    }
    IEnumerator DeleyRevive()
    {
        yield return new WaitForSeconds(3);
        _rigidbody.useGravity = true;
    }

}
