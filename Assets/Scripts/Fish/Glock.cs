using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glock : MonoBehaviour {
    public Transform top;
    public AnimationCurve fireCurve;
    public float fireDuration;
    public Vector3 fireOffset = new Vector3(0, 0, -0.1f);
    Coroutine fireRoutine;
    public ParticleSystem casings;

    public Transform muzzleFlash;
    Material m;

    Vector3 startOffset;
    float startAngle;
    float angle;

    public bool offhand;

    // Start is called before the first frame update
    void Start() {
        startOffset = top.localPosition;
        startAngle = transform.localEulerAngles.x;
        m = muzzleFlash.GetComponent<Renderer>().material;
        m.SetFloat("_Dissolve", 0);
    }

    // Update is called once per frame
    void Update() {
        top.localPosition = Vector3.Lerp(top.localPosition, startOffset, Time.deltaTime * 10);
        angle = Mathf.Lerp(angle, startAngle, Time.deltaTime * 10);
        transform.localEulerAngles = new Vector3(angle, 0, 0);

        if (Input.GetButtonDown("Fire1") && !offhand) {
            Fire();
        }
        if (Input.GetButtonDown("Fire2") && offhand) {
            Fire();
        }
    }

    public void Fire() {
        if (fireRoutine != null) {
            StopCoroutine(fireRoutine);
        }
        top.localPosition = fireOffset;
        angle = startAngle - 10;
        casings.Emit(1);
        fireRoutine = StartCoroutine(FireRoutine());
    }

    IEnumerator FireRoutine() {
        float start = Time.realtimeSinceStartup;
        float perc;
        do {
            perc = Mathf.Clamp01((Time.realtimeSinceStartup - start) / fireDuration);
            m.SetFloat("_Dissolve", Mathf.Lerp(0, 1, fireCurve.Evaluate(perc)));
            // top.localPosition = Vector3.Lerp(startOffset, fireOffset, fireCurve.Evaluate(perc));
            yield return null;
        }
        while (perc < 1);
        m.SetFloat("_Dissolve", Mathf.Lerp(0, 1, fireCurve.Evaluate(1)));
        // top.localPosition = Vector3.Lerp(startOffset, fireOffset, fireCurve.Evaluate(1));
        fireRoutine = null;
    }

    private void OnDestroy() {
        Destroy(m);
    }
}