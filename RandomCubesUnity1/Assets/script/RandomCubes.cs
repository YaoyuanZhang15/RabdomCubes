/****
 * Created by: Yaoyuan Zhang
 * Data created: 1/24/2022
 * 
 * Last edited by :
 * Last Edited: 1/26/2022
 * 
 * Decription: Spowns multiple cube prefabs in scene
  ****/















using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject CubePrefab;
    public List<GameObject> gameObjectList;//list for all cubes
    public float scalingfactor = 0.95f;
    public int numOfcubes = 0;
    [HideInInspector]
    

    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>();// instatiate the cubes
    }

    // Update is called once per frame
    void Update()
    {
        numOfcubes++;//add to the number of the cubes
        GameObject gObj = Instantiate<GameObject>(CubePrefab);//instatiate the cube

        gObj.name = "Cube" + numOfcubes;//name property of the object
        gObj.transform.position = Random.insideUnitSphere; // Random point inside a sphere radius of 1

        Color randColor = new Color(Random.value, Random.value, Random.value);

        gObj.GetComponent<Renderer>().material.color = randColor; //assign random color to cube
        gameObjectList.Add(gObj); // add cube to the list


        List<GameObject> removeList = new List<GameObject>(); //List of game objects to remove

        foreach (GameObject goTemp in gameObjectList) 
        {
            float scale = goTemp.transform.localScale.x; //record starting scale
            scale *= scalingfactor; //set scale multipled by scaling factor
            goTemp.transform.localScale = Vector3.one * scale; // Transform the scale


            if (scale <= 0.1f)
            {
                removeList.Add(goTemp);// add to the remove List

            
            
            }
        
            
        
        }

        foreach (GameObject goTemp in removeList)
            {
            gameObjectList.Remove(goTemp); //remove from gamobject list
            Destroy(goTemp); // destory the item from the scene

            }
        
    }
}
