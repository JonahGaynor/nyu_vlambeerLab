using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MAZE PROC GEN LAB
// all students: complete steps 1-6, as listed in this file
// optional: if you have extra time, complete the "extra tasks" to do at the very bottom

// STEP 1: ======================================================================================
// put this script on a Sphere... it will move around, and drop a path of floor tiles behind it

public class Pathmaker : MonoBehaviour {

// STEP 2: ============================================================================================
// translate the pseudocode below

//	DECLARE CLASS MEMBER VARIABLES:
	int counter = 0;
	float longHallwayNo = 0f;
	float whatTile;
	public float myLifetime;
	public float generateNew;
	public static int psi = 0;
	public static int numberofGenerators = 1;
	public Transform floorPrefab; //assign this in inspector
	public Transform floorPrefabTwo;
	public Transform floorPrefabThree;
	public Transform pathmakerSpherePrefab; //assign this in inspector
//	Declare a private integer called counter that starts at 0; 		// counter var will track how many floor tiles I've instantiated
//	Declare a public Transform called floorPrefab, assign the prefab in inspector;
//	Declare a public Transform called pathmakerSpherePrefab, assign the prefab in inspector; 		// you'll have to make a "pathmakerSphere" prefab later

	void Start () {

		myLifetime = Random.Range (0f, 200f);
		generateNew = Random.Range (0.90f, 0.99f);


	}

	void Update () {
		whatTile = Random.Range (0f, 2.99f);
		if (psi < 500) {
			if (counter < 500) {
				float randNumber = Random.Range (0.0f, 1.0f);
				if (randNumber < 0.25f - (longHallwayNo / 2)) {
					transform.Rotate (0f, 90f, 0f);
					if (longHallwayNo >= 0.2f) {
						longHallwayNo = 0f;
					}
				} else if (randNumber >= 0.25f - (longHallwayNo / 2) && randNumber < 0.5f - longHallwayNo) {
					transform.Rotate (0f, -90f, 0f);
					if (longHallwayNo >= 0.2f) {
						longHallwayNo = 0f;
					}
				} else if (randNumber >= generateNew && numberofGenerators <= 4) {
					Instantiate (pathmakerSpherePrefab, transform.position, Quaternion.identity);
					numberofGenerators++;
				} else {
					longHallwayNo += 0.02f;
					if (longHallwayNo >= 0.8f) {
						longHallwayNo = 0f;
					}
				}
				if (whatTile <= 0.99f) {
					Instantiate (floorPrefab, transform.position, Quaternion.identity);
				}
				if (whatTile > 0.99f && whatTile <= 1.99f) {
					Instantiate (floorPrefabTwo, transform.position, Quaternion.identity);
				}
				if (whatTile > 1.99f) {
					Instantiate (floorPrefabThree, transform.position, Quaternion.identity);
				}
				myLifetime++;
				transform.position += transform.forward * 5f;
				counter++;
				psi++;
			}
		}		
		if (myLifetime >= 300f && psi >= 400) {
			Destroy (gameObject);
		}
		if (Input.GetKeyDown(KeyCode.R)){
			psi = 0;
		}
	}

} // end of class scope


// OPTIONAL EXTRA TASKS TO DO, IF YOU WANT: ===================================================

// DYNAMIC CAMERA:
// position the camera to center itself based on your generated world...
// 1. keep a list of all your spawned tiles
// 2. then calculate the average position of all of them (use a for() loop to go through the whole list) 
// 3. then move your camera to that averaged center and make sure fieldOfView is wide enough?

// BETTER UI:
// learn how to use UI Sliders (https://unity3d.com/learn/tutorials/topics/user-interface-ui/ui-slider) 
// let us tweak various parameters and settings of our tech demo
// let us click a UI Button to reload the scene, so we don't even need the keyboard anymore!

// WALL GENERATION
// add a "wall pass" to your proc gen after it generates all the floors
// 1. raycast downwards around each floor tile (that'd be 8 raycasts per floor tile, in a square "ring" around each tile?)
// 2. if the raycast "fails" that means there's empty void there, so then instantiate a Wall tile prefab
// 3. ... repeat until walls surround your entire floorplan
// (technically, you will end up raycasting the same spot over and over... but the "proper" way to do this would involve keeping more lists and arrays to track all this data)
