var OxOd893=["formSearch","idSource","inc_width","inc_height","W640","W800","W1024","onload","availWidth","screen","window","availHeight","contentWindow","outerHTML","documentElement","text/html","replace","onresize","value","dialogWidth","dialogHeight","innerWidth","innerHeight","px","dialogTop","dialogLeft","screenY","screenX","checked","contentDocument","document"];var formSearch=Window_GetElement(window,OxOd893[0],true);var idSource=Window_GetElement(window,OxOd893[1],true);var inc_width=Window_GetElement(window,OxOd893[2],true);var inc_height=Window_GetElement(window,OxOd893[3],true);var W640=Window_GetElement(window,OxOd893[4],true);var W800=Window_GetElement(window,OxOd893[5],true);var W1024=Window_GetElement(window,OxOd893[6],true);var ParentW;var ParentH;window[OxOd893[7]]=function window_onload(){ParentW=top[OxOd893[10]][OxOd893[9]][OxOd893[8]];ParentH=top[OxOd893[10]][OxOd893[9]][OxOd893[11]];var iframe=idSource[OxOd893[12]];var editdoc=Window_GetDialogArguments(window);var Oxee;if(Browser_IsWinIE()){Oxee=editdoc[OxOd893[14]][OxOd893[13]];} else {Oxee=outerHTML(editdoc.documentElement);} ;var Ox466=Frame_GetContentDocument(iframe);Ox466.open(OxOd893[15],OxOd893[16]);Ox466.write(Oxee);Ox466.close();ShowSizeInfo();} ;window[OxOd893[17]]=ShowSizeInfo;function ShowSizeInfo(){if(Browser_IsWinIE()){inc_width[OxOd893[18]]=self[OxOd893[19]];inc_height[OxOd893[18]]=self[OxOd893[20]];} else {inc_width[OxOd893[18]]=self[OxOd893[21]];inc_height[OxOd893[18]]=self[OxOd893[22]];} ;} ;function do_Close(){Window_CloseDialog(window);} ;function ResizeThis(Oxda,Ox2b){if(Browser_IsWinIE()){self[OxOd893[19]]=Oxda+OxOd893[23];self[OxOd893[20]]=Ox2b+OxOd893[23];var Ox469=ParentW/2-Oxda/2;var Ox232=ParentH/2-Ox2b/2;self[OxOd893[24]]=Ox232+OxOd893[23];self[OxOd893[25]]=Ox469+OxOd893[23];} else {if(Browser_IsGecko()){self[OxOd893[21]]=Oxda;self[OxOd893[22]]=Ox2b;var Ox469=ParentW/2-Oxda/2;var Ox232=ParentH/2-Ox2b/2;self[OxOd893[26]]=Ox232;self[OxOd893[27]]=Ox469;} else {window.resizeTo(Oxda,Ox2b);if((screen[OxOd893[8]]-Oxda>0)&&(screen[OxOd893[11]]-Ox2b>0)){window.moveTo((screen[OxOd893[8]]-Oxda)/2,(screen[OxOd893[11]]-Ox2b)/2);} ;} ;} ;switch(Oxda){case 640:W640[OxOd893[28]]=true;break ;;case 800:W800[OxOd893[28]]=true;break ;;case 1024:W1024[OxOd893[28]]=true;break ;;} ;} ;function Frame_GetContentDocument(Ox340){if(Ox340[OxOd893[29]]){return Ox340[OxOd893[29]];} ;return Ox340[OxOd893[30]];} ;