using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AnimationCreation : EditorWindow {

    public AnimationClip clipF;
    public AnimationClip clipB;
    public AnimationClip clipL;
    public AnimationClip clipR;
    public AnimationClip clipIF;
    public AnimationClip clipIB;
    public AnimationClip clipIL;
    public AnimationClip clipIR;

    public Animator anim;
    public bool battleBool = false;

    public Sprite[] spritesF = new Sprite[5];
    public Sprite[] spritesB = new Sprite[5];
    public Sprite[] spritesL = new Sprite[5];
    public Sprite[] spritesR = new Sprite[5];
    public Sprite[] massSprites;

    public string characterName = "PHanimation";
    public string clipNameF = "WalkForward";
    public string clipNameB = "WalkBack";
    public string clipNameL = "WalkLeft";
    public string clipNameR = "WalkRight";
    public string clipNameIF = "IdleForward";
    public string clipNameIB = "IdleBack";
    public string clipNameIL = "IdleLeft";
    public string clipNameIR = "IdleRight";
    public string[] charactersNames;
    public SerializedProperty charactersNamesProp;
    public SerializedProperty massSpritesProp;
    public SerializedObject so;


    // Add menu named "My Window" to the Window menu
    [MenuItem("Create/Create Animation")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        GetWindow(typeof(AnimationCreation), true);
        GetWindow(typeof(AnimationCreation)).minSize = new Vector2(1250.0f, 550.0f);
    }

    void OnEnable()
    {
        clipF = new AnimationClip();
        clipB = new AnimationClip();
        clipL = new AnimationClip();
        clipR = new AnimationClip();
        clipIF = new AnimationClip();
        clipIB = new AnimationClip();
        clipIL = new AnimationClip();
        clipIR = new AnimationClip();
        anim = new Animator();

        ScriptableObject target = this;
        so = new SerializedObject(target);
        charactersNamesProp = so.FindProperty("charactersNames");
        massSpritesProp = so.FindProperty("massSprites");
    }

    void OnGUI()
    {
        GUILayout.Label("Animation Creator", EditorStyles.boldLabel);
        battleBool = EditorGUILayout.Toggle(battleBool, GUILayout.ExpandWidth(false));

        if(battleBool == false)
        {
            characterName = EditorGUILayout.TextField("Character Name", characterName as string, GUILayout.Width(500.0f));
            GUILayout.BeginHorizontal();

            GUILayout.BeginVertical();
            spritesF[0] = EditorGUILayout.ObjectField(clipNameF + "1", spritesF[0], typeof(Sprite), true) as Sprite;
            spritesF[1] = spritesF[3] = spritesF[4] = EditorGUILayout.ObjectField(clipNameF + "2", spritesF[1], typeof(Sprite), true) as Sprite;
            spritesF[2] = EditorGUILayout.ObjectField(clipNameF + "3", spritesF[2], typeof(Sprite), true) as Sprite;
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            spritesB[0] = EditorGUILayout.ObjectField(clipNameB + "1", spritesB[0], typeof(Sprite), true) as Sprite;
            spritesB[1] = spritesB[3] = spritesB[4] = EditorGUILayout.ObjectField(clipNameB + "2", spritesB[1], typeof(Sprite), true) as Sprite;
            spritesB[2] = EditorGUILayout.ObjectField(clipNameB + "3", spritesB[2], typeof(Sprite), true) as Sprite;
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            spritesL[0] = EditorGUILayout.ObjectField(clipNameL + "1", spritesL[0], typeof(Sprite), true) as Sprite;
            spritesL[1] = spritesL[3] = spritesL[4] = EditorGUILayout.ObjectField(clipNameL + "2", spritesL[1], typeof(Sprite), true) as Sprite;
            spritesL[2] = EditorGUILayout.ObjectField(clipNameL + "3", spritesL[2], typeof(Sprite), true) as Sprite;
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            spritesR[0] = EditorGUILayout.ObjectField(clipNameR + "1", spritesR[0], typeof(Sprite), true) as Sprite;
            spritesR[1] = spritesR[3] = spritesR[4] = EditorGUILayout.ObjectField(clipNameR + "2", spritesR[1], typeof(Sprite), true) as Sprite;
            spritesR[2] = EditorGUILayout.ObjectField(clipNameR + "3", spritesR[2], typeof(Sprite), true) as Sprite;
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
            if (GUILayout.Button("Build Animation Clip", GUILayout.ExpandWidth(false)))
            {
                CreateFolders();
                CreateAnimationClip(spritesF, ref clipF, clipNameF);
                CreateAnimationClip(spritesB, ref clipB, clipNameB);
                CreateAnimationClip(spritesL, ref clipL, clipNameL);
                CreateAnimationClip(spritesR, ref clipR, clipNameR);
                CreateSingleAnimationClip(spritesF[1], ref clipIF, clipNameIF);
                CreateSingleAnimationClip(spritesB[1], ref clipIB, clipNameIB);
                CreateSingleAnimationClip(spritesL[1], ref clipIL, clipNameIL);
                CreateSingleAnimationClip(spritesR[1], ref clipIR, clipNameIR);
                CreateAnimator();
            }
        }

        if(battleBool == true)
        {
            EditorGUILayout.PropertyField(charactersNamesProp, true);
            EditorGUILayout.PropertyField(massSpritesProp, true);
            GUILayout.BeginHorizontal();

            GUILayout.EndHorizontal();
            so.ApplyModifiedProperties();
        }
    }

    void CreateFolders()
    {
        //Make sure to create these folders
        if (!AssetDatabase.IsValidFolder("Assets/Animations"))
            AssetDatabase.CreateFolder("Assets", "Animations");

        if (!AssetDatabase.IsValidFolder("Assets/Animations/" + characterName))
            AssetDatabase.CreateFolder("Assets/Animations", characterName);
    }

    void CreateSingleAnimationClip(Sprite sprite, ref AnimationClip clip, string clipname)
    {
        float keytime = 0.0f;

        EditorCurveBinding spriteBinding = new EditorCurveBinding
        {
            type = typeof(SpriteRenderer),
            path = "",
            propertyName = "m_Sprite"
        };

        ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[1];

            spriteKeyFrames[0] = new ObjectReferenceKeyframe
            {
                time = keytime,
                value = sprite
            };

            keytime = keytime + 0.1666666666667f;

        AnimationClipSettings tsettings = AnimationUtility.GetAnimationClipSettings(clip);
        tsettings.loopTime = true;
        AnimationUtility.SetAnimationClipSettings(clip, tsettings);

        AnimationUtility.SetObjectReferenceCurve(clip, spriteBinding, spriteKeyFrames);
        AssetDatabase.CreateAsset(clip, "Assets/Animations/" + characterName + "/" + clipname + ".anim");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    void CreateAnimationClip(Sprite[] sprite, ref AnimationClip clip, string clipname)
    {
        float keytime = 0.0f;

        EditorCurveBinding spriteBinding = new EditorCurveBinding
        {
            type = typeof(SpriteRenderer),
            path = "",
            propertyName = "m_Sprite"
        };

        ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[sprite.Length];

        for (int i = 0; i < sprite.Length; i++)
        {
            spriteKeyFrames[i] = new ObjectReferenceKeyframe
            {
                time = keytime,
                value = sprite[i]
            };

            keytime = keytime + 0.1666666666667f;
        }

        AnimationClipSettings tsettings = AnimationUtility.GetAnimationClipSettings(clip);
        tsettings.loopTime = true;
        AnimationUtility.SetAnimationClipSettings(clip, tsettings);

        AnimationUtility.SetObjectReferenceCurve(clip, spriteBinding, spriteKeyFrames);
        AssetDatabase.CreateAsset(clip, "Assets/Animations/" + characterName + "/" + clipname + ".anim");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    void CreateAnimator()
    {
        var controller = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath("Assets/Animations/" + characterName + "/" + characterName + ".controller");

        // Add parameters
        controller.AddParameter("VelX", AnimatorControllerParameterType.Float);
        controller.AddParameter("VelY", AnimatorControllerParameterType.Float);
        controller.AddParameter("Movement", AnimatorControllerParameterType.Bool);
        controller.AddParameter("IdleX", AnimatorControllerParameterType.Float);
        controller.AddParameter("IdleY", AnimatorControllerParameterType.Float);

        // Add StateMachines
        var rootStateMachine = controller.layers[0].stateMachine;

        ////////////IDLE/////////////
        var tree = new UnityEditor.Animations.BlendTree();
        var blendType = UnityEditor.Animations.BlendTreeType.SimpleDirectional2D;

        var rootBlendTreeIdle = controller.CreateBlendTreeInController("Idle", out tree);
        tree.blendType = blendType;
        tree.blendParameter = "IdleX";
        tree.blendParameterY = "IdleY";

        var childmotion = new UnityEditor.Animations.ChildMotion();
        childmotion.motion = clipIF;
        tree.AddChild(childmotion.motion, new Vector2(0.0f, -1.0f)); /*this adds motion and PosX and PosY*/

        childmotion = new UnityEditor.Animations.ChildMotion();
        childmotion.motion = clipIB;
        tree.AddChild(childmotion.motion, new Vector2(0.0f, 1.0f)); /*this adds motion and PosX and PosY*/

        childmotion = new UnityEditor.Animations.ChildMotion();
        childmotion.motion = clipIL;
        tree.AddChild(childmotion.motion, new Vector2(-1.0f, 0.0f)); /*this adds motion and PosX and PosY*/

        childmotion = new UnityEditor.Animations.ChildMotion();
        childmotion.motion = clipIR;
        tree.AddChild(childmotion.motion, new Vector2(1.0f, 0.0f)); /*this adds motion and PosX and PosY*/

        //////////MOVEMENT//////////
        tree = new UnityEditor.Animations.BlendTree();
        blendType = UnityEditor.Animations.BlendTreeType.SimpleDirectional2D;

        var rootBlendTreeWalk = controller.CreateBlendTreeInController("Movement", out tree);
        tree.blendType = blendType;
        tree.blendParameter = "VelX";
        tree.blendParameterY = "VelY";

        childmotion = new UnityEditor.Animations.ChildMotion();
        childmotion.motion = clipF;
        tree.AddChild(childmotion.motion, new Vector2(0.0f, -1.0f)); /*this adds motion and PosX and PosY*/

        childmotion = new UnityEditor.Animations.ChildMotion();
        childmotion.motion = clipB;
        tree.AddChild(childmotion.motion, new Vector2(0.0f, 1.0f)); /*this adds motion and PosX and PosY*/

        childmotion = new UnityEditor.Animations.ChildMotion();
        childmotion.motion = clipL;
        tree.AddChild(childmotion.motion, new Vector2(-1.0f, 0.0f)); /*this adds motion and PosX and PosY*/

        childmotion = new UnityEditor.Animations.ChildMotion();
        childmotion.motion = clipR;
        tree.AddChild(childmotion.motion, new Vector2(1.0f, 0.0f)); /*this adds motion and PosX and PosY*/

        /////////////Transitions///////////////
        var IdleTransition = rootBlendTreeIdle.AddTransition(rootBlendTreeWalk);
        IdleTransition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "Movement");
        IdleTransition.duration = 0;

        var WalkTransition = rootBlendTreeWalk.AddTransition(rootBlendTreeIdle);
        WalkTransition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.IfNot, 0, "Movement");
        WalkTransition.duration = 0;

    }

}