#include "httpRequest.h"
#include<iostream>
#include<vector>
#include<string.h>
#include<string> 
using namespace std;

inline int httpPost(LPCSTR url,LPCSTR headers,BYTE *post,DWORD postLength,HTTPRequest *req){
	/*"Content-Type: application/x-www-form-urlencoded\r\n"*/
	return SendHTTP(url,headers,post,postLength,req);
}
inline int httpGet(LPCSTR url,HTTPRequest *req){
	 return SendHTTP(url,NULL,NULL,0,req);   
}

int main(int argc,char *argv[]){
	HTTPRequest req;
	char url[]="http://mytest.yupage.com/globalRefresher.php";

	const unsigned int deafult_sleeptime=20*60;
	unsigned int sleeptime=deafult_sleeptime;
	if(argc>=2){
		sleeptime=atoi(argv[1]);
	}
	if(sleeptime<0)sleeptime=deafult_sleeptime;
	if(sleeptime>24*60*60)sleeptime=deafult_sleeptime;;

	cout<<"set url="<<url<<endl;
	cout<<"set sleepTime="<<sleeptime<<endl;
	cout<<"start fectch url after sleepTime again and again."<<endl;

	while(1){
	cout<<"fetching "<<url<<"\nPlease wait..."<<endl;
	httpGet(url,&req);
	
	cout<<"Fetch successfully!\nSleep "<<sleeptime<<" seconds."<<endl;

	Sleep(sleeptime*1000);
	}
	return 0;
}
