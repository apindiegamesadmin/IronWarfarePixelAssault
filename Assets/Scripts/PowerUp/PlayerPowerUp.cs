using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    public GameObject tripleShotPrefab;
    public GameObject tripleShotIcon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TripleShot")
        {
            // TripleShot Trigger
            TriggerTripleShot();
        }

        if (collision.gameObject.tag == "AOEPowerup")
        {
            // Large and powerful shot 
            TriggerPowerfulShot();
        }
    }

    void TriggerTripleShot()
    {

    }

    void TriggerPowerfulShot()
    {

    }
}
