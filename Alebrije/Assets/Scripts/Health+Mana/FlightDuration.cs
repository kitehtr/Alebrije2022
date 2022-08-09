using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightDuration : MonoBehaviour
{
    playerMovement playerMovement;
    [SerializeField] private float currentTime;


    // Update is called once per frame
    void Update()
    {
        currentTime = playerMovement.currentTime;
    }
}
