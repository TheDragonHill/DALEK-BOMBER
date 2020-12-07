using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singelton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public GameObject grenade;
    public int grenadeSpawnCount;

    private void Start()
    {
        spawnGrenades();
    }

	/// <summary>
	/// Spawn prozedual pickable grenades random in the map
	/// </summary>
	void spawnGrenades()
    {
        for (int i = 0; i < grenadeSpawnCount; i++)
        {
            Instantiate(grenade, new Vector3(transform.position.x + Random.Range(0, 200f), transform.position.y, transform.position.z - Random.Range(0, 310f)), Quaternion.identity);
        }
    }
}
