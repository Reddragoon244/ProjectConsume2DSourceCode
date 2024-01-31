using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagementSystem : MonoBehaviour
{
    public static SceneManagementSystem instance;
    
    void Start () {
        if(instance == null)
            instance = this;
            
        DontDestroyOnLoad(this.gameObject);
	}
    
    public void SceneChange(string sceneName)
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single));
    }

    public string CheckScene()
    {
        string sceneCheck = "";

        sceneCheck = SceneManager.GetActiveScene().name;

        return sceneCheck;
    }
}
