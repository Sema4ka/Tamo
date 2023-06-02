using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteAlways]
public class WaterShapeController : MonoBehaviour
{

    private int _corsnersCount = 2;
    [SerializeField]
    private SpriteShapeController spriteShapeController;
    [SerializeField]
    private GameObject wavePointPref;
    [SerializeField]
    private GameObject wavePoints;

    [SerializeField]
    [Range(1, 100)]
    private int _wavesCount;
    private List<WaterDrop> _springs = new();
    public float springStiffness = 0.1f;
    public float dampening = 0.03f;
    public float spread = 0.006f;

    void OnValidate()
    {
        // Clean waterpoints 
        StartCoroutine(CreateWaves());
    }
    IEnumerator CreateWaves()
    {
        foreach (Transform child in wavePoints.transform)
        {
            StartCoroutine(Destroy(child.gameObject));
        }
        yield return null;
        SetWaves();
        yield return null;
    }
    IEnumerator Destroy(GameObject go)
    {
        yield return null;
        DestroyImmediate(go);
    }
    private void SetWaves()
    {
        Spline waterSpline = spriteShapeController.spline;
        int waterPointsCount = waterSpline.GetPointCount();

        
        for (int i = _corsnersCount; i < waterPointsCount - _corsnersCount; i++)
        {
            waterSpline.RemovePointAt(_corsnersCount);
        }

        Vector3 waterTopLeftCorner = waterSpline.GetPosition(1);
        Vector3 waterTopRightCorner = waterSpline.GetPosition(2);
        float waterWidth = waterTopRightCorner.x - waterTopLeftCorner.x;

        float spacingPerWave = waterWidth / (_wavesCount + 1);
        // Set new points for the waves
        for (int i = _wavesCount; i > 0; i--)
        {
            int index = _corsnersCount;

            float xPosition = waterTopLeftCorner.x + (spacingPerWave * i);
            Vector3 wavePoint = new Vector3(xPosition, waterTopLeftCorner.y, waterTopLeftCorner.z);
            waterSpline.InsertPointAt(index, wavePoint);
            waterSpline.SetHeight(index, 0.1f);
            waterSpline.SetCorner(index, false);
            waterSpline.SetTangentMode(index, ShapeTangentMode.Continuous);

        }


        _springs = new();
        for (int i = 0; i <= _wavesCount + 1; i++)
        {
            int index = i + 1;

            Smoothen(waterSpline, index);

            GameObject wavePoint = Instantiate(wavePointPref, wavePoints.transform, false);
            wavePoint.transform.localPosition = waterSpline.GetPosition(index);

            WaterDrop waterSpring = wavePoint.GetComponent<WaterDrop>();
            waterSpring.Init(spriteShapeController);
            _springs.Add(waterSpring);

        }

    }


    private void Smoothen(Spline waterSpline, int index)
    {
        Vector3 position = waterSpline.GetPosition(index);
        Vector3 positionPrev = position;
        Vector3 positionNext = position;
        if (index > 1)
        {
            positionPrev = waterSpline.GetPosition(index - 1);
        }
        if (index - 1 <= _wavesCount)
        {
            positionNext = waterSpline.GetPosition(index + 1);
        }

        Vector3 forward = gameObject.transform.forward;

        float scale = Mathf.Min((positionNext - position).magnitude, (positionPrev - position).magnitude) * 0.33f;

        Vector3 leftTangent = (positionPrev - position).normalized * scale;
        Vector3 rightTangent = (positionNext - position).normalized * scale;

        SplineUtility.CalculateTangents(position, positionPrev, positionNext, forward, scale, out rightTangent, out leftTangent);

        waterSpline.SetLeftTangent(index, leftTangent);
        waterSpline.SetRightTangent(index, rightTangent);
    }
    void FixedUpdate()
    {
        foreach (WaterDrop waterSpringComponent in _springs)
        {
            waterSpringComponent.WaveSpringUpdate(springStiffness, dampening);
            waterSpringComponent.WavePointUpdate();
        }

        UpdateSprings();

    }

    private void UpdateSprings()
    {
        int count = _springs.Count;
        float[] left_deltas = new float[count];
        float[] right_deltas = new float[count];

        for (int i = 0; i < count; i++)
        {
            if (i > 0)
            {
                left_deltas[i] = spread * (_springs[i].height - _springs[i - 1].height);
                _springs[i - 1].velocity += left_deltas[i];
            }
            if (i < _springs.Count - 1)
            {
                right_deltas[i] = spread * (_springs[i].height - _springs[i + 1].height);
                _springs[i + 1].velocity += right_deltas[i];
            }
        }
    }
    private void Splash(int index, float speed)
    {
        if (index >= 0 && index < _springs.Count)
        {
            _springs[index].velocity += speed;
        }
    }
}