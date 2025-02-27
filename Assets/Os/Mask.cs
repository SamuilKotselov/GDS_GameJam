using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
   private ChoosenMask choosenMask;

    private void Start()
    {
        choosenMask = GetComponent<ChoosenMask>();
    }
    void Update()
    {
        ClickMask();
     

    }

    public void ClickMask()
    {
        if (choosenMask != null && choosenMask.MascaraW() !=null && Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit.collider != null)
            {
                Debug.Log("¡Has ganado!");
                Destroy(choosenMask.MascaraW());

            }

        }

    }
 

}
