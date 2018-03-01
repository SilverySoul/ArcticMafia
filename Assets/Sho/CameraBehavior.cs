using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class CameraBehavior : MonoBehaviour
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private Vector3 offset;
		[SerializeField]
		private float dist = 10.0f;
		[SerializeField]
		private Vector3 lookat_offset;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void LateUpdate()
		{
			this.transform.position = target.transform.position + offset - target.transform.forward * dist;
			this.transform.LookAt(target.transform.position + lookat_offset);
		}
	}
}