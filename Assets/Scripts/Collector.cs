using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collector : MonoBehaviour
{
    GameObject mainCube;
    public int height;
    // SerializeField makes a field display in the Inspector and causes it to be saved.
    [SerializeField]
    private AudioClip audioClip;
    public Movement movement;
    
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Canvas canvasWin;

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

            AudioSource.PlayClipAtPoint(audioClip, transform.position, 100);
        }

        else if (mainCube.transform.childCount < 3 && other.gameObject.tag == "Barrier")
        {
            Debug.Log("You Lost!");
            movement.forwardSpeed = 0;
            movement.leftRightSpeed = 0;

            AudioSource audioSource = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
            //Stop the audio
            audioSource.Stop();

            canvas.gameObject.SetActive(true);
        }

        else if (mainCube.transform.childCount < 3 && other.gameObject.tag == "Win")
        {
            Debug.Log("You Win!");
            movement.forwardSpeed = 0;
            movement.leftRightSpeed = 0;
        }

        else if (other.gameObject.tag == "Win")
        {
            canvasWin.gameObject.SetActive(true);
        }
    }
}
