using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class JumpingObject : MonoBehaviour
{
    float rayDistance = 10f;
    public float addForce;

    public Rigidbody hitRigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            Debug.Log("Hit: " + hit.collider.name);

            hitRigidbody = hit.collider.GetComponent<Rigidbody>();

            if (hitRigidbody != null)
            {
                Debug.Log("Hit: " + hitRigidbody);
                hitRigidbody.AddForce(Vector2.up * addForce, ForceMode.Impulse);
            }
        }
        Debug.DrawRay(transform.position, transform.up * rayDistance, Color.red);
    }
}
