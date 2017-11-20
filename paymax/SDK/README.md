# 项目说明：

### 1、GernerateKey

​      用于生成RSA密钥对。密钥有两种格式：

​    （1） .net 格式：用于Demo程序。将生成的 .net public key 替换程序里SignConfig.cs里的PUBLIC_KEY， .net private key 替换程序里SignConfig.cs里的PRIVATE_KEY。

​    （2） java格式：用于paymax网站。将生成的Java public key 填写到：开发信息－商户公钥，保存。

### 2、ConvertKeyTool

​      用于将java格式的密钥转换为.net格式。

​     （1）将paymax网站上的 paymax公钥复制到此工具的Java public key ，点击“convert" ，转换成.net格式的key。

​     （2） 将转换好的.net 格式的paymax公钥，替换程序里SignConfig.cs里的PAYMAX_PUBLIC_KEY。

### 3、Dlls

​      用于生成RSA密钥对和转换密钥所需的dll文件。

### 4、Paymax

​      封装的paymax接口类库，包含签名、验签、下单、查询下单、退款、查询退款接口的实现。

### 5、PaymaxExample

​     调用paymax类库，运行此项目即可进行下单、查询下单、退款、查询退款的接口测试。