using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sho
{
	public class Cursor : MonoBehaviour
	{
		private PenguinManager Manager { get; set; }

		[SerializeField,Header("Offset of Penguin when create")]
		private float offset_height = 1.0f;

		// Use this for initialization
		void Start()
		{
			Manager = GameObject.Find("PenguinManager").GetComponent<PenguinManager>();
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				var ts = Input.mousePosition;

				ts.x = Mathf.Clamp(ts.x, 0.0f, Screen.width);
				ts.y = Mathf.Clamp(ts.y, 0.0f, Screen.height);

				var tpr = Camera.main.ScreenPointToRay(ts);

				var hit = new RaycastHit();
				if (Physics.Raycast(tpr, out hit))
				{
					if (hit.collider.gameObject.tag == "Ground")
					{
						var p = hit.point;
						p.y += offset_height;
						Manager.CreatePenguins(p);
					}
				}
			}
		}
	}
}