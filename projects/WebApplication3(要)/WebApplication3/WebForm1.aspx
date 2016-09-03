<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<script src="js/swfobject.js" type="text/javascript"></script>
<script type="text/javascript">
    var flashvars = {
        spaceLen: 6.0, //specify the length bwteen the end of line and the letter
        size: 18.0, //specify the length of two letter
        color1: "<%=getColor1()%>", //just test by youself
        color2: "<%=getColor2()%>", //if you need,i can give you more control of swf!
        seqs: "<%=getSeqs()%>",
        mathces: "<%=getMatches()%>"
    };
    var params = {
        menu: "true",
        scale: "noScale",
        allowFullscreen: "false",
        allowScriptAccess: "always",
        bgcolor: "#FFFFFF"
    };
    var attributes = {
        id: "RNAShower"
    };
    swfobject.embedSWF("./RNAShower.swf", "altContent", "1", "1", "9.0.0", "expressInstall.swf", flashvars, params, attributes);
</script>
<title>无标题文档</title>
<style type="text/css">
.style1
{
width: 874px;
height: 32px;
}
.style2
{
width: 453px;
height: 31px;
}
.style4
{
height: 258px;
}
.style5
{
width: 100%;
}
.style6
{
width: 32px;
}
.style7
{
width: 390px;
height: 237px;
}
.style8
{
width: 189px;
height: 37px;
}
.style9
{
width: 262px;
height: 44px;
}
.style10
{
width: 631px;
height: 32px;
}
.style11
{
width: 70px;
height: 52px;
}
.style12
{
width: 713px;
height: 37px;
}
.style13
{
width: 155px;
height: 28px;
}
.style14
{
width: 853px;
height: 37px;
}
.style15
{
width: 21px;
}
.style16
{
width: 126px;
height: 28px;
}
.style17
{
font-size: x-large;
font-family: "Broadway BT";
}
.style18
{
font-family: Aparajita;
font-size: x-large;
}
</style>
</head>

<body style="height: 713px" >
<form id="form1" runat="server">
<table width="1267" align="center" style="height: 656px">
<tr>
<td colspan="10"><div align="center"><img src="img/主题1.PNG" width="866" height="125" /><img src="img/主题1.2" width="386" height="125" /></div></td>
</tr>
<tr>
<td rowspan="8" class="style15"><img src="img/主题2.4.PNG" width="31" height="581" /></td>
<td height="15" colspan="8">
<img alt="" class="style1"
src="img/改过文字1.PNG" /><br />
<img alt="" class="style2"
src="img/改过文字1.1.PNG" /></td>
<td width="31" rowspan="8"><img src="img/主题2.4.PNG" width="31" height="581" /></td>
</tr>
<tr>
<td height="33" colspan="3"><img src="img/说明1.PNG" width="320" height="31" /></td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td height="34" colspan="3">&nbsp;<asp:TextBox
ID="TextBox1" runat="server"
BorderColor="#005B00" BorderStyle="Ridge" Height="61px"
ontextchanged="TextBox1_TextChanged" Width="611px" AutoPostBack="True"
TextMode="MultiLine" ></asp:TextBox>
</a></td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>i
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td>
<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/按钮2.PNG"
onclick="ImageButton1_Click" Height="26px" Width="66px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<div >
<asp:Label ID="RNAViewerLabel" runat="server" Text="RNAViewer:" Visible=false></asp:Label>
<div id="altContent" >
<h1>RNAViewer:</h1>
<p>Sorry,there may be something wrong with the flash!</p>
<p><a href="http://www.adobe.com/go/getflashplayer"><img
src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
alt="Get Adobe Flash player" /></a></p>
</div>
</div>
<asp:Label ID="Label1" runat="server" Text="efficiency"></asp:Label>
</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td height="15" colspan="8"><img src="img/分割.PNG" width="417" height="13" /><img src="img/分割.PNG" width="417" height="13" /><img src="img/分割.PNG" width="354" height="13" /></td>
</tr>
<tr>
<td height="34" colspan="3">


<img alt="" class="style14"
src="img/改过文字2.1.PNG" /><a href="page1.html"><img src="img/按钮3.PNG" width="140" height="36" border="0" /></a></td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td height="15" colspan="8"><img src="img/分割.PNG" width="417" height="13" /><img src="img/分割.PNG" width="417" height="13" /><img src="img/分割.PNG" width="352" height="13" /></td>
</tr>
<tr>
<td width="818" class="style4"><p><img src="img/用户手册.PNG" width="514" height="151" /></p>
<p style="width: 995px">
<img alt="" class="style12"
src="img/credits.PNG" /><img
alt="" class="style13"
src="img/credit.1.PNG" /><img alt="" class="style16"
src="file:///E:/img/he.PNG" /></p>
</td>
<td width="5" class="style4"></td>
<td class="style4"></td>
<td class="style4"></td>
<td class="style4"></td>
<td class="style4"></td>
<td class="style4"></td>
<td class="style4"></td>
</tr>
</table>
<table class="style5">
<tr>
<td class="style6">
&nbsp;</td>
<td style="font-family: Batang">
<span class="style17"><strong>Acknowledgement：</strong></span>
<span class="style18">Zhu Chaoyang，Liu Weicai，BGI</span><br />
<br />
<img alt="" class="style8"
src="/img/ssupported.PNG" /><a href="http://www.sustc.edu.cn/"><img
alt="" class="style9"
src="img/sustc.PNG"/></a><br />
<img alt="" class="style10"
src="img/wiki.PNG" /><a href="http://2012.igem.org/Team:SUSTC-Shenzhen-B"><img
alt="" class="style11"
src="img/logoo.PNG" /></a></td>
</tr>
<tr>
<td class="style6">
&nbsp;</td>
<td>
<img alt="" class="style7"
src="img/contact.PNG" /></td>
</tr>
</table>
</form>

<script type="text/javascript">
    function showRna(seqs, matches) {
        if (!thisMovie("RNAShower").showRna(seqs, matches)) {
            document.write("args error");
        }
    }
    function setWidthHeight(w, h) {
        var b = thisMovie("RNAShower").getIsDrawSuccess();
        if (b == 1) {
            thisMovie("RNAShower").width = w;
            thisMovie("RNAShower").height = h;
        } else {
            thisMovie("RNAShower").width = thisMovie("RNAShower").height = 1;
        }
    }
    function thisMovie(movieName) {
        /*if (navigator.appName.indexOf("Microsoft") != -1) {
        return window[movieName]
        }
        else {
        return document[movieName]
        }*/
        return document.getElementById("RNAShower");
    }
</script>

</body>
</html>