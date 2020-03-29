using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DSMode : MonoBehaviour
{
    public void BackCommand()
    {
        SceneManager.LoadScene(0);
    }
}
