using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class JobCreation : EditorWindow {

	public JobScript PHjob;
	private BaseAbility PHability = null;
	private string PHname;

	private new string title = "Welcome to Job Creator";

	[MenuItem("Tools/Create Job")]
    static void Init()
    {
        GetWindow(typeof(JobCreation));
        GetWindow(typeof(JobCreation)).minSize = new Vector2(550.0f, 550.0f);
    }

    void OnEnable()
    {
		createJob();
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            PHjob = AssetDatabase.LoadAssetAtPath(objectPath, typeof(JobScript)) as JobScript;
        }
    }

    void OnGUI()
    {
		GUILayout.BeginHorizontal();
		GUILayout.Space(50);
        GUILayout.Label(title, EditorStyles.centeredGreyMiniLabel);
		GUILayout.Space(50);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
		if(title == "Welcome to Job Creator") {
			if (GUILayout.Button ("Create Job")) {
				title = "Create Job Menu";
			}
			GUILayout.Space (100);
			if (GUILayout.Button ("Modify Job")) {
				title = "Modify Job Menu";
				PHjob = null;
			}
		}
		GUILayout.EndHorizontal ();

		if(title == "Create Job Menu") {
			GUILayout.BeginVertical();
			PHjob.jobname = (JobScript.jobName)EditorGUILayout.EnumPopup("Job", PHjob.jobname);
			PHname = PHjob.jobname.ToString();
			GUILayout.EndVertical();
			if (PHjob)
			{
				GUILayout.BeginVertical();
				PHability = EditorGUILayout.ObjectField("Choose Ability", PHability, typeof(BaseAbility), true) as BaseAbility;
				
				if (PHability)
				{
					addToAbilityList();
				}

				if (GUILayout.Button("Create Empty Job", GUILayout.ExpandWidth(false)) && PHjob.abilityList.Count.Equals(0))
					CreateNewJob();
				else if (GUILayout.Button("Create Job with " + PHjob.abilityList.Count + " abilities in it", GUILayout.ExpandWidth(false)) && PHjob.abilityList.Count >= 1)
					CreateNewJob();

				GUILayout.EndVertical();
			}
		}
	
		if(title == "Modify Job Menu") {
			GUILayout.BeginVertical();
			PHjob = EditorGUILayout.ObjectField("Choose a Job", PHjob, typeof(JobScript), true) as JobScript;
			GUILayout.EndVertical();

			if (PHjob)
			{
				PHname = PHjob.jobname.ToString();
				GUILayout.BeginVertical();
				PHability = EditorGUILayout.ObjectField("Choose Ability", PHability, typeof(BaseAbility), true) as BaseAbility;
				GUILayout.EndVertical();
				
				if (PHability)
				{
					addToAbilityList();
				}
				
				GUILayout.BeginVertical();
				if (GUILayout.Button("Modify Job with " + PHjob.abilityList.Count + " abilities in it", GUILayout.ExpandWidth(false)) && PHjob.abilityList.Count >= 1)
					ModifyNewJob();

				GUILayout.EndVertical();
			}
		}
	}

	void addToAbilityList()
    {
		GUILayout.BeginVertical();
        if (GUILayout.Button("Add Ability", GUILayout.ExpandWidth(false)))
        {
            PHjob.abilityList.Add(PHability);
            PHability = null;
        }
		GUILayout.EndVertical();
    }

	void createJob() {
		PHjob = CreateInstance<JobScript>();
	}

    void CreateNewJob()
    {
        JobScript job = PHjob;

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects"))
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects/Jobs"))
            AssetDatabase.CreateFolder("Assets/ScriptableObjects", "Jobs");

        AssetDatabase.CreateAsset(job, "Assets/ScriptableObjects/Jobs/" + PHname + ".asset");
            AssetDatabase.SaveAssets();

		createJob();
    }
	void ModifyNewJob()
    {
    	AssetDatabase.SaveAssets();
    }

}
