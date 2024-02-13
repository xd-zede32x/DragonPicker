using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace StartMenu
{
    public class Menu : MonoBehaviour
    { 
        public void TranslationScene(int index) => SceneManager.LoadScene(index);
        public void ExitGame() => Application.Quit(); 
    }
}