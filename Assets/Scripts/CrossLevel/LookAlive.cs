using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAlive : MonoBehaviour {

    private const float TAU = Mathf.PI * 2.0f;
    private const float degree_to_radian = TAU / 360.0f;

    public enum FunctionType
    {
        Off,
        Theta,
        Cos,
        Sin
    };

    public FunctionType x_rot_func = FunctionType.Off;
    public FunctionType y_rot_func = FunctionType.Off;
    public FunctionType z_rot_func = FunctionType.Off;
    public Vector3 rot_freq = Vector3.zero;
    public Vector3 rot_amplitude = Vector3.zero;
    public Vector3 rot_phase = Vector3.zero;

    public FunctionType x_pos_func = FunctionType.Off;
    public FunctionType y_pos_func = FunctionType.Off;
    public FunctionType z_pos_func = FunctionType.Off;
    public Vector3 pos_freq = Vector3.zero;
    public Vector3 pos_amplitude = Vector3.zero;
    public Vector3 pos_phase = Vector3.zero;

    private Vector3 offset_last;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        offset_last = Vector3.zero;
        rb = gameObject.GetComponent<Rigidbody>();
        if (rb == null) Debug.Log(gameObject.name + " does not have a Rigidbody attached");
    }

    //Update is called every frame
    void Update()
    {
        // Move the transform of the game object, taking into account the time elapsed since last frame.
        Vector3 offset = Vector3.zero;

        if (x_pos_func != FunctionType.Off)
            offset.x = look_alive_function(x_pos_func, pos_freq.x, pos_phase.x, pos_amplitude.x);
        if (y_pos_func != FunctionType.Off)
            offset.y = look_alive_function(y_pos_func, pos_freq.y, pos_phase.y, pos_amplitude.y);
        if (z_pos_func != FunctionType.Off)
            offset.z = look_alive_function(z_pos_func, pos_freq.z, pos_phase.z, pos_amplitude.z);

        //transform.position = transform.position + offset - offset_last;
        if (rb != null) rb.MovePosition(transform.position + offset - offset_last);

        offset_last = offset;

        // Rotate the transform of the game object, taking into account the time elapsed since last frame.
        Vector3 rotation = Vector3.zero;

        if (x_rot_func != FunctionType.Off)
            rotation.x = look_alive_function(x_rot_func, rot_freq.x, rot_phase.x, rot_amplitude.x);
        if (y_rot_func != FunctionType.Off)
            rotation.y = look_alive_function(y_rot_func, rot_freq.y, rot_phase.y, rot_amplitude.y);
        if (z_rot_func != FunctionType.Off)
            rotation.z = look_alive_function(z_rot_func, rot_freq.z, rot_phase.z, rot_amplitude.z);

        transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        //if (rb2d != null) rb2d.MoveRotation(rotation.z);  // This doesn't work on 3D rigidbodies (need to fix)

        //Debug.Log(theta_z.ToString());
    }
    private float look_alive_function(FunctionType func, float freq, float phase, float amplitude)
    {
        float theta_rad = (Time.time * TAU) * freq + phase;
        float result = 0;

        switch (func)
        {
            case FunctionType.Off:
                break;
            case FunctionType.Theta:
                result = amplitude * theta_rad;
                break;
            case FunctionType.Sin:
                result = amplitude * Mathf.Sin(theta_rad);
                break;
            case FunctionType.Cos:
                result = amplitude * Mathf.Cos(theta_rad);
                break;
        }
        return result;
    }
}
