using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneToTransitioner : MonoBehaviour
{
    [SerializeField]
    private string sceneToTransitionTo;
    public void Transition()
    {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync(sceneToTransitionTo));
    }
}
