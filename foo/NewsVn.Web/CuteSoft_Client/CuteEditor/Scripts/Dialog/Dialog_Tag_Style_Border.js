var OxO442c=["SetStyle","length","","GetStyle","GetText",":",";","cssText","div_selector_event","div_selector","sel_part","tb_margin","sel_margin_unit","tb_padding","sel_padding_unit","tb_border","sel_border_unit","sel_border","sel_style","inp_color","inp_color_Preview","outer","div_demo","offsetWidth","offsetHeight","Top","Left","Bottom","Right","onmousemove","runtimeStyle","border","4px solid red","style","onmouseout","onclick","value","onchange","disabled","selectedIndex","4px solid blue","-","Color"," ","#7f7c75","backgroundColor","Style","Width","options","margin","padding"];function pause(Ox49e){var Oxa1= new Date();var Ox49f=Oxa1.getTime()+Ox49e;while(true){Oxa1= new Date();if(Oxa1.getTime()>Ox49f){return ;} ;} ;} ;function StyleClass(Ox1fa){var Ox4a1=[];var Ox4a2={};if(Ox1fa){Ox4a7();} ;this[OxO442c[0]]=function SetStyle(name,Ox4e,Ox4a4){name=name.toLowerCase();for(var i=0;i<Ox4a1[OxO442c[1]];i++){if(Ox4a1[i]==name){break ;} ;} ;Ox4a1[i]=name;Ox4a2[name]=Ox4e?(Ox4e+(Ox4a4||OxO442c[2])):OxO442c[2];} ;this[OxO442c[3]]=function GetStyle(name){name=name.toLowerCase();return Ox4a2[name]||OxO442c[2];} ;this[OxO442c[4]]=function Ox4a6(){var Ox1fa=OxO442c[2];for(var i=0;i<Ox4a1[OxO442c[1]];i++){var n=Ox4a1[i];var p=Ox4a2[n];if(p){Ox1fa+=n+OxO442c[5]+p+OxO442c[6];} ;} ;return Ox1fa;} ;function Ox4a7(){var arr=Ox1fa.split(OxO442c[6]);for(var i=0;i<arr[OxO442c[1]];i++){var p=arr[i].split(OxO442c[5]);var n=p[0].replace(/^\s+/g,OxO442c[2]).replace(/\s+$/g,OxO442c[2]).toLowerCase();Ox4a1[Ox4a1[OxO442c[1]]]=n;Ox4a2[n]=p[1];} ;} ;} ;function GetStyle(Ox130,name){return  new StyleClass(Ox130.cssText).GetStyle(name);} ;function SetStyle(Ox130,name,Ox4e,Ox4a8){var Ox4a9= new StyleClass(Ox130.cssText);Ox4a9.SetStyle(name,Ox4e,Ox4a8);Ox130[OxO442c[7]]=Ox4a9.GetText();} ;function ParseFloatToString(Ox24){var Ox8=parseFloat(Ox24);if(isNaN(Ox8)){return OxO442c[2];} ;return Ox8+OxO442c[2];} ;var div_selector_event=Window_GetElement(window,OxO442c[8],true);var div_selector=Window_GetElement(window,OxO442c[9],true);var sel_part=Window_GetElement(window,OxO442c[10],true);var tb_margin=Window_GetElement(window,OxO442c[11],true);var sel_margin_unit=Window_GetElement(window,OxO442c[12],true);var tb_padding=Window_GetElement(window,OxO442c[13],true);var sel_padding_unit=Window_GetElement(window,OxO442c[14],true);var tb_border=Window_GetElement(window,OxO442c[15],true);var sel_border_unit=Window_GetElement(window,OxO442c[16],true);var sel_border=Window_GetElement(window,OxO442c[17],true);var sel_style=Window_GetElement(window,OxO442c[18],true);var inp_color=Window_GetElement(window,OxO442c[19],true);var inp_color_Preview=Window_GetElement(window,OxO442c[20],true);var outer=Window_GetElement(window,OxO442c[21],true);var div_demo=Window_GetElement(window,OxO442c[22],true);function GetPartFromEvent(){var src=Event_GetSrcElement();var x=Event_GetOffsetX();var y=Event_GetOffsetY();if(src==div_selector){x+=10;y+=10;} ;var Ox11=15-x;var Oxa=x-(div_selector_event[OxO442c[23]]-15);var Ox12=15-y;var b=y-(div_selector_event[OxO442c[24]]-15);if(Ox11>0){if(Ox12>0){return Ox11>Ox12?OxO442c[25]:OxO442c[26];} ;if(b>0){return Ox11>b?OxO442c[27]:OxO442c[26];} ;return OxO442c[26];} ;if(Oxa>0){if(Ox12>0){return Oxa>Ox12?OxO442c[25]:OxO442c[28];} ;if(b>0){return Oxa>b?OxO442c[27]:OxO442c[28];} ;return OxO442c[28];} ;if(Ox12>0){return OxO442c[25];} ;if(b>0){return OxO442c[27];} ;return OxO442c[2];} ;div_selector_event[OxO442c[29]]=function div_selector_event_onmousemove(){var Ox4c1=GetPartFromEvent();if(Browser_IsWinIE()){div_selector[OxO442c[30]][OxO442c[7]]=OxO442c[2];div_selector[OxO442c[30]][OxO442c[31]+Ox4c1]=OxO442c[32];} else {div_selector[OxO442c[33]][OxO442c[7]]=OxO442c[2];div_selector[OxO442c[33]][OxO442c[31]+Ox4c1]=OxO442c[32];} ;} ;div_selector_event[OxO442c[34]]=function div_selector_event_onmouseout(){if(Browser_IsWinIE()){div_selector[OxO442c[30]][OxO442c[7]]=OxO442c[2];} else {div_selector[OxO442c[33]][OxO442c[7]]=OxO442c[2];} ;} ;div_selector_event[OxO442c[35]]=function div_selector_event_onclick(){sel_part[OxO442c[36]]=GetPartFromEvent();SyncToViewInternal();UpdateState();} ;sel_part[OxO442c[37]]=function sel_part_onchange(){SyncToViewInternal();UpdateState();} ;UpdateState=function UpdateState_Border(){tb_border[OxO442c[38]]=sel_border_unit[OxO442c[38]]=(sel_border[OxO442c[39]]>0);div_demo[OxO442c[33]][OxO442c[7]]=element[OxO442c[33]][OxO442c[7]];div_selector[OxO442c[33]][OxO442c[7]]=OxO442c[2];div_selector[OxO442c[33]][OxO442c[31]+(sel_part[OxO442c[36]]||OxO442c[2])]=OxO442c[40];} ;SyncToView=function SyncToView_Border(){var Ox4c1=sel_part[OxO442c[36]];var Ox4c2=Ox4c1?OxO442c[41]+Ox4c1:Ox4c1;if(Browser_IsWinIE()){inp_color[OxO442c[36]]=element[OxO442c[33]][OxO442c[31]+Ox4c1+OxO442c[42]];} else {var arr=revertColor(element[OxO442c[33]][OxO442c[31]+Ox4c1+OxO442c[42]]).split(OxO442c[43]);if(arr[0]!=OxO442c[44]){inp_color[OxO442c[36]]=arr[0];} ;} ;inp_color[OxO442c[33]][OxO442c[45]]=inp_color[OxO442c[36]];sel_style[OxO442c[36]]=element[OxO442c[33]][OxO442c[31]+Ox4c1+OxO442c[46]];sel_border[OxO442c[36]]=element[OxO442c[33]][OxO442c[31]+Ox4c1+OxO442c[47]];var Ox5cb=element[OxO442c[33]][OxO442c[31]+Ox4c1+OxO442c[47]];tb_border[OxO442c[36]]=ParseFloatToString(Ox5cb);if(tb_border[OxO442c[36]]){for(var i=0;i<sel_border_unit[OxO442c[48]][OxO442c[1]];i++){var Ox13b=sel_border_unit[OxO442c[48]][i][OxO442c[36]];if(Ox13b&&Ox5cb.indexOf(Ox13b)!=-1){sel_border_unit[OxO442c[39]]=i;break ;} ;} ;} ;var Ox5cc=element[OxO442c[33]][OxO442c[49]+Ox4c1];tb_margin[OxO442c[36]]=ParseFloatToString(Ox5cc);if(tb_margin[OxO442c[36]]){for(var i=0;i<sel_margin_unit[OxO442c[48]][OxO442c[1]];i++){var Ox13b=sel_margin_unit[OxO442c[48]][i][OxO442c[36]];if(Ox13b&&Ox5cc.indexOf(Ox13b)!=-1){sel_margin_unit[OxO442c[39]]=i;break ;} ;} ;} ;var Ox5cd=element[OxO442c[33]][OxO442c[50]+Ox4c1];tb_padding[OxO442c[36]]=ParseFloatToString(Ox5cd);if(tb_padding[OxO442c[36]]){for(var i=0;i<sel_padding_unit[OxO442c[48]][OxO442c[1]];i++){var Ox13b=sel_padding_unit[OxO442c[48]][i][OxO442c[36]];if(Ox13b&&Ox5cd.indexOf(Ox13b)!=-1){sel_padding_unit[OxO442c[39]]=i;break ;} ;} ;} ;} ;SyncTo=function SyncTo_Border(element){var Ox4c1=sel_part[OxO442c[36]];var Ox4c2=Ox4c1?OxO442c[41]+Ox4c1:Ox4c1;var Ox4c3=OxO442c[2];if(sel_border[OxO442c[39]]>0){Ox4c3=sel_border[OxO442c[36]];} else {if(ParseFloatToString(tb_border.value)){Ox4c3=ParseFloatToString(tb_border.value)+sel_border_unit[OxO442c[36]];} else {Ox4c3=OxO442c[2];} ;} ;var Oxd5=inp_color[OxO442c[36]]||OxO442c[2];var Ox130=sel_style[OxO442c[36]]||OxO442c[2];if(Ox4c3||Ox130){SetStyle(element.style,OxO442c[31]+Ox4c2,Ox4c3+OxO442c[43]+Ox130+OxO442c[43]+Oxd5);} else {SetStyle(element.style,OxO442c[31]+Ox4c2,OxO442c[2]);} ;SetStyle(element.style,OxO442c[49]+Ox4c2,ParseFloatToString(tb_margin.value),sel_margin_unit.value);SetStyle(element.style,OxO442c[50]+Ox4c2,ParseFloatToString(tb_padding.value),sel_padding_unit.value);} ;inp_color[OxO442c[35]]=inp_color_Preview[OxO442c[35]]=function inp_color_onclick(){SelectColor(inp_color,inp_color_Preview);} ;