using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Unity.FPS.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        List<string> scenes = new List<string> {"Level_1", "Level_2", "Level_3", "Level_4", "Level_5"}; 

        void Update()
        {
            if (EventSystem.current.currentSelectedGameObject == gameObject
                && Input.GetButtonDown(GameConstants.k_ButtonNameSubmit))
            {
                LoadTargetScene();
            }
        }

        public void LoadTargetScene()
        {
            string currScene = PlayerPrefs.GetString("scene");
            int numScene = scenes.IndexOf(currScene) + 1;
            if (numScene == 5) numScene = 1;
            SceneManager.LoadScene(scenes[numScene]);
        }
    }
}