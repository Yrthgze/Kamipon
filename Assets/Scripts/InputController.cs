using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Quadrant
{
    HighLeftQuadrant = 0,
    HighRightQuadrant = 1,
    LowLeftQuadrant = 2,
    LowRightQuadrant = 3
}
public class InputController : MonoBehaviour
{
    private AudioClip[] a_audio_clips = new AudioClip[4];
    public Camera c_camera;
    private float f_screen_height, f_screen_width, f_screen_mid_height, f_screen_mid_width;
    public AudioClip c_audio_clip_ka, c_audio_clip_mi, c_audio_clip_po, c_audio_clip_n;
    private AudioSource c_as_audio_player;
    private List<Quadrant> l_e_quadrants = new List<Quadrant>();

    // Start is called before the first frame update
    void Start()
    {
        f_screen_height = Screen.height;
        f_screen_width = Screen.width;
        f_screen_mid_height = f_screen_height / 2;
        f_screen_mid_width = f_screen_width / 2;
        c_as_audio_player = GetComponent<AudioSource>();
        a_audio_clips[0] = c_audio_clip_ka;
        a_audio_clips[1] = c_audio_clip_mi;
        a_audio_clips[2] = c_audio_clip_po;
        a_audio_clips[3] = c_audio_clip_n;
    }

    Quadrant GetQuadrantClicked(float f_width, float f_height)
    {
        Quadrant e_quadrant = Quadrant.LowLeftQuadrant;
        if (f_width <= f_screen_mid_width)
        {
            if(f_height > f_screen_mid_height)
            {
                e_quadrant = Quadrant.HighLeftQuadrant;
            }
            //! Otherwise, LowLeftQuadrant. As it is default case, it is not necessary
        }
        else
        {
            if (f_height > f_screen_mid_height)
            {
                e_quadrant = Quadrant.HighRightQuadrant;
            }
            else
            {
                e_quadrant = Quadrant.LowRightQuadrant;
            }
        }
        Debug.Log("quadrant: " + e_quadrant);
        return e_quadrant;
    }

    bool CheckIfAnthemIsValid()
    {
        if(l_e_quadrants.Count >= 4)
        {
            return true;
        }
        return false;
    }
    void PlayQuadrant(Quadrant e_quadrant)
    {
        l_e_quadrants.Add(e_quadrant);
        if(CheckIfAnthemIsValid())
        {
            
        }
        c_as_audio_player.PlayOneShot(a_audio_clips[(int)e_quadrant]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Quadrant e_quadrant = GetQuadrantClicked(Input.mousePosition.x, Input.mousePosition.y);
            PlayQuadrant(e_quadrant);
        }
    }
}
