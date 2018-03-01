using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class GunBehavior : Internal.PenguinBehavior
	{

        public AudioPenguinScript SoundScript;

		private float shot_dist = 5.0f;

		private Coroutine attack = null;


		// Use this for initialization
		void Start()
		{
			Target = GameObject.Find("SeaRion");
			Parent.Type = PenguinManager.PenguinType.Gun;
		}

		// Update is called once per frame
		void Update()
		{
			shot_dist = Storage.GunsAttackRange;

			var v = Target.transform.position - this.transform.position;
			if (v.magnitude > shot_dist)
			{
				Agent.destination = v.normalized * shot_dist + this.transform.position;
			}
			else
			{
				this.transform.LookAt(Target.transform);
				if (attack == null)
				{
					attack = StartCoroutine(Attack());
				}
			}
		}

		private void OnDestroy()
		{
			StopAllCoroutines();
		}

		IEnumerator Attack()
		{
			while (true)
			{
				yield return new WaitForSeconds(Storage.GunAttackSpan);

				// RayCastTest
				var ray = new Ray(this.transform.position, this.transform.forward);
				RaycastHit hit_info;
				if (Physics.Raycast(ray, out hit_info))
				{
                    SoundScript.PenguinShootSound();
					var n = Instantiate(Storage.BulletPrehab);
					//n.transform.LookAt(Target.transform);
					n.transform.rotation = this.transform.rotation;
					n.AttackRange = Storage.GunsAttackRange;
					n.transform.position = this.transform.position + this.transform.forward * 2;
					yield return new WaitForSeconds(Storage.GunAttackSpanToNextBullet);
					Debug.Log(hit_info.collider.gameObject.tag);
					if (hit_info.collider.gameObject.tag == "SeaRion")
					{
						for (int i = 0; i < 3; i++)
						{
                        SoundScript.PenguinShootSound();
							var n = Instantiate(Storage.BulletPrehab);
							//n.transform.LookAt(Target.transform);
							n.transform.rotation = this.transform.rotation;
							n.AttackRange = Storage.GunsAttackRange;
							n.transform.position = this.transform.position + this.transform.forward * 2;
							yield return new WaitForSeconds(Storage.GunAttackSpanToNextBullet);
						}
					}
                }
            }
		}
	}
}