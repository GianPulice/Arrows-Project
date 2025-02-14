using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGenerator : MonoBehaviour
{
    public GameObject prefab; // Referencia al prefab de Tile
    public int initialLength = 10; // Longitud inicial del camino
    public float tileSize = 1.0f; // Tamaño de cada tile

    private List<GameObject> tiles = new List<GameObject>(); // Lista para almacenar los tiles generados

    void Start() {
        GenerateEndlessPath(initialLength, tileSize); // Genera los tiles al iniciar
    }

    public void GenerateEndlessPath(int initialLength, float tileSize) {
        if (prefab == null) {
            Debug.LogError("El prefab no puede ser nulo.");
            return; // Salir si el prefab es nulo
        }
        
        for (int i = 0; i < initialLength; i++) {
            Vector3 position = new Vector3(i * tileSize, 0, 0);
            GameObject tile = Instantiate(prefab, position, Quaternion.identity);
            tiles.Add(tile); // Agregar el tile a la lista
        }
    }

    // Nueva función para mover un prefab hacia adelante un tile
    public void MovePrefabForward(GameObject objectToMove) {
        if (objectToMove == null) {
            Debug.LogError("El objeto a mover no puede ser nulo.");
            return; // Salir si el objeto es nulo
        }

        // Obtener la posición actual del objeto
        Vector3 currentPosition = objectToMove.transform.position;

        // Calcular la posición del siguiente tile
        Vector3 nextPosition = currentPosition + new Vector3(tileSize, 0, 0);

        // Verificar si el objeto ha llegado al último tile
        if (nextPosition.x >= (tiles.Count - 1) * tileSize) {
            // Mover al primer tile
            objectToMove.transform.position = new Vector3(0, 0, 0);
        } else {
            // Mover al siguiente tile
            objectToMove.transform.position = nextPosition;
        }

        Debug.Log("Objeto movido a: " + objectToMove.transform.position); // Para verificar el movimiento
    }
}