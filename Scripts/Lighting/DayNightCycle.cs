using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun;
    public float secondsInFullDay = 540f;
    [Range(0,1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;
    
    float sunInitialIntensity;

    public static DayNightCycle instance;
    private GameManagerScript gm;

    
    void Awake() {
        if(instance == null)
            instance = this;
        
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
        gm = FindObjectOfType<GameManagerScript>();

        sunInitialIntensity = sun.intensity;
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
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;
    }
    
    void UpdateSun() {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
    }
}
