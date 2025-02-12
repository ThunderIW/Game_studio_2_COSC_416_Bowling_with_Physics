using System;
using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    private FallTrigger[] pins;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include,FindObjectsSortMode.None);

        foreach(FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


