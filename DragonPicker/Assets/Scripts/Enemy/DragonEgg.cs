using UnityEngine;

namespace Dragon
{
    [RequireComponent(typeof(AudioSource))]
    public class DragonEgg : MonoBehaviour
    {
        [SerializeField] private float _bottomY;
        [SerializeField] private float _timeToDeath;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();     
        }

        private void Update()
        {
            if (transform.position.y < _bottomY)
            {
                Destroy(gameObject);

                DragonPicker dragonPicker = Camera.main.GetComponent<DragonPicker>();
                dragonPicker.DragonEggDestroyed();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            ParticleSystem particleSystem = GetComponent<ParticleSystem>();
            var emission = particleSystem.emission;
            emission.enabled = true;

            Renderer renderer = GetComponent<Renderer>();
            renderer.enabled = false;

            _audioSource.Play();

            Destroy(gameObject, _timeToDeath);
        }
    }
}