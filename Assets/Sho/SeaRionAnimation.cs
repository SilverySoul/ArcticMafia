using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class SeaRionAnimation : MonoBehaviour
	{
		private float Timer { get; set; }
		[SerializeField]
		private float amplitude = 10.0f;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void LateUpdate()
		{
			Timer += Time.deltaTime;
			var p = this.transform.rotation.eulerAngles;
			p.x += Mathf.Sin(Timer) * amplitude;
			this.transform.rotation = Quaternion.Euler(p);
		}
	}
}