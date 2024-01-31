using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MassAnimationCreation  : EditorWindow
{
    
    enum location {Abilities, Enemies, MainCharacters, NPCs, Objects, UI};
    location loc = location.NPCs;
    public AnimationClip clipF;
    public AnimationClip clipB;
    public AnimationClip clipL;
    public AnimationClip clipR;
    public AnimationClip clipIF;
    public AnimationClip clipIB;
    public AnimationClip clipIL;
    public AnimationClip clipIR;
    public int nameSize = 0;
    public Animator anim;
    public Sprite[] spritesF = new Sprite[5];
    public Sprite[] spritesB = new Sprite[5];
    public Sprite[] spritesL = new Sprite[5];
    public Sprite[] spritesR = new Sprite[5];
    public Sprite[] massSprites;

    public string clipNameF = "WalkForward";
    public string clipNameB = "WalkBack";
    public string clipNameL = "WalkLeft";
    public string clipNameR = "WalkRight";
    public string clipNameIF = "IdleForward";
    public string clipNameIB = "IdleBack";
    public string clipNameIL = "IdleLeft";
    public string clipNameIR = "IdleRight";
    public string clipNameAction1 = "Action1";
    public string clipNameAction2 = "Action2";
    public string clipNameAction3 = "Action3";
    public string clipNameAction4 = "Action4";
    public string clipNameDirectionAction1 = "DirectionAction1";
    public string clipNameDirectionAction2 = "DirectionAction2";
    public string clipNameDirectionAction3 = "DirectionAction3";
    public string clipNameDirectionAction4 = "DirectionAction4";
    public string npcspritesheettitle = "NPC Direction (no action) Sprite Sheet";
    public string[] charactersNames;
    public SerializedProperty charactersNamesProp;
    public SerializedProperty massSpritesProp;
    public SerializedObject so;
    public ScriptableObject target;
    private int j = -4, tempSize = 0;
    private int numberofnpcs = 8;
    private bool npcaction = false;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Create/Create Mass Animation")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        GetWindow(typeof(MassAnimationCreation), true);
        GetWindow(typeof(MassAnimationCreation)).minSize = new Vector2(1250.0f, 550.0f);
    }

    void OnEnable()
    {
        InitAnimationItems();
        target = this;
        so = new SerializedObject(target);
        massSpritesProp = so.FindProperty("massSprites");
    }

    void OnGUI()
    {
        GUILayout.Label("Mass Animation Creator", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(massSpritesProp, true);
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical();
        loc = (location) EditorGUILayout.EnumPopup("Type", loc, GUILayout.ExpandWidth(false));
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        npcaction = EditorGUILayout.Toggle(npcspritesheettitle, npcaction, GUILayout.ExpandWidth(false));            
        GUILayout.EndVertical();

        GUILayout.BeginHorizontal();
        numberofnpcs = EditorGUILayout.IntField("Number of NPCs", numberofnpcs, GUILayout.ExpandWidth(false));
        GUILayout.EndHorizontal();

        if(npcaction == false)
            npcspritesheettitle = "NPC Direction (no action) Sprite Sheet";
        else    
            npcspritesheettitle = "NPC Action Sprite Sheet";

        GUILayout.EndHorizontal();

        if(massSprites != null)
        {
            if(massSprites.Length > 2) {
                nameSize = numberofnpcs;

                if(tempSize != nameSize)
                {
                    charactersNames = new string[nameSize];
                    tempSize = nameSize;
                }
    
                for(int k = 0; k < nameSize; k++)
                {
                    charactersNames[k] = EditorGUILayout.TextField("Character Name " + k, charactersNames[k], GUILayout.ExpandWidth(true));
                 }
            } else {
                nameSize = 0;
                charactersNames = new string[nameSize];
                
            }
        }

        so.ApplyModifiedProperties();

        if (GUILayout.Button("Mass Build Animation Cips", GUILayout.ExpandWidth(false)))
        {
            for(int i = 0; i < nameSize; i++)
            {
                CreateFolders(charactersNames[i]);
                if(npcaction == false)
                {
                    if(i % 4 == 0)
                    {
                        j+=4;
                    }    

                    spritesF[0] = massSprites[(i*3)+(j*9)];
                    spritesF[1] = spritesF[3] = spritesF[4] = massSprites[(i*3)+1+(j*9)];
                    spritesF[2] = massSprites[(i*3)+2+(j*9)];

                    spritesL[0] = massSprites[(i*3)+12+(j*9)];
                    spritesL[1] = spritesL[3] = spritesL[4] = massSprites[(i*3)+1+12+(j*9)];
                    spritesL[2] = massSprites[(i*3)+2+12+(j*9)];

                    spritesR[0] = massSprites[(i*3)+24+(j*9)];
                    spritesR[1] = spritesR[3] = spritesR[4] = massSprites[(i*3)+1+24+(j*9)];
                    spritesR[2] = massSprites[(i*3)+2+24+(j*9)];

                    spritesB[0] = massSprites[(i*3)+36+(j*9)];
                    spritesB[1] = spritesB[3] = spritesB[4] = massSprites[(i*3)+1+36+(j*9)];
                    spritesB[2] = massSprites[(i*3)+2+36+(j*9)];

                    CreateAnimationClip(spritesF, ref clipF, clipNameF, charactersNames[i]);
                    CreateAnimationClip(spritesB, ref clipB, clipNameB, charactersNames[i]);
                    CreateAnimationClip(spritesL, ref clipL, clipNameL, charactersNames[i]);
                    CreateAnimationClip(spritesR, ref clipR, clipNameR, charactersNames[i]);
                    CreateSingleAnimationClip(spritesF[1], ref clipIF, clipNameIF, charactersNames[i]);
                    CreateSingleAnimationClip(spritesB[1], ref clipIB, clipNameIB, charactersNames[i]);
                    CreateSingleAnimationClip(spritesL[1], ref clipIL, clipNameIL, charactersNames[i]);
                    CreateSingleAnimationClip(spritesR[1], ref clipIR, clipNameIR, charactersNames[i]);
                } else {
                    spritesF[0] = massSprites[(i*3)];
                    spritesF[1] = spritesF[3] = spritesF[4] = massSprites[(i*3)+1];
                    spritesF[2] = massSprites[(i*3)+2];

                    CreateAnimationClip(spritesF, ref clipF, clipNameAction1, charactersNames[i]);
                }
                CreateAnimator(charactersNames[i]);
                InitAnimationItems();
            }

            this.EndWindows();
        }
        
    }

    void InitAnimationItems()
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
    }

    void CreateFolders(string charname)
    {
        //Make sure to create these folders
        if (!AssetDatabase.IsValidFolder("Assets/Animations" + "/" + loc.ToString()))
            AssetDatabase.CreateFolder("Assets/Animations", loc.ToString());

        if (!AssetDatabase.IsValidFolder("Assets/Animations/" + loc.ToString() + "/" + charname))
            AssetDatabase.CreateFolder("Assets/Animations/" + loc.ToString(), charname);
    }

    void CreateSingleAnimationClip(Sprite sprite, ref AnimationClip clip, string clipname, string charname)
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
        AssetDatabase.CreateAsset(clip, "Assets/Animations/" + loc.ToString() + "/" + charname + "/" + clipname + ".anim");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    void CreateAnimationClip(Sprite[] sprite, ref AnimationClip clip, string clipname, string charname)
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
        AssetDatabase.CreateAsset(clip, "Assets/Animations/" + loc.ToString() + "/" + charname + "/" + clipname + ".anim");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    void CreateAnimator(string charname)
    {
        var controller = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath("Assets/Animations/" + loc.ToString() + "/" + charname + "/" + charname + ".controller");

        if(npcaction == false)
        {
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
        } else {
            // Add StateMachines
            var rootStateMachine = controller.layers[0].stateMachine;

            //////////Animation//////////
            controller.AddMotion(clipF);
        }

    }

}
