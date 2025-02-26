using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosenMask : MonoBehaviour
{
    [SerializeField] GameObject[] Mascaras;
    private GameObject ChoosenMascara;

    // Start is called before the first frame update
    void Start()
    {
        RandomChoise();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomChoise()
    {
        if (Mascaras.Length > 0)
        {
            ChoosenMascara = Mascaras[Random.Range(0, Mascaras.Length)];
          
            Debug.Log("Mask" + ChoosenMascara);

        }


    }

  
}
