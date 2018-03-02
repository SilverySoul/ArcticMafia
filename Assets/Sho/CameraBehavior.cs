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
		private GameObject[] penguin;

		public bool CanStart { get; set; }

		public float Timer { get; set; }

		[SerializeField]
		private float temp = -0.02f;
		[SerializeField]
		private float rate = 0.8f;

		// Use this for initialization
		void Start()
		{
			foreach (var item in penguin)
			{
				item.SetActive(false);
			}
			Timer = temp;
		}

		// Update is called once per frame
		void Update()
		{
			if (CanStart)
			{
				if (target)
				{
					if (Timer <= 0.0f)
					{
						this.transform.position += target.transform.forward * rate;
					}
					else
					{
						this.transform.position = Vector3.Slerp(this.transform.position, target.transform.position, Timer);
						this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target.transform.rotation, Timer);
						if (Timer >= 1.0f)
						{
							Destroy(target);
							target = null;
							foreach (var item in penguin)
							{
								item.SetActive(true);
							}
						}
					}
					Timer += Time.deltaTime * 0.5f;
				}
			}
		}
	}
}