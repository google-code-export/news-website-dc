var OxOd3b9=["inp_width","eenheid","alignment","hrcolor","hrcolorpreview","shade","sel_size","width","style","value","px","%","size","align","color","backgroundColor","noShade","noshade","","onclick"];var inp_width=Window_GetElement(window,OxOd3b9[0],true);var eenheid=Window_GetElement(window,OxOd3b9[1],true);var alignment=Window_GetElement(window,OxOd3b9[2],true);var hrcolor=Window_GetElement(window,OxOd3b9[3],true);var hrcolorpreview=Window_GetElement(window,OxOd3b9[4],true);var shade=Window_GetElement(window,OxOd3b9[5],true);var sel_size=Window_GetElement(window,OxOd3b9[6],true);UpdateState=function UpdateState_Hr(){} ;SyncToView=function SyncToView_Hr(){if(element[OxOd3b9[8]][OxOd3b9[7]]){if(element[OxOd3b9[8]][OxOd3b9[7]].search(/%/)<0){eenheid[OxOd3b9[9]]=OxOd3b9[10];inp_width[OxOd3b9[9]]=element[OxOd3b9[8]][OxOd3b9[7]].split(OxOd3b9[10])[0];} else {eenheid[OxOd3b9[9]]=OxOd3b9[11];inp_width[OxOd3b9[9]]=element[OxOd3b9[8]][OxOd3b9[7]].split(OxOd3b9[11])[0];} ;} ;sel_size[OxOd3b9[9]]=element[OxOd3b9[12]];alignment[OxOd3b9[9]]=element[OxOd3b9[13]];hrcolor[OxOd3b9[9]]=element[OxOd3b9[14]];if(element[OxOd3b9[14]]){hrcolor[OxOd3b9[8]][OxOd3b9[15]]=element[OxOd3b9[14]];} ;if(element[OxOd3b9[16]]){shade[OxOd3b9[9]]=OxOd3b9[17];} else {shade[OxOd3b9[9]]=OxOd3b9[18];} ;} ;SyncTo=function SyncTo_Hr(element){if(sel_size[OxOd3b9[9]]){element[OxOd3b9[12]]=sel_size[OxOd3b9[9]];} ;if(hrcolor[OxOd3b9[9]]){element[OxOd3b9[14]]=hrcolor[OxOd3b9[9]];} ;if(alignment[OxOd3b9[9]]){element[OxOd3b9[13]]=alignment[OxOd3b9[9]];} ;if(shade[OxOd3b9[9]]==OxOd3b9[17]){element[OxOd3b9[16]]=true;} else {element[OxOd3b9[16]]=false;} ;if(inp_width[OxOd3b9[9]]){element[OxOd3b9[8]][OxOd3b9[7]]=inp_width[OxOd3b9[9]]+eenheid[OxOd3b9[9]];} ;} ;hrcolor[OxOd3b9[19]]=hrcolorpreview[OxOd3b9[19]]=function hrcolor_onclick(){SelectColor(hrcolor,hrcolorpreview);} ;