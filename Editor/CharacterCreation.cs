using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CharacterCreation :  EditorWindow{

    public GameObject PHgameobject;
    public CombatCharacter PHcharacter;
    public BaseCharacter NPCcharacter;
    public RuntimeAnimatorController NPCanim = null;

    public bool Roam, Static = false;
    private string PHname;

    [MenuItem("Tools/Create Character")]
    static void Init()
    {
        GetWindow(typeof(CharacterCreation));
        GetWindow(typeof(CharacterCreation)).minSize = new Vector2(550.0f, 550.0f);
    }

    void OnEnable()
    {
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            PHcharacter = AssetDatabase.LoadAssetAtPath(objectPath, typeof(CombatCharacter)) as CombatCharacter;
        }
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Space(250);
        GUILayout.Label("Create Character", EditorStyles.centeredGreyMiniLabel);
        GUILayout.Space(250);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Space(175);

        if (GUILayout.Button("Create Combat Character", GUILayout.ExpandWidth(true)))
        {
            createCharacter();
        }
        GUILayout.Space(25);
        if (GUILayout.Button("Create NPC Character", GUILayout.ExpandWidth(true)))
        {
            createNPC();
        }

        GUILayout.Space(175);
        GUILayout.EndHorizontal();

        if (PHcharacter)
        {
            GUILayout.BeginVertical();
            PHname = EditorGUILayout.TextField("Character Name", PHname as string);
            PHcharacter.characterSprite = EditorGUILayout.ObjectField("Character Image", PHcharacter.characterSprite, typeof(Sprite), true) as Sprite;
            PHcharacter.characterGameObject = EditorGUILayout.ObjectField("Game Object", PHcharacter.characterGameObject, typeof(GameObject), false) as GameObject;
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            if (GUILayout.Button("Create Character", GUILayout.ExpandWidth(false)))
                CreateNewCharacter();

            GUILayout.EndVertical();
        } else if (NPCcharacter)
        {
            GUILayout.BeginVertical();
            NPCanim = EditorGUILayout.ObjectField("Animator", NPCanim, typeof(RuntimeAnimatorController), true) as RuntimeAnimatorController;

            if(NPCanim == null)
            {
                NPCcharacter.characterName = PHname = EditorGUILayout.TextField("Character Name", PHname as string);
                NPCcharacter.characterSprite = EditorGUILayout.ObjectField("Character Image", NPCcharacter.characterSprite, typeof(Sprite), true) as Sprite;
            } else {
                NPCcharacter.characterName = PHname = NPCanim.name;
                NPCcharacter.characterName = PHname = EditorGUILayout.TextField("Character Name", PHname as string);

                EditorCurveBinding spriteBinding = new EditorCurveBinding
                {
                    type = typeof(SpriteRenderer),
                    path = "",
                    propertyName = "m_Sprite"
                };
    
                if(NPCanim.animationClips.Length == 1)
                {
                    var animutil = AnimationUtility.GetObjectReferenceCurve(NPCanim.animationClips[0], spriteBinding);
                    NPCcharacter.characterSprite = animutil[1].value as Sprite;
                    NPCcharacter.characterSprite = EditorGUILayout.ObjectField("Character Image", NPCcharacter.characterSprite, typeof(Sprite), true) as Sprite;
                } else {
                    var animutil = AnimationUtility.GetObjectReferenceCurve(NPCanim.animationClips[0], spriteBinding);
                    NPCcharacter.characterSprite = animutil[0].value as Sprite;
                    NPCcharacter.characterSprite = EditorGUILayout.ObjectField("Character Image", NPCcharacter.characterSprite, typeof(Sprite), true) as Sprite;
                }
            }

            Roam = EditorGUILayout.Toggle("Roam", Roam, GUILayout.ExpandWidth(false));
            Static = EditorGUILayout.Toggle("Static", Static, GUILayout.ExpandWidth(false));
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            if (GUILayout.Button("Create Character", GUILayout.ExpandWidth(false)))
                CreateNPCCharacter();

            GUILayout.EndVertical();
        }

    }

    void createCharacter()
    {
        PHcharacter = CreateInstance<CombatCharacter>();
        NPCcharacter = null;
    }

    void createNPC()
    {
        NPCcharacter = CreateInstance<BaseCharacter>();
        PHcharacter = null;
    }

    void CreateNewCharacter()
    {
        CombatCharacter cchar = PHcharacter;

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects"))
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects/CharacterSheets"))
            AssetDatabase.CreateFolder("Assets/ScriptableObjects", "CharacterSheets");

        AssetDatabase.CreateAsset(cchar, "Assets/ScriptableObjects/CharacterSheets/" + PHname + ".asset");
        AssetDatabase.SaveAssets();

        createCharacter();
    }

    void CreateNPCCharacter()
    {
        BaseCharacter cchar = NPCcharacter;
        GameObject PHgoAnim, PHgoTriggerTop, PHgoTriggerLeft, PHgoTriggerRight, PHgoTriggerBottom;

        //Make sure to create these folders
        if (!AssetDatabase.IsValidFolder("Assets/Prefabs"))
            AssetDatabase.CreateFolder("Assets", "Prefabs");

        if (!AssetDatabase.IsValidFolder("Assets/Prefabs/NPCs"))
            AssetDatabase.CreateFolder("Assets/Prefabs", "NPCs");

        //GameObject constructor 
        PHgameobject = new GameObject(cchar.characterName);
        PHgoAnim = new GameObject("Animation");
        PHgoTriggerTop = new GameObject("TriggerAreaTop");
        PHgoTriggerLeft = new GameObject("TriggerAreaLeft");
        PHgoTriggerRight = new GameObject("TriggerAreaRight");
        PHgoTriggerBottom = new GameObject("TriggerAreaBottom");

        PHgoAnim.transform.SetParent(PHgameobject.transform, true);
        PHgoTriggerTop.transform.SetParent(PHgameobject.transform, true);
        PHgoTriggerLeft.transform.SetParent(PHgameobject.transform, true);
        PHgoTriggerRight.transform.SetParent(PHgameobject.transform, true);
        PHgoTriggerBottom.transform.SetParent(PHgameobject.transform, true);

        PHgameobject.tag = "NPC";

        PHgameobject.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);

        PHgameobject.AddComponent<NPC_Movement>();
        PHgameobject.GetComponent<NPC_Movement>().triggerareas[0] = PHgoTriggerTop;
        PHgameobject.GetComponent<NPC_Movement>().triggerareas[1] = PHgoTriggerLeft;
        PHgameobject.GetComponent<NPC_Movement>().triggerareas[2] = PHgoTriggerRight;
        PHgameobject.GetComponent<NPC_Movement>().triggerareas[3] = PHgoTriggerBottom;
        PHgameobject.GetComponent<NPC_Movement>().Roam = Roam;
        PHgameobject.GetComponent<NPC_Movement>().Static = Static;
        PHgameobject.GetComponent<NPC_Movement>().moveSpeed = 0.03f;

        PHgameobject.AddComponent<DialogueScript>();
        PHgameobject.GetComponent<DialogueScript>().character = cchar;
        PHgameobject.GetComponent<DialogueScript>().dialogueArray = new string[10];
        
        PHgameobject.AddComponent<BoxCollider2D>();
        PHgameobject.GetComponent<BoxCollider2D>().offset = new Vector2(0.0f, -0.16f);
        PHgameobject.GetComponent<BoxCollider2D>().size = new Vector2(0.34f, 0.31f);

        //you can change the sprite options here
        PHgoAnim.AddComponent<SpriteRenderer>();
        PHgoAnim.GetComponent<SpriteRenderer>().sprite = cchar.characterSprite;
        PHgoAnim.GetComponent<SpriteRenderer>().sortingLayerName = "CharacterDefault";

        PHgoAnim.AddComponent<Animator>();
        PHgoAnim.GetComponent<Animator>().runtimeAnimatorController = NPCanim;

        PHgoAnim.AddComponent<BoxCollider2D>();
        PHgoAnim.GetComponent<BoxCollider2D>().isTrigger = true;
        PHgoAnim.GetComponent<BoxCollider2D>().size = new Vector2(0.34f, 0.6f);

        PHgoAnim.AddComponent<Rigidbody2D>();
        PHgoAnim.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        PHgoAnim.GetComponent<Rigidbody2D>().simulated = true;

        PHgoTriggerTop.AddComponent<BoxCollider2D>();
        PHgoTriggerLeft.AddComponent<BoxCollider2D>();
        PHgoTriggerRight.AddComponent<BoxCollider2D>();
        PHgoTriggerBottom.AddComponent<BoxCollider2D>();
        PHgoTriggerTop.AddComponent<TriggerAreaScript>();
        PHgoTriggerLeft.AddComponent<TriggerAreaScript>();
        PHgoTriggerRight.AddComponent<TriggerAreaScript>();
        PHgoTriggerBottom.AddComponent<TriggerAreaScript>();

        PHgoTriggerTop.GetComponent<BoxCollider2D>().isTrigger = true;
        PHgoTriggerTop.GetComponent<BoxCollider2D>().offset = new Vector2(0.0f, 0.25f);
        PHgoTriggerTop.GetComponent<BoxCollider2D>().size = new Vector2(0.13f, 0.25f);

        PHgoTriggerLeft.GetComponent<BoxCollider2D>().isTrigger = true;
        PHgoTriggerLeft.GetComponent<BoxCollider2D>().offset = new Vector2(-0.18f, 0.0f);
        PHgoTriggerLeft.GetComponent<BoxCollider2D>().size = new Vector2(0.18f, 0.18f);

        PHgoTriggerRight.GetComponent<BoxCollider2D>().isTrigger = true;
        PHgoTriggerRight.GetComponent<BoxCollider2D>().offset = new Vector2(0.18f, 0.0f);
        PHgoTriggerRight.GetComponent<BoxCollider2D>().size = new Vector2(0.18f, 0.18f);

        PHgoTriggerBottom.GetComponent<BoxCollider2D>().isTrigger = true;
        PHgoTriggerBottom.GetComponent<BoxCollider2D>().offset = new Vector2(0.0f, -0.25f);
        PHgoTriggerBottom.GetComponent<BoxCollider2D>().size = new Vector2(0.13f, 0.25f);

        cchar.characterGameObject = PHgameobject;

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects"))
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects/CharacterSheets"))
            AssetDatabase.CreateFolder("Assets/ScriptableObjects", "CharacterSheets");

        AssetDatabase.CreateAsset(cchar, "Assets/ScriptableObjects/CharacterSheets/" + PHname + ".asset");

        PrefabUtility.SaveAsPrefabAsset(PHgameobject, "Assets/Prefabs/NPCs/" + cchar.name + ".prefab");
        AssetDatabase.SaveAssets();

        createNPC();
    }
}
