using UnityEngine;

namespace Controllers
{
    public class AudioPlaybackController : MonoBehaviour
    {
        [SerializeField]
        private AudioClip clickSound;

        [SerializeField]
        private AudioClip explosionSound;

        [SerializeField]
        private AudioClip powerUpSound;

        [SerializeField]
        private AudioClip gameOverSound;

        public void PlayClickSound()
        {
            GetComponent<AudioSource>().PlayOneShot(clickSound);
        }

        public void PlayExplosionSound()
        {
            GetComponent<AudioSource>().PlayOneShot(explosionSound);
        }

        public void PlayPowerUpSound()
        {
            GetComponent<AudioSource>().PlayOneShot(powerUpSound);
        }

        public void PlayGameOverSound()
        {
            GetComponent<AudioSource>().PlayOneShot(gameOverSound);
        }
    }
}