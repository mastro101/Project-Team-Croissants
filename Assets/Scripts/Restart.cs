using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// PROVVISORIO
public class Restart : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene("SceneSelector");
            FindObjectOfType<AudioManager>().Pause();
        }

        //if (Input.GetKeyDown(KeyCode.Alpha0))
        //{
        //    if (SceneManager.GetActiveScene().buildIndex + 1 == SceneManager.sceneCountInBuildSettings)
        //    {
        //        SceneManager.LoadScene(1);
        //    }
        //    else
        //    {
        //        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //    }


        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            FindObjectOfType<AudioManager>().Pause();
        }

        //}

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadSceneAsync("02AnconaScene", LoadSceneMode.Additive);
        }

        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    SceneManager.LoadScene(2);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    SceneManager.LoadScene(3);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha4))
        //{
        //    SceneManager.LoadScene(4);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha5))
        //{
        //    SceneManager.LoadScene(5);
        //}

        //if (Input.GetKeyDown(KeyCode.Alpha6))
        //{
        //    SceneManager.LoadScene(6);
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("CharacterSelect");
            FindObjectOfType<AudioManager>().Pause();
        }

    }
}
