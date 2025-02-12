using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Drawing;
using UnityEngine;

public class RANGO : MonoBehaviour
{
    public float radioBusqueda;
    public LayerMask capaJugador;
    public Transform transformJugador;

    public float velocidadMovimiento;
    public float distanciaMaxima;
    public Vector3 puntoInicial;

    public EstadosMovimiento estadoActual;
    public enum EstadosMovimiento
    {
        Esperando,
        Siguiendo,
        Volviendo,
    }

    private void Start()
    {
        puntoInicial = transform.position;

    }

    private void Update()
    {
        switch (estadoActual)
        {
            case EstadosMovimiento.Esperando:
                EstadoEsperando();
                break;
            case EstadosMovimiento.Siguiendo:
                EstadoSiguiendo();
                break;
            case EstadosMovimiento.Volviendo:
                Estadovolviendo();
                break;

        }



    }

    private void EstadoEsperando()
    {
        Collider2D jugadorCollider = Physics2D.OverlapCircle(transform.position, radioBusqueda, capaJugador);
        if (jugadorCollider)
        {
            transformJugador = jugadorCollider.transform;

            estadoActual = EstadosMovimiento.Siguiendo;
        }
    }

    private void EstadoSiguiendo()
    {
        if (transformJugador == null)
        {
            return;
        }
    

    transform.position = Vector2.MoveTowards(transform.position, transformJugador.position, velocidadMovimiento* Time.deltaTime);
    if (Vector2.Distance(transform.position, puntoInicial) > distanciaMaxima ||
        Vector2.Distance(transform.position, transformJugador.position) > distanciaMaxima)

        estadoActual = EstadosMovimiento.Volviendo;
        transformJugador = null;
}

    private void Estadovolviendo()
    {
    transform.position = Vector2.MoveTowards(transform.position, puntoInicial, velocidadMovimiento * Time.deltaTime);
        if(Vector2.Distance(transform.position, puntoInicial)< 0.1f)
        {
            estadoActual = EstadosMovimiento.Esperando;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioBusqueda);
        Gizmos.DrawWireSphere(puntoInicial, distanciaMaxima);
    }

}
