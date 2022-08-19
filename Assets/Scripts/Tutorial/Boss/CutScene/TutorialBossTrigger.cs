using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TutorialBossTrigger : MonoBehaviour
{
    PlayableDirector director;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject blocks;
    void Start()
    {
        director = GetComponentInParent<PlayableDirector>();
    }

    public void PlayCutScene()
    {
        if (director != null)
        {
            Debug.Log("Playing Cut Scene");
            gameUI.SetActive(false);
            blocks.SetActive(false);
            Time.timeScale = 0;
            director.Play();
            //Destroy(this.gameObject);
        }
    }

    public void EndCutScene()
    {
        if (director != null)
        {
            Debug.Log("Ending Cut Scene");
            gameUI.SetActive(true);
            blocks.SetActive(true);
            Time.timeScale = 1;
            director.Stop();
            Destroy(this.gameObject);
        }
    }
}
