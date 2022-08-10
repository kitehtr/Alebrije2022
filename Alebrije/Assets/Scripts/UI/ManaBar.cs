using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] private Mana playerMana;
    [SerializeField] private Image totalManaBar;
    [SerializeField] private Image currentManaBar;

    private void Start()
    {
        totalManaBar.fillAmount = playerMana.currentMana/10;
    }

    private void Update()
    {
        currentManaBar.fillAmount = playerMana.currentMana/10;
    }
}
