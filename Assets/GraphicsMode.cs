using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GraphicsMode : MonoBehaviour
{
    public void BackCommand()
    {
        SceneManager.LoadScene(0);
    }

    public void InfoPanelBackCommand()
    {
        SceneManager.LoadScene(0);
    }
}
