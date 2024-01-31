using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CombinedAbilityCreation : EditorWindow {

    public AbilityList library;

    [MenuItem("Tools/Create Combined Ability Library")]
    static void Init()
    {
        GetWindow(typeof(CombinedAbilityCreation), true);
        GetWindow(typeof(CombinedAbilityCreation)).minSize = new Vector2(550.0f, 550.0f);
    }
    void OnEnable()
    {
        library = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Libraries/CombinedSpellBook.asset", typeof(AbilityList)) as AbilityList;
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Space(150);
        GUILayout.Label("Create ScriptableObject of a Combined Ability", EditorStyles.centeredGreyMiniLabel);
        GUILayout.Space(150);
        GUILayout.EndHorizontal();
        GUILayout.BeginVertical();

        if (GUILayout.Button("Create 50", GUILayout.ExpandWidth(false)))
        {
            CreateCombinedAbility();
        }

    }

    void CreateCombinedAbility()
    {
        /*Summary: Create Combined Ability ScripableObject Class and save in Assets/ScriptableObjects/Abilities
       */

        //Make sure to create these folders
        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects"))
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects/Abilities"))
            AssetDatabase.CreateFolder("Assets/ScriptableObjects", "Abilities");

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects/Abilities/Combined"))
            AssetDatabase.CreateFolder("Assets/ScriptableObjects/Abilities", "Combined");

        //Create ScripableObject//
        for(int i = 0; i <=50; i++)
        {
            CombinedAbility createdAbility = CreateInstance<CombinedAbility>();
            AssetDatabase.CreateAsset(createdAbility, "Assets/ScriptableObjects/Abilities/Combined/CombinedAbility" + i + ".asset");
            AssetDatabase.SaveAssets();
            library.library.Add(createdAbility);
        }
    }
}
