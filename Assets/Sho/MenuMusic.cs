using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class MenuMusic : MonoBehaviour
	{
		AudioSource src;

		[SerializeField]
		private CameraBehavior behavior;

		// Use this for initialization
		void Start()
		{
			src = this.GetComponent<AudioSource>();
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void OnClick()
		{
			src.Stop();
			GameObject.Find("AudioMusick").GetComponent<AudioSource>().Play();
			// sorry
			behavior.CanStart = true;
		}
	}
}