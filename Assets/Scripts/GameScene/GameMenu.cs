using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameScene
{
    public class GameMenu : MonoBehaviour
    {
        public void QuitGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}