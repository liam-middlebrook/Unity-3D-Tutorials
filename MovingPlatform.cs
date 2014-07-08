/*
The MIT License (MIT)

Copyright (c) 2014 Liam Middlebrook ( https://github.com/liam-middlebrook )

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

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

