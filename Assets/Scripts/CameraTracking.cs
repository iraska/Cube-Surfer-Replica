using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public GameObject target;
    public Vector3 distance;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + distance, Time.deltaTime); 
        
        //We make it follow slowly with the Vector3.Lerp() function. We write its position in the first parameter, and the position of the object to follow + the distance in the second parameter. Finally, we write the tracking speed.
    }
}
