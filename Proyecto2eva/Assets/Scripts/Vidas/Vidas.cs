using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    public GameObject[] vidas;
    private int numvidas = 3;

    private void Start()
    {
        for (int i = 0; i < numvidas; i++)
        {
            vidas[i].SetActive(true);
        }
    }

    void Update()
    {
        
    }
    public void DesactivarVida(int indice)
    {
        if (indice >= 0 && indice < numvidas)
        {
            vidas[indice].SetActive(false);
        }
    }

    public void ActivarVida(int indice)
    {
        if (indice >= 0 && indice < numvidas)
        {
            vidas[indice].SetActive(true);
        }
    }

    public void RecibirDaño()
    {
        if (numvidas > 0)
        {
            numvidas--;
            DesactivarVida(numvidas);
        }
    }

    public void GanarVida()
    {
        if (numvidas <vidas.Length)
        {
            ActivarVida(numvidas);
            numvidas++;
        }
    }


}
