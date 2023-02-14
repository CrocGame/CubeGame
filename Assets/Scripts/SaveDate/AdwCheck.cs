using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AdwCheck : MonoBehaviour
{

    public static AdwCheck Instance;


    public float TimeAds;
    public bool ButtonTimeCoins;

    private FMOD.Studio.Bus Master;
    private bool viewAds;
    public bool ViewAds => viewAds;


    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
            

        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Master = FMODUnity.RuntimeManager.GetBus("bus:/");
    }   
    private void Update()
    {
        if (TimeAds > 0)
        {
            TimeAds -= Time.deltaTime;
        }
    }
    public void MusicOff()
    {
        Master.setVolume(0);
        viewAds = true;
    }
    public void MusicOn()
    {
        Master.setVolume(1);
        viewAds = false;
    }

}
