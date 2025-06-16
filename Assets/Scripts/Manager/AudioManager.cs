using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioDataSO _audioData;
    public AudioDataSO AudioData => _audioData;

    //# BGM 전용 AudioSource, SFX는 ObjectPool을 사용
    private AudioSource _bgmAudioSource;

    private Dictionary<AudioClipName, AudioClip> _audioClips = new Dictionary<AudioClipName, AudioClip>(10);

    private void Awake()
    {
        InitAudioClip();
        InitBGMAudioSource();
    }

    private void Start() => PlayBGM(AudioClipName.Background);

    //# enum을 사용하여 Audio Clip을 Dictionary로 관리
    private void InitAudioClip()
    {
        _audioClips[AudioClipName.Background] = _audioData.Background;
        _audioClips[AudioClipName.RoomDoorSound] = _audioData.RoomDoorSound;
        // _audioClips[AudioClipName.DoorSound] = _audioData.DoorSound;
        _audioClips[AudioClipName.CardSound] = _audioData.CardSound;
        // _audioClips[AudioClipName.WalkSound] = _audioData.WalkSound;
        // _audioClips[AudioClipName.PushButtonSound] = _audioData.PushButtonSound;
        // _audioClips[AudioClipName.ChestSound] = _audioData.ChestSound;
        _audioClips[AudioClipName.SocketItemSound] = _audioData.SocketItemSound;
        _audioClips[AudioClipName.KeypadSound] = _audioData.KeypadSound;
    }

    private void InitBGMAudioSource()
    {
        if (_bgmAudioSource == null)
        {
            _bgmAudioSource = gameObject.AddComponent<AudioSource>();
        }

        //# BGM 설정
        _bgmAudioSource.outputAudioMixerGroup = _audioData.BGMAudioMixer;
        _bgmAudioSource.loop = true;
        _bgmAudioSource.playOnAwake = false;

        //# 2D 사운드 - BGM 입체적으로 들릴 필요가 없음
        _bgmAudioSource.spatialBlend = 0f;
    }

    //# BGM 재생
    public void PlayBGM(AudioClipName clipName)
    {
        if (_audioClips.TryGetValue(clipName, out var clip))
        {
            _bgmAudioSource.clip = clip;
            _bgmAudioSource.Play();
        }
    }

    //# SFX 재생 - Pool 사용
    public void PlaySFX(AudioClipName clipName, Vector3 position, bool isUI = false, float volume = 1f, float pitch = 1f)
    {
        if (_audioClips.TryGetValue(clipName, out var clip))
        {
            var audioController = AudioSourcePool.Instance.Pool.Get();

            // audioController.AudioSource.outputAudioMixerGroup = _audioData.SFXAudioMixer;

            // Pool에서 가져온 AudioSource 설정 강제 적용
            if (isUI)
            {
                audioController.AudioSource.spatialBlend = 0f;
            }
            else
            {
                audioController.AudioSource.spatialBlend = 1f;
                audioController.AudioSource.rolloffMode = AudioRolloffMode.Logarithmic;
                audioController.AudioSource.minDistance = 5f;
                audioController.AudioSource.maxDistance = 30f; // 현재 설정과 맞춤
            }

            audioController.AudioSource.outputAudioMixerGroup = _audioData.SFXAudioMixer;
            audioController.PlayAudio(clip, position, volume, pitch);
        }
    }

    //# UI(Button Click) 재생
    public void Play2DSFX(AudioClipName clipName, float volume = 1f)
    {
        PlaySFX(clipName, Vector3.zero, true, volume);
    }

    public void StopBGM()
    {
        _bgmAudioSource.Stop();
    }
}