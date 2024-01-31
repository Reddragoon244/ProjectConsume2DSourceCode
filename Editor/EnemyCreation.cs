using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyCreation : EditorWindow
{
    public CombatCharacter PHcharacter;
    public GameObject PHgameobject;
    private string PHname;

    [MenuItem("Tools/Create Enemy")]
    static void Init()
    {
        GetWindow(typeof(EnemyCreation));
        GetWindow(typeof(EnemyCreation)).minSize = new Vector2(550.0f, 550.0f);
    }

    void OnEnable()
    {
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            PHcharacter = AssetDatabase.LoadAssetAtPath(objectPath, typeof(CombatCharacter)) as CombatCharacter;
        }

        PHcharacter = CreateInstance<CombatCharacter> ();
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Space(250);
        GUILayout.Label("Create Enemy", EditorStyles.centeredGreyMiniLabel);
        GUILayout.Space(250);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        PHname = PHcharacter.characterName = EditorGUILayout.TextField("Enemy Name", PHcharacter.characterName);
        PHcharacter.characterSprite = EditorGUILayout.ObjectField("Enemy Image", PHcharacter.characterSprite, typeof(Sprite), true) as Sprite;
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Space(340);
        GUILayout.BeginVertical();
        PHcharacter.level = EditorGUILayout.IntField("Level", PHcharacter.level, GUILayout.ExpandWidth (false));
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();

        GUILayout.BeginVertical();
        if (GUILayout.Button("Create Enemy", GUILayout.ExpandWidth(false)))
            CreateNewEnemy();
        GUILayout.EndVertical();
    }

    void createCharacter()
    {
        PHcharacter = CreateInstance<CombatCharacter>();
    }

    void CreateNewEnemy()
    {
        CombatCharacter cEnemy = PHcharacter;

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects"))
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects/EnemySheets"))
            AssetDatabase.CreateFolder("Assets/ScriptableObjects", "EnemySheets");

        AssetDatabase.CreateAsset(cEnemy, "Assets/ScriptableObjects/EnemySheets/" + PHname + ".asset");
        AssetDatabase.SaveAssets();

        CreateGameObject(cEnemy);

        createCharacter();
    }

    void CreateGameObject(CombatCharacter enemy)
    {
        /*Summary: Creates a GameObject of an Enemy and stores as a Prefab for later use
        Parameters: CombatCharacter Class*/

        //Make sure to create these folders
        if (!AssetDatabase.IsValidFolder("Assets/Prefabs"))
            AssetDatabase.CreateFolder("Assets", "Prefabs");

        if (!AssetDatabase.IsValidFolder("Assets/Prefabs/Enemies"))
            AssetDatabase.CreateFolder("Assets/Prefabs", "Enemies");

        //GameObject constructor 
        PHgameobject = new GameObject(enemy.characterName);

        PHgameobject.AddComponent<SpriteRenderer>();
        PHgameobject.GetComponent<SpriteRenderer>().sprite = enemy.characterSprite;
        //you can change the sprite options here

        PHgameobject.AddComponent<EnemyStatus>();
        PHgameobject.GetComponent<EnemyStatus>().character = enemy;
        //enemy character sheet added to game object

        PrefabUtility.SaveAsPrefabAsset(PHgameobject, "Assets/Prefabs/Enemies/" + PHgameobject.name + ".prefab");
        
        AssetDatabase.SaveAssets();
    }
}
