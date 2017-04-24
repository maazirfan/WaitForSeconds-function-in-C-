using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class lerp : MonoBehaviour {

	public Transform[] path;
	public float speed = 5.0f;
	public float reachDist = 1.0f;
	public int currentPoint = 0;
	public GameObject SelectionPanel;
	public	bool start;
	public AudioSource Playbtn;
	public AudioSource AlertSound;
	public UI skybx;


	private float timer;
	public Image _timerRef;
	public int startTime = 3;
	public Text timerText;
	public bool entered;





	private bool alreadyWaiting = false;
	private bool alreadyWaitingTwo = false;






	// Use this for initialization
	void Start () {
		start = false;



			}






// Update is called once per frame
	void Update () {
		
		if (start == true) {

			Vector3 dir =   path [currentPoint].position - transform.position ;
			transform.position += dir * Time.deltaTime * speed;

			if (dir.magnitude <= reachDist)
			{
				currentPoint++;

			}


			if (currentPoint == 3 && !alreadyWaiting) 
			{
				entered = true;
				StartCoroutine ("Wait");     


				//added extra code for testing
				timer -= Time.deltaTime;
				timerText.text = timer.ToString ("00");
				_timerRef.fillAmount = timer * 0.1f;
				if (timer <= 0) 
				{
					timer = startTime;
					entered = false;
				}

			} 
		


			if (currentPoint == 5 && !alreadyWaitingTwo)
			{
				StartCoroutine("WaitTwo");
			}



			if(currentPoint>=path.Length)
			{
 		
				currentPoint = 11;


			}

		}



	 


	}


IEnumerator	 Wait()
	{
		
		
			start = false;
			alreadyWaiting = true;
			yield return new WaitForSeconds (10f);
		print (start);

		start = true;
		print (Time.time);


			alreadyWaiting = true;

		AlertSound.Play ();

	}

	IEnumerator	 WaitTwo()
	{


		start = false;
		alreadyWaitingTwo = true;
		yield return new WaitForSeconds (10f);
		print (start);

		start = true;
		print (Time.time);


		alreadyWaitingTwo = true;

		AlertSound.Play ();

	}





	void OnDrawGizmos()
	{
		if(path.Length > 0)
			for (int i = 0; i < path.Length; i++) 
			{
				if(path[i] !=null)
				{
					Gizmos.DrawSphere(path[i].position,reachDist);
				}
			}
	}




	public void locationChngBtn()
	{		
		Playbtn.Play ();
				start = true;
				SelectionPanel.SetActive (false);

			skybx.RotateBtn = false;
		
		//skybx.RotateBtn = false;

	}







	public void locationbtn()
	{
		if (currentPoint == path.Length) 
		{
			start = true;
		}
	}
	}

