using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;

public class CliffTile : Tile {

    [SerializeField]
    private Sprite[] cliffSprites;

    [SerializeField]
    private Sprite preview;

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                Vector3Int nPos = new Vector3Int(position.x + x, position.y + y, position.z);

                if(HasCliff(tilemap, nPos))
                {
                    tilemap.RefreshTile(nPos);
                }
            }
        }
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        string composition = string.Empty;

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if(x != 0 || y!= 0)
                {
                    if (HasCliff(tilemap, new Vector3Int(position.x + x, position.y + y, position.z)))
                    {
                        composition += 'C';
                    }
                    else
                    {
                        composition += 'E';
                    }
                }
            }
        }
        //Logic for this
        tileData.sprite = cliffSprites[0];
    }

    private bool HasCliff(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/CliffTile")]
    public static void CreateCliffTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save CliffTile", "New Clifftile", "asset", "Save CliffTile", "Assets");
        if(path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(CreateInstance<CliffTile>(), path);
    }

#endif
}
