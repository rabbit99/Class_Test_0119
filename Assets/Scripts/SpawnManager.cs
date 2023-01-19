using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject MyObject;
    public Transform SpawnPointToRed;
    public Transform SpawnPointToBlue;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance == null || GameManager.Instance.GetPlayerData() == null)
        {
            MyObject.transform.SetPositionAndRotation(SpawnPointToRed.localPosition, Quaternion.identity);
            return;
        }

        if (GameManager.Instance.GetPlayerData().CampType == CampType.Red)
        {
            MyObject.transform.SetPositionAndRotation(SpawnPointToRed.localPosition, Quaternion.identity);
        }
        else
        {
            MyObject.transform.SetPositionAndRotation(SpawnPointToBlue.localPosition, Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
