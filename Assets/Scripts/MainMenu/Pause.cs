using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    //[SerializeField] private AudioMixerGroup _audioMixer;

    private bool _isPause;


    private FMOD.Studio.Bus BackGrounds;
    private FMOD.Studio.Bus Effect;
    private FMOD.Studio.Bus Master;

    private void Start()
    {
        BackGrounds = FMODUnity.RuntimeManager.GetBus("bus:/BackGrounds");
        Effect = FMODUnity.RuntimeManager.GetBus("bus:/Effects");
        Master = FMODUnity.RuntimeManager.GetBus("bus:/");

    }

    public void OnPause()
    {
        if (_isPause)
        {
            Time.timeScale = 1;
            _isPause = false;
        }
        else
        {
            Time.timeScale = 0;
            _isPause = true;
        }
        _pausePanel.SetActive(_isPause);
    }
    public void Music(float volume)
    {
        BackGrounds.setVolume(volume);
    }
    public void Effects(float volume)
    {
        Effect.setVolume(volume);
    }
    void OnApplicationFocus(bool hasFocus)
    {
        if (!AdwCheck.Instance.ViewAds)
        {
            if (hasFocus)
            {
                Master.setVolume(1);
            }
            else
            {
                Master.setVolume(0);
            }
        }

    }

    void OnApplicationPause(bool pauseStatus)
    {
        if (!AdwCheck.Instance.ViewAds)
        {
            if (pauseStatus)
            {
                Master.setVolume(1);
            }
            else
            {
                Master.setVolume(0);
            }
        }
    }
}
