#ifndef HTTPREQUEST_H
#define HTTPREQUEST_H
#include <stdio.h>   
#include <string.h>   
#include <ctype.h>
#include "winsock2.h"   
/* HTTPRequest: Structure that returns the HTTP headers and message  
                from the request*/   
typedef struct   
{    
    LPSTR headers;/* Pointer to HTTP headers */   
    LPSTR message;/* Pointer to the HTTP message */   
    long messageLength;/* Length of the message */   
} HTTPRequest;   
int SendHTTP(LPCSTR url,LPCSTR headers,BYTE *post,DWORD postLength,HTTPRequest *req);
#endif