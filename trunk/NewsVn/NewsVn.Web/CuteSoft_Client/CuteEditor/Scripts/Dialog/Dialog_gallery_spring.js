var OxOf7c9=["is_spring_image","1","gid","zIndex","style","srcImg","documentElement","body","getBoundingClientRect","left","top","getBoxObjectFor","x","y","offsetWidth","offsetHeight","offsetLeft","offsetTop","offsetParent","R","width","px","height","M","spring_expand(\x27","id","\x27)","lastActiveElement","spring_collapse(\x27","display","none","copy","parentNode","block","hidetip","IMG","src","url","className","spring_image_popup","void(0)","expand","collapse","onmouseout","onmouseover","onclick","tooltip","click","prototype","MouseEvents","ownerDocument","addEventListener","scroll","attachEvent","onscroll"];function hidetip(){} ;function render_spring_image(Ox27){if(Ox27.getAttribute(OxOf7c9[0])==OxOf7c9[1]){return ;} ;Ox27.setAttribute(OxOf7c9[0],OxOf7c9[1]);render_spring_image[OxOf7c9[2]]=render_spring_image[OxOf7c9[2]]||1;render_spring_image[OxOf7c9[2]]++;function Ox31c(){clearTimeout(this.M);render_spring_image[OxOf7c9[2]]++;this[OxOf7c9[4]][OxOf7c9[3]]=1000000+render_spring_image[OxOf7c9[2]];var Ox31d=this[OxOf7c9[5]];var Ox31e,Ox31f,Ox320,Ox321;Ox320=Math.max(document[OxOf7c9[6]].scrollTop,document[OxOf7c9[7]].scrollTop);Ox321=Math.max(document[OxOf7c9[6]].scrollLeft,document[OxOf7c9[7]].scrollLeft);if(Ox31d[OxOf7c9[8]]){Ox31e=Ox31d.getBoundingClientRect()[OxOf7c9[9]];Ox31f=Ox31d.getBoundingClientRect()[OxOf7c9[10]];} else {if(document[OxOf7c9[11]]){Ox31e=document.getBoxObjectFor(Ox31d)[OxOf7c9[12]]-Ox321;Ox31f=document.getBoxObjectFor(Ox31d)[OxOf7c9[13]]-Ox320;} else {var Ox322=Ox323(Ox31d);Ox31e=Ox322[OxOf7c9[12]]-Ox321;Ox31f=Ox322[OxOf7c9[13]]-Ox320;} ;} ;function Ox323(element){var Ox322={x:0,y:0,width:element[OxOf7c9[14]],height:element[OxOf7c9[15]]};while(element){Ox322[OxOf7c9[12]]+=element[OxOf7c9[16]];Ox322[OxOf7c9[13]]+=element[OxOf7c9[17]];element=element[OxOf7c9[18]];} ;return Ox322;} ;if(this[OxOf7c9[19]]<1.35){this[OxOf7c9[19]]+=0.1;this[OxOf7c9[4]][OxOf7c9[20]]=Math.floor(Ox31d[OxOf7c9[14]]*this[OxOf7c9[19]])+OxOf7c9[21];this[OxOf7c9[4]][OxOf7c9[22]]=Math.floor(Ox31d[OxOf7c9[15]]*this[OxOf7c9[19]])+OxOf7c9[21];Ox31f=Math.floor(Ox31f+Ox320-(this[OxOf7c9[14]]-Ox31d[OxOf7c9[14]])/2)+OxOf7c9[21];;;Ox31e=Math.floor(Ox31e+Ox321-(this[OxOf7c9[15]]-Ox31d[OxOf7c9[15]])/2)+OxOf7c9[21];this[OxOf7c9[4]][OxOf7c9[10]]=Ox31f;this[OxOf7c9[4]][OxOf7c9[9]]=Ox31e;this[OxOf7c9[23]]=setTimeout(OxOf7c9[24]+this[OxOf7c9[25]]+OxOf7c9[26],20);} else {if(render_spring_image[OxOf7c9[27]]!=this){this[OxOf7c9[23]]=setTimeout(OxOf7c9[28]+this[OxOf7c9[25]]+OxOf7c9[26],20);} ;} ;} ;function Ox324(){clearTimeout(this.M);var Ox31d=this[OxOf7c9[5]];var Ox31e,Ox31f,Ox320,Ox321;Ox320=Math.max(document[OxOf7c9[6]].scrollTop,document[OxOf7c9[7]].scrollTop);Ox321=Math.max(document[OxOf7c9[6]].scrollLeft,document[OxOf7c9[7]].scrollLeft);if(Ox31d[OxOf7c9[8]]){Ox31e=Ox31d.getBoundingClientRect()[OxOf7c9[9]];Ox31f=Ox31d.getBoundingClientRect()[OxOf7c9[10]];} else {if(document[OxOf7c9[11]]){Ox31e=document.getBoxObjectFor(Ox31d)[OxOf7c9[12]]-Ox321;Ox31f=document.getBoxObjectFor(Ox31d)[OxOf7c9[13]]-Ox320;} ;} ;if(this[OxOf7c9[19]]>1){this[OxOf7c9[19]]-=0.1;this[OxOf7c9[4]][OxOf7c9[20]]=Math.ceil(Ox31d[OxOf7c9[14]]*this[OxOf7c9[19]])+OxOf7c9[21];this[OxOf7c9[4]][OxOf7c9[22]]=Math.ceil(Ox31d[OxOf7c9[15]]*this[OxOf7c9[19]])+OxOf7c9[21];Ox31f=Math.ceil(Ox31f+Ox320-(this[OxOf7c9[14]]-Ox31d[OxOf7c9[14]])/2)+OxOf7c9[21];;;Ox31e=Math.ceil(Ox31e+Ox321-(this[OxOf7c9[15]]-Ox31d[OxOf7c9[15]])/2)+OxOf7c9[21];this[OxOf7c9[4]][OxOf7c9[10]]=Ox31f;this[OxOf7c9[4]][OxOf7c9[9]]=Ox31e;this[OxOf7c9[23]]=setTimeout(OxOf7c9[28]+this[OxOf7c9[25]]+OxOf7c9[26],0);} else {this[OxOf7c9[4]][OxOf7c9[29]]=OxOf7c9[30];} ;} ;function Ox325(){var Ox326=this[OxOf7c9[31]];if(Ox326[OxOf7c9[32]]==null){document[OxOf7c9[7]].appendChild(Ox326);} ;if((render_spring_image[OxOf7c9[27]]!=null)&&(render_spring_image[OxOf7c9[27]]!=this)){render_spring_image[OxOf7c9[27]][OxOf7c9[23]]=setTimeout(OxOf7c9[28]+render_spring_image[OxOf7c9[27]][OxOf7c9[25]]+OxOf7c9[26],0);} ;render_spring_image[OxOf7c9[27]]=Ox326;Ox326[OxOf7c9[4]][OxOf7c9[29]]=OxOf7c9[33];Ox326.expand();} ;function Ox327(){try{if(window[OxOf7c9[34]]){hidetip();} ;this.collapse();} catch(x){} ;} ;Ox27[OxOf7c9[31]]=document.createElement(OxOf7c9[35]);Ox27[OxOf7c9[31]][OxOf7c9[36]]=Ox27.getAttribute(OxOf7c9[37])||Ox27[OxOf7c9[36]];Ox27[OxOf7c9[31]][OxOf7c9[38]]=OxOf7c9[39];Ox27[OxOf7c9[31]][OxOf7c9[25]]=OxOf7c9[39]+render_spring_image[OxOf7c9[2]];Ox27[OxOf7c9[31]][OxOf7c9[23]]=setTimeout(OxOf7c9[40],0);Ox27[OxOf7c9[31]][OxOf7c9[19]]=1;Ox27[OxOf7c9[31]][OxOf7c9[5]]=Ox27;Ox27[OxOf7c9[31]][OxOf7c9[41]]=Ox31c;Ox27[OxOf7c9[31]][OxOf7c9[42]]=Ox324;Ox27[OxOf7c9[31]][OxOf7c9[43]]=Ox327;Ox27[OxOf7c9[31]][OxOf7c9[44]]=Ox328;Ox27[OxOf7c9[31]][OxOf7c9[45]]=function (){insert(Ox27.getAttribute(OxOf7c9[37]));} ;function Ox328(){var Ox329=Ox27.getAttribute(OxOf7c9[46]);showTooltip(Ox329,this);} ;try{Ox27[OxOf7c9[44]]=Ox325;} catch(x){} ;} ;if(document[OxOf7c9[11]]!=null){HTMLElement[OxOf7c9[48]][OxOf7c9[47]]=function (){var Ox32a=this[OxOf7c9[50]].createEvent(OxOf7c9[49]);Ox32a.initMouseEvent(OxOf7c9[47],true,true,this[OxOf7c9[50]].defaultView,1,0,0,0,0,false,false,false,false,0,null);this.dispatchEvent(Ox32a);} ;} ;function spring_image_scrcoll(){render_spring_image[OxOf7c9[27]]=null;} ;if(window[OxOf7c9[51]]){window.addEventListener(OxOf7c9[52],spring_image_scrcoll,true);} else {if(window[OxOf7c9[53]]){window.attachEvent(OxOf7c9[54],spring_image_scrcoll);} ;} ;function spring_expand(Ox93){var Ox27=document.getElementById(Ox93);if(Ox27){Ox27.expand();} ;} ;function spring_collapse(Ox93){var Ox27=document.getElementById(Ox93);if(Ox27){Ox27.collapse();} ;} ;