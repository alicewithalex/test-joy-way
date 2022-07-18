using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffectListener : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    public void PlaySoundEffect()
    {
        if (!_audioSource || !_audioClip) return;

        _audioSource.PlayOneShot(_audioClip);
    }
}
