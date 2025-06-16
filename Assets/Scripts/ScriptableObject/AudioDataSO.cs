using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioDataSO", menuName = "Scriptable Objects/AudioDataSo")]
public class AudioDataSO : ScriptableObject
{
    [Header("Audio Mixer Groups")]
    public AudioMixerGroup BGMAudioMixer;
    public AudioMixerGroup SFXAudioMixer;

    [Header("BGM Clips")]
    public AudioClip Background;

    [Header("SFX Clips")]
    public AudioClip RoomDoorSound;
    // public AudioClip DoorSound;
    public AudioClip CardSound;
    // public AudioClip WalkSound;
    // public AudioClip PushButtonSound;
    // public AudioClip ChestSound;
    public AudioClip SocketItemSound;
    public AudioClip KeypadSound;
}