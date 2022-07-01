using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCube : MonoBehaviour
{
    bool hasItCollected;
    // Collect position/height
    int index; 
    public Collector collector;

    void Start()
    {
        // Uncollected -flag-
        hasItCollected = false; // Uncollected -flag-
    }

    void Update()
    {
        if (hasItCollected == true)
        {
            if (transform.parent != null)
            {
                // The position of the collected cubes should be adjusted (0, below, 0)
                transform.localPosition = new Vector3(0, -index, 0); 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Barrier") 
         {
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            // The collider of the barrier is also closed.
            other.gameObject.GetComponent<BoxCollider>().enabled = false; 
            // The height of the collector should decrease when it hits the barrier.
            collector.DecreaseHeight();
         } 
    }

    public bool GethasItCollected()
    {
        // read only
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
