using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlightDuration : MonoBehaviour
{
    [SerializeField] private playerMovement playerMovement;
    //public Text text;
    public TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = ("Flight Duration: ")+ playerMovement.currentTime.ToString();
    }


}
