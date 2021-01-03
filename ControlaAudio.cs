using UnityEditor;
using UnityEngine;

namespace Assets.Scripts
{
    public class ControlaAudio : MonoBehaviour
    {
        private AudioSource meuAudioSource;
        public static AudioSource instancia;

        void Awake()
        {
            meuAudioSource = GetComponent<AudioSource>();
            instancia = meuAudioSource;
        }

    }
}