# 为abp vnext生成C#客户端给非abp的net程序使用

abp vnext提供了动态C#API客户端和静态C#API客户端来调用abp项目的接口，但是有局限性；要使用动态C#API客户端的项目必须也是ABP vnext的项目。静态C#API客户端也依赖abp的包，如下图为的静态客户端依赖于 Volo.Abp.DependencyInjection、Volo.Abp.Http.Client.ClientProxying等abp包，普通的net web api项目也是没办法直接使用的。

![](https://img2022.cnblogs.com/blog/883152/202210/883152-20221009174933125-441585115.png)


如果非abp的net 项目想调用abp vnext项目的方法应该怎么办呢？可能很多人会想到使用HttpClient来调用,类似于如下方式

```C#
伪代码
var client=new HttpClient();
...设置请求地址，请求路径、请求参数
var result=await client.SendAsync(requst);
...解析返回值等

```

这种方式使用起来非常的繁琐，很不好用。那有没有其他方式就像调用本地方法一样直观又方便的方式呢？

答案是有的，我们将使用[NSwagStudio](https://github.com/RicoSuter/NSwag/wiki/NSwagStudio) 来动态的生成客户端代码，使用客户端代码非abp的net项目就可以像调用本地方法一样方便的调用abp项目的方法。下载并安装NSwagStudio,安装成功后将后如下图

![](https://img2022.cnblogs.com/blog/883152/202210/883152-20221009175008069-746459824.png)


准备测试的项目，通过[abp官网](https://abp.io/get-started)在线创建一个项目名为AbpProject

![](https://img2022.cnblogs.com/blog/883152/202210/883152-20221009175032187-1695240180.png)


生成abp项目下载解压后在Application、Contract添加测试使用到的类
![](https://img2022.cnblogs.com/blog/883152/202210/883152-20221009175052461-1151901952.png)


代码非常简单

![](https://img2022.cnblogs.com/blog/883152/202210/883152-20221009175118693-107959915.png)


将AbpProject.HttpApi.Host设为启动项目，并启动项目

![](https://img2022.cnblogs.com/blog/883152/202210/883152-20221009175143172-23918932.png)


打开NSwagStudio，设置swagger.json地址，设置输出文件路径，点击"Generate Files"
![](https://img2022.cnblogs.com/blog/883152/202210/883152-20221009175203968-1652605077.png)


我们将得到一个AbpProjectClient.cs文件

![](https://img2022.cnblogs.com/blog/883152/202210/883152-20221009175226918-1758853858.png)


接线来我们生成一个web api项目，并将AbpProjectClient.cs文件放入该项目：

![](https://img2022.cnblogs.com/blog/883152/202210/883152-20221009175250032-1312531592.png)


在控制器中添加测试方法,真正的使用时应该使用HttpClientFactory来创建HttpClinet。
![](https://img2022.cnblogs.com/blog/883152/202210/883152-20221009175309512-993406726.png)


运行web api项目，并通过swagger调用测试方法，测试成功。web api项目调用Abp项目的接口成功并拿到了返回结果，并且不用序列化就能直接使用返回结果。

![](https://img2022.cnblogs.com/blog/883152/202210/883152-20221009175328723-999002832.png)

当然还可以使用其他方式来生成C#客户端，比如[NSwag.CodeGeneration.CSharp](https://www.nuget.org/packages/NSwag.CodeGeneration.CSharp/）、[NSwag.MSBuild](https://github.com/RicoSuter/NSwag/wiki/NSwag.MSBuild)等。

博客园地址：https://www.cnblogs.com/qmjblog/p/16773147.ht
