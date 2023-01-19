using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CampType
{
    None,
    Red,
    Blue
}
public class PlayerData : MonoBehaviour
{
    public CampType CampType = CampType.None;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCampType(CampType type)
    {
        CampType = type;
    }
}
