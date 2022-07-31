using UnityEngine;

public class Plane : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public Transform StartingPoint;
    public Transform EndPoint;
    private float _speed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartingPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + _speed, transform.position.y + _speed, 0);
    }
}
