using System;
using Binding;
using Plugins.Util;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Util;

namespace Plugins.Data
{
    [RequireComponent(typeof(Button))]
    public class ResetButton : MonoBehaviour
    {
        public static event EventHandler OnGlobalReset;
        public static bool HasReset = false;

        public bool clearScenes;
        
        [Bind] 
        private Button _button;
        
        private void Awake()
        {
            this.Bind();
            _button.onClick.AddListener(() => ResetData(clearScenes));
        }

        public static void ResetData(bool clearScenes = false)
        {
            HasReset = true;
            foreach (var obj in SceneManager.GetActiveScene().GetRootGameObjects())
                obj.SetActive(false);
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            OnGlobalReset?.Invoke();
            if (clearScenes)
                Scenes.Clear();
            else
                Scenes.Reload();
        }
    }
}