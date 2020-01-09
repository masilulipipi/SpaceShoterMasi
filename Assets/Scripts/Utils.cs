using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils   {

    public static Vector2 GetHalfDimensionsInWorldUnits()
    {
        float whith, height;

        Camera cam = Camera.main;
        float ratio = cam.pixelWidth / (float)cam.pixelHeight;
        height = cam.orthographicSize * 2;
        whith = height * ratio;

        return new Vector2(whith, height) / 2f;
    }
		
	}

