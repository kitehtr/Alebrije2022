using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;


public class EndConditions : MonoBehaviour
{
    
    public Flower flower;
    List<GameObject> objectsInScene;
    
    
    void Start()
    {
        
        objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
            {
                if(go.tag == "Flower")
                {
                    objectsInScene.Add(go);
                    Debug.Log("GameObject: "+ go.tag);
                    Debug.Log("Flower: " + go.GetComponent<Flower>().Pollinated);
                }

            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        int flowersPollinated = 0;
        foreach(GameObject go in objectsInScene )
        {
            if(go.GetComponent<Flower>() == null)
            {
                Debug.Log("GameObject:" + go);
                continue;
            }
            Debug.Log("Flower: Update:" + go.GetComponent<Flower>().Pollinated + "flowers pollinated " + flowersPollinated);
            if(go.GetComponent<Flower>().Pollinated)
            {
            flowersPollinated++;
            if(flowersPollinated >= 2)
            {
            SceneManager.LoadScene("endcredits");
            }

            }
        }
        Debug.Log("Flowers pollinated "+ flowersPollinated);


    }
}
