using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class videoControl : MonoBehaviour
{
	public GameObject playPauseButton;
	public Slider frameSlider;
	public Sprite play;
	public Sprite pause;
	private long newFrame;
	private bool isDraging;
	public Text timeText;

    // Start is called before the first frame update
    void Start()
    {
		var vp = GetComponent<UnityEngine.Video.VideoPlayer>();
		vp.SetDirectAudioVolume(0,1);
    }

    // Update is called once per frame
    void Update()
    {
		var vp = GetComponent<UnityEngine.Video.VideoPlayer>();
		var sliderValue = vp.frame / (float)vp.frameCount;

		if (vp.isPlaying)
		{	if (!isDraging) {
				//var sliderValue = vp.frame / (float)vp.frameCount;
				frameSlider.SetValueWithoutNotify((float)sliderValue);

				float timer = vp.frame / 29.7f;
				float frameCount  = vp.frameCount / 29.7f;
				int minutes = Mathf.FloorToInt(timer / 60F);
				int seconds = Mathf.FloorToInt(timer - minutes * 60);
				string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
				
				int minutesTotal = Mathf.FloorToInt(frameCount / 60F);
				int secondsTotal = Mathf.FloorToInt(frameCount - minutesTotal * 60);
				string niceTimeTotal = string.Format("{0:0}:{1:00}", minutesTotal, secondsTotal);
				timeText.text = niceTime+ " / "+ niceTimeTotal;

			}
			
			playPauseButton.GetComponent<Image>().sprite = pause;
		}
		else
		{
			playPauseButton.GetComponent<Image>().sprite = play;

		}



    }

	public void setVolume(float volume)
	{	var vp = GetComponent<UnityEngine.Video.VideoPlayer>();
		vp.SetDirectAudioVolume(0,volume);
		//Debug.Log(vp.GetDirectAudioVolume(0));


	}

	public void setFrame(float sliderFrame)
	{	

		var vp = GetComponent<UnityEngine.Video.VideoPlayer>();

		var frame = sliderFrame * vp.frameCount;
		vp.frame = (long)frame;

		float timer = frame / 29.7f;
		int minutes = Mathf.FloorToInt(timer / 60F);
		int seconds = Mathf.FloorToInt(timer - minutes * 60);
		string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
		
		float frameCount  = vp.frameCount / 29.7f;
		int minutesTotal = Mathf.FloorToInt(frameCount / 60F);
		int secondsTotal = Mathf.FloorToInt(frameCount - minutesTotal * 60);
		string niceTimeTotal = string.Format("{0:0}:{1:00}", minutesTotal, secondsTotal);
		timeText.text = niceTime+ " / "+ niceTimeTotal;

		Debug.Log(niceTime+ " / "+ niceTimeTotal);
		
		
	}

	public void isScrubing (bool isDrag){
		isDraging = isDrag;
		var vp = GetComponent<UnityEngine.Video.VideoPlayer>();
		if (isDrag) {
			vp.Pause ();
		} else {
			vp.Play();
		}
	}

	public void playPause()
	{

		var vp = GetComponent<UnityEngine.Video.VideoPlayer>();
		if (vp.isPlaying)
		{
			vp.Pause();
		
		}
		else
		{
			vp.Play();

		}
	}
}
