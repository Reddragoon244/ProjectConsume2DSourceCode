using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public UnityEngine.Rendering.Universal.Light2D sun;
    public float secondsInFullDay = 540f;
    [Range(0,1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;

    public static DayNightCycle instance;
    private GameManagerScript gm;
    private bool midnight = false;
    private bool afternoon = false;

    
    void Awake() {
        if(midnight == false && afternoon == false) {
            midnight = true;
        }

        if(instance == null)
            instance = this;
        
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
        gm = FindObjectOfType<GameManagerScript>();
    }
    
    void Update() {
        if(gm.playeroutside == false) {
            sun.GetComponent<Light>().enabled = false;
        } else {
            if(sun.GetComponent<Light>().enabled == false) {
                sun.GetComponent<Light>().enabled = true;
            }
        }
 
        UpdateSun();
    }
    
    void UpdateSun() {
        if(sun.intensity <= 0.0f) {
            midnight = true;
            afternoon = false;
        }

        if(sun.intensity >= 1.0f) {
            afternoon = true;
            midnight = false;
        }

        if(afternoon) {
            currentTimeOfDay -= (Time.deltaTime / secondsInFullDay) * timeMultiplier;
            sun.intensity = Mathf.Clamp(currentTimeOfDay, 0.0f, 1.0f);
            
        }

        if(midnight) {
            currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
            sun.intensity = Mathf.Clamp(currentTimeOfDay, 0.0f, 1.0f);
        }
        
    }
}
