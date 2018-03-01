using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class BearController : MonoBehaviour
	{
		[SerializeField]
		private float speed = 0.0f;
		public float Speed
		{
			get
			{
				return speed;
			}
		}

		[SerializeField]
		private float rotate_rate = 20.0f;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKey(KeyCode.W))
			{
				//this.transform.Translate(this.transform.forward * Speed * Time.deltaTime);
				this.transform.position += this.transform.forward * Speed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.S))
			{
				//this.transform.Translate(this.transform.forward * -Speed * Time.deltaTime);
				this.transform.position -= this.transform.forward * Speed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.A))
			{
				//this.transform.Translate(this.transform.right * -Speed * Time.deltaTime);
				this.transform.Rotate(new Vector3(0, -rotate_rate, 0) * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.D))
			{
				//this.transform.Translate(this.transform.right * Speed * Time.deltaTime);
				this.transform.Rotate(new Vector3(0, rotate_rate, 0) * Time.deltaTime);
			}
		}
	}
}