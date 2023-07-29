# Unity Sprite Afterimage Effect

这个项目提供了一个 Unity 脚本，它可以在 Unity 中创建一个精灵图的残影效果。当精灵图在场景中移动时，它会自动在移动路径上留下一些半透明的残影。这些残影会在一段时间后自动消失。

## 如何使用

将 AfterImageEffectController 脚本添加到想要创建残影效果的精灵图对象上，然后在 Unity 编辑器中设置相关的参数。

## 参数设置

afterImageMaterial: 在 Unity 编辑器中，你需要将创建的残影 Shader 赋值给这个 Material。
fadeDuration: 残影消失的时间，单位为秒。
fixedAfterImageDelay: 创建残影的时间间隔，单位为秒。
enable: 控制是否开启残影效果，设置为 true 则开启残影效果。

## 运行原理

当精灵图的全局位置发生变化，也就是说精灵图有移动时，脚本会每隔一段时间就创建一个新的残影。
新的残影对象将会被赋予当前精灵图的图像、材质、颜色以及位置、旋转、大小信息。
脚本还会在每一帧中处理所有残影的淡出和销毁。

## 版权信息

本项目采用 MIT 开源许可证，欢迎任何人对项目的改进和使用。
