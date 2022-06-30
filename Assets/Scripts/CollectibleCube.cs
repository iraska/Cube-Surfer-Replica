using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCube : MonoBehaviour
{
    bool hasItCollected;
    int index; // Collect position/height
    public Collector collector;
    void Start()
    {
        hasItCollected = false; // Uncollected -flag-
    }

    void Update()
    {
        if (hasItCollected == true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0); // The position of the collected cubes should be adjusted (0, below, 0)
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Barrier") // The height of the collector should decrease when it hits the barrier.
        {
            collector.DecreaseHeight();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false; 
            other.gameObject.GetComponent<BoxCollider>().enabled = false; // The collider of the barrier is also closed.
        } 
    }
    public bool GethasItCollected()
    {
        return hasItCollected;
    }
    public void doItCollected()
    {
        hasItCollected = true;
    }
    public void SetIndex(int index)
    {
        this.index = index;
    }
}
