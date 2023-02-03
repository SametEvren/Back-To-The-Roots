using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Managers
{
    public class SceneController : Instancable<SceneController>
    {
        public void LoadModernWorld()
        {
            SceneManager.LoadScene("ModernWorld");
        }
    }
}
