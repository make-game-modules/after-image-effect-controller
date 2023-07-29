// 引入必要的库
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 这个脚本用于在Unity中创建一个精灵图的残影效果。当精灵图在场景中移动时，
 * 它会自动在移动路径上留下一些半透明的残影。这些残影会在一段时间后自动消失。
 * 使用此脚本时，需要将其添加到想要创建残影效果的精灵图对象上，并在Unity编辑器中设置相关的参数。
 */

public class AfterImageEffectController : MonoBehaviour
{
    public Material afterImageMaterial ; // 在Unity编辑器中，你需要将创建的残影Shader赋值给这个Material
    public float fadeDuration = 0.1f; // 残影消失的时间，单位为秒
    public float fixedAfterImageDelay = 0.07f; // 创建残影的时间间隔，单位为秒
    public bool enable = true;

    private float afterImageDelay; // 当前残影的时间间隔，单位为秒
    private SpriteRenderer spriteRenderer; // 存储精灵图的渲染器
    private List<SpriteRenderer> afterImages = new List<SpriteRenderer>(); // 用于存储所有的残影
    private Vector3 lastGlobalPosition;  // 用于记录精灵图上一帧的全局位置

    void Start() // 在精灵图创建时执行
    {
        afterImageDelay = fixedAfterImageDelay;

        spriteRenderer = GetComponent<SpriteRenderer>(); // 获取精灵图的渲染器
        lastGlobalPosition = transform.position; // 记录精灵图的初始全局位置
    }

    void Update() // 在每一帧中执行
    {
        if (!enable) return;

        // 如果精灵图的全局位置有变化，也就是说精灵图有移动
        if (Vector3.Distance(lastGlobalPosition, transform.position) > 0)
        {
            // 每隔一段时间就创建一个新的残影
            if (afterImageDelay > 0)
            {
                afterImageDelay -= Time.deltaTime; // 计时器递减
                if (afterImageDelay <= 0) // 当计时器到零时
                {
                    CreateAfterImage(); // 创建新的残影
                    afterImageDelay = fixedAfterImageDelay; // 重置计时器
                }
            }
        }

        // 处理所有残影的淡出和销毁
        for (int i = afterImages.Count - 1; i >= 0; i--)
        {
            SpriteRenderer afterImage = afterImages[i];

            // 逐渐改变残影的透明度
            Color color = afterImage.color;
            color.a -= Time.deltaTime / fadeDuration;
            afterImage.color = color;

            // 当残影完全透明后，删除它
            if (color.a <= 0)
            {
                afterImages.RemoveAt(i); // 从列表中移除
                Destroy(afterImage.gameObject); // 销毁残影对象
            }
        }

        lastGlobalPosition = transform.position; // 更新精灵图的全局位置
    }

    // 创建一个新的残影
    void CreateAfterImage()
    {
        GameObject afterImageObj = new GameObject("AfterImage"); // 创建一个新的游戏对象用于存储残影
        SpriteRenderer afterImageRenderer = afterImageObj.AddComponent<SpriteRenderer>(); // 给新的游戏对象添加渲染器组件

        // 将残影设置为当前精灵图的复制
        afterImageRenderer.sprite = spriteRenderer.sprite; // 设置残影的图像
        afterImageRenderer.material = afterImageMaterial; // 设置残影的材质
        afterImageRenderer.color = spriteRenderer.color; // 设置残影的颜色
        afterImageObj.transform.position = transform.position; // 设置残影的位置
        afterImageObj.transform.rotation = transform.rotation; // 设置残影的旋转
        afterImageObj.transform.localScale = transform.localScale; // 设置残影的大小

        //设置渲染顺序，使其在原始精灵之下
        afterImageRenderer.sortingLayerID = spriteRenderer.sortingLayerID; // 设置渲染层
        afterImageRenderer.sortingOrder = spriteRenderer.sortingOrder - 1; // 设置渲染顺序

        // 将新的残影添加到列表中
        afterImages.Add(afterImageRenderer);
    }
}
