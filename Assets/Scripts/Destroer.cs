using UnityEngine;
using System.Collections;

public class Destroer : MonoBehaviour
{
    [SerializeField] private bool IsActive;

    [SerializeField] private float _timeVisible;

    [SerializeField] private Rigidbody[] _rigidbodys;



    public void Active()
    {
        foreach (var item in _rigidbodys)
        {
            item.gameObject.SetActive(true);
            item.AddForceAtPosition(Vector3.up * Random.Range(400,600), transform.position);
        }
        StartCoroutine(DestroyDied());
    }

    IEnumerator DestroyDied()
    {
        yield return new WaitForSeconds(_timeVisible);
        Destroy(gameObject);

    }
}
