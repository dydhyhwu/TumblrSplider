# DY.Crawler.Core
独立类库

> 2017.11.23 更新



#### 快速开始 

``` c#
// 直接根据url 获取内容。
var url = "http://www.baidu.com";
var client = new HttpClient();
var content = url.get_content(client);
Console.WriteLine(content);
```



``` c#
// 自定义解析数据, 解析规则目前只支持XPath

var url = "http://m.bxwx9.org/modules/article/waplist.php?fullflag=1&page=1";
var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
var client = new HttpClient(handler);
var parse_rule = new DocumentNodeParseRule() { 
  Name = "书名", // 自定义规则名称，可忽略
  AttributeName = "content", // 待取元素名称(content表示 innerHTML)
  RuleValue ="/html/body/div[2]/table/tr/td[2]/div/a[1]" // XPath路径
}

var book_name = url.get_content(client).load(new List<ResourceFieldDef>() {parse_rule});

Console.WriteLine(book_name);
```



~~目前解析数据的设置稍显复杂，待重构。~~



#### 关于类库

> 此类库目前的目标并非是深度/广度非定向爬虫，而是自定义的定向爬虫。

目前版本暂还不能实现在定向的基础上进行深度/广度爬取。



#### TODO

| 目标                                       | 状态   |
| ---------------------------------------- | ---- |
| 简化自定义解析数据                                | 已完成  |
| 加入多线程模型                                  | 计划中  |
| 支持深度/广度爬取                                | 计划中  |
| 重构DTask, 目前结构耦合度高。 没有很好的划分任务与爬取操作之间的职责。  | 重构中  |
| 支持简单的登录机制（无验证码的登录情景）                     | 已完成  |
| 另起Vjudge Core项目, 利用此类库开发                 | 计划中  |
| Vjudge Core中加入分布式消息队列，支持分布式判题，选用NetMQ作为消息队列 | 计划中  |



> 先简化目前的结构，让单步定向爬取变得更简洁，可连贯操作。



#### About

欢迎各位提出宝贵的意见/PR。

> 个人知识及能力有限，代码实现或架构上有缺陷还请指正。不胜感激