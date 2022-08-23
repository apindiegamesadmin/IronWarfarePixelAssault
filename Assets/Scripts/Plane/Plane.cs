using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] GameObject airDropPrefab;
    [SerializeField] Transform StartingPoint;
    [SerializeField] Transform EndingPoint;
    [SerializeField] float speed = 1f;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        transform.position = StartingPoint.position;
        StartCoroutine(MoveToEndPoint());
        StartCoroutine(DelayDrop());

        yield return new WaitForSeconds(20f);
        Destroy(transform.parent.gameObject);
    }

    IEnumerator DelayDrop()
    {
        float delay = Random.Range(6, 10);
        yield return new WaitForSeconds(delay);
        SpawnAirDrop();
    }

    void SpawnAirDrop()
    {
        Instantiate(airDropPrefab,transform.position,Quaternion.identity);
    }

    IEnumerator MoveToEndPoint()
    {
        float AngleRad = Mathf.Atan2(EndingPoint.position.y - transform.position.y, EndingPoint.position.x - transform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        // Rotate Object
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        float playerDistance = Vector2.Distance(transform.position, EndingPoint.position);
        while (playerDistance > 0)
        {
            playerDistance = Vector2.Distance(transform.position, EndingPoint.position);
            transform.GetChild(0).transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            transform.position = Vector2.MoveTowards(transform.position, EndingPoint.position, speed * Time.deltaTime);
            yield return null;
        }
        //Destroy(transform.parent.gameObject);
    }
}
