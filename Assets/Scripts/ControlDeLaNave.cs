using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeLaNave : MonoBehaviour
{
    public float Velocidad;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");

        Vector2 Direccion = new Vector2(X, Y).normalized;

        Mover(Direccion);
    }

    void Mover(Vector2 Direccion)
    {
        Vector2 Minimo = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 Maximo = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Maximo.x = Maximo.x - 0.225f;
        Minimo.x = Minimo.x + 0.225f;

        Maximo.y = Maximo.y - 0.285f;
        Maximo.y = Maximo.y + 0.285f;

        Vector2 Posicion = transform.position;

        Posicion += Direccion * Velocidad * Time.deltaTime;

        Posicion.x = Mathf.Clamp(Posicion.x, Minimo.x, Maximo.x);
        Posicion.y = Mathf.Clamp(Posicion.y, Minimo.y, Maximo.y);

        transform.position = Posicion;
    }
}
