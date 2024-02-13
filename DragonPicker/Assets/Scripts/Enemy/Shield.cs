using TMPro;
using UnityEngine;

namespace Dragon
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] private int _score;
        [SerializeField] private TextMeshProUGUI _scoreText;

        private void Start()
        {
            GameObject scoreGameObject = GameObject.Find("ScoreText");
            _scoreText = scoreGameObject.GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            _scoreText.text = $"Score: {_score}";
            CursorMovements();
        }

        private void CursorMovements()
        {
            Vector3 mousePosition2D = Input.mousePosition;
            mousePosition2D.z = Camera.main.transform.position.z;
            Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint(mousePosition2D);

            Vector3 position = transform.position;
            position.x = mousePosition3D.x;
            transform.position = position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out DragonEgg dragonEgg))
                Destroy(collision.gameObject);

            _score++;
        }
    }
}