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
        int numScene;

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
            Scene currScene = SceneManager.GetActiveScene();
            string pastScene = PlayerPrefs.GetString("scene");
            numScene = scenes.IndexOf(pastScene) + 1;
            int boolState = 0;
            if (currScene.name == "NewIntroMenu" || currScene.name == "NewLoseScene")
            {
                boolState = 1;
            }

            if (boolState == 1  || numScene == 5)
            {
                numScene = 0;
            }

            Debug.Log(scenes[numScene]);
            SceneManager.LoadScene(scenes[numScene]);
        }
    }
}