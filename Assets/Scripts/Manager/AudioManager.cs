using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _backgroundMusicList = new List<AudioClip>();
    [SerializeField] private AudioSource _audioSource;

    private int _musicIndex = 0;

    private float _currentTime;
    private float _delayTime;
    
    void Start()
    {
        _audioSource.clip = _backgroundMusicList[_musicIndex];
        _audioSource.Play();
        _currentTime = Time.time + (_audioSource.clip.length - 0.1f);
    }

    void Update()
    {
        HandleMusic();
    }

    private void HandleMusic()
    {
        if(_currentTime < Time.time){
            _musicIndex++;
            if(_musicIndex >= _backgroundMusicList.Count)
                _musicIndex = 0;
            
            _audioSource.clip = _backgroundMusicList[_musicIndex];
            _audioSource.Play();

            _currentTime = Time.time + (_audioSource.clip.length - 0.1f);
        }
    }
}
