using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DebugPlayer : MonoBehaviour {

    public GameObject playerObj;


	// Use this for initialization
	void Start () {

        /*
        int[] array = { -18, -14, 0, 2, 3, 4, 5, 6, 20, 66, 99, 15000 };


        Debug.Log(BinarySearch(array.ToList<int>(), -18));
        Debug.Log(BinarySearch(array.ToList<int>(), -14));
        Debug.Log(BinarySearch(array.ToList<int>(), 0));
        Debug.Log(BinarySearch(array.ToList<int>(), 2));
        Debug.Log(BinarySearch(array.ToList<int>(), 3));
        Debug.Log(BinarySearch(array.ToList<int>(), 4));
        Debug.Log(BinarySearch(array.ToList<int>(), 5));
        Debug.Log(BinarySearch(array.ToList<int>(), 6));
        Debug.Log(BinarySearch(array.ToList<int>(), 20));
        Debug.Log(BinarySearch(array.ToList<int>(), 66));
        Debug.Log(BinarySearch(array.ToList<int>(), 99));
        Debug.Log(BinarySearch(array.ToList<int>(), 15000));
        Debug.Log(BinarySearch(array.ToList<int>(), -500));
        Debug.Log(BinarySearch(array.ToList<int>(), 1));
        Debug.Log(BinarySearch(array.ToList<int>(), -13));
        Debug.Log(BinarySearch(array.ToList<int>(), 35));
        Debug.Log(BinarySearch(array.ToList<int>(), 99090));
        */
	}

    int BinarySearch (List<int> list, int target) {
        int middleIndex = list.Count / 2;

        if (list.Count == 0) {
            return -1;
        }
        if (target == list[middleIndex]) {
            return middleIndex;
        }
        else if(target < list[middleIndex]){
            return BinarySearch(list.GetRange(0, list.Count / 2), target);
        }
        else{
            int result = BinarySearch(list.GetRange(middleIndex + 1, list.Count / 2 - (list.Count % 2 == 0 ? 1 : 0)), target);
            return result == -1? -1: result + middleIndex + 1;
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R)) {
            playerObj.transform.position = GM.inst.spawn.transform.position;
        }

	}
}
