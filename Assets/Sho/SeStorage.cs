using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class SeStorage : MonoBehaviour
	{
		[SerializeField]
		private List<AudioSource> srcs = new List<AudioSource>();

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public void PlayOneShot(int index)
		{
			srcs[index].PlayOneShot(srcs[index].clip);
		}
	}
}