using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This is a vey simple script to draw a line between two points. Simple? Nah, let me add a twist.
Now, what if you want a Bezeir curve. Wait, what? Yes. There are three bezier curves.
1. Linear Bezier Curve 		- B(t) = P0 + t(P1 – P0) = (1-t) P0 + tP1 , 0 < t < 1
2. Quadratic Bezier Curve	- B(t) = (1-t)2P0 + 2(1-t)tP1 + t2P2 , 0 < t < 1
3. Cubic Bezier Curve		- B(t) = (1-t)3P0 + 3(1-t)2tP1 + 3(1-t)t2P2 + t3P3 , 0 < t < 1
 */

public class SBezierPoints {

	//This is to define the type
	public enum BezierType {
		Linear = 2,
		Quadratic = 3,
		Cubic = 4
	}

	//These are vertex points for line renderer 
	public static int _linePoints = 50;

	//Minimum vertex points
	public static int _minimumLinePoints = 10;


	//---------------------------------------------------------------------- DRAW ------------------------------------------------------------------------//

	public static List<Vector3> DrawBezierCurve(Vector3[] _vectors, BezierType _beziertype, int _xpoints = 50) {															
		 //DRAW BEZIER CURVE
		if(_vectors.Length == (int)_beziertype) {
			int _points = (_xpoints < _minimumLinePoints) ? _xpoints : _linePoints; 
			//Now, the reason why we start from 1 is because the dividend should not be 0.
			/*As the line position is with respect to time. i.e 1. So, the computation becomes smooth*/ 
			List<Vector3> positions = new List<Vector3>();
			for (int i=1; i<=_points; i++) {
				float t = i/(float)_points;
				//Add points
				if(_vectors.Length == 2) 
					positions.Add(CalculateLinearBezierPoint(t,_vectors[0],_vectors[1]));
				else if(_vectors.Length == 3)
					positions.Add(CalculateQuadraticBezierPoint(t,_vectors[0],_vectors[1], _vectors[2]));
				else
					positions.Add(CalculateCubicBezierPoint(t,_vectors[0],_vectors[1], _vectors[2],_vectors[3]));
			}
			return positions;

		}else {
			Debug.Log("Please check the points");
			return new List<Vector3>();
		}
	}

	public static List<Vector3> DrawLinearBezierCurve(Vector3 _p1, Vector3 _p2, int _xpoints = 50) {
		//DRAW LINEAR BEZIER CURVE
		int _points = (_xpoints < _minimumLinePoints) ? _xpoints : _linePoints;
		List<Vector3> positions = new List<Vector3>();
		for (int i=1; i<=_points; i++) {
			float t = i/(float)_points;
			positions.Add(CalculateLinearBezierPoint(t,_p1, _p2));
		}
		return positions;
	}

	public static List<Vector3> DrawQuadraticBezierCurve(Vector3 _p1, Vector3 _p2, Vector3 _p3, int _xpoints = 50) {
		//DRAW QUADRATIC BEZIER CURVE
		int _points = (_xpoints < _minimumLinePoints) ? _xpoints : _linePoints;
		List<Vector3> positions = new List<Vector3>();
		for (int i=1; i<=_points; i++) {
			float t = i/(float)_points;
			//Add points
			positions.Add(CalculateQuadraticBezierPoint(t,_p1, _p2, _p3));
		}
		return positions;
	}
	
	public static List<Vector3> DrawCubicBezierCurve(Vector3 _p1, Vector3 _p2, Vector3 _p3, Vector3 _p4, int _xpoints = 50) {
		//DRAW CUBIC BEZIER CURVE
		int _points = (_xpoints < _minimumLinePoints) ? _xpoints : _linePoints;
		List<Vector3> positions = new List<Vector3>();
		for (int i=1; i<=_points; i++) {
			float t = i/(float)_points;
			//Add points
			positions.Add(CalculateQuadraticBezierPoint(t,_p1, _p2, _p3));
		}
		return positions;
	}

	//---------------------------------------------------------------------- COMPUTE -----------------------------------------------------------------------//
	
	public static Vector3 CalculateLinearBezierPoint(float t, Vector3 p0, Vector3 p1) {
		//COMPUTE LINEAR BEZIER CURVE
		/*This function calculates points line with respect to time. So, there is a start point and an end point. And taking them in the picture we draw a line.*/
		return p0 + t * (p1 - p0);	//This is the formula for line Bezier curve
	}

	
	public static Vector3 CalculateQuadraticBezierPoint(float _time, Vector3 p0, Vector3 p1, Vector3 p2) {
		//COMPUTE QUADRATIC BEZIER CURVE
		/*This function calculates points line with respect to time. So, there is a start point and an end point. And taking them in the picture we draw a line.*/
		float u = 1 - _time;
        float tt = _time * _time;
        float uu = u * u;
        Vector3 p = uu * p0 + 2 * u * _time * p1 + tt * p2;
        return p;
	}

	
	public static Vector3 CalculateCubicBezierPoint(float _time, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3) {
		//COMPUTE QUADRATIC BEZIER CURVE
		float u = 1 -_time;
		float tt = _time*_time;
		float uu = u*u;
		float uuu = uu*u;
		float ttt = tt*_time;
		Vector3 p = uuu * p0;
		p+= 3 * uu * _time *p1;
		p+= 3 * u * tt * p2;
		p+= ttt * p3;
		return p;
	}

	
}
