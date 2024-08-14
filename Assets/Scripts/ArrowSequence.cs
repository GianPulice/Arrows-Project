using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSequence : MonoBehaviour
{
    public List<KeyCode> arrowSequence = new List<KeyCode>();
    private int currentIndex = 0;
    public int sequenceLength = 5; // Longitud inicial de la secuencia

    void Start()
    {
        GenerateRandomSequence();
    }

    void Update()
    {
        if (currentIndex < arrowSequence.Count)
        {
            if (Input.GetKeyDown(arrowSequence[currentIndex]))
            {
                // Tecla correcta, avanza en la secuencia
                currentIndex++;
                Debug.Log("Tecla correcta presionada!");
            }
            else if (Input.anyKeyDown)
            {
                // Tecla incorrecta, maneja el error
                Debug.Log("Tecla incorrecta, reiniciar secuencia!");
                currentIndex = 0; // Reinicia la secuencia
            }
        }
        else
        {
            Debug.Log("¡Secuencia completada!");
            sequenceLength++; // Incrementa la longitud de la secuencia
            currentIndex = 0; // Reinicia el índice para la nueva secuencia
            GenerateRandomSequence(); // Genera una nueva secuencia aleatoria
        }
    }

    void GenerateRandomSequence()
    {
        arrowSequence.Clear(); // Limpiar la secuencia anterior
        for (int i = 0; i < sequenceLength; i++)
        {
            int randomArrow = Random.Range(0, 4); // Genera un número aleatorio entre 0 y 3
            switch (randomArrow)
            {
                case 0:
                    arrowSequence.Add(KeyCode.UpArrow);
                    break;
                case 1:
                    arrowSequence.Add(KeyCode.DownArrow);
                    break;
                case 2:
                    arrowSequence.Add(KeyCode.LeftArrow);
                    break;
                case 3:
                    arrowSequence.Add(KeyCode.RightArrow);
                    break;
            }
        }
        Debug.Log("Secuencia generada:");
        foreach (var arrow in arrowSequence)
        {
            Debug.Log(arrow);
        }
    }
}
