using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton { get; private set; }

    public enum GameState { BOOT, END, GAME, MENU, LOAD_G, LOAD_M }
    public GameState State { get; private set; }

    public GameObject PlayerManagerPrefab { get; private set; }

    private void Awake()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(this);
        }
        else
        {
            Singleton = this;
            State = GameState.BOOT;

            PlayerManagerPrefab = Resources.Load<GameObject>("Prefabs/Player Manager");
            if (PlayerManagerPrefab != null)
            {
                Instantiate(PlayerManagerPrefab, Vector3.zero, Quaternion.identity);
            }
            else
            {
                Debug.LogError("Prefab not found: Prefabs/Player Manager");
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
