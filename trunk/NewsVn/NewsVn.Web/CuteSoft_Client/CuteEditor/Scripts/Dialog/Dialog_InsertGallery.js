var OxO9c3a=["Form1","FoldersAndFiles","Image1","FolderDescription","cbThumbSize","cbColumns","cbRows","cbTypes","cbSorts","ThumbList1_MyList","ThumbList1_hdnCurPage","ThumbList1_hdnPrevPath","hiddenAlert","lightyellow","0px","-3px","value","","onload","all","getElementById","\x3Cdiv id=\x22tooltipdiv\x22 style=\x22visibility:hidden;background-color:","\x22 \x3E\x3C/div\x3E","tooltipdiv","left","offsetLeft","offsetTop","offsetParent","style","top","visibility","compatMode","BackCompat","documentElement","body","rightedge","opera","scrollLeft","clientWidth","pageXOffset","innerWidth","contentmeasure","offsetWidth","x","scrollTop","clientHeight","pageYOffset","innerHeight","offsetHeight","y","innerHTML","visible","hidden","px","bottomedge","undefined","hidetip()","element","editor","editdoc","^[a-z]*:[/][/][^/]*","IMG","src","width","height","border","alt","product","Gecko","src_cetemp","Edit"];var Form1=Window_GetElement(window,OxO9c3a[0],true);var FoldersAndFiles=Window_GetElement(window,OxO9c3a[1],true);var Image1=Window_GetElement(window,OxO9c3a[2],true);var FolderDescription=Window_GetElement(window,OxO9c3a[3],true);var cbThumbSize=Window_GetElement(window,OxO9c3a[4],true);var cbColumns=Window_GetElement(window,OxO9c3a[5],true);var cbRows=Window_GetElement(window,OxO9c3a[6],true);var cbTypes=Window_GetElement(window,OxO9c3a[7],true);var cbSorts=Window_GetElement(window,OxO9c3a[8],true);var ThumbList1_MyList=Window_GetElement(window,OxO9c3a[9],true);var ThumbList1_hdnCurPage=Window_GetElement(window,OxO9c3a[10],true);var ThumbList1_hdnPrevPath=Window_GetElement(window,OxO9c3a[11],true);var hiddenAlert=Window_GetElement(window,OxO9c3a[12],true);var tipbgcolor=OxO9c3a[13];var disappeardelay=250;var vertical_offset=OxO9c3a[14];var horizontal_offset=OxO9c3a[15];var delayhidetimerid;function reset_hiddens(){if(hiddenAlert[OxO9c3a[16]]){alert(hiddenAlert.value);} ;hiddenAlert[OxO9c3a[16]]=OxO9c3a[17];} ;Event_Attach(window,OxO9c3a[18],reset_hiddens);var ie4=document[OxO9c3a[19]];var ns6=document[OxO9c3a[20]]&&!document[OxO9c3a[19]];if(ie4||ns6){document.write(OxO9c3a[21]+tipbgcolor+OxO9c3a[22]);var dropmenuobj=Window_GetElement(window,OxO9c3a[23],true);} ;function getposOffset(Ox3fb,Ox3fc){var Ox3fd=(Ox3fc==OxO9c3a[24])?Ox3fb[OxO9c3a[25]]:Ox3fb[OxO9c3a[26]];var Ox3fe=Ox3fb[OxO9c3a[27]];while(Ox3fe!=null){Ox3fd+=(Ox3fc==OxO9c3a[24])?Ox3fe[OxO9c3a[25]]:Ox3fe[OxO9c3a[26]];Ox3fe=Ox3fe[OxO9c3a[27]];} ;return Ox3fd;} ;function showhide(obj,Ox400,Ox401){if(ie4||ns6){dropmenuobj[OxO9c3a[28]][OxO9c3a[24]]=dropmenuobj[OxO9c3a[28]][OxO9c3a[29]]=-500;} ;obj[OxO9c3a[30]]=Ox400;} ;function iecompattest(){return (document[OxO9c3a[31]]&&document[OxO9c3a[31]]!=OxO9c3a[32])?document[OxO9c3a[33]]:document[OxO9c3a[34]];} ;function clearbrowseredge(obj,Ox404){var Ox405=(Ox404==OxO9c3a[35])?parseInt(horizontal_offset)*-1:parseInt(vertical_offset)*-1;if(Ox404==OxO9c3a[35]){var Ox406=ie4&&!window[OxO9c3a[36]]?iecompattest()[OxO9c3a[37]]+iecompattest()[OxO9c3a[38]]-15:window[OxO9c3a[39]]+window[OxO9c3a[40]]-15;dropmenuobj[OxO9c3a[41]]=dropmenuobj[OxO9c3a[42]];if(Ox406-dropmenuobj[OxO9c3a[43]]<dropmenuobj[OxO9c3a[41]]){Ox405=dropmenuobj[OxO9c3a[41]]-obj[OxO9c3a[42]];} ;} else {var Ox406=ie4&&!window[OxO9c3a[36]]?iecompattest()[OxO9c3a[44]]+iecompattest()[OxO9c3a[45]]-15:window[OxO9c3a[46]]+window[OxO9c3a[47]]-18;dropmenuobj[OxO9c3a[41]]=dropmenuobj[OxO9c3a[48]];if(Ox406-dropmenuobj[OxO9c3a[49]]<dropmenuobj[OxO9c3a[41]]){Ox405=dropmenuobj[OxO9c3a[41]]+obj[OxO9c3a[48]];} ;} ;return Ox405;} ;function showTooltip(Ox41,obj){Event_CancelEvent();clearhidetip();dropmenuobj[OxO9c3a[50]]=Ox41;if(ie4||ns6){showhide(dropmenuobj.style,OxO9c3a[51],OxO9c3a[52]);dropmenuobj[OxO9c3a[43]]=getposOffset(obj,OxO9c3a[24]);dropmenuobj[OxO9c3a[49]]=getposOffset(obj,OxO9c3a[29]);dropmenuobj[OxO9c3a[28]][OxO9c3a[24]]=dropmenuobj[OxO9c3a[43]]-clearbrowseredge(obj,OxO9c3a[35])+OxO9c3a[53];dropmenuobj[OxO9c3a[28]][OxO9c3a[29]]=dropmenuobj[OxO9c3a[49]]-clearbrowseredge(obj,OxO9c3a[54])+obj[OxO9c3a[48]]*1.1+2+OxO9c3a[53];} ;} ;function hidetip(){if( typeof dropmenuobj!=OxO9c3a[55]){if(ie4||ns6){dropmenuobj[OxO9c3a[28]][OxO9c3a[30]]=OxO9c3a[52];} ;} ;} ;function delayhidetip(){if(ie4||ns6){delayhidetimerid=setTimeout(OxO9c3a[56],disappeardelay);} ;} ;function clearhidetip(){clearTimeout(delayhidetimerid);} ;function cancel(){Window_CloseDialog(window);} ;var obj=Window_GetDialogArguments(window);var element=obj[OxO9c3a[57]];var editor=obj[OxO9c3a[58]];var editdoc=obj[OxO9c3a[59]];function insert(src){if(src){var Ox280=src.replace( new RegExp(OxO9c3a[60],OxO9c3a[17]),OxO9c3a[17]);function Actualsize(){var Ox76=document.createElement(OxO9c3a[61]);Ox76[OxO9c3a[62]]=Ox280;if(Ox76[OxO9c3a[63]]>0&&Ox76[OxO9c3a[64]]>0){element[OxO9c3a[63]]=Ox76[OxO9c3a[63]];element[OxO9c3a[64]]=Ox76[OxO9c3a[64]];} else {setTimeout(Actualsize,400);} ;} ;if(element){element[OxO9c3a[62]]=Ox280;} else {element=editdoc.createElement(OxO9c3a[61]);element[OxO9c3a[62]]=Ox280;element[OxO9c3a[65]]=0;element[OxO9c3a[66]]=OxO9c3a[17];Actualsize();} ;if(navigator[OxO9c3a[67]]==OxO9c3a[68]){try{element.setAttribute(OxO9c3a[69],Ox280);} catch(e){} ;} else {if(editor.GetActiveTab()==OxO9c3a[70]){element.setAttribute(OxO9c3a[69],Ox280);} ;} ;editor.InsertElement(element);Window_CloseDialog(window);} ;} ;