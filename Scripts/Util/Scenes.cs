using UnityEngine;
using UnityEngine.SceneManagement;

namespace Plugins.Util
{
    public static class Scenes
    {
        public static void Reload()
        {
            var scene = SceneManager.GetActiveScene();
            Debug.Log($"Reset to Scene: ${scene.name}");
            SceneManager.LoadScene(scene.buildIndex);
        }
        
    }
}