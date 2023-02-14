using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderSoundView : MonoBehaviour
{
    [SerializeField] private FMOD.Studio.Bus _bus;
    [SerializeField] private Slider _slider;
    [SerializeField] private string _nameGroup;


    private void OnEnable()
    {
        _bus=FMODUnity.RuntimeManager.GetBus(_nameGroup);
        _bus.getVolume(out float value);
            _slider.value = value;
    }
}
