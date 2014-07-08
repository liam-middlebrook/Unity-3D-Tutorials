using UnityEngine;
using System.Collections;

/* MovingPlatform Class for Unity3D
 * 
 * A Moving Platform that will Oscillate given
 * a direction and distance
*/
public class MovingPlatform : MonoBehaviour
{
    public float Period; // How Many Seconds the Platform takes to complete a cycle
    public float Distance; // How far the platform will go in a cycle.
    public Vector3 Direction;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = (Time.time / Period ); // How far are we into a cycle?

        // Velocity is equal to `Distance * Direction * sin(elapsedTime *2PI)`
        // This will cause the platform to Oscillate a total distance of `Distance` Units
        // in the direction `Direction`
        this.rigidbody.velocity = Distance * Direction * Mathf.Sin(elapsedTime * 2 * Mathf.PI);
    }
}

