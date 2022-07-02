using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    GameObject mainCube;
    public int height;

    [SerializeField]
    private AudioClip audioClip;

    void Start()
    {
        mainCube = GameObject.Find("MainCube");
    }

    void Update()
    {
        mainCube.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
        // Let the cubes we collect be added to between MainCube and Collector.
        this.transform.localPosition = new Vector3(0, -height, 0);  
    }

    public void DecreaseHeight()
    {
        height--;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collect" && other.gameObject.GetComponent<CollectibleCube>().GethasItCollected() == false)
        {
            // Each time we collect cubes, our height will increase.
            height += 1;
            other.gameObject.GetComponent<CollectibleCube>().doItCollected();
            other.gameObject.GetComponent<CollectibleCube>().SetIndex(height);
            other.gameObject.transform.parent = mainCube.transform;

            // mainCube.transform.position = new Vector3(transform.position.x, height + 1, transform.position.z);
            // Let the cubes we collect be added to between MainCube and Collector.
            // this.transform.localPosition = new Vector3(0, -height, 0);

            AudioSource.PlayClipAtPoint(audioClip, transform.position, 100);
        }
    }
}
