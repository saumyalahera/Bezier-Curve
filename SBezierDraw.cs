using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBezierDraw : MonoBehaviour {

	//LINE RENDERER 
	public LineRenderer lineRenderer;

	//SBezierPoints
	//public SBezierPoints bezier;

	//TESTER
	public Transform hand1, hand2;
	void saumya(Vector3 _sp, Vector3 _ep) {
		
		var sp= _sp;					//rightHand.localPosition;
        var ep= _ep;					//leftHand.localPosition;
        var heightK=5f;                 //Throw height
        var z=0f;                       //z constant

        var pkh=1;                      //x Pass constant
        var pkw=2;                      //y pass constant


        var p1 = sp;
        var p2 = new Vector3((sp.x+ep.x)/2,heightK,z);
        var p3 = ep;
        var p4 = new Vector3((p3.x-(pkw/2)),p3.y-pkh,z);
        var p5 = new Vector3((p3.x-pkw),p3.y, z);

        var p7 = new Vector3((p1.x-pkw),p1.y,z);
        var p6 = new Vector3((p5.x+p7.x)/2, heightK ,z);
        var p8 = new Vector3((p1.x-(pkw/2)),p1.y-pkh,z);

		SBezierCurve saumya = new SBezierCurve();
		
		var _points = 50;
		var pts1 = SBezierPoints.DrawQuadraticBezierCurve(p1,p2,p3,_points); //SaumyaBezierHelper.//DrawQuadraticCurve(p1,p2,p3,_points);
		var pts2 = SBezierPoints.DrawQuadraticBezierCurve(p3,p4,p5,_points);
		var pts3 = SBezierPoints.DrawQuadraticBezierCurve(p5,p6,p7,_points);
		var pts4 = SBezierPoints.DrawQuadraticBezierCurve(p7,p8,p1,_points);
		


		var spline = new List<Vector3>();
		spline.AddRange(pts1);
		spline.AddRange(pts2);
		spline.AddRange(pts3);
		spline.AddRange(pts4);

		Debug.Log("Number of points to be drawn : "+spline.Count);
		DrawLineRenderer(spline.ToArray());
	}
	//TESTER ENDS

	
	//---------------------------------------------------------------------- DELEGATES ------------------------------------------------------------------------//
	void Start() {
		//TESTER
		setupLineRenderer(Color.white, 0.1f);
		//TESTER ENDS
	}

	void Update () {
		//TESTER
			saumya(hand1.transform.localPosition,hand2.transform.localPosition);
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
