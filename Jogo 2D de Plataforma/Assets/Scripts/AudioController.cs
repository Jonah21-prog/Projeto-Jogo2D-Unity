using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audiosourceMusicaDeFundo;
    public AudioSource audioSourceSFX;
    public AudioClip[] musicasDeFundo;
    // Start is called before the first frame update
    void Start()
    {
        int IndexDaMusicaDeFundo = Random.Range(0, 2);
        AudioClip musicaDeFundoDessaFase = musicasDeFundo[IndexDaMusicaDeFundo];
        audiosourceMusicaDeFundo.clip = musicaDeFundoDessaFase;
        audiosourceMusicaDeFundo.loop = true;
        audiosourceMusicaDeFundo.Play();
    }

    public void ToqueSFX(AudioClip clip)
    {
        audioSourceSFX.clip = clip;
        audioSourceSFX.Play();
    }
}
