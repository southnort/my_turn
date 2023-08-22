using Yrr.UI;
using UnityEngine.SceneManagement;

namespace Game.UI
{
    internal sealed class GameOverScreen : UIScreen
    {
        public void ClickOnRestart()
        {
            SceneManager.LoadScene(gameObject.scene.name);
        }
    }
}
