var OxOa66e=["inp_type","inp_name","inp_value","row_txt1","inp_Size","row_txt2","inp_MaxLength","row_img","inp_src","btnbrowse","row_img2","sel_Align","optNotSet","optLeft","optRight","optTexttop","optAbsMiddle","optBaseline","optAbsBottom","optBottom","optMiddle","optTop","inp_Border","row_img3","inp_width","inp_height","row_img4","inp_HSpace","inp_VSpace","row_img5","AlternateText","inp_id","row_txt3","inp_access","row_txt4","inp_index","row_chk","inp_checked","row_txt5","inp_Disabled","row_txt6","inp_Readonly","onclick","value","Name","name","id","src","type","checked","disabled","readOnly","tabIndex","","accessKey","size","maxLength","width","height","vspace","hspace","border","align","alt","text","display","style","none","password","hidden","radio","checkbox","submit","reset","button","image","className","class"];var inp_type=Window_GetElement(window,OxOa66e[0],true);var inp_name=Window_GetElement(window,OxOa66e[1],true);var inp_value=Window_GetElement(window,OxOa66e[2],true);var row_txt1=Window_GetElement(window,OxOa66e[3],true);var inp_Size=Window_GetElement(window,OxOa66e[4],true);var row_txt2=Window_GetElement(window,OxOa66e[5],true);var inp_MaxLength=Window_GetElement(window,OxOa66e[6],true);var row_img=Window_GetElement(window,OxOa66e[7],true);var inp_src=Window_GetElement(window,OxOa66e[8],true);var btnbrowse=Window_GetElement(window,OxOa66e[9],true);var row_img2=Window_GetElement(window,OxOa66e[10],true);var sel_Align=Window_GetElement(window,OxOa66e[11],true);var optNotSet=Window_GetElement(window,OxOa66e[12],true);var optLeft=Window_GetElement(window,OxOa66e[13],true);var optRight=Window_GetElement(window,OxOa66e[14],true);var optTexttop=Window_GetElement(window,OxOa66e[15],true);var optAbsMiddle=Window_GetElement(window,OxOa66e[16],true);var optBaseline=Window_GetElement(window,OxOa66e[17],true);var optAbsBottom=Window_GetElement(window,OxOa66e[18],true);var optBottom=Window_GetElement(window,OxOa66e[19],true);var optMiddle=Window_GetElement(window,OxOa66e[20],true);var optTop=Window_GetElement(window,OxOa66e[21],true);var inp_Border=Window_GetElement(window,OxOa66e[22],true);var row_img3=Window_GetElement(window,OxOa66e[23],true);var inp_width=Window_GetElement(window,OxOa66e[24],true);var inp_height=Window_GetElement(window,OxOa66e[25],true);var row_img4=Window_GetElement(window,OxOa66e[26],true);var inp_HSpace=Window_GetElement(window,OxOa66e[27],true);var inp_VSpace=Window_GetElement(window,OxOa66e[28],true);var row_img5=Window_GetElement(window,OxOa66e[29],true);var AlternateText=Window_GetElement(window,OxOa66e[30],true);var inp_id=Window_GetElement(window,OxOa66e[31],true);var row_txt3=Window_GetElement(window,OxOa66e[32],true);var inp_access=Window_GetElement(window,OxOa66e[33],true);var row_txt4=Window_GetElement(window,OxOa66e[34],true);var inp_index=Window_GetElement(window,OxOa66e[35],true);var row_chk=Window_GetElement(window,OxOa66e[36],true);var inp_checked=Window_GetElement(window,OxOa66e[37],true);var row_txt5=Window_GetElement(window,OxOa66e[38],true);var inp_Disabled=Window_GetElement(window,OxOa66e[39],true);var row_txt6=Window_GetElement(window,OxOa66e[40],true);var inp_Readonly=Window_GetElement(window,OxOa66e[41],true);btnbrowse[OxOa66e[42]]=function btnbrowse_onclick(){function Ox354(Ox137){if(Ox137){inp_src[OxOa66e[43]]=Ox137;SyncTo(element);} ;} ;editor.SetNextDialogWindow(window);if(Browser_IsSafari()){editor.ShowSelectImageDialog(Ox354,inp_src.value,inp_src);} else {editor.ShowSelectImageDialog(Ox354,inp_src.value);} ;} ;UpdateState=function UpdateState_Input(){} ;SyncToView=function SyncToView_Input(){if(element[OxOa66e[44]]){inp_name[OxOa66e[43]]=element[OxOa66e[44]];} ;if(element[OxOa66e[45]]){inp_name[OxOa66e[43]]=element[OxOa66e[45]];} ;inp_id[OxOa66e[43]]=element[OxOa66e[46]];inp_value[OxOa66e[43]]=(element[OxOa66e[43]]).trim();inp_src[OxOa66e[43]]=element[OxOa66e[47]];inp_type[OxOa66e[43]]=element[OxOa66e[48]];inp_checked[OxOa66e[49]]=element[OxOa66e[49]];inp_Disabled[OxOa66e[49]]=element[OxOa66e[50]];inp_Readonly[OxOa66e[49]]=element[OxOa66e[51]];if(element[OxOa66e[52]]==0){inp_index[OxOa66e[43]]=OxOa66e[53];} else {inp_index[OxOa66e[43]]=element[OxOa66e[52]];} ;if(element[OxOa66e[54]]){inp_access[OxOa66e[43]]=element[OxOa66e[54]];} ;if(element[OxOa66e[55]]){if(element[OxOa66e[55]]==20){inp_Size[OxOa66e[43]]=OxOa66e[53];} else {inp_Size[OxOa66e[43]]=element[OxOa66e[55]];} ;} ;if(element[OxOa66e[56]]){if(element[OxOa66e[56]]==2147483647||element[OxOa66e[56]]<=0){inp_MaxLength[OxOa66e[43]]=OxOa66e[53];} else {inp_MaxLength[OxOa66e[43]]=element[OxOa66e[56]];} ;} ;if(element[OxOa66e[57]]){inp_width[OxOa66e[43]]=element[OxOa66e[57]];} ;if(element[OxOa66e[58]]){inp_height[OxOa66e[43]]=element[OxOa66e[58]];} ;if(element[OxOa66e[59]]){inp_HSpace[OxOa66e[43]]=element[OxOa66e[59]];} ;if(element[OxOa66e[60]]){inp_VSpace[OxOa66e[43]]=element[OxOa66e[60]];} ;if(element[OxOa66e[61]]){inp_Border[OxOa66e[43]]=element[OxOa66e[61]];} ;if(element[OxOa66e[62]]){sel_Align[OxOa66e[43]]=element[OxOa66e[62]];} ;if(element[OxOa66e[63]]){alt[OxOa66e[43]]=element[OxOa66e[63]];} ;switch((element[OxOa66e[48]]).toLowerCase()){case OxOa66e[64]:;case OxOa66e[68]:row_img[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img2[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img3[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img4[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img5[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_chk[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];break ;;case OxOa66e[69]:row_img[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img2[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img3[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img4[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img5[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_chk[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt1[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt2[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt3[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt4[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt5[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt6[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];break ;;case OxOa66e[70]:;case OxOa66e[71]:row_img[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img2[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img3[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img4[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img5[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt1[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt2[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt6[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];break ;;case OxOa66e[72]:;case OxOa66e[73]:;case OxOa66e[74]:row_chk[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img2[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img3[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img4[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_img5[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt1[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt2[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt6[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];break ;;case OxOa66e[75]:row_chk[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt1[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt2[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];row_txt6[OxOa66e[66]][OxOa66e[65]]=OxOa66e[67];break ;;} ;} ;SyncTo=function SyncTo_Input(element){element[OxOa66e[45]]=inp_name[OxOa66e[43]];if(element[OxOa66e[44]]){element[OxOa66e[44]]=inp_name[OxOa66e[43]];} else {if(element[OxOa66e[45]]){element.removeAttribute(OxOa66e[45],0);element[OxOa66e[44]]=inp_name[OxOa66e[43]];} else {element[OxOa66e[44]]=inp_name[OxOa66e[43]];} ;} ;element[OxOa66e[46]]=inp_id[OxOa66e[43]];if(inp_src[OxOa66e[43]]){element[OxOa66e[47]]=inp_src[OxOa66e[43]];} ;element[OxOa66e[49]]=inp_checked[OxOa66e[49]];element[OxOa66e[43]]=inp_value[OxOa66e[43]];element.setAttribute(OxOa66e[43],inp_value.value);element[OxOa66e[50]]=inp_Disabled[OxOa66e[49]];element[OxOa66e[51]]=inp_Readonly[OxOa66e[49]];element[OxOa66e[54]]=inp_access[OxOa66e[43]];element[OxOa66e[52]]=inp_index[OxOa66e[43]];element[OxOa66e[56]]=inp_MaxLength[OxOa66e[43]];element[OxOa66e[57]]=inp_width[OxOa66e[43]];element[OxOa66e[58]]=inp_height[OxOa66e[43]];element[OxOa66e[59]]=inp_HSpace[OxOa66e[43]];element[OxOa66e[60]]=inp_VSpace[OxOa66e[43]];element[OxOa66e[61]]=inp_Border[OxOa66e[43]];element[OxOa66e[62]]=sel_Align[OxOa66e[43]];element[OxOa66e[63]]=AlternateText[OxOa66e[43]];try{element[OxOa66e[55]]=inp_Size[OxOa66e[43]];} catch(e){element[OxOa66e[55]]=20;} ;if(element[OxOa66e[52]]==OxOa66e[53]){element.removeAttribute(OxOa66e[52]);} ;if(element[OxOa66e[54]]==OxOa66e[53]){element.removeAttribute(OxOa66e[54]);} ;if(element[OxOa66e[56]]==OxOa66e[53]){element.removeAttribute(OxOa66e[56]);} ;if(element[OxOa66e[55]]==0){element.removeAttribute(OxOa66e[55]);} ;if(element[OxOa66e[57]]==0){element.removeAttribute(OxOa66e[57]);} ;if(element[OxOa66e[58]]==0){element.removeAttribute(OxOa66e[58]);} ;if(element[OxOa66e[60]]==OxOa66e[53]){element.removeAttribute(OxOa66e[60]);} ;if(element[OxOa66e[59]]==OxOa66e[53]){element.removeAttribute(OxOa66e[59]);} ;if(element[OxOa66e[46]]==OxOa66e[53]){element.removeAttribute(OxOa66e[46]);} ;if(element[OxOa66e[44]]==OxOa66e[53]){element.removeAttribute(OxOa66e[44]);} ;if(element[OxOa66e[63]]==OxOa66e[53]){element.removeAttribute(OxOa66e[63]);} ;if(element[OxOa66e[62]]==OxOa66e[53]){element.removeAttribute(OxOa66e[62]);} ;if(element[OxOa66e[76]]==OxOa66e[53]){element.removeAttribute(OxOa66e[77]);} ;if(element[OxOa66e[76]]==OxOa66e[53]){element.removeAttribute(OxOa66e[76]);} ;switch((element[OxOa66e[48]]).toLowerCase()){case OxOa66e[64]:;case OxOa66e[68]:;case OxOa66e[69]:;case OxOa66e[70]:;case OxOa66e[71]:;case OxOa66e[72]:;case OxOa66e[73]:;case OxOa66e[74]:element.removeAttribute(OxOa66e[58]);element.removeAttribute(OxOa66e[61]);element.removeAttribute(OxOa66e[47]);break ;;case OxOa66e[75]:break ;;} ;} ;