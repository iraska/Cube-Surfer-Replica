using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    GameObject mainCube;
    int height; // Each time we collect cubes, our height will increase.
    void Start()
    {
        mainCube = GameObject.Find("MainCube");
    }

    void Update()
    {
        mainCube.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        this.transform.localPosition = new Vector3(0, -height, 0);  // Let the cubes we collect be added to our bottom.
    }
    public void DecreaseHeight()
    {
        height--;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collect" && other.gameObject.GetComponent<CollectibleCube>().GethasItCollected() == false)
        {
            height++;
            other.gameObject.GetComponent<CollectibleCube>().doItCollected();
            other.gameObject.GetComponent<CollectibleCube>().SetIndex(height);
            other.gameObject.transform.parent = mainCube.transform;
        }
    }
}
