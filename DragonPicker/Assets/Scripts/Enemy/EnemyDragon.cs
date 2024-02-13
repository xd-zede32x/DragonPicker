using UnityEngine;
using System.Collections;

namespace Dragon
{
    public class EnemyDragon : MonoBehaviour
    {
        [SerializeField] private GameObject _dragonEggPrefab;

        [SerializeField] private float _speedFlyDragon;
        [SerializeField] private float _timeBetweenEggDrops;
        [SerializeField] private float _leftRightDistance;
        [SerializeField] private float _changeDirections;

        private void Start() => StartCoroutine(DropEgg(_timeBetweenEggDrops));

        private void FixedUpdate()
        {
            if (Random.value < _changeDirections)
                _speedFlyDragon *= -1;
        }

        private void Update() => FlightDragon();

        private void FlightDragon()
        {
            Vector3 position = transform.position;
            position.x += _speedFlyDragon * Time.deltaTime;
            transform.position = position;

            if (position.x < -_leftRightDistance)
                _speedFlyDragon = Mathf.Abs(_speedFlyDragon);

            else if (position.x > _leftRightDistance)
                _speedFlyDragon = -Mathf.Abs(_speedFlyDragon);
        }

        private void DragonDropEgg()
        {
            Vector3 position = new(0.0f, 5.0f, 0.0f);

            GameObject egg = Instantiate(_dragonEggPrefab);
            egg.transform.position = transform.position + position;

            StartCoroutine(DropEgg(_timeBetweenEggDrops));
        }

        private IEnumerator DropEgg(float timeSpawnEgg)
        {
            yield return new WaitForSeconds(timeSpawnEgg);
            DragonDropEgg();
        }
    }
}