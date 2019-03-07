using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MapGenerator map = target as MapGenerator;

        if (GUILayout.Button("GenerateMap"))
        {
            // Date la colpa a Papagno
            if (EditorUtility.DisplayDialog("CREARE NUOVA ARENA?", "PERDERAI TUTTI I DATI NON SALVATI SEI DAVVERO SICURO SICURO?",
                "si, distruggo l'arena", "NO!"))
            {
                map.GenerateMap();
            }
        }

        if (GUILayout.Button("UpdateModulo"))
        {
            map.UpdateMap();
        }
    }
}
