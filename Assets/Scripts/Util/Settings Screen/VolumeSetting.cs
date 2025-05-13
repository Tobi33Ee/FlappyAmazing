using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    public void setBgMusic(float volume)
    {
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void setSoundEffects(float volume)
    {
        PlayerPrefs.SetFloat("effectVolume", volume);
    }
}
