using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AbilityCreation : EditorWindow {

    public BaseAbility ability;
    public AbilityList library;
    public AbilityList typeLibrary;
    InventoryItem INVitem = new InventoryItem();
    CombatCharacter.status statusType;
    RuntimeAnimatorController animator = null;
    Sprite firstImage = null;
    GameObject gobject = null;
    string statusString = " Statuses for this Ability";
    string particleString = " Particles for this Ability";
    string materialString = " Materials needed to craft this Ability";
    string gobjectString = " GameObjects for this Ability";
    string sameNameString = "You can't have two of the same name for two spells!";
    int g = 0; 
    int c = 0;
    int p = 0;
    int s = 0;

    [MenuItem("Tools/Create Ability")]
    static void Init()
    {
        GetWindow(typeof(AbilityCreation), true);
        GetWindow(typeof(AbilityCreation)).minSize = new Vector2(550.0f, 550.0f);
    }
    void OnEnable()
    {
        library = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Libraries/AbilityLibrary.asset", typeof(AbilityList)) as AbilityList;
        ability = CreateInstance<BaseAbility>();
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            ability = AssetDatabase.LoadAssetAtPath(objectPath, typeof(BaseAbility)) as BaseAbility;
        }
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Space(150);
        GUILayout.Label("Create An Ability", EditorStyles.centeredGreyMiniLabel);
        GUILayout.Space(150);
        GUILayout.EndHorizontal();
        GUILayout.BeginVertical();

        ability.abilityName = EditorGUILayout.TextField("Ability Name", ability.abilityName as string);
        ability.abilType = (BaseAbility.Abilitytype)EditorGUILayout.EnumPopup("Element Type", ability.abilType);
        ability.UIicon = EditorGUILayout.ObjectField("Ability Icon", ability.UIicon, typeof(Sprite), true) as Sprite;
        firstImage = EditorGUILayout.ObjectField("Showing Sprite", firstImage, typeof(Sprite), false) as Sprite;

        /////////**BEGIN**Particle System Option**BEGIN**/////////
        GUILayout.BeginHorizontal();
        animator = EditorGUILayout.ObjectField("Animator", animator, typeof(RuntimeAnimatorController), true) as RuntimeAnimatorController;
        GUILayout.EndHorizontal();
        GUILayout.Label(p + particleString, EditorStyles.centeredGreyMiniLabel);
        //////////**END**Particle System Option**END**//////////

        /////////***BEGIN***GameObject Option***BEGIN***/////////
        GUILayout.BeginHorizontal();
        gobject = EditorGUILayout.ObjectField("Can only have 3 GameObjects", gobject, typeof(GameObject), true) as GameObject;
        if (GUILayout.Button("Add GameObject", GUILayout.ExpandWidth(false)))
        {
            if (g == 3)
            {
                gobjectString = " is the max GameObjects allowed";
            }
            else
            {
                ability.animations[g] = gobject;
                g++;
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.Label(g + gobjectString, EditorStyles.centeredGreyMiniLabel);
        //////////***END***GameObject Option***END***//////////

        //////////**BEGIN**Status Effect Option**BEGIN**//////////
        GUILayout.BeginHorizontal();
        statusType = (CombatCharacter.status)EditorGUILayout.EnumPopup("Only 10 Statuses Allowed", statusType);
        if (GUILayout.Button("Add Status Effect", GUILayout.ExpandWidth(false)))
        {
            if(s == 10)
            {
                statusString = " is the max Status Effects your allowed";
            } else
            {
                ability.AbilityEffects[s] = statusType;
                s++;
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.Label(s + statusString, EditorStyles.centeredGreyMiniLabel);
        ///////////**END**Status Effect Option**END**///////////
        GUILayout.Space(25);
        //**BEGIN**Materials Needed to Craft Option**BEGIN**//
        GUILayout.BeginHorizontal();
        INVitem.item = EditorGUILayout.ObjectField("Choose 6 materials", INVitem.item, typeof(Item), true) as Item;
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        INVitem.amount = EditorGUILayout.IntField("Choose Amount needed", INVitem.amount);
        if (GUILayout.Button("Add Material Needed", GUILayout.ExpandWidth(false)))
        {
            if (c == 6)
            {
                materialString = " is the max Materials allowed to craft";
            }
            else
            {
                ability.craftingMaterialsNeeded[c] = INVitem;
                INVitem = new InventoryItem();
                c++;
            }

        }
        GUILayout.EndHorizontal();
        GUILayout.Label(c + materialString, EditorStyles.centeredGreyMiniLabel);
        //**END**Materials Needed to Craft Option**END**//
        GUILayout.Space(25);

        ability.aoe = EditorGUILayout.Toggle("Area of Effect", ability.aoe);
        ability.damage = EditorGUILayout.IntField("Damage Amount", ability.damage);
        ability.manaUse = EditorGUILayout.IntField("Mana Use Amount", ability.manaUse);
        ability.levelRequired = EditorGUILayout.IntField("Level Required", ability.levelRequired);

        ability.abilityDescription = EditorGUILayout.TextField("Ability Description", ability.abilityDescription as string, GUILayout.MaxHeight(75));

        GUILayout.EndVertical();

        GUILayout.BeginHorizontal();
        if (library.library.Find(i => i.abilityName == ability.abilityName))
        {
            GUILayout.Label(sameNameString, EditorStyles.centeredGreyMiniLabel);
        } else
        {
            if (GUILayout.Button("Create Ability", GUILayout.ExpandWidth(false)))
            {
                CreateAbility();
            }
        }
        GUILayout.EndHorizontal();
    }

    void CreateAbility()
    {
        /*Summary: Create Base Item ScripableObject Class and save in Assets/ScriptableObjects/Items
        */
        BaseAbility createdAbility = CreateInstance<BaseAbility>();

        createdAbility = ability;

        //For Animations
        //Make sure to create these folders
        if (!AssetDatabase.IsValidFolder("Assets/Animations/Abilities"))
            AssetDatabase.CreateFolder("Assets/Animations", "Abilities");

        if (!AssetDatabase.IsValidFolder("Assets/Animations/Abilities/" + createdAbility.abilityName))
            AssetDatabase.CreateFolder("Assets/Animations/Abilities", createdAbility.abilityName);

        //Make sure to create these folders
        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects"))
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects/Abilities"))
            AssetDatabase.CreateFolder("Assets/ScriptableObjects", "Abilities");

        //Create ScripableObject//
        AssetDatabase.CreateAsset(createdAbility, "Assets/ScriptableObjects/Abilities/" + createdAbility.abilityName + ".asset");
        AssetDatabase.SaveAssets();

        typeLibrary = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Libraries/" + createdAbility.abilType.ToString() + "SpellBook.asset", typeof(AbilityList)) as AbilityList;

        typeLibrary.library.Add(createdAbility);
        library.library.Add(createdAbility);

        CreateGameObject();

        createdAbility = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Abilities/" + ability.abilityName + ".asset", typeof(BaseAbility)) as BaseAbility;

        createdAbility.animations[0] = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Abilities/" + ability.abilityName + ".prefab", typeof(GameObject)) as GameObject;

        //Initialize for continued use//
        InitializeScript();
        createdAbility = CreateInstance<BaseAbility>();
    }

    void CreateGameObject()
    {
        GameObject goAbility = new GameObject(ability.abilityName);

        goAbility.transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);

        goAbility.AddComponent<SpriteRenderer>();
        goAbility.AddComponent<Animator>();
        goAbility.AddComponent<AbilityAnimationFunctions>();

        if(firstImage != null)
            goAbility.GetComponent<SpriteRenderer>().sprite = firstImage;

        goAbility.GetComponent<SpriteRenderer>().sortingLayerName = "Abilities";

        goAbility.GetComponent<AbilityAnimationFunctions>().ability = AssetDatabase.LoadAssetAtPath("Assets/ScriptableObjects/Abilities/" + ability.abilityName + ".asset", typeof(BaseAbility)) as BaseAbility;

        if(animator != null)
            goAbility.GetComponent<Animator>().runtimeAnimatorController = animator;
        else
        {
            var controller = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath("Assets/Animations/Abilities/" + ability.abilityName + "/" + ability.abilityName + ".controller");

            // Add parameters
            controller.AddParameter("Speed", AnimatorControllerParameterType.Float);
            Debug.Log(controller.parameters[0].name);
            Debug.Log(controller.parameters[0].defaultFloat.ToString());
            controller.parameters[0].defaultFloat = 1.0f;
            Debug.Log(controller.parameters[0].defaultFloat.ToString());

            controller.AddParameter("Multi", AnimatorControllerParameterType.Bool);
            Debug.Log(controller.parameters[1].name);
            Debug.Log(controller.parameters[1].defaultBool.ToString());
            controller.parameters[1].defaultBool = ability.aoe;
            Debug.Log(controller.parameters[1].defaultBool.ToString());

            controller.AddParameter("Repeat", AnimatorControllerParameterType.Bool);
            Debug.Log(controller.parameters[2].name);
            Debug.Log(controller.parameters[2].defaultBool.ToString());
            controller.parameters[2].defaultBool = true;
            Debug.Log(controller.parameters[2].defaultBool.ToString());

            controller.AddParameter("NoRepeat", AnimatorControllerParameterType.Bool);
            Debug.Log(controller.parameters[3].name);
            Debug.Log(controller.parameters[3].defaultBool.ToString());
            controller.parameters[3].defaultBool = true;
            Debug.Log(controller.parameters[3].defaultBool.ToString());

            AnimationClip anim = new AnimationClip();
            AssetDatabase.CreateAsset(anim, "Assets/Animations/Abilities/" + ability.abilityName + "/SingleAction.anim");

            anim = new AnimationClip();
            AssetDatabase.CreateAsset(anim, "Assets/Animations/Abilities/" + ability.abilityName + "/MultipleAction.anim");

            anim = new AnimationClip();
            AssetDatabase.CreateAsset(anim, "Assets/Animations/Abilities/" + ability.abilityName + "/RepeatMultipleAction.anim");

            anim = new AnimationClip();
            AssetDatabase.CreateAsset(anim, "Assets/Animations/Abilities/" + ability.abilityName + "/EndMultipleAction.anim");

            goAbility.GetComponent<Animator>().runtimeAnimatorController = controller;
        }

        if (!AssetDatabase.IsValidFolder("Assets/Prefabs"))
            AssetDatabase.CreateFolder("Assets", "Prefabs");

        if (!AssetDatabase.IsValidFolder("Assets/Prefabs/Abilities"))
            AssetDatabase.CreateFolder("Assets/Prefabs", "Abilities");

        PrefabUtility.SaveAsPrefabAsset(goAbility, "Assets/Prefabs/Abilities/" + ability.abilityName + ".prefab");
        AssetDatabase.SaveAssets();
    }

    void InitializeScript()
    {
        ability = CreateInstance<BaseAbility>();
        INVitem = new InventoryItem();
        gobject = null;
        statusString = " Statuses for this Ability";
        particleString = " Particles for this Ability";
        materialString = " Materials needed to craft this Ability";
        gobjectString = " GameObjects for this Ability";
        g = 0;
        c = 0;
        p = 0;
        s = 0;
    }
}
