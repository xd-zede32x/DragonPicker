using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dragon
{
    public class DragonPicker : MonoBehaviour
    {
        [SerializeField] private int _numberShield;
        [SerializeField] private float _shieldButtomY;
        [SerializeField] private GameObject _shieldPrefab;
        [SerializeField] private List<GameObject> _basketList;

        private void Start() => SpawnShield();

        public void DragonEggDestroyed()
        {
            GameObject[] _dragonEggArray = GameObject.FindGameObjectsWithTag("DragonEgg");

            foreach (GameObject gameObject in _dragonEggArray)
                Destroy(gameObject);

            int basketIndex = _basketList.Count - 1;
            GameObject backetGameObject = _basketList[basketIndex];
            _basketList.RemoveAt(basketIndex);

            Destroy(backetGameObject);

            if (_basketList.Count == 0) 
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void SpawnShield()
        {
            _basketList = new List<GameObject>();

            for (int index = 1; index <= _numberShield; index++)
            {
                GameObject gameObject = Instantiate(_shieldPrefab);
                gameObject.transform.position = new(0f, _shieldButtomY, 0f);
                _basketList.Add(gameObject);
            }
        }
    }
}