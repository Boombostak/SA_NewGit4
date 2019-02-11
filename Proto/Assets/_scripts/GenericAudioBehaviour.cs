using UnityEngine;
using System.Collections;
using System;

public enum repeatOptions
{
	Daily=0,
	Weekly=1,
	Monthly=2,
	Yearly=3,
	NoRepeat=4
}

public class GenericAudioBehaviour : MonoBehaviour {

	//calendars are updated by SimpleCalendar

	public GameObject sun;
	public GameObject moon;
	public bool sunBelowHorizon;
	public bool moonBelowHorizon;
	public TOD_Sky sky;
	public DateTime gregorianDateTime;
	public string gregorianDateTimeString;
	public DateTime hijriDateTime;
	public string hijriDateTimeString;
	public bool useHijri;
	public DateTime targetDateTime;
	public bool clipHasPlayed;
	public bool repeatDaily;
	public bool repeatWeekly;
	public bool repeatMonthly;
	public bool repeatYearly;
	public bool noRepeat;
	public repeatOptions repeatType;
	//public ReverNodeZoneDetectorForListener RNZDFL;
	//public AudioLowPassFilter filter;
	//public AudioSource[] sourcesToMute;

	//public bool fadeOutOtherSound = false;
	//public float fadeTime;

	/*Tracks and allows triggering based on
	 * Sun angle
	 * Moon Angle
	 * Moonvisibility(?)
	 * DateTime (day of year, day of month, day of week, hour)
	 * Conditional relationships between all
	*/

	// Use this for initialization
	void Start () {
		//filter = this.GetComponent<AudioLowPassFilter> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Determine which reverb zones to use and apply lowpass filter.
		/*
		if (RNZDFL == null) {
			RNZDFL = GameObject.FindObjectOfType<ReverNodeZoneDetectorForListener> ();
		}
		if (RNZDFL.playerIsInside) {
			filter.enabled = true;
		} else {
			filter.enabled = false;
		}
		*/

		//is the sun above horizon?
		if (sun.transform.position.y < -3) {
			sunBelowHorizon = true;
		} else {
			sunBelowHorizon = false;
		}

		//is the moon above horizon?
		if (moon.transform.position.y < -3) {
			moonBelowHorizon = true;
		} else {
			moonBelowHorizon = false;
		}

		//Playback Logic
		if (!useHijri) { //ie. Gregorian
			if (targetDateTime>gregorianDateTime && noRepeat && !clipHasPlayed) {
				PlaySound ();
				clipHasPlayed = true;
			}
			if (targetDateTime>gregorianDateTime && repeatDaily && !clipHasPlayed) {
				PlaySound ();
				clipHasPlayed = true;
				targetDateTime = targetDateTime.AddDays (1);
				clipHasPlayed = false;
			}
			if (targetDateTime>gregorianDateTime && repeatWeekly && !clipHasPlayed) {
				PlaySound ();
				clipHasPlayed = true;
				targetDateTime = targetDateTime.AddDays(7);
				clipHasPlayed = false;
			}
			if (targetDateTime>gregorianDateTime && repeatMonthly && !clipHasPlayed) {
				PlaySound ();
				clipHasPlayed = true;
				targetDateTime = targetDateTime.AddMonths (1);
				clipHasPlayed = false;
			}
			if (targetDateTime>gregorianDateTime && repeatYearly && !clipHasPlayed) {
				PlaySound ();
				clipHasPlayed = true;
				targetDateTime = targetDateTime.AddYears (1);
				clipHasPlayed = false;
			}
		}
		if (useHijri) { //ie. Hijri
			if (targetDateTime>hijriDateTime && noRepeat && !clipHasPlayed) {
				PlaySound ();
				clipHasPlayed = true;
			}
			if (targetDateTime>hijriDateTime && repeatDaily && !clipHasPlayed) {
				PlaySound ();
				clipHasPlayed = true;
				targetDateTime = targetDateTime.AddDays (1);
				clipHasPlayed = false;
			}
			if (targetDateTime>hijriDateTime && repeatWeekly && !clipHasPlayed) {
				PlaySound ();
				clipHasPlayed = true;
				targetDateTime = targetDateTime.AddDays(7);
				clipHasPlayed = false;
			}
			if (targetDateTime>hijriDateTime && repeatMonthly && !clipHasPlayed) {
				PlaySound ();
				clipHasPlayed = true;
				targetDateTime = targetDateTime.AddMonths (1);
				clipHasPlayed = false;
			}
			if (targetDateTime>hijriDateTime && repeatYearly && !clipHasPlayed) {
				PlaySound ();
				clipHasPlayed = true;
				targetDateTime = targetDateTime.AddYears (1);
				clipHasPlayed = false;
			}
		}
	}

	public void SetRepeatType(repeatOptions repeatType){
		switch (repeatType) {
		case repeatOptions.Daily:
			repeatDaily = true;
			repeatWeekly = false;
			repeatMonthly = false;
			repeatYearly = false;
			noRepeat = false;
			break;
		case repeatOptions.Weekly:
			repeatDaily = false;
			repeatWeekly = true;
			repeatMonthly = false;
			repeatYearly = false;
			noRepeat = false;
			break;
		case repeatOptions.Monthly:
			repeatDaily = false;
			repeatWeekly = false;
			repeatMonthly = true;
			repeatYearly = false;
			noRepeat = false;
			break;
		case repeatOptions.Yearly:
			repeatDaily = false;
			repeatWeekly = false;
			repeatMonthly = false;
			repeatYearly = true;
			noRepeat = false;
			break;
		case repeatOptions.NoRepeat:
			repeatDaily = false;
			repeatWeekly = false;
			repeatMonthly = false;
			repeatYearly = false;
			noRepeat = true;
			break;
		default:
			Debug.Log ("Unrecognized option in SetRepeatType");
			break;
		}
	}

	public void PlaySound(){
	}
}
