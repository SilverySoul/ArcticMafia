using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class BulletBehavior : MonoBehaviour
	{
		public float AttackRange { get; set; }

		[SerializeField]
		private float speed = 1.0f;
		public float Speed
		{
			get
			{
				return speed;
			}
		}

		private Vector3 StartPos { get; set; }

		[SerializeField]
		private float offset_y = 1.5f;

		// Use this for initialization
		void Start()
		{
			this.transform.position += new Vector3(0, offset_y, 0);
		}

		// Update is called once per frame
		void Update()
		{
			this.transform.position += this.transform.forward * Speed * Time.deltaTime;
			var v = StartPos - this.transform.position;
			if (v.sqrMagnitude > AttackRange * AttackRange)
			{
				Destroy(this.gameObject);
			}
		}

		private void OnTriggerEnter(Collider collision)
		{
			if(collision.gameObject.tag == "SeaRion")
			{
				var n = collision.gameObject.GetComponent<SeaRion>();
				if (!n) return;
				n.Damage(1);
				Destroy(this.gameObject);
			}
		}
	}
}