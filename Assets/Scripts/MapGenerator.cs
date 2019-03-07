using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform TilePrefab;
    public Vector2 MapSize;

    /// <summary>
    /// Distanza tra le Tile
    /// </summary>
    public float Outline;


    ArenaMovement[] tilesinScene;
    string holderName = "GeneratedMap";
    Transform mapHolder;

    public void GenerateMap()
    {
        /// Distrugge La griglia precedente 
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        /// Crea Un GO padre dove contenere le tile
        mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for (int x = 0; x < MapSize.x; x++)
        {
            for (int y = 0; y < MapSize.y; y++)
            {
                Vector3 tilePosition = new Vector3(-MapSize.x + (Outline * x), transform.position.y, -MapSize.y + (Outline * y));
                Transform newTile = Instantiate(TilePrefab, tilePosition, Quaternion.Euler(Vector3.zero));
                newTile.parent = mapHolder;
            }
        }
    }

    public void UpdateMap()
    {
        Debug.Log("UpdateMap");
        tilesinScene = new ArenaMovement[100];

        tilesinScene = FindObjectsOfType<ArenaMovement>();
        int i = 0;
        foreach (ArenaMovement tile in tilesinScene)
        {
            if (tile == null)
                break;

            i++;
            Debug.Log(i);

            //tile.CopyValue(newPosition, movementDuration, WaitTime);
            Transform t = Instantiate(TilePrefab, tile.transform.position, Quaternion.Euler(Vector3.zero));
            t.GetComponent<ArenaMovement>().SetValue(tile.newPosition, tile.movementDuration, tile.WaitTime);
            t.parent = tile.transform.parent;
            DestroyImmediate(tile.gameObject);
        }
    }
}
