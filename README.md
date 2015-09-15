# Alan.GoogleApiMapping
拯救被墙的Google CDN。

### 目的
这个项目的目的是让你在自己的电脑上访问正常访问使用Google CDN的网站.

### 思路
修改Windows系统的Hosts文件, 将 `ajax.googleapis.com` 的域名解析指向自己的IP, 然后自己的PC上架设一个网站返回相应的文件.

### 步骤

1 修改 `hosts` 文件, 文件位于 `C:\Windows\System32\drivers\etc\hosts`, 增加下列一行解析:
	
	192.168.11.80		ajax.googleapis.com

192.168.11.80是你的IP地址.

2 将项目clone下来然后发布到IIS里，绑定域名
![IIS](https://raw.githubusercontent.com/Allen-Wei/Alan.GoogleApiMapping/master/Images/iis_config.png)

3 修改映射文件, 映射文件位于 `~/App_Data/mapping.json`.

4 使映射即时生效需要访问一下 `http://ajax.googleapis.com/Configurations/RefreshConfig.ashx`


