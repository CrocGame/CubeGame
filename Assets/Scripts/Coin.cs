using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rotation
{
    Right,
    Left,
    Up,
    Down,
    Drop
}

public class Coin : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;
    [SerializeField] public float _speed;
    [SerializeField] public float _timeLife;
    [SerializeField] public Rigidbody _rigidbody;




    public Rotation _rotation;

    private Vector3 direction;
    private float timer;

    private void OnEnable()
    {
        timer = _timeLife;
        _rigidbody.useGravity = false;
        switch (_rotation)
        {
            case Rotation.Right:
                direction = Vector3.right;
                break;
            case Rotation.Left:
                direction = Vector3.left;
                break;
            case Rotation.Up:
                direction = Vector3.forward;
                break;
            case Rotation.Down:
                direction = Vector3.back;
                break;
            case Rotation.Drop:
                direction = Vector3.zero;
                _rigidbody.useGravity = true;
                break;
        }
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameObject.SetActive(false);
        }
        _rigidbody.AddTorque(_rotationSpeed * Time.deltaTime, _rotationSpeed * Time.deltaTime, 0);
        _rigidbody.position += direction * _speed * Time.deltaTime;
    }
    public void PickUp()
    {
        gameObject.SetActive(false);
    }
}
