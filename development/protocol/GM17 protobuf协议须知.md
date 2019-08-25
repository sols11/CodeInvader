#### GM17 protobuf协议须知

--------

**数据包说明** 客户端和服务器间的通信的数据包由协议号(proto_id)和数据(proto_data)两部分组成。proto_id用于进行协议服务的分发处理。在分发处理函数中，通过proto_id识别并解析出proto_data中携带的protobuf协议数据。

**协议注册** 客户端和服务器间的协议通信类似大作业中的机制，由SID(16bits) + CID(16 bits)组合而成。

每一类大的协议服务可以定义在同一个proto文件使用同一个SID，每个人注册自己需要的大类协议服务时使用的SID切莫与别人发生冲突。每个人在占用某个SID协议号后记得要在下面代码框内添加服务协议号SID(最好再注明服务协议的用途)，以免发生Dispatch冲突，至于CID自己在自定义的proto文件内随意支配。相关示例见proto文件夹下的AccountMessage.proto。

```
SID：
ACCOUNT_SERVICE = 0x0001;	# 游戏用户账号相关协议
ROOM_SERVICE 	= 0x0002;	# 游戏房间系统相关协议
AI_SERVICE      = 0x0003;   # AI编程相关协议
# !!!!!!!!!!!一定记得要在这里面添加服务协议号(SID)!!!!!!!!!!!!!
```

**protobuf相关生成** 在本地安装好protoc命令后，将proto文件放在svn的protocol文件夹的子文件夹proto，并调用proto_cs.bat 或proto_pb2.bat 生成对应protobuf文件对应的语言版本的数据定义，生成后的文件在对应语言的文件夹下c# -> cs/, python-> pb2, python_grpc -> pb2_grpc.



### 协议服务实现

协议注册按SID注册一类服务，下面以AccountService为例说明在客户端和服务器两端的协议注册：

**服务器部分**

1. 在在protobuf文件中定义好协议请求和回传的内容数据格式，生成对应语言的文件后放在protocol_servcuces/protobuf_msg文件夹中。
2. 在protocol_services下以每类服务建立文件夹，并在**_service中提供分发函数。提供init()函数进行协议的注册
3. 在services.py中调用该类协议的init()进行注册

**客户端部分**  

1. 在protobuf文件中定义好协议请求和回传的内容数据格式，生成对应语言的文件后放在ProtocolService/Protobuf文件夹中。

2. 为每一类协议服务创建**Service文件夹（参考AccountService），在里面定义协议函数：

   ① \*\*Service.cs : 注册该类协议的各个服务协议的消息分发函数

   ② \*\*ServiceRequest.cs: 该类协议的协议请求处理、

   ③ \*\*ServiceResponse.cs: 该类协议的协议分发处理函数，这里的函数在第①个文件中进行注册

   ④ *\*ServiceNotification.cs: 该类协议处理服务器传来的通知消息（指那种服务器主动发送的） 

3. 在ServiceMgr中初始化该类服务函数

   

   

