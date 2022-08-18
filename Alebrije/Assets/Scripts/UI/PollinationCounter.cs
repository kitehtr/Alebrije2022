using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PollinationCounter : MonoBehaviour
{
    [SerializeField] private Flower Flower;
    [SerializeField] private EndConditions EndConditions;
    public TextMeshProUGUI text;
    
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = ("Flowers Pollinated: ")+ EndConditions.flowerCounter.ToString()+ ("/10");
    }
}
