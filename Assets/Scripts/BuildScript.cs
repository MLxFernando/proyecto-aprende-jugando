using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
public class BuildScript {
    public static void BuildAndroid() {
        string buildPath = "Builds/Android/game.apk";
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions {
            scenes = new[] { "Assets/Scenes/esena.unity" }, 
            locationPathName = buildPath,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}

