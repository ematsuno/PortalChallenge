using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalBehavior : MonoBehaviour {

    // public
    public int loadSceneNumber;  //scenet to load
    public float transitionTime = 2f;   // amount of time for transition / fade
    public Color fadeColor;   // color of screen to fade
    public Image fadeScreen;   // image overlaying screen for the fade
    
    //private
    private bool _isTranstioning = false;     // boolean to trigger transition
    private float _timeStartedTransitioning;  // tmp var to mark beging of transition
    void Update()
    {
        if (_isTranstioning == true)
            fade();
    }
    void onCharacterPortalCollision()
    {
        startFading();
    }

    void startFading()
    {
        // triggered by colliding with portal: onCharacterPortalCollision
        _isTranstioning = true;
        _timeStartedTransitioning = Time.time;
    }
    void fade()
    {
        //starting with a clear overlaying image: fadscreen, 
        //lerp color in update increments to final color in increments 
        //  within transition time 
        Color startColor = new Color(0.0F, 0.0F, 0.0F, 0.0F);
        float timeSinceStarted = Time.time - _timeStartedTransitioning;
        float percentageComplete = timeSinceStarted / transitionTime;

        fadeScreen.color = Color.Lerp(startColor, fadeColor, percentageComplete);

        if (percentageComplete >= 1.0f)
        {
            SceneManager.LoadScene(loadSceneNumber);
        }
    }
}