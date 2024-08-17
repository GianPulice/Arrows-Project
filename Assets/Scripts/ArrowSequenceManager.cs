using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArrowSequenceManager : MonoBehaviour
{ 
 public ArrowSequenceGenerator sequenceGenerator;
    public Timer timer;
    public ScoreManager scoreManager;

    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI sequenceText;
    public TextMeshProUGUI lastPressedKeyText; 

    private int currentIndex = 0;
    private KeyCode lastPressedKey = KeyCode.None; 

    void Start()
    {
        sequenceGenerator.GenerateRandomSequence();
        UpdateUI();
    }

    void Update()
    {
        timer.UpdateTimer();

        if (timer.HasTimerExpired())
        {
            HandleTimerExpiration();
        }
        else if (IsSequenceIncomplete())
        {
            HandleUserInput();
        }
        else
        {
            HandleSequenceCompletion();
        }

        UpdateUI();
    }

    bool IsSequenceIncomplete()
    {
        return currentIndex < sequenceGenerator.arrowSequence.Count;
    }

    void HandleUserInput()
    {
        if (Input.GetKeyDown(sequenceGenerator.arrowSequence[currentIndex]))
        {
            lastPressedKey = sequenceGenerator.arrowSequence[currentIndex]; 
            currentIndex++;
            Debug.Log(" correcta");
        }
        else if (Input.anyKeyDown)
        {
            Debug.Log(" incorrecta!");

            
            scoreManager.UpdateScore(-1);
            timer.ResetTimer();
            ResetCurrentIndex();
            lastPressedKey = KeyCode.None; 
        }
    }

    void HandleSequenceCompletion()
    {
        Debug.Log("Secuencia completada");
        scoreManager.UpdateScore(1);

        if (sequenceGenerator.sequenceLength < sequenceGenerator.maxSequenceLength)
        {
            sequenceGenerator.IncreaseSequenceLength();
        }

        ResetTimerAndSequence();
    }

    void HandleTimerExpiration()
    {
        Debug.Log("Tiempo agotado");
        scoreManager.UpdateScore(-1);
        ResetTimerAndSequence();
    }

    void ResetTimerAndSequence()
    {
        timer.ResetTimer();
        ResetCurrentIndex();
        sequenceGenerator.GenerateRandomSequence();
    }

    void ResetCurrentIndex()
    {
        currentIndex = 0;
        lastPressedKey = KeyCode.None; // Reinicia la última tecla presionada
    }

    void UpdateUI()
    {
        scoreText.text = "Puntuación: " + scoreManager.GetScore();
        timerText.text = "Tiempo: " + Mathf.Ceil(timer.GetRemainingTime()).ToString("F0");
        sequenceText.text = GetSequenceDisplay();
        lastPressedKeyText.text = GetArrowSymbol(lastPressedKey); 
    }

    string GetSequenceDisplay()
    {
        string sequenceDisplay = "";
        foreach (var arrow in sequenceGenerator.arrowSequence)
        {
            sequenceDisplay += GetArrowSymbol(arrow) + " ";
        }
        return sequenceDisplay;
    }

    string GetArrowSymbol(KeyCode arrow)
    {
        switch (arrow)
        {
            case KeyCode.UpArrow: return "↑";
            case KeyCode.DownArrow: return "↓";
            case KeyCode.LeftArrow: return "←";
            case KeyCode.RightArrow: return "→";
            default: return "";
        }
    }
}
