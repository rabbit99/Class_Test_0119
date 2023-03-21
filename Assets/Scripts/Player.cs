using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, 1 << LayerMask.NameToLayer("Ground")))
            {
                //����ƹ����䤣��|�@����s��m
                //�{�b�O�����X�{�b���w��m
                //�i�ϥγo�� hit.point �y�СA�������U�ز����ޥh����
                gameObject.transform.SetPositionAndRotation(hit.point + new Vector3(0, 0.5f, 0), Quaternion.identity);
            }
        }
    }
}
