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
        if (isBouncy)
        {
            ApplyForce();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ApplyForce()
    {
        Vector2 direction = new Vector2((float)Random.Range(-2, 2), (float)Random.Range(-2, 2));

        float force = (float)Random.Range(-1, 1);
        GetComponent<Rigidbody2D>().AddForce(direction * force);

        if (GetComponent<Rigidbody2D>().velocity.magnitude > 1f)
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * 1f;
        }
    }

    void OnCollision2D(Collider2D col)
    {
        ApplyForce();
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
}
