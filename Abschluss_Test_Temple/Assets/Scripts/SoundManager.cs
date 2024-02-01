using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource CorrectSound;
    public AudioSource WinSound;
    public AudioSource WrongSound;

    public void PlayCorectSound()
    {
        CorrectSound.Play();
    }

    public void PlayWinSound()
    {
        WinSound.Play();
    }

    public void PlayWrongSound()
    {
        WrongSound.Play();
    }
}
