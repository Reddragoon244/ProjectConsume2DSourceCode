using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobManagement : MonoBehaviour {

	public List<JobScript> unlockedJobs = new List<JobScript>();
	public JobScript[] activeJob = new JobScript[2];
    
    public static JobManagement instance;

	// Use this for initialization
	void Start () {
        if(instance == null)
            instance = this;
        
		if(unlockedJobs.Count == 0) {
			Debug.Log("job array empty");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void unlockJob(JobScript job) {
		if(job.unlocked == true) {
			unlockedJobs.Add(job);
		}
	}

	public void changeActiveJob1(JobScript job) {
		JobScript phJob;
		foreach(JobScript j in unlockedJobs) {
			if(j.jobname == job.jobname) {
				if(activeJob[1].jobname == job.jobname) {
					phJob = activeJob[0];
					activeJob[0] = activeJob[1];
					activeJob[1] = phJob;

				} else {
					activeJob[0] = job;
				}
			}
		}
	}

	public void changeActiveJob2(JobScript job) {
		JobScript phJob;
		foreach(JobScript j in unlockedJobs) {
			if(j.jobname == job.jobname) {
				if(activeJob[0].jobname == job.jobname) {
					phJob = activeJob[1];
					activeJob[1] = activeJob[0];
					activeJob[1] = phJob;
				} else {
					activeJob[1] = job;
				}
			}
		}
	}
}
