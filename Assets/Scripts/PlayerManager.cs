using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Singleton { get; private set; }

    public StartupData StartupData { get; private set; }

    public GameObject PlayerPrefab { get; private set; }
    public GameObject Player { get; private set; }
    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(this);
        }
        else
        {
            Singleton = this;
            StartupData = ScriptableObject.CreateInstance<StartupData>();

            PlayerPrefab = Resources.Load<GameObject>("Prefabs/Player Prefab");
            if (PlayerPrefab != null)
            {
                Player = Instantiate(PlayerPrefab, StartupData.PlayerStartingPos, StartupData.PlayerStartingRot);
            }
            else
            {
                Debug.LogError("Prefab not found: Prefabs/Player Prefab");
            }
        }
    }

    private void Start()
    {

    }

    private void FixedUpdate()
    {

    }

    private void Update()
    {

    }

    private void LateUpdate()
    {

    }
}
