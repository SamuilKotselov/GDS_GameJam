using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosenMask : MonoBehaviour
{
    [SerializeField] GameObject[] Mascaras;
    [SerializeField] GameObject[] MascarasInGame;

    private GameObject ChoosenMascara;
    private GameObject GamEMascara;
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
            //Choose one mask in mascaras
            int ThisOne = Random.Range(0, Mascaras.Length);
            ChoosenMascara = Mascaras[ThisOne];
            GamEMascara = MascarasInGame[ThisOne];

         ChoosenMascara.SetActive(true);
            Debug.Log("Máscara seleccionada: " + ChoosenMascara.name + " (Nombre: " + GamEMascara + ")");

        }


    }

    public GameObject MascaraW()
    {
        return GamEMascara;
    }
   
  
}
