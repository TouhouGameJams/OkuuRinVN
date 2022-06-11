using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bounce : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isBouncy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localRotation = Quaternion.identity;
    }

    public void ApplyForce()
    {
        /*        Vector2 direction = new Vector2((float)Random.Range(-1, 1), (float)Random.Range(-1, 1));

                float force = (float)Random.Range(-100, 100);*/
        GetComponent<Rigidbody2D>().velocity = RandomVector(-50f, 50f);
    }

    void OnCollision2D(Collider2D col)
    {
        //ApplyForce();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBouncy = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().angularVelocity = 0;
        transform.rotation = Quaternion.identity;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBouncy = true;
    }

    private Vector3 RandomVector(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = 0;
        return new Vector3(x, y, z);
    }
}
