#include "httpRequest.h"
#include "tinyxml.h"
#include<iostream>
#include<vector>
#include<string.h>
#include<string> 
using namespace std;
/*
*这是一个，用来查天气预报的．．．
*httpRequest.h　tinxml.h 这两个是网上找的，不是我写的（直接用就好）
*这个main.cpp才是我写的．．．
*汗，太无聊，所以瞎搞了这个．．．(其实，是我在学学http)
*author:eric
*/
int getWeather(const char *city);
int main(){
	cout<<"********************沈马虎之专用天气预报********************"<<endl;
	getWeather("深圳");
	while(1){
		cout<<endl;
		char city[20];
		cout<<"City:";cin>>city;
		getWeather(city);
	}
	return 0;
}
inline int httpPost(LPCSTR url,LPCSTR headers,BYTE *post,DWORD postLength,HTTPRequest *req){
	/*"Content-Type: application/x-www-form-urlencoded\r\n"*/
	return SendHTTP(url,headers,post,postLength,req);
}
inline int httpGet(LPCSTR url,HTTPRequest *req){
	 return SendHTTP(url,NULL,NULL,0,req);   
}
inline wstring utf8ToUnicode(string str){
    size_t wcsLen = MultiByteToWideChar(CP_UTF8, NULL, str.c_str(), str.length(), NULL, 0);
    wchar_t* wszString = new wchar_t[wcsLen + 1];
    memset(wszString, 0, sizeof(wchar_t)*(wcsLen + 1));
    ::MultiByteToWideChar(CP_UTF8, NULL, str.c_str(), str.length(), wszString, wcsLen);
    wstring wstr= wszString;
    delete wszString;
    return wstr;
}
inline string utf8ToAnsi(string str){
	wstring ws=utf8ToUnicode(str);
	size_t len= WideCharToMultiByte(CP_ACP,NULL,ws.c_str(),ws.length(),NULL,0,NULL,NULL);
	char *szAnsi=new char [len+1];
	memset(szAnsi,0,len+1);
	WideCharToMultiByte(CP_ACP,NULL,ws.c_str(),ws.length(),szAnsi,len,NULL,NULL);
	string s=string(szAnsi);
	delete szAnsi;
	return s;
}
int getXml(const char *url,TiXmlDocument* xml){
	HTTPRequest req;;
	FILE *file;
	if(httpGet(url,&req)==0){
			if((file=tmpfile())!=NULL){
				fputs(req.message,file);
				fflush(file);
				
				if(xml->LoadFile(file)){
					free(req.headers);
					free(req.message);
					fclose(file);
					return 0;
				}
				fclose(file);
			}
		free(req.headers);
		free(req.message);
		return 1;
	}
	return 1;
}
int getWeather(const char *city){
#define GET_WEATHER "http://www.webxml.com.cn/WebServices/WeatherWebService.asmx/getWeatherbyCityName?theCityName=%s"
#define GET_PROVIN_CODE "http://www.webxml.com.cn/WebServices/WeatherWebService.asmx/getSupportCity?byProvinceName="
	char url[1024];
	char cityCode[10];
	TiXmlDocument xml;
	HTTPRequest req;
	string cityCodesInfo;
	//
	sprintf(url,GET_PROVIN_CODE);
	if(httpGet(url,&req)!=0){//提取网页（含城市编号）
		cout<<"Connect to network fail！"<<endl;
			return 1;
	}
	cityCodesInfo=utf8ToAnsi(req.message);//编码(UTF-8 to ANSI)　之前一直出现乱码，后来才知道怎么转码
										//网页上是UTF-8的编码，但控制台显示是是ANSI的汉字编码，所以要进行转换，否则乱码！
	//cout<<"cityCodesInfo="<<cityCodesInfo<<endl;//可查看源数据
	free(req.headers);
	free(req.message);
	const char *p=strstr(cityCodesInfo.c_str(),city);//搜索　城市代码
	if(p!=NULL){
		const char *pbeg,*pend;
		pbeg=strchr(p,'(');
		pend=strchr(p,')');
		memset(cityCode,0,sizeof(cityCode));
		strncpy(cityCode,pbeg+1,pend-pbeg-1);//取出城市代码
		vector<string>strs;
		{
			sprintf(url,GET_WEATHER,cityCode);
			if(getXml(url,&xml)==0){//提取天气的ＸＭＬ文件
				//以下对ＸＭＬ分析
				TiXmlElement *ele=xml.RootElement()->FirstChildElement();
				do{
					strs.push_back(utf8ToAnsi(ele->FirstChild()->Value()));
					ele=ele->NextSiblingElement();
				}while(ele!=NULL);
				/*通过 getSupportCity 或 getSupportDataSet 获得)；
				返回数据： 一个一维数组 String(22)，共有23个元素。
String(0) 到 String(4)：省份，城市，城市代码，城市图片名称，最后更新时间。
String(5) 到 String(11)：当天的 气温，概况，风向和风力，天气趋势开始图片名称(以下称：图标一)，
天气趋势结束图片名称(以下称：图标二)，现在的天气实况，天气和生活指数。
String(12) 到 String(16)：第二天的 气温，概况，风向和风力，图标一，图标二。
String(17) 到 String(21)：第三天的 气温，概况，风向和风力，图标一，图标二。
String(22) 被查询的城市或地区的介绍 */
				printf("城市：%s\n",strs[1].c_str());
				printf("时间  气温\t\t概况\t风向和风力\n");
				printf("今天  %s\t%s\t%s\n",strs[5].c_str(),strs[6].c_str(),strs[7].c_str());
				printf("明天  %s\t%s\t%s\n",strs[12].c_str(),strs[13].c_str(),strs[14].c_str());
				printf("后天  %s\t%s\t%s\n",strs[17].c_str(),strs[18].c_str(),strs[19].c_str());
				return 0;
			}else{
				cout<<"Get weather fail!"<<endl;
				return 1;
			}
		}
	}else{
		cout<<"Don't support this city:"<<city<<endl;
		return 1;
	}
    return 0;   
}
