///
/// マウスのスクリーン座標をワールド座標に変換する
/// 
///
using UnityEngine;
using System.Collections;

public class MouseSynchronizeObject : MonoBehaviour
{
	// 位置座標
	Vector3 position;
	// スクリーン座標をワールド座標に変換した位置座標
	Vector3 screenToWorldPointPosition;
	//衝突検知する最大距離
	[SerializeField] float maxRange = 1000f;
	//衝突位置の位置調整
	[SerializeField] Vector3 adjustPosition = new Vector3(0, 1, 0);
	void Update()
	{
		// Vector3でマウス位置座標を取得する
		position = Input.mousePosition;
		// Z軸修正
		position.z = 10f;
		// マウス位置座標をスクリーン座標からワールド座標に変換する
		screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
		//カメラの位置取得
		var camerapos = Camera.main.transform.position;
		//レイを作成
		var ray = new Ray(camerapos, screenToWorldPointPosition - camerapos);
		//レイの衝突を検知
		var raycastHits = new RaycastHit[1];
		Physics.RaycastNonAlloc(ray, raycastHits, maxRange);
		var hitpoint = raycastHits[0].point;

		if (hitpoint == default)
		{
			hitpoint = ray.GetPoint(maxRange);
		}
		//位置調整
		hitpoint += adjustPosition;
		// ワールド座標に変換されたマウス座標を代入
		gameObject.transform.position = hitpoint;
	}
}
