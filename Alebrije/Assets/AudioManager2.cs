using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class AudioManager2 {

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

}
