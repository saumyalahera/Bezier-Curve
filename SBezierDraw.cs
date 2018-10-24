using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBezierDraw : MonoBehaviour {

	//LINE RENDERER 
	public LineRenderer lineRenderer;

	//Two different objects
	public Transform o1,o2;

	//---------------------------------------------------------------------- DELEGATES ------------------------------------------------------------------------//
	void Start() {
		//TESTER
		setupLineRenderer(Color.white, 0.1f);
		//TESTER ENDS
	}

	void Update () {
		//TESTER
			var vectors = SBezierPoints.DrawLinearBezierCurve(o1.localPosition,o2.localPosition,50);
			DrawLineRenderer(vectors.ToArray());
		//TESTER ENDS
	}

	//---------------------------------------------------------------------- LINE RENDERER ------------------------------------------------------------------------//
	private void setupLineRenderer(Color _color, float _linewidth) {
		lineRenderer.startColor = lineRenderer.endColor = _color;
        lineRenderer.startWidth = lineRenderer.endWidth = _linewidth;
	}

	private void DrawLineRenderer(Vector3[] _vectors) {
		lineRenderer.positionCount = _vectors.Length;
		lineRenderer.SetPositions(_vectors);
	}
}
