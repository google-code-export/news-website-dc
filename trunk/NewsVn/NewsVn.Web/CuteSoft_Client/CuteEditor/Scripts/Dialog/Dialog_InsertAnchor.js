var OxOe56f=["nodeName","INPUT","TEXTAREA","BUTTON","IMG","SELECT","TABLE","position","style","absolute","relative","|H1|H2|H3|H4|H5|H6|P|PRE|LI|TD|DIV|BLOCKQUOTE|DT|DD|TABLE|HR|IMG|","|","body","document","allanchors","anchor_name","editor","window","name","value","[[ValidName]]","options","length","anchors","OPTION","text","#","images","className","cetempAnchor","anchorname"];function Element_IsBlockControl(element){var name=element[OxOe56f[0]];if(name==OxOe56f[1]){return true;} ;if(name==OxOe56f[2]){return true;} ;if(name==OxOe56f[3]){return true;} ;if(name==OxOe56f[4]){return true;} ;if(name==OxOe56f[5]){return true;} ;if(name==OxOe56f[6]){return true;} ;var Ox11f=element[OxOe56f[8]][OxOe56f[7]];if(Ox11f==OxOe56f[9]||Ox11f==OxOe56f[10]){return true;} ;return false;} ;function Element_CUtil_IsBlock(Ox366){var Ox367=OxOe56f[11];return (Ox366!=null)&&(Ox367.indexOf(OxOe56f[12]+Ox366[OxOe56f[0]]+OxOe56f[12])!=-1);} ;function Window_SelectElement(Ox1a1,element){if(Browser_UseIESelection()){if(Element_IsBlockControl(element)){var Ox2f=Ox1a1[OxOe56f[14]][OxOe56f[13]].createControlRange();Ox2f.add(element);Ox2f.select();} else {var Ox21f=Ox1a1[OxOe56f[14]][OxOe56f[13]].createTextRange();Ox21f.moveToElementText(element);Ox21f.select();} ;} else {var Ox21f=Ox1a1[OxOe56f[14]].createRange();try{Ox21f.selectNode(element);} catch(x){Ox21f.selectNodeContents(element);} ;var Ox12f=Ox1a1.getSelection();Ox12f.removeAllRanges();Ox12f.addRange(Ox21f);} ;} ;var allanchors=Window_GetElement(window,OxOe56f[15],true);var anchor_name=Window_GetElement(window,OxOe56f[16],true);var obj=Window_GetDialogArguments(window);var editor=obj[OxOe56f[17]];var editwin=obj[OxOe56f[18]];var editdoc=obj[OxOe56f[14]];var name=obj[OxOe56f[19]];function insert_link(){var Ox36c=anchor_name[OxOe56f[20]];var Ox36d=/[^a-z\d]/i;if(Ox36d.test(Ox36c)){alert(OxOe56f[21]);} else {Window_SetDialogReturnValue(window,Ox36c);Window_CloseDialog(window);} ;} ;function updateList(){while(allanchors[OxOe56f[22]][OxOe56f[23]]!=0){allanchors[OxOe56f[22]].remove(allanchors.options(0));} ;if(Browser_IsWinIE()){for(var i=0;i<editdoc[OxOe56f[24]][OxOe56f[23]];i++){var Ox36f=document.createElement(OxOe56f[25]);Ox36f[OxOe56f[26]]=OxOe56f[27]+editdoc[OxOe56f[24]][i][OxOe56f[19]];Ox36f[OxOe56f[20]]=editdoc[OxOe56f[24]][i][OxOe56f[19]];allanchors[OxOe56f[22]].add(Ox36f);} ;} else {var Ox370=editdoc[OxOe56f[28]];if(Ox370){for(var j=0;j<Ox370[OxOe56f[23]];j++){var img=Ox370[j];if(img[OxOe56f[29]]==OxOe56f[30]){var Ox36f=document.createElement(OxOe56f[25]);Ox36f[OxOe56f[26]]=OxOe56f[27]+img.getAttribute(OxOe56f[31]);Ox36f[OxOe56f[20]]=img.getAttribute(OxOe56f[31]);allanchors[OxOe56f[22]].add(Ox36f);} ;} ;} ;} ;} ;function selectAnchor(Ox372){editor.FocusDocument();for(var i=0;i<editdoc[OxOe56f[24]][OxOe56f[23]];i++){if(editdoc[OxOe56f[24]][i][OxOe56f[19]]==Ox372){anchor_name[OxOe56f[20]]=Ox372;Window_SelectElement(editwin,editdoc[OxOe56f[24]][i]);} ;} ;} ;if(name){anchor_name[OxOe56f[20]]=name;} ;updateList();