using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<GameObject> popUps;

    public void PopDown(GameObject pop)
    {
        pop.GetComponent<Animator>().Play("Pop_Down");
        StartCoroutine(DelayPopDown(popUps.Last()));
    }

    public void PopDownObject(GameObject pop)
    {
        pop.GetComponent<Animator>().Play("Pop_Down");
        StartCoroutine(DelayPopDownObject(pop));
    }

    IEnumerator DelayPopDownObject(GameObject pop)
    {
        yield return new WaitForSecondsRealtime(0.26f);//Delay
        pop.SetActive(false);//Disable Object
    }

    IEnumerator DelayPopDown(GameObject pop)
    {
        yield return new WaitForSecondsRealtime(0.26f);//Delay
        pop.SetActive(false);//Disable Object
        popUps.Remove(pop);
    }

    public void PopUp(GameObject pop)
    {
        popUps.Add(pop);
        popUps.Last().SetActive(true);
    }

    public void PopUpObject(GameObject pop)
    {
        pop.SetActive(true);
    }

    public void OpenUrl(string url)
    {
        Application.OpenURL(url);//URL for Website
    }

    public void ExitFromGame()
    {
        Application.Quit();
    }
}
