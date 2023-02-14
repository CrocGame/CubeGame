using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Stay
{
    Default = 0,
    Stay = 1,
    Down = 2,
    NoActive = 3
}

public class CubeFloor : MonoBehaviour
{
   

    [SerializeField] private Material[] materials;

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private MeshRenderer _mesh;

    private float point = -1;
    public Stay _stay = Stay.Default;

    private float timer = 0;

    private void FixedUpdate()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            _rigidbody.position = Vector3.Lerp(new Vector3(_rigidbody.position.x, point, _rigidbody.position.z), _rigidbody.position, timer / 3);
        }
        if (timer <= 0 && _stay == Stay.Stay)
            SetDown();
        if (timer <= 0 && _stay == Stay.Down)
            SetDefault();
    }
    public void SwitchStay(Stay stay)
    {
        timer = 3;
        _mesh.material = materials[(int)stay];
        _stay = stay;
    }
    public void SetDefault()
    {      
        SwitchStay(Stay.Default);
        point = -1;
    }
    public void SetStay()
    {
        SwitchStay(Stay.Stay);
        point = -1;
    }
    public void SetDown()
    {
        SwitchStay(Stay.Down);
        point = -5;
    }
    public void SetNoActive()
    {
        SetStay();
        StartCoroutine(TimeToNoActive());
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       if( collision.gameObject.TryGetComponent(out Player player))
        {
            if (_stay == Stay.Default)
                SetStay();           
        }
    }
    IEnumerator TimeToNoActive()
    {
        yield return new WaitForSeconds(3);
        SwitchStay(Stay.NoActive);
        point = -5;
    }
}

