using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Build.Content;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    void Update()
    {
        puntos.text = GameManager.Instance.PuntosTotales.ToString();
    }
    public void ActualizarPuntos(int puntosTotales)
    {
        puntos.text = puntosTotales.ToString();
    }
}





