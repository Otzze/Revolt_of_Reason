using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public float minX;
    public float minZ;
    public float maxX;
    public float maxZ;
    public List<GameObject> PlayerObject;
    public static SpawnPlayers Instance;
    
    public void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 100, Random.Range(minZ, maxZ));
        var player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        playerPrefab.GetComponent<Rigidbody>().mass = 1000;
        Instance.PlayerObject.Add(player);
    }
}
