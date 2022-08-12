using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class beforeyouplay : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("jordonlevel");
    }
}
