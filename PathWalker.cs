using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PathWalker : MonoBehaviour {

	public List<Vector3> nodeList = new List<Vector3>();
	private Queue<Vector3> nodeQueue;
	public float playerSpeed = 10.0f;
	private Vector3 currentNode;
	private Vector3 prevNode;
	private int waveTimer;
	private Animator animator;
	private const int WaveTime = 2500;
	private float progress = 0.0f;
	private NPC npcScript;
	// Use this for initialization
	void Start ()
	{
		animator = this.gameObject.GetComponent<Animator> ();
		nodeQueue = new Queue<Vector3> (nodeList);
		prevNode = this.transform.position;
		npcScript = this.gameObject.GetComponent<NPC> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!npcScript.inBounds)
		{
			if(waveTimer == -1)
			{
				progress += 0.1f/playerSpeed * Time.deltaTime;
				currentNode = nodeQueue.Peek ();
				Debug.Log(currentNode);
	
				this.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(this.transform.forward, nodeQueue.Peek () - transform.position, Mathf.PI/6.0f * Time.deltaTime, 0.0f));
	
				animator.SetFloat ("speed", 2);
				if(progress > 1.0f)
				{
					nodeQueue.Enqueue (nodeQueue.Dequeue ());
			    	this.waveTimer = 0;
					this.progress = 0;
					prevNode = currentNode;
				}
				this.transform.position = Vector3.Lerp(prevNode, currentNode, progress);
	    	}
			else if(waveTimer < WaveTime)
			{
				animator.SetFloat("speed", 0);
				waveTimer+=(int)(Time.deltaTime*1000);
			}
			else
			{
				waveTimer = -1;
			}
		}
		else
		{
			this.transform.rotation = Quaternion.LookRotation (Vector3.RotateTowards(this.transform.forward, GameObject.FindGameObjectWithTag("Player").transform.position - this.transform.position, Mathf.PI/6.0f * Time.deltaTime, 0.0f));
			animator.SetFloat ("speed", 0);
		}
	}
}
