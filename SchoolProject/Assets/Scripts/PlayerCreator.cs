using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour
{
    public GameObject[] playerPrefabs;

    int id;
    // Start is called before the first frame update
    void Start()
    {
        id = PlayerPrefs.GetInt("PlayerID",0);
        GameObject playerPrefab = Instantiate(playerPrefabs[id],Vector3.zero,Quaternion.identity);
        playerPrefab.transform.parent = gameObject.transform;
    }

    
}
