using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform[] TilePrefab;
    public Vector2 MapSize;

    /// <summary>
    /// Distanza tra le Tile
    /// </summary>
    public float Outline;


    ArenaMovement[] tilesinScene;
    LoopsMovement[] tileinLoop;
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
                int[] i = { 0, 90, 180, 270, 360 };
                Transform newTile = Instantiate(TilePrefab[Random.Range(0, TilePrefab.Length)], tilePosition, Quaternion.Euler(Vector3.up * i[Random.Range(0, i.Length)]));
                newTile.parent = mapHolder;
            }
        }
    }

    public void UpdateMap()
    {
        Debug.Log("UpdateMap");
        tilesinScene = new ArenaMovement[100];

        tilesinScene = FindObjectsOfType<ArenaMovement>();
        tileinLoop = new LoopsMovement[tilesinScene.Length];
        int n = 0;
        foreach (ArenaMovement go in tilesinScene)
        {
            tileinLoop[n] = go.GetComponent<LoopsMovement>();
            n++;
        }

        int i = 0;
        Transform t = null;
        foreach (ArenaMovement tile in tilesinScene)
        {
            if (tile == null)
                continue;

            if (tile.gameObject.tag == "Ground")
            {
                Debug.Log(i);

                int[] r = { 0, 90, 180, 270, 360 };
                //tile.CopyValue(newPosition, movementDuration, WaitTime);
                t = Instantiate(TilePrefab[Random.Range(0, TilePrefab.Length)], tile.transform.position, Quaternion.Euler(Vector3.up * r[Random.Range(0, r.Length)]));
                t.GetComponent<ArenaMovement>().SetValue(tile.newPosition, tile.movementDuration, tile.WaitTime, tile.Curve);
                //t.GetComponent<LoopsMovement>().SetValue(t.GetComponent<LoopsMovement>().Paths, t.GetComponent<LoopsMovement>().MovementDuration, t.GetComponent<LoopsMovement>().WaitTime, 
                //t.GetComponent<LoopsMovement>().Curve, t.GetComponent<LoopsMovement>().LoopType, t.GetComponent<LoopsMovement>().Looptimes);
                t.parent = tile.transform.parent;
                //DestroyImmediate(tile.gameObject);

                LoopsMovement tileLoop = tile.GetComponent<LoopsMovement>();
                LoopsMovement tLoop = t.GetComponent<LoopsMovement>();

                if (tileLoop == null)
                {
                    DestroyImmediate(tile.gameObject);
                    continue;
                }

                if (tLoop != null)
                {
                    if (tile.gameObject.tag == "Ground")
                    {
                        tLoop.Paths = new Vector3[tileLoop.Paths.Length];
                        tLoop.SetValue(tileLoop.Paths, tileLoop.MovementDuration, tileLoop.WaitTime, tileLoop.Curve, tileLoop.LoopType, tileLoop.Looptimes);
                        //t.parent = tile.transform.parent;
                        DestroyImmediate(tile.gameObject);
                    }
                }

                i++;
            }
        }

        //foreach (LoopsMovement tile in tileinLoop)
        //{
        //    if (tile == null)
        //        continue;
        //
        //    if (tile.gameObject.tag == "Ground")
        //    {
        //        t.GetComponent<LoopsMovement>().Paths = new Vector3[tile.Paths.Length];
        //        t.GetComponent<LoopsMovement>().SetValue(tile.Paths, tile.MovementDuration, tile.WaitTime, tile.Curve, tile.LoopType, tile.Looptimes);
        //        //t.parent = tile.transform.parent;
        //        DestroyImmediate(tile.gameObject);
        //    }
        //}
    }
}
