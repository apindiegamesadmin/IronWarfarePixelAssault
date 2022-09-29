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
        //StartCoroutine(DelayPopBack(pop));//Disable Object After Animation End
    }

    IEnumerator DelayPopBack(GameObject pop)
    {
        yield return new WaitForSeconds(0.4f);//Delay
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
