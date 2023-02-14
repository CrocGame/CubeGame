using UnityEngine;
using UnityEngine.UI;

public class ReviwePanel : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Image _image;

    [SerializeField] private PlayerManager _playerManager;


    private float _timer;

    private void OnEnable()
    {
        _timer = _time;
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            _image.fillAmount = _timer / _time;
        }
        else
        {
            ButtonClose();
        }
    }

    
    public void ButtonReviwe()
    {
        AdwCheck.Instance.MusicOff();
        _playerManager.StartAdwReviwe();
        gameObject.SetActive(false);
    }
    public void ButtonClose()
    {
        _playerManager.SaveScore();
        gameObject.SetActive(false);
    }
}
