# README

## 版本说明

使用protobuf 3.9 版本

## 环境配置

### Python

- 切换至protobuf-python-3.9.0/python
- 在该位置打开CMD( or git bash )
- 依次运行:
    - python setup.py build
    - python setup.py test 
    - python setup.py install 
- 运行python, import google.protobuf检测是否安装成功.

### C#

- 确保.net Framework 版本大于等于4.5
- 为项目添加NuGet
- 搜索Google.Protobuf, 并安装
- using Google.Protobuf

## 使用说明

1. 通过Protocol Buffer语法 描述需要存储的数据结构 (**.proto文件**)
2. 打开cmd, 使用如下命令, 编译.proto文件到相应平台。(确保当前目录存在protoc.exe文件)
   
- 将test.proto编译为test.cs文件

```
protoc -I=$SRC_DIR --csharp_out=$DST_DIR $SRC_DIR/test.proto
```

- 将test.proto编译为test.py文件
```
protoc -I=$SRC_DIR --python_out=$DST_DIR $SRC_DIR/test.proto
```

其中\$SRC_DIR是待编译的.proto文件的目录位置，\$DST_DIR是想要将生成的文件放在的目录位置，如果不提供值则使用当前目录。 

3. 将相应生成文件导入项目