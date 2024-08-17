using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSequenceGenerator : MonoBehaviour
{
    public List<KeyCode> arrowSequence = new List<KeyCode>();
    public int sequenceLength = 5;
    public int maxSequenceLength = 10;

    public void GenerateRandomSequence()
    {
        arrowSequence.Clear();
        for (int i = 0; i < sequenceLength; i++)
        {
            arrowSequence.Add(GetRandomArrowKey());
        }
        DisplayGeneratedSequence();
    }

    KeyCode GetRandomArrowKey()
    {
        int randomArrow = Random.Range(0, 4);
        switch (randomArrow)
        {
            case 0: return KeyCode.UpArrow;
            case 1: return KeyCode.DownArrow;
            case 2: return KeyCode.LeftArrow;
            case 3: return KeyCode.RightArrow;
            default: return KeyCode.UpArrow; 
        }
    }

    public void IncreaseSequenceLength()
    {
        sequenceLength++;
    }

    void DisplayGeneratedSequence()
    {
        Debug.Log("Secuencia generada");
        foreach (var arrow in arrowSequence)
        {
            Debug.Log(arrow);
        }
    }
}
