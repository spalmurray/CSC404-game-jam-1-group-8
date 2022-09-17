using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    private Rigidbody _rigidBody;
    private Transform _transform;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        _rigidBody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(1,0,0) * speed * Time.deltaTime);
        if (gameObject.transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
