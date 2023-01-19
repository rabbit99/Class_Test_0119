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
                //按住滑鼠左鍵不放會一直更新位置
                //現在是直接出現在指定位置
                //可使用這個 hit.point 座標，替換成各種移動邏去移動
                gameObject.transform.SetPositionAndRotation(hit.point + new Vector3(0, 0.5f, 0), Quaternion.identity);
            }
        }
    }
}
