using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureScreenShoot : MonoBehaviour
{
    public string screenShootName;
    public int index;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenCapture.CaptureScreenshot("D:/Android_Build/ScreenShot/" + screenShootName + index + ".png");
            index++;
        }
    }
}
