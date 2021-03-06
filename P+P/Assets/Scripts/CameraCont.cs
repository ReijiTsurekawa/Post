﻿//http://www2.gyafuuuun.com/2016/03/%E3%82%AD%E3%83%A3%E3%83%A9%E3%82%AF%E3%82%BF%E8%BF%BD%E5%BE%93%E3%81%99%E3%82%8B%E3%82%AB%E3%83%A1%E3%83%A9%E3%81%AE%E8%A9%B1/

using UnityEngine;
using System.Collections;

public class CameraCont : MonoBehaviour
{

    private float distance;
    private float cameraHeight;
    private float yRotate;

    public GameObject target;
    public float followSpeed = 5;
    public int cameraAngle = 20;


    // Use this for initialization
    void Start()
    {
        //平面(X,Z)での距離を取得
        distance = Vector3.Distance(
            new Vector3(target.transform.position.x, 0, target.transform.position.z),
            new Vector3(transform.position.x, 0, transform.position.z));

        //カメラの高さの差分を取得
        cameraHeight = transform.position.y - target.transform.position.y;
    }

    void LateUpdate()
    {
        //カメラの位置を高さだけ、ターゲットに合わせて作成
        var current = new Vector3(
            transform.position.x,
            target.transform.position.y,
            transform.position.z
        );

        //チェック用の位置情報を作成(バックした時にカメラが引けるようにdistance分位置を後ろにずらす)
        var checkCurrent = current + Vector3.Normalize(current - target.transform.position) * distance;

        //カメラが到達すべきポイントを計算（もともとのターゲットとの差分から計算します）
        var v = Vector3.MoveTowards(
            target.transform.position,
            checkCurrent,
            distance);

        //カメラ位置移動(位置計算後にカメラの高さを修正）
        transform.position = Vector3.Lerp(
            current,
            v,
            Time.deltaTime * followSpeed
        ) + new Vector3(0, cameraHeight, 0);

        //カメラの角度を調整
        var newRotation = Quaternion.LookRotation(target.transform.position - transform.position).eulerAngles;
        newRotation.x = cameraAngle;
        newRotation.z = 0;
        transform.rotation = Quaternion.Euler(newRotation);
    }

}