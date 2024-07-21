
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("masterVolume", level);
    }

    public void SetSoundFXVolume(bool level)
    {
        if (level)
        {
            audioMixer.SetFloat("soundFXVolume", 0f);            
        }
        else
        {
            audioMixer.SetFloat("soundFXVolume", -80f);
        }
        
    }

    public void SetMusicVolume(bool level)
    {
        if (level)
        {
            audioMixer.SetFloat("musicVolume", 0f);            
        }
        else
        {
            audioMixer.SetFloat("musicVolume", -80f);
        }
    }
}
