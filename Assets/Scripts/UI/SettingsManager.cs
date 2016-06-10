using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class SettingsManager : MonoBehaviour 
{
    public enum SettingsPainels { Main, Grapchics, Audio }

  
    public AudioMixer masterMixer = null;

    public GameObject MainPainel = null;
    public GameObject GraphicsPainel = null;
    public GameObject AudioPainel = null;


    public Sprite mude = null;
    public Sprite sound = null;
    public Image musicImg = null;
    public Image sfxImg = null;
    public Image geralImg = null;

    public Slider music = null;
    public Slider sfx = null;
    public Slider Geral = null;
    public Dropdown resolutionDropDown = null;
    public Toggle fullscreen = null;
    public Toggle vSync = null;

    private bool _fullscreen;
    private Resolution[] _resolutions;
    private float _masterVol = 0.0f;
    private float _musicVol = 0.0f;
    private float _sfxVol = 0.0f;

    private AudioSource clickAudio = null;

    private void Awake()
    {
        clickAudio = GetComponent<AudioSource>();
        _resolutions = Screen.resolutions;                                                       // Recebe resoluções suportadas.
        resolutionDropDown.options.Clear();
        resolutionDropDown.captionText.text = Screen.currentResolution.width + " x " + Screen.currentResolution.height;

        foreach (var item in _resolutions)
        {
            resolutionDropDown.options.Add(new Dropdown.OptionData() { text = item.width + " x " + item.height });
        }

        masterMixer.GetFloat("masterVol", out _masterVol);
        Geral.value = _masterVol;
        masterMixer.GetFloat("musicVol", out _musicVol);
        music.value = _musicVol;
        masterMixer.GetFloat("sfxVol", out _sfxVol);
        sfx.value = _sfxVol;
    } 
        

    private void OnEnable()
    {
        resolutionDropDown.captionText.text = Screen.currentResolution.width + " x " + Screen.currentResolution.height;
        SetPainel(SettingsPainels.Main);
    }

    public void OnClick(string function)
    {
        StartCoroutine(function);
    }

    public void GraphicsApply()
    {        
        QualitySettings.vSyncCount = (vSync.isOn) ? 2 : 0;             
        Screen.SetResolution(_resolutions[resolutionDropDown.value].width, _resolutions[resolutionDropDown.value].height, fullscreen.isOn);
        clickAudio.Play();
        SetPainel(SettingsPainels.Main);

        // Serializar em arquivo??
    }

    // retorna o audio ao volume antes de alterações
    public void AudioCancel()
    {        
        masterMixer.SetFloat("masterVol", _masterVol);
        masterMixer.SetFloat("musicVol", _musicVol);
        masterMixer.SetFloat("sfxVol", _sfxVol);
        Geral.value = _masterVol;
        music.value = _musicVol;
        sfx.value = _sfxVol;
        clickAudio.Play();
        SetPainel(SettingsPainels.Main);
    }

    public void SetMainPainel()
    {
        clickAudio.Play();
        SetPainel(SettingsPainels.Main);
    }

    public void SetGraphicsPainel()
    {
        clickAudio.Play();
        SetPainel(SettingsPainels.Grapchics);
    }

    public void SetAudioPainel()
    {
        clickAudio.Play();
        SetPainel(SettingsPainels.Audio);
    }

    public void SetMasterVol(float masterVol)
    {
        masterMixer.SetFloat("masterVol", masterVol);
    }

    public void SetMusicVol(float musicVol)
    {
        masterMixer.SetFloat("musicVol", musicVol);
    }

    public void SetSfxVol(float sfxVol)
    {
        masterMixer.SetFloat("sfxVol", sfxVol);
    }


    private void SetPainel(SettingsPainels painel)
    {
        switch (painel)
        {
            case SettingsPainels.Main:
                MainPainel.SetActive(true);
                GraphicsPainel.SetActive(false);
                AudioPainel.SetActive(false);
                break;

            case SettingsPainels.Grapchics:
                resolutionDropDown.captionText.text = Screen.currentResolution.width + " x " + Screen.currentResolution.height;
                MainPainel.SetActive(false);
                GraphicsPainel.SetActive(true);
                AudioPainel.SetActive(false);
                break;

            case SettingsPainels.Audio:                
                MainPainel.SetActive(false);
                GraphicsPainel.SetActive(false);
                AudioPainel.SetActive(true);
                masterMixer.GetFloat("masterVol", out _masterVol);
                masterMixer.GetFloat("musicVol", out _musicVol);
                masterMixer.GetFloat("sfxVol", out _sfxVol);



                break;

            default:
                break;
        }

    }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
