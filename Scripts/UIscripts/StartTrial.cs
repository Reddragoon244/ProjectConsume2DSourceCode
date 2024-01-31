using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartTrial : MonoBehaviour
{
    public void Starttrial() {
        LoadingScreen.Instance.Show(SceneManager.LoadSceneAsync("AlphaGame"));
        FindObjectOfType<GameManagerScript>().Player.gameObject.SetActive(true);
    }
}
