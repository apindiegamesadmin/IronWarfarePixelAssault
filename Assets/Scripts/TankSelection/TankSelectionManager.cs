using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankSelectionManager : MonoBehaviour
{
    public ScreenSwitcher screenSwitcher;

    public static int skinIndex;

    public void ChooseTank(int index)
    {
        skinIndex = index;
        screenSwitcher.LoadSceneIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
