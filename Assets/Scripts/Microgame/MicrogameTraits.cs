﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MicrogameTraits : MonoBehaviour
{
	[SerializeField]
	private ControlScheme _controlScheme;
	public virtual ControlScheme controlScheme { get { return _controlScheme; } set { } }

	[SerializeField]
	private bool _hideCursor;
	public virtual bool hideCursor { get { return _hideCursor; } set { } }

	[SerializeField]
	private Duration _duration;
	public virtual Duration duration { get { return _duration; } set { } }

	[SerializeField]
	private bool _canEndEarly;
	public virtual bool canEndEarly { get { return _canEndEarly; } set { } }

	[SerializeField]
	private string _command;
	public virtual string command { get { return TextHelper.getLocalizedText("microgame." + microgameId + ".command", _command); } set { } }

	[SerializeField]
	private bool _defaultVictory;
	public virtual bool defaultVictory { get { return _defaultVictory; } set { } }

	[SerializeField]
	private float _victoryVoiceDelay, _failureVoiceDelay;
	public virtual float victoryVoiceDelay { get { return _victoryVoiceDelay; } set { } }
	public virtual float failureVoiceDelay { get { return _failureVoiceDelay; } set { } }

	[SerializeField]
	private AudioClip _musicClip;
	public virtual AudioClip musicClip{ get { return _musicClip; } set { } }


	private string microgameId;

	public enum ControlScheme
	{
		Key,
		Mouse
	}

	public enum Duration
	{
		Short8Beats,
		Long16Beats
	}

	public virtual void onAccessInStage(string microgameId)
	{
		this.microgameId = microgameId;
	}

	public float getDurationInBeats()
	{
		return duration == Duration.Short8Beats ? 8f : 16f;
	}

	public static MicrogameTraits findMicrogameTraits(string microgameId, int difficulty)
	{
		GameObject traits = Resources.Load<GameObject>("Microgames/_Finished/" + microgameId + "/Traits" + difficulty.ToString());
		if (traits != null)
			return traits.GetComponent<MicrogameTraits>();

		traits = Resources.Load<GameObject>("Microgames/" + microgameId + "/Traits" + difficulty.ToString());
		if (traits != null)
			return traits.GetComponent<MicrogameTraits>();

		traits = Resources.Load<GameObject>("Microgames/_Bosses/" + microgameId + "/Traits" + difficulty.ToString());
		if (traits != null)
			return traits.GetComponent<MicrogameTraits>();

		Debug.LogError("Can't find Traits prefab for " + microgameId + difficulty.ToString());
		return null;
	}
}