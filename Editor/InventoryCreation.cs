using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryCreation : EditorWindow
{
    public InventoryObject PHinventory;

    private string PHname;
    private InventoryItem PHitem = null;
    private bool npcInventory = false;

    [MenuItem("Tools/Create Inventory")]
    static void Init()
    {
        GetWindow(typeof(InventoryCreation));
        GetWindow(typeof(InventoryCreation)).minSize = new Vector2(550.0f, 550.0f);
    }

    void OnEnable()
    {
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            PHinventory = AssetDatabase.LoadAssetAtPath(objectPath, typeof(InventoryObject)) as InventoryObject;
        }
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Create Inventory", EditorStyles.centeredGreyMiniLabel);
        GUILayout.Space(250);
        npcInventory = EditorGUILayout.Toggle("NPC inventory", npcInventory, GUILayout.ExpandWidth(true));
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();

        if(npcInventory == true)
        {
            if (GUILayout.Button("Store", GUILayout.ExpandWidth(true)))
            {
                createInventory();
            }
            GUILayout.Space(25);
            if (GUILayout.Button("Loot Table", GUILayout.ExpandWidth(true)))
            {
                createInventory();
            }

        } else
        {
            if (GUILayout.Button("Player Inventory", GUILayout.ExpandWidth(true)))
            {
                createInventory();
            }

        }

        GUILayout.EndHorizontal();

        if (PHinventory)
        {
            GUILayout.BeginVertical();
            PHname = EditorGUILayout.TextField("Inventory Name", PHname as string);
            PHitem.item = EditorGUILayout.ObjectField("Add Item to inventory", PHitem.item, typeof(Item), true) as Item;


            if (PHitem.item)
            {
                PHitem.amount = EditorGUILayout.IntField("How Many of this Item", PHitem.amount);
                addToInventory();
            }
                

            if (GUILayout.Button("Create Empty Inventory", GUILayout.ExpandWidth(false)) && PHinventory.inventory.Count.Equals(0))
                CreateNewInventory();
            else if (GUILayout.Button("Create Inventory with " + PHinventory.inventory.Count + " items in it", GUILayout.ExpandWidth(false)) && PHinventory.inventory.Count >= 1)
                CreateNewInventory();

            GUILayout.EndVertical();
        }

    }

    void addToInventory()
    {
        if (GUILayout.Button("Add to Inventory", GUILayout.ExpandWidth(false)))
        {
            PHinventory.inventory.Add(PHitem);
            PHitem = new InventoryItem();
        }
    }

    void createInventory()
    {
        PHinventory = CreateInstance<InventoryObject>();
        PHitem = new InventoryItem();
    }

    void CreateNewInventory()
    {
        InventoryObject inventory = PHinventory;

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects"))
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects/Inventories"))
            AssetDatabase.CreateFolder("Assets/ScriptableObjects", "Inventories");

        AssetDatabase.CreateAsset(inventory, "Assets/ScriptableObjects/Inventories/" + PHname + ".asset");
            AssetDatabase.SaveAssets();

        PHitem = new InventoryItem();
    }
}
