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

    public void GenerateMap()
    {
        string holderName = "GeneratedMap";
        /// Distrugge La griglia precedente 
        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        /// Crea Un GO padre dove contenere le tile
        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        for (int x = 0; x < MapSize.x; x++)
        {
            for (int y = 0; y < MapSize.y; y++)
            {
                Vector3 tilePosition = new Vector3(-MapSize.x / 2 + 0.5f + (Outline * x), transform.position.y, -MapSize.y / 2 + 0.5f + (Outline * y));
                Transform newTile = Instantiate(TilePrefab, tilePosition, Quaternion.Euler(Vector3.zero));
                newTile.parent = mapHolder;
            }
        }
    }
}
