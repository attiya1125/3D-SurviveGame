using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public ItemData itemToGive;
    public int quantityPerHit = 1;
    public int capacy;

    public void Gather(Vector3 hitPoint, Vector3 hitNoraml)
    {
        for(int i = 0; i < quantityPerHit; i++)
        {
            if (capacy <= 0) break;
            capacy -= 1;
            Instantiate(itemToGive.dropPrfab, hitPoint + Vector3.up, Quaternion.LookRotation(hitNoraml,Vector3.up));
        }
    }

    private void Update()
    {
        if (capacy == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
