using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
	//TREE/OBJECT GENERATOR


	public GameObject[] objects; //Grab the prefabs and drop it on the objects array on Unity

	void Start()
	{

		int r = Random.Range(0, objects.Length); //Picks a random object from the objects array
		Instantiate(objects[r], transform.position, Quaternion.identity); //Spawn object in random way in the position of the spawn point
	}

	
}
