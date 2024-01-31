using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemCreation : EditorWindow {

	public Item item;
	public Item itemItem;
	public UsableItem usableItem;
	public EquipmentItem equipmentItem;

    private int amount;
    private GameObject gameobject;
    private int PHid;
    private bool select2D = false, select3D = false, select1D = false;

    [MenuItem("Tools/Create An Item")]
	static void Init () {
		GetWindow (typeof(ItemCreation), true);
        GetWindow(typeof(ItemCreation)).minSize = new Vector2(550.0f, 550.0f);
    }
	void OnEnable() {
        if (EditorPrefs.HasKey ("ObjectPath")) {
            string objectPath = EditorPrefs.GetString ("ObjectPath");
			item = AssetDatabase.LoadAssetAtPath(objectPath, typeof(Item)) as Item;
        }
	}
	void OnGUI() {
        GUILayout.BeginHorizontal ();
		GUILayout.Space (150);
		GUILayout.Label ("Create An Item", EditorStyles.centeredGreyMiniLabel);
		GUILayout.Space (150);
		GUILayout.EndHorizontal ();
		GUILayout.BeginHorizontal ();

		if (GUILayout.Button ("Equipment Item")) {
			usableItem = null;
			itemItem = null;
			CreateEquipment ();
            generateID();
        }
		GUILayout.Space (50);
		if (GUILayout.Button ("Usable Item")) {
			equipmentItem = null;
			itemItem = null;
			CreateUsable ();
            generateID();
        }
		GUILayout.Space (50);
		if (GUILayout.Button ("Basic Item")) {
			equipmentItem = null;
			usableItem = null;
            CreateItem();
            generateID();
        }

		GUILayout.EndHorizontal ();

        if (equipmentItem) {//do not show unless Equipment Item is selected//
            GUILayout.BeginVertical();
            equipmentItem.itemName = EditorGUILayout.TextField("Item Name", equipmentItem.itemName as string);
            equipmentItem.itemImage = EditorGUILayout.ObjectField("Item Image", equipmentItem.itemImage, typeof(Sprite), true) as Sprite;
            equipmentItem.gameObject = EditorGUILayout.ObjectField("Game Object", equipmentItem.gameObject, typeof(GameObject), false) as GameObject;

            equipmentItem.hp = EditorGUILayout.IntField("HP", equipmentItem.hp);
            equipmentItem.defense = EditorGUILayout.IntField("Defense", equipmentItem.defense);
            equipmentItem.speed = EditorGUILayout.IntField("Speed", equipmentItem.speed);
            equipmentItem.strength = EditorGUILayout.IntField("Strength", equipmentItem.strength);
            equipmentItem.intelligence = EditorGUILayout.IntField("Intelligence", equipmentItem.intelligence);

            equipmentItem.Critical = EditorGUILayout.IntField("Critical", equipmentItem.Critical);
            equipmentItem.Haste = EditorGUILayout.IntField("Haste", equipmentItem.Haste);

            equipmentItem.buyPrice = EditorGUILayout.IntField("Buy Price", equipmentItem.buyPrice);
            equipmentItem.sellPrice = EditorGUILayout.IntField("Sell Price", equipmentItem.sellPrice);

            GUILayout.BeginHorizontal();
            equipmentItem.itemID = EditorGUILayout.IntField("Item ID", PHid);
            if (GUILayout.Button("Generate an ID", GUILayout.ExpandWidth(false)))
            {
                Debug.Log(PHid);
                generateID();
                Debug.Log(PHid);
            }
            GUILayout.EndHorizontal();

            amount = EditorGUILayout.IntField("Amount of this Item", 1);
            equipmentItem.itemUnique = EditorGUILayout.Toggle("Item Uniqueness", equipmentItem.itemUnique);
            equipmentItem.specialText = EditorGUILayout.TextField("Special Text", equipmentItem.specialText as string);
            equipmentItem.itemDescription = EditorGUILayout.TextField("Item Description", equipmentItem.itemDescription as string);
            equipmentItem.equipmentType = (EquipmentItem.type)EditorGUILayout.EnumPopup("Type of Equipment", equipmentItem.equipmentType);
            GUILayout.EndVertical();

            GUILayout.BeginHorizontal();
            GUILayout.Space(100);
            if (GUILayout.Button("Create Equipment Item", GUILayout.ExpandWidth(false)))
            {
                select1D = true;
                select3D = select2D = false;
                CreateItemItem();
            }
            GUILayout.Space(100);
            if (equipmentItem.itemImage != null) { 
				if (GUILayout.Button("Create Equipment 2D Item", GUILayout.ExpandWidth(false)))
                {
                    select2D = true;
                    select3D = select1D = false;
                    CreateItemItem();
                }
            }
            GUILayout.Space(100);
            if (equipmentItem.gameObject != null)
            {
				if (GUILayout.Button("Create Equipment 3D Item", GUILayout.ExpandWidth(false)))
                {
                    select3D = true;
                    select1D = select2D = false;
                    CreateItemItem();
                }
            }
            GUILayout.Space(100);
            GUILayout.EndHorizontal();


        } else if (usableItem) {//do not show unless Usable Item is selected//
			GUILayout.BeginVertical ();
			usableItem.itemName = EditorGUILayout.TextField ("Item Name", usableItem.itemName as string);
			usableItem.itemImage = EditorGUILayout.ObjectField ("Item Image", usableItem.itemImage, typeof(Sprite), true) as Sprite;
            usableItem.gameObject = EditorGUILayout.ObjectField("Game Object", usableItem.gameObject, typeof(GameObject), false) as GameObject;

			usableItem.hp = EditorGUILayout.IntField ("Health Restored", usableItem.hp);
			usableItem.mana = EditorGUILayout.IntField ("Mana Restored", usableItem.mana);
			usableItem.exp = EditorGUILayout.IntField ("Experience Gained", usableItem.exp);

			usableItem.Critical = EditorGUILayout.IntField ("Critical", usableItem.Critical);
			usableItem.Haste = EditorGUILayout.IntField ("Haste", usableItem.Haste);

			usableItem.buyPrice = EditorGUILayout.IntField ("Buy Price", usableItem.buyPrice);
			usableItem.sellPrice = EditorGUILayout.IntField ("Sell Price", usableItem.sellPrice);

            GUILayout.BeginHorizontal();
            usableItem.itemID = EditorGUILayout.IntField("Item ID", PHid);
            if (GUILayout.Button("Generate an ID", GUILayout.ExpandWidth(false)))
            {
                Debug.Log(PHid);
                generateID();
                Debug.Log(PHid);
            }
            GUILayout.EndHorizontal();

            amount = EditorGUILayout.IntField("Amount of this Item", 1);
            usableItem.itemUnique = EditorGUILayout.Toggle ("Item Uniqueness", usableItem.itemUnique);
			usableItem.revive = EditorGUILayout.Toggle ("Revive", usableItem.revive);
			usableItem.party = EditorGUILayout.Toggle ("Party", usableItem.party);
			usableItem.itemDescription = EditorGUILayout.TextField ("Item Description", usableItem.itemDescription as string);
			GUILayout.EndVertical ();

            GUILayout.BeginHorizontal();
            GUILayout.Space(100);
            if (GUILayout.Button("Create Usable Item", GUILayout.ExpandWidth(false)))
            {
                select1D = true;
                select3D = select2D = false;
                CreateItemItem();
            }
            GUILayout.Space(100);
            if(usableItem.itemImage != null)
            {
				if (GUILayout.Button("Create Usable 2D Item", GUILayout.ExpandWidth(false)))
                {
                    select2D = true;
                    select3D = select1D = false;
                    CreateItemItem();
                }
            }
            GUILayout.Space(100);
            if(usableItem.gameObject != null)
            {
				if (GUILayout.Button("Create Usable 3D Item", GUILayout.ExpandWidth(false)))
                {
                    select3D = true;
                    select1D = select2D = false;
                    CreateItemItem();
                }
            }
            GUILayout.Space(100);
            GUILayout.EndHorizontal();

        } else if (itemItem) { //do not show unless Basic Item is selected//
            GUILayout.BeginVertical();
            itemItem.itemName = EditorGUILayout.TextField("Item Name", itemItem.itemName as string);
            itemItem.itemImage = EditorGUILayout.ObjectField("Item Image", itemItem.itemImage, typeof(Sprite), true) as Sprite;
            itemItem.gameObject = EditorGUILayout.ObjectField("Game Object", itemItem.gameObject, typeof(GameObject), false) as GameObject;

            itemItem.buyPrice = EditorGUILayout.IntField("Buy Price", itemItem.buyPrice);
            itemItem.sellPrice = EditorGUILayout.IntField("Sell Price", itemItem.sellPrice);

            GUILayout.BeginHorizontal();
            itemItem.itemID = EditorGUILayout.IntField("Item ID", PHid);
            if (GUILayout.Button("Generate an ID", GUILayout.ExpandWidth(false)))
            {
                Debug.Log(PHid);
                generateID();
                Debug.Log(PHid);
            }
            GUILayout.EndHorizontal();

            amount = EditorGUILayout.IntField("Amount of this Item", 1);
            itemItem.itemUnique = EditorGUILayout.Toggle("Item Uniqueness", itemItem.itemUnique);
            itemItem.itemDescription = EditorGUILayout.TextField("Item Description", itemItem.itemDescription as string);
            GUILayout.EndVertical();

            GUILayout.BeginHorizontal();
            GUILayout.Space(100);
            if (GUILayout.Button("Create Basic Item", GUILayout.ExpandWidth(false)) )
            {
                select1D = true;
                select3D = select2D = false;
                CreateItemItem();
            }
            GUILayout.Space(100);
            if(itemItem.itemImage != null)
            {
                if (GUILayout.Button("Create Basic 2D Item", GUILayout.ExpandWidth(false)))
                {
                    select2D = true;
                    select3D = select1D = false;
                    CreateItemItem();
                }
            }
            GUILayout.Space(100);
            if(itemItem.gameObject != null)
            {
                if (GUILayout.Button("Create Basic 3D Item", GUILayout.ExpandWidth(false)))
                {
                    select3D = true;
                    select1D = select2D = false;
                    CreateItemItem();
                }
            }
            GUILayout.Space(100);
            GUILayout.EndHorizontal();
        }

        

    }

    public void IDcheck() {
        /*Summary: Check IDs of all Item ScriptableObjects to compare with New Item*/
        Item i;

        //gather every Item//
        string[] stringArray = { "Assets/ScriptableObjects/Items" };
        var scriptableObjects = AssetDatabase.FindAssets("t:Item", stringArray);

        //search for the same id, if so, change it//
        foreach (var objects in scriptableObjects)
        {
            i = (Item)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(objects).ToString(), typeof(Item));

            if (i.itemID == PHid)
            {
                Debug.Log("two items can not have the same ID");
                generateID();
            }

        }
    }
    public void generateID() {
        /*Summary: Generate an ID for Item*/
        Debug.Log("run generator");
        PHid = Random.Range(1, 100000000);

        IDcheck();
    }
	void CreateEquipment() {
        /*Summary: ScriptableObject constructor, if need to modify new ScriptableObject, function exist*/
        equipmentItem = CreateInstance<EquipmentItem> ();
	}
    void CreateUsable() {
        /*Summary: ScriptableObject constructor, if need to modify new ScriptableObject, function exist*/
        usableItem = CreateInstance<UsableItem> ();
	}
    void CreateItem() {
        /*Summary: ScriptableObject constructor, if need to modify new ScriptableObject, function exist*/
        itemItem = CreateInstance<Item> ();
	}
    void CreateGameObject(Item goItem)
    {
        /*Summary: Creates a GameObject of Item and stores as a Prefab for later use
        Parameters: Item Class*/

        //InventoryItem Constructor//
        //Needed for ObjectTesting Script//
        InventoryItem invItem = new InventoryItem();

        invItem.item = goItem;
        invItem.amount = amount;

        //Make sure to create these folders
        if (!AssetDatabase.IsValidFolder("Assets/Prefabs"))
            AssetDatabase.CreateFolder("Assets", "Prefabs");

        if (!AssetDatabase.IsValidFolder("Assets/Prefabs/Items"))
            AssetDatabase.CreateFolder("Assets/Prefabs", "Items");

        if(select1D == true)
        {

        } else if(select2D == true)
        {
            //GameObject constructor 
            gameobject = new GameObject(goItem.itemName);

            gameobject.AddComponent<SpriteRenderer>();
            gameobject.GetComponent<SpriteRenderer>().sprite = goItem.itemImage;
            //you can change the sprite options here

            //redo when interaction is finished
            gameobject.AddComponent<ObjectTesting>();
            gameobject.GetComponent<ObjectTesting>().inventoryItem = invItem;

            gameobject.AddComponent<BoxCollider2D>();
            //you can change the collider options here
            PrefabUtility.SaveAsPrefabAsset(gameobject, "Assets/Prefabs/Items/" + gameobject.name + ".prefab");

        } else if(select3D == true)
        {
            //GameObject constructor 
            gameobject = new GameObject(goItem.itemName);

            //redo when interaction is finished
            gameobject.AddComponent<ObjectTesting>();
            gameobject.GetComponent<ObjectTesting>().inventoryItem = invItem;

            gameobject.AddComponent<BoxCollider>();
            //you can change the collider options here

            PrefabUtility.SaveAsPrefabAsset(gameobject, "Assets/Prefabs/Items/" + gameobject.name + ".prefab");
        }

        AssetDatabase.SaveAssets();

    }
    void CreateItemItem() {
        /*Summary: Create Base Item ScripableObject Class and save in Assets/ScriptableObjects/Items
        */
        Item createItem = CreateInstance<Item>();

        if (itemItem != null) {
            createItem = itemItem;
        } else if(equipmentItem != null) {
            createItem = equipmentItem;
        } else if (usableItem != null) {
            createItem = usableItem;
        }

        //Make sure to create these folders
        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects"))
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");

        if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects/Items"))
            AssetDatabase.CreateFolder("Assets/ScriptableObjects", "Items");

        //Create ScripableObject//
        AssetDatabase.CreateAsset(createItem, "Assets/ScriptableObjects/Items/" + createItem.itemName + ".asset");
        AssetDatabase.SaveAssets();

        //Create GameObject & Prefab//
        CreateGameObject(createItem);
        //Initialize for continued use//
        itemItem = CreateInstance<Item>();
    }

}
