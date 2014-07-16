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
using System.Collections.Generic;

/*
 * A NPC that will say scripted lines to the player
 */
public class NPC : MonoBehaviour {

    // A list of lines that the NPC will say to the player
	public List<string> chatText = new List<string>();
	
	// Whether or not to rest how far the NPC is into it's dialogue when exiting it's range
	public bool resetSpeech = true;
	
	// The current line of the dialogue that the NPC is on
	private int currentLine = 0;
	
	// Whether or not the player is in the bounds of the NPC
	public bool inBounds;
	// Use this for initialization
	void Start ()
	{
	    // if the developer didn't enter any lines, have a backup message
		if (chatText.Count < 1)
		{
			chatText.Add ("Hi, I'm an NPC");
			chatText.Add ("Add text to me using the Unity Inspector Menu");
		}
	}

	void OnGUI()
	{
	    // Check that the player is in bounds of the NPC
		if (!inBounds)
		{
			return;
		}
		// Draw out the message in the top-center of the screen
		GUI.Box (new Rect (Screen.width/2 - 150, 10, 300, 50), chatText [currentLine] + "\nPress T to Advance Text");
	}

	void OnTriggerStay(Collider other)
	{
	    // When we're in constant contact with the player
		if (other.gameObject.tag == "Player")
		{
		    // We are now in the player's bounds
			inBounds = true;
			
			// If the player presses T
			if(Input.GetKeyDown(KeyCode.T))
			{
			    // Make sure we don't over-extend the dialogue
				if(currentLine < chatText.Count - 1)
				{
				    // increment the position in the NPC's dialogue
					currentLine++;
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
	    // If we stop colliding with the player
		if(other.gameObject.tag=="Player")
		{
		    // We are no longer in bounds
			inBounds=false;
			
			// If we are supposed to reset the speech position when leaving bounds
			if(resetSpeech)
			{
			    // Reset the speech position in dialogue
				currentLine=0;
			}
		}
	}
}
