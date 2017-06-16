﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WrenchBg : MonoBehaviour
{
	[SerializeField]
	private bool update;
	[SerializeField]
	private int linesX, linesY;
	[SerializeField]
	private float lineSeparation, lineExtent;
	[SerializeField]
	private Vector3 linesStart;

	private LineRenderer lineRenderer;

	//void Awake()
	//{
	//	lineRenderer = GetComponent<LineRenderer>();
	//}

	void Update()
	{
		if (update)
		{
			if (lineRenderer == null)
				lineRenderer = GetComponent<LineRenderer>();
			createLines();
			update = false;
		}
	}

	void createLines()
	{
		List<Vector3> points = new List<Vector3>();

		for (int i = 0; i < linesX; i++)
		{
			float x = linesStart.x + (lineSeparation * (float)i),
				y = i % 2 == 1 ? lineExtent : -lineExtent;
			points.Add(new Vector3(x, y, 0f));
			points.Add(new Vector3(x, -y, 0f));
		}
		for (int i = 0; i < linesY; i++)
		{
			float y = linesStart.y + (lineSeparation * (float)i),
				x = i % 2 == 1 ? lineExtent : -lineExtent;
			points.Add(new Vector3(x, y, 0f));
			points.Add(new Vector3(-x, y, 0f));
		}

		lineRenderer.numPositions = points.Count;
		lineRenderer.SetPositions(points.ToArray());
		//lineRenderer.SetPositions(new Vector3[points.Count]);
		//for (int i = 0; i < points.Count; i++)
		//{
		//	lineRenderer.SetPosition(i, points[i]);
		//}
	}
}