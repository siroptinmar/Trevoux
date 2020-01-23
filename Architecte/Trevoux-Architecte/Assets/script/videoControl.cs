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
		if (vp.isPlaying)
		{	if (!isDraging) {
				var sliderValue = vp.frame / (float)vp.frameCount;
				frameSlider.SetValueWithoutNotify((float)sliderValue);
			}
			//else {vp.frame = newFrame;}
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


		//Debug.Log(vp.GetDirectAudioVolume(0));
		
		
	}

	public void isScrubing (bool isDrag){
		isDraging = isDrag;
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
