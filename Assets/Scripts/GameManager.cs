using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private PlayerData playerData;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerData(PlayerData _playerData)
    {
        playerData = _playerData;
    }

    public PlayerData GetPlayerData()
    {
        return playerData;
    }
}
