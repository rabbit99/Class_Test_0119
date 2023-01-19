using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseUI : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject LeftPanel;
    public GameObject RightPanel;

    public GameObject MyObejct;
    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = MyObejct.GetComponent<PlayerData>();
        data.SetCampType(CampType.Red);
        GameManager.SetPlayerData(data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToRightSide()
    {
        MyObejct.transform.SetParent(RightPanel.transform, false);
        PlayerData data = MyObejct.GetComponent<PlayerData>();
        data.SetCampType(CampType.Blue);
        GameManager.SetPlayerData(data);
    }

    public void MoveToLeftSide()
    {
        MyObejct.transform.SetParent(LeftPanel.transform, false);
        PlayerData data = MyObejct.GetComponent<PlayerData>();
        data.SetCampType(CampType.Red);
        GameManager.SetPlayerData(data);
    }
}
