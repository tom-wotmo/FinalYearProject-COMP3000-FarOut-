using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WotmoObjectSpawner : EditorWindow
{

    string objectName = "";
    int objectID = 1;
    GameObject objectToSpawn;
    float objectScale;
    float spawnRadius = 5f;
    float numberOfObjects = 1f;
    bool rotation = false;
    bool randomScale = false;


    [MenuItem("Custom Tools/Wotmo's Object Spawner")]
    public static void ShowWindow()
    {
        GetWindow(typeof(WotmoObjectSpawner));
    }
    private void OnGUI()
    {
        GUILayout.Label("Spawn New Object", EditorStyles.boldLabel);
        objectName = EditorGUILayout.TextField("object name", objectName);
        objectID = EditorGUILayout.IntField("id", objectID);
        objectScale = EditorGUILayout.Slider("scale", objectScale, 0.5f, 3f); //f are low end and high end
        spawnRadius = EditorGUILayout.FloatField("spawn radius", spawnRadius);
        objectToSpawn = EditorGUILayout.ObjectField("object", objectToSpawn, typeof(GameObject), false) as GameObject; //boolean is for scene objects 
        numberOfObjects = EditorGUILayout.FloatField("number of objects to spawn", numberOfObjects);
        rotation = EditorGUILayout.Toggle("random rotation", rotation);
        randomScale = EditorGUILayout.Toggle("random scale", randomScale);

        if (GUILayout.Button("Spawn Object"))
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                SpawnObject();
            }
            
        }
    }

    private void SpawnObject()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("Error: please assign an object to be spawned");
            return;
        }
        if(objectName == string.Empty)
        {
            Debug.LogError("Error: Please enter a base name for the object");
            return;
        }
        Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(spawnCircle.x, 0f, spawnCircle.y);

        GameObject newObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);

        newObject.name = objectName + objectID;
        newObject.transform.localScale = Vector3.one * objectScale;
       if (rotation == true)
        {
            newObject.transform.rotation = Random.rotation;
        }
       if (randomScale == true)
        {
            newObject.transform.localScale = Vector3.one * Random.value;
        }
        
        

        objectID++;
    }
    
}
