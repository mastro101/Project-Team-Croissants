using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// PROVVISORIO
public class Restart : MonoBehaviour {

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("ProgrammerScene");

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        
    }
}
