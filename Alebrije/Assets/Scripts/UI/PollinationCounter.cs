using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PollinationCounter : MonoBehaviour
{
    [SerializeField] private Flower Flower;
    public TextMeshProUGUI text;
    
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //text.text = ("Flowers Pollinated: ")+ Flower.flowersPollinated.ToString();
    }
}
