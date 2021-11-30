using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ObjectSpawnScript : EditorWindow
{
    string objName = "";
    int objId = 1;
    GameObject objToSpawn;
    float objectScale;
    float spawnRadius = 5f;
    float numberOfObjs = 1f;
    bool rotation = false;
    bool randomScale = false;

    public static void ShowWindow() 
    {
        GetWindow(typeof(ObjectSpawnScript));
    }
    private void OnGUI()
    {
        GUILayout.Label("Spawn new obj's", EditorStyles.boldLabel);
        objName = EditorGUILayout.TextField("obj name", objName);
        objId = EditorGUILayout.IntField("id", objId);
        objectScale = EditorGUILayout.Slider("scale", objectScale, 0.5f, 3f);
        spawnRadius = EditorGUILayout.FloatField("spawn radius", spawnRadius);
        objToSpawn = EditorGUILayout.ObjectField("object", objToSpawn, typeof(GameObject), false) as GameObject;
        numberOfObjs = EditorGUILayout.FloatField("number of objects", numberOfObjs);
        rotation = EditorGUILayout.Toggle("random rotation", rotation);
        randomScale = EditorGUILayout.Toggle("random scale", randomScale);

        if(GUILayout.Button("Spawn Objects"))
        {
            for (int i = 0; i < numberOfObjs; i++)
            {
                SpawnObject();
            }
        }

    }
    private void SpawnObject()
    {
        if(objToSpawn == null) 
        {
            Debug.LogError("Please assign an object");
            return;
        }
        if(objName == string.Empty)
        {
            Debug.LogError("Enter name");
            return;
        }
        Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(spawnCircle.x, 0f, spawnCircle.y);

        GameObject newObject = Instantiate(objToSpawn, spawnPos, Quaternion.identity);

        newObject.name = objName + objId;
        newObject.transform.localScale = Vector3.one * objectScale;
        if(rotation == true)
        {
            newObject.transform.rotation = Random.rotation;

        }
        if(randomScale == true) 
        {
            newObject.transform.localScale = Vector3.one * Random.value;
        }

        objId++;
    }
   
}
