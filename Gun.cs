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

public class Gun : MonoBehaviour
{

    // The object which will be shot from the gun
    public GameObject bulletObject;
    public Vector3 bulletOffset = new Vector3(.75f, .5f, 1);
    // The speed (in Unity units) that the object should be shot at
    public float speed = 10.0f;

    // Update is called once per frame
    void Update () 
    {
       if (Input.GetButtonDown("Fire1"))
        {   
            // We're going to make a new bullet object
            GameObject newBullet = (GameObject)Instantiate(
                                                   bulletObject, // The object to create a new instance of
                                                   this.gameObject.transform.position, // The position to create it at
                                                   this.gameObject.transform.rotation); // The rotation to create it at
            // Now we need to slightly translate the bullet so it's not in the player
            newBullet.transform.Translate(
                                    bulletOffset, // How much we're going to offset it
                                    newBullet.transform); // The object we'll offset it relative to
            
            // Now we need to set the object's velocity to match the way we're looking
            // Offset according to player camera rotation
            newBullet.rigidbody.velocity = this.transform.FindChild("Main Camera").forward * speed;
        }
    }
}
