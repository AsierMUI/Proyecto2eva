using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Enemigo"))
        {
            //Vidas.RecibirDa�o();
        }

        if(other.CompareTag("Vida"))
        {
            //Vidas.GanarVida();
            Destroy(other.gameObject);
        }

    }


}
