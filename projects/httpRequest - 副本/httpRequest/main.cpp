#include "httpRequest.h"
#include "tinyxml.h"
#include<iostream>
#include<vector>
#include<string.h>
#include<string> 
using namespace std;
/*
*����һ��������������Ԥ���ģ�����
*httpRequest.h��tinxml.h �������������ҵģ�������д�ģ�ֱ���þͺã�
*���main.cpp������д�ģ�����
*����̫���ģ�����Ϲ�������������(��ʵ��������ѧѧhttp)
*author:eric
*/
int getWeather(const char *city);
int main(){
	cout<<"********************����֮ר������Ԥ��********************"<<endl;
	getWeather("����");
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
	if(httpGet(url,&req)!=0){//��ȡ��ҳ�������б�ţ�
		cout<<"Connect to network fail��"<<endl;
			return 1;
	}
	cityCodesInfo=utf8ToAnsi(req.message);//����(UTF-8 to ANSI)��֮ǰһֱ�������룬������֪����ôת��
										//��ҳ����UTF-8�ı��룬������̨��ʾ����ANSI�ĺ��ֱ��룬����Ҫ����ת�����������룡
	//cout<<"cityCodesInfo="<<cityCodesInfo<<endl;//�ɲ鿴Դ����
	free(req.headers);
	free(req.message);
	const char *p=strstr(cityCodesInfo.c_str(),city);//���������д���
	if(p!=NULL){
		const char *pbeg,*pend;
		pbeg=strchr(p,'(');
		pend=strchr(p,')');
		memset(cityCode,0,sizeof(cityCode));
		strncpy(cityCode,pbeg+1,pend-pbeg-1);//ȡ�����д���
		vector<string>strs;
		{
			sprintf(url,GET_WEATHER,cityCode);
			if(getXml(url,&xml)==0){//��ȡ�����ģأͣ��ļ�
				//���¶ԣأ̷ͣ���
				TiXmlElement *ele=xml.RootElement()->FirstChildElement();
				do{
					strs.push_back(utf8ToAnsi(ele->FirstChild()->Value()));
					ele=ele->NextSiblingElement();
				}while(ele!=NULL);
				/*ͨ�� getSupportCity �� getSupportDataSet ���)��
				�������ݣ� һ��һά���� String(22)������23��Ԫ�ء�
String(0) �� String(4)��ʡ�ݣ����У����д��룬����ͼƬ���ƣ�������ʱ�䡣
String(5) �� String(11)������� ���£��ſ�������ͷ������������ƿ�ʼͼƬ����(���³ƣ�ͼ��һ)��
�������ƽ���ͼƬ����(���³ƣ�ͼ���)�����ڵ�����ʵ��������������ָ����
String(12) �� String(16)���ڶ���� ���£��ſ�������ͷ�����ͼ��һ��ͼ�����
String(17) �� String(21)��������� ���£��ſ�������ͷ�����ͼ��һ��ͼ�����
String(22) ����ѯ�ĳ��л�����Ľ��� */
				printf("���У�%s\n",strs[1].c_str());
				printf("ʱ��  ����\t\t�ſ�\t����ͷ���\n");
				printf("����  %s\t%s\t%s\n",strs[5].c_str(),strs[6].c_str(),strs[7].c_str());
				printf("����  %s\t%s\t%s\n",strs[12].c_str(),strs[13].c_str(),strs[14].c_str());
				printf("����  %s\t%s\t%s\n",strs[17].c_str(),strs[18].c_str(),strs[19].c_str());
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
