var OxOf453=["SetStyle","length","","GetStyle","GetText",":",";","cssText","inp_color","inp_color_Preview","tb_image","btnbrowse","sel_bgrepeat","sel_bgattach","sel_hor","tb_hor","sel_hor_unit","sel_ver","tb_ver","sel_ver_unit","outer","div_demo","onclick","value","disabled","selectedIndex","style","backgroundImage","backgroundColor","backgroundRepeat","backgroundAttachment","backgroundPositionX","options","backgroundPositionY","url(",")","background-image","backgroundPosition","none"];function pause(Ox49e){var Oxa1= new Date();var Ox49f=Oxa1.getTime()+Ox49e;while(true){Oxa1= new Date();if(Oxa1.getTime()>Ox49f){return ;} ;} ;} ;function StyleClass(Ox1fa){var Ox4a1=[];var Ox4a2={};if(Ox1fa){Ox4a7();} ;this[OxOf453[0]]=function SetStyle(name,Ox4e,Ox4a4){name=name.toLowerCase();for(var i=0;i<Ox4a1[OxOf453[1]];i++){if(Ox4a1[i]==name){break ;} ;} ;Ox4a1[i]=name;Ox4a2[name]=Ox4e?(Ox4e+(Ox4a4||OxOf453[2])):OxOf453[2];} ;this[OxOf453[3]]=function GetStyle(name){name=name.toLowerCase();return Ox4a2[name]||OxOf453[2];} ;this[OxOf453[4]]=function Ox4a6(){var Ox1fa=OxOf453[2];for(var i=0;i<Ox4a1[OxOf453[1]];i++){var n=Ox4a1[i];var p=Ox4a2[n];if(p){Ox1fa+=n+OxOf453[5]+p+OxOf453[6];} ;} ;return Ox1fa;} ;function Ox4a7(){var arr=Ox1fa.split(OxOf453[6]);for(var i=0;i<arr[OxOf453[1]];i++){var p=arr[i].split(OxOf453[5]);var n=p[0].replace(/^\s+/g,OxOf453[2]).replace(/\s+$/g,OxOf453[2]).toLowerCase();Ox4a1[Ox4a1[OxOf453[1]]]=n;Ox4a2[n]=p[1];} ;} ;} ;function GetStyle(Ox130,name){return  new StyleClass(Ox130.cssText).GetStyle(name);} ;function SetStyle(Ox130,name,Ox4e,Ox4a8){var Ox4a9= new StyleClass(Ox130.cssText);Ox4a9.SetStyle(name,Ox4e,Ox4a8);Ox130[OxOf453[7]]=Ox4a9.GetText();} ;function ParseFloatToString(Ox24){var Ox8=parseFloat(Ox24);if(isNaN(Ox8)){return OxOf453[2];} ;return Ox8+OxOf453[2];} ;var inp_color=Window_GetElement(window,OxOf453[8],true);var inp_color_Preview=Window_GetElement(window,OxOf453[9],true);var tb_image=Window_GetElement(window,OxOf453[10],true);var btnbrowse=Window_GetElement(window,OxOf453[11],true);var sel_bgrepeat=Window_GetElement(window,OxOf453[12],true);var sel_bgattach=Window_GetElement(window,OxOf453[13],true);var sel_hor=Window_GetElement(window,OxOf453[14],true);var tb_hor=Window_GetElement(window,OxOf453[15],true);var sel_hor_unit=Window_GetElement(window,OxOf453[16],true);var sel_ver=Window_GetElement(window,OxOf453[17],true);var tb_ver=Window_GetElement(window,OxOf453[18],true);var sel_ver_unit=Window_GetElement(window,OxOf453[19],true);var outer=Window_GetElement(window,OxOf453[20],true);var div_demo=Window_GetElement(window,OxOf453[21],true);btnbrowse[OxOf453[22]]=function btnbrowse_onclick(){function Ox354(Ox137){if(Ox137){tb_image[OxOf453[23]]=Ox137;} ;} ;editor.SetNextDialogWindow(window);if(Browser_IsSafari()){editor.ShowSelectImageDialog(Ox354,tb_image.value,tb_image);} else {editor.ShowSelectImageDialog(Ox354,tb_image.value);} ;} ;UpdateState=function UpdateState_Background(){tb_hor[OxOf453[24]]=sel_hor_unit[OxOf453[24]]=(sel_hor[OxOf453[25]]>0);tb_ver[OxOf453[24]]=sel_ver_unit[OxOf453[24]]=(sel_ver[OxOf453[25]]>0);div_demo[OxOf453[26]][OxOf453[7]]=element[OxOf453[26]][OxOf453[7]];} ;SyncToView=function SyncToView_Background(){tb_image[OxOf453[23]]=element[OxOf453[26]][OxOf453[27]];FixTbImage();inp_color[OxOf453[23]]=element[OxOf453[26]][OxOf453[28]];inp_color[OxOf453[26]][OxOf453[28]]=element[OxOf453[26]][OxOf453[28]];inp_color_Preview[OxOf453[26]][OxOf453[28]]=element[OxOf453[26]][OxOf453[28]];sel_bgrepeat[OxOf453[23]]=element[OxOf453[26]][OxOf453[29]];sel_bgattach[OxOf453[23]]=element[OxOf453[26]][OxOf453[30]];sel_hor[OxOf453[23]]=element[OxOf453[26]][OxOf453[31]];sel_hor_unit[OxOf453[25]]=0;if(sel_hor[OxOf453[25]]==-1){if(ParseFloatToString(element[OxOf453[26]].backgroundPositionX)){tb_hor[OxOf453[23]]=ParseFloatToString(element[OxOf453[26]].backgroundPositionX);for(var i=0;i<sel_hor_unit[OxOf453[32]][OxOf453[1]];i++){var Ox13b=sel_hor_unit[OxOf453[32]][i][OxOf453[23]];if(Ox13b&&element[OxOf453[26]][OxOf453[31]].indexOf(Ox13b)!=-1){sel_hor_unit[OxOf453[25]]=i;break ;} ;} ;} ;} ;sel_ver[OxOf453[23]]=element[OxOf453[26]][OxOf453[33]];sel_ver_unit[OxOf453[25]]=0;if(sel_ver[OxOf453[25]]==-1){if(ParseFloatToString(element[OxOf453[26]].backgroundPositionY)){tb_ver[OxOf453[23]]=ParseFloatToString(element[OxOf453[26]].backgroundPositionY);for(var i=0;i<sel_ver_unit[OxOf453[32]][OxOf453[1]];i++){var Ox13b=sel_ver_unit[OxOf453[32]][i][OxOf453[23]];if(Ox13b&&element[OxOf453[26]][OxOf453[33]].indexOf(Ox13b)!=-1){sel_ver_unit[OxOf453[25]]=i;break ;} ;} ;} ;} ;} ;SyncTo=function SyncTo_Background(element){if(tb_image[OxOf453[23]]){element[OxOf453[26]][OxOf453[27]]=OxOf453[34]+tb_image[OxOf453[23]]+OxOf453[35];} else {SetStyle(element.style,OxOf453[36],OxOf453[2]);} ;try{element[OxOf453[26]][OxOf453[28]]=inp_color[OxOf453[23]]||OxOf453[2];} catch(x){element[OxOf453[26]][OxOf453[28]]=OxOf453[2];} ;element[OxOf453[26]][OxOf453[29]]=sel_bgrepeat[OxOf453[23]]||OxOf453[2];element[OxOf453[26]][OxOf453[30]]=sel_bgattach[OxOf453[23]]||OxOf453[2];element[OxOf453[26]][OxOf453[37]]=OxOf453[2];if(sel_hor[OxOf453[25]]>0){element[OxOf453[26]][OxOf453[31]]=sel_hor[OxOf453[23]];} else {if(ParseFloatToString(tb_hor.value)){element[OxOf453[26]][OxOf453[31]]=ParseFloatToString(tb_hor.value)+sel_hor_unit[OxOf453[23]];} else {element[OxOf453[26]][OxOf453[31]]=OxOf453[2];} ;} ;if(sel_ver[OxOf453[25]]>0){element[OxOf453[26]][OxOf453[33]]=sel_ver[OxOf453[23]];} else {if(ParseFloatToString(tb_ver.value)){element[OxOf453[26]][OxOf453[33]]=ParseFloatToString(tb_ver.value)+sel_ver_unit[OxOf453[23]];} else {element[OxOf453[26]][OxOf453[33]]=OxOf453[2];} ;} ;} ;function FixTbImage(){var Ox13b=tb_image[OxOf453[23]].replace(/^(\s+)/g,OxOf453[2]).replace(/(\s+)$/g,OxOf453[2]);if(Ox13b.substr(0,4).toLowerCase()==OxOf453[34]){Ox13b=Ox13b.substr(4,Ox13b[OxOf453[1]]-4);} ;if(Ox13b.substr(Ox13b[OxOf453[1]]-1,1)==OxOf453[35]){Ox13b=Ox13b.substr(0,Ox13b[OxOf453[1]]-1);} ;if(Ox13b==OxOf453[38]){Ox13b=OxOf453[2];} ;tb_image[OxOf453[23]]=Ox13b;} ;inp_color[OxOf453[22]]=inp_color_Preview[OxOf453[22]]=function inp_color_onclick(){SelectColor(inp_color,inp_color_Preview);} ;