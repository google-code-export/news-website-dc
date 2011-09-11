<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<script runat="server">
string GetDialogQueryString;
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["Dialog"]=="Standard")
	{	
	if(Context.Request.QueryString["IsFrame"]==null)
	{
		string FrameSrc="colorpicker_basic.aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
		CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[MoreColors]]",FrameSrc);
		Context.Response.End();
	}
	}
	string s="";
	if(Context.Request.QueryString["Dialog"]=="Standard")	
		s="&Dialog=Standard";
	
	GetDialogQueryString="Theme="+Context.Request.QueryString["Theme"]+s;	
	base.OnInit(args);
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<script type="text/javascript" src="Load.ashx?type=dialogscript&file=DialogHead.js"></script>
		<script type="text/javascript" src="Load.ashx?type=dialogscript&file=Dialog_ColorPicker.js"></script>
		<link href='Load.ashx?type=themecss&file=dialog.css&theme=[[_Theme_]]' type="text/css"
			rel="stylesheet" />
		<style type="text/css">
			.colorcell
			{
				width:16px;
				height:17px;
				cursor:hand;
			}
			.colordiv,.customdiv
			{
				border:solid 1px #808080;
				width:16px;
				height:17px;
				font-size:1px;
			}
		</style>
		<title>[[NamedColors]]</title>
		<script>
								
		var OxO13f4=["Green","#008000","Lime","#00FF00","Teal","#008080","Aqua","#00FFFF","Navy","#000080","Blue","#0000FF","Purple","#800080","Fuchsia","#FF00FF","Maroon","#800000","Red","#FF0000","Olive","#808000","Yellow","#FFFF00","White","#FFFFFF","Silver","#C0C0C0","Gray","#808080","Black","#000000","DarkOliveGreen","#556B2F","DarkGreen","#006400","DarkSlateGray","#2F4F4F","SlateGray","#708090","DarkBlue","#00008B","MidnightBlue","#191970","Indigo","#4B0082","DarkMagenta","#8B008B","Brown","#A52A2A","DarkRed","#8B0000","Sienna","#A0522D","SaddleBrown","#8B4513","DarkGoldenrod","#B8860B","Beige","#F5F5DC","HoneyDew","#F0FFF0","DimGray","#696969","OliveDrab","#6B8E23","ForestGreen","#228B22","DarkCyan","#008B8B","LightSlateGray","#778899","MediumBlue","#0000CD","DarkSlateBlue","#483D8B","DarkViolet","#9400D3","MediumVioletRed","#C71585","IndianRed","#CD5C5C","Firebrick","#B22222","Chocolate","#D2691E","Peru","#CD853F","Goldenrod","#DAA520","LightGoldenrodYellow","#FAFAD2","MintCream","#F5FFFA","DarkGray","#A9A9A9","YellowGreen","#9ACD32","SeaGreen","#2E8B57","CadetBlue","#5F9EA0","SteelBlue","#4682B4","RoyalBlue","#4169E1","BlueViolet","#8A2BE2","DarkOrchid","#9932CC","DeepPink","#FF1493","RosyBrown","#BC8F8F","Crimson","#DC143C","DarkOrange","#FF8C00","BurlyWood","#DEB887","DarkKhaki","#BDB76B","LightYellow","#FFFFE0","Azure","#F0FFFF","LightGray","#D3D3D3","LawnGreen","#7CFC00","MediumSeaGreen","#3CB371","LightSeaGreen","#20B2AA","DeepSkyBlue","#00BFFF","DodgerBlue","#1E90FF","SlateBlue","#6A5ACD","MediumOrchid","#BA55D3","PaleVioletRed","#DB7093","Salmon","#FA8072","OrangeRed","#FF4500","SandyBrown","#F4A460","Tan","#D2B48C","Gold","#FFD700","Ivory","#FFFFF0","GhostWhite","#F8F8FF","Gainsboro","#DCDCDC","Chartreuse","#7FFF00","LimeGreen","#32CD32","MediumAquamarine","#66CDAA","DarkTurquoise","#00CED1","CornflowerBlue","#6495ED","MediumSlateBlue","#7B68EE","Orchid","#DA70D6","HotPink","#FF69B4","LightCoral","#F08080","Tomato","#FF6347","Orange","#FFA500","Bisque","#FFE4C4","Khaki","#F0E68C","Cornsilk","#FFF8DC","Linen","#FAF0E6","WhiteSmoke","#F5F5F5","GreenYellow","#ADFF2F","DarkSeaGreen","#8FBC8B","Turquoise","#40E0D0","MediumTurquoise","#48D1CC","SkyBlue","#87CEEB","MediumPurple","#9370DB","Violet","#EE82EE","LightPink","#FFB6C1","DarkSalmon","#E9967A","Coral","#FF7F50","NavajoWhite","#FFDEAD","BlanchedAlmond","#FFEBCD","PaleGoldenrod","#EEE8AA","Oldlace","#FDF5E6","Seashell","#FFF5EE","PaleGreen","#98FB98","SpringGreen","#00FF7F","Aquamarine","#7FFFD4","PowderBlue","#B0E0E6","LightSkyBlue","#87CEFA","LightSteelBlue","#B0C4DE","Plum","#DDA0DD","Pink","#FFC0CB","LightSalmon","#FFA07A","Wheat","#F5DEB3","Moccasin","#FFE4B5","AntiqueWhite","#FAEBD7","LemonChiffon","#FFFACD","FloralWhite","#FFFAF0","Snow","#FFFAFA","AliceBlue","#F0F8FF","LightGreen","#90EE90","MediumSpringGreen","#00FA9A","PaleTurquoise","#AFEEEE","LightCyan","#E0FFFF","LightBlue","#ADD8E6","Lavender","#E6E6FA","Thistle","#D8BFD8","MistyRose","#FFE4E1","Peachpuff","#FFDAB9","PapayaWhip","#FFEFD5"];var colorlist=[{n:OxO13f4[0],h:OxO13f4[1]},{n:OxO13f4[2],h:OxO13f4[3]},{n:OxO13f4[4],h:OxO13f4[5]},{n:OxO13f4[6],h:OxO13f4[7]},{n:OxO13f4[8],h:OxO13f4[9]},{n:OxO13f4[10],h:OxO13f4[11]},{n:OxO13f4[12],h:OxO13f4[13]},{n:OxO13f4[14],h:OxO13f4[15]},{n:OxO13f4[16],h:OxO13f4[17]},{n:OxO13f4[18],h:OxO13f4[19]},{n:OxO13f4[20],h:OxO13f4[21]},{n:OxO13f4[22],h:OxO13f4[23]},{n:OxO13f4[24],h:OxO13f4[25]},{n:OxO13f4[26],h:OxO13f4[27]},{n:OxO13f4[28],h:OxO13f4[29]},{n:OxO13f4[30],h:OxO13f4[31]}];var colormore=[{n:OxO13f4[32],h:OxO13f4[33]},{n:OxO13f4[34],h:OxO13f4[35]},{n:OxO13f4[36],h:OxO13f4[37]},{n:OxO13f4[38],h:OxO13f4[39]},{n:OxO13f4[40],h:OxO13f4[41]},{n:OxO13f4[42],h:OxO13f4[43]},{n:OxO13f4[44],h:OxO13f4[45]},{n:OxO13f4[46],h:OxO13f4[47]},{n:OxO13f4[48],h:OxO13f4[49]},{n:OxO13f4[50],h:OxO13f4[51]},{n:OxO13f4[52],h:OxO13f4[53]},{n:OxO13f4[54],h:OxO13f4[55]},{n:OxO13f4[56],h:OxO13f4[57]},{n:OxO13f4[58],h:OxO13f4[59]},{n:OxO13f4[60],h:OxO13f4[61]},{n:OxO13f4[62],h:OxO13f4[63]},{n:OxO13f4[64],h:OxO13f4[65]},{n:OxO13f4[66],h:OxO13f4[67]},{n:OxO13f4[68],h:OxO13f4[69]},{n:OxO13f4[70],h:OxO13f4[71]},{n:OxO13f4[72],h:OxO13f4[73]},{n:OxO13f4[74],h:OxO13f4[75]},{n:OxO13f4[76],h:OxO13f4[77]},{n:OxO13f4[78],h:OxO13f4[79]},{n:OxO13f4[80],h:OxO13f4[81]},{n:OxO13f4[82],h:OxO13f4[83]},{n:OxO13f4[84],h:OxO13f4[85]},{n:OxO13f4[86],h:OxO13f4[87]},{n:OxO13f4[88],h:OxO13f4[89]},{n:OxO13f4[90],h:OxO13f4[91]},{n:OxO13f4[92],h:OxO13f4[93]},{n:OxO13f4[94],h:OxO13f4[95]},{n:OxO13f4[96],h:OxO13f4[97]},{n:OxO13f4[98],h:OxO13f4[99]},{n:OxO13f4[100],h:OxO13f4[101]},{n:OxO13f4[102],h:OxO13f4[103]},{n:OxO13f4[104],h:OxO13f4[105]},{n:OxO13f4[106],h:OxO13f4[107]},{n:OxO13f4[108],h:OxO13f4[109]},{n:OxO13f4[110],h:OxO13f4[111]},{n:OxO13f4[112],h:OxO13f4[113]},{n:OxO13f4[114],h:OxO13f4[115]},{n:OxO13f4[116],h:OxO13f4[117]},{n:OxO13f4[118],h:OxO13f4[119]},{n:OxO13f4[120],h:OxO13f4[121]},{n:OxO13f4[122],h:OxO13f4[123]},{n:OxO13f4[124],h:OxO13f4[125]},{n:OxO13f4[126],h:OxO13f4[127]},{n:OxO13f4[128],h:OxO13f4[129]},{n:OxO13f4[130],h:OxO13f4[131]},{n:OxO13f4[132],h:OxO13f4[133]},{n:OxO13f4[134],h:OxO13f4[135]},{n:OxO13f4[136],h:OxO13f4[137]},{n:OxO13f4[138],h:OxO13f4[139]},{n:OxO13f4[140],h:OxO13f4[141]},{n:OxO13f4[142],h:OxO13f4[143]},{n:OxO13f4[144],h:OxO13f4[145]},{n:OxO13f4[146],h:OxO13f4[147]},{n:OxO13f4[148],h:OxO13f4[149]},{n:OxO13f4[150],h:OxO13f4[151]},{n:OxO13f4[152],h:OxO13f4[153]},{n:OxO13f4[154],h:OxO13f4[155]},{n:OxO13f4[156],h:OxO13f4[157]},{n:OxO13f4[158],h:OxO13f4[159]},{n:OxO13f4[160],h:OxO13f4[161]},{n:OxO13f4[162],h:OxO13f4[163]},{n:OxO13f4[164],h:OxO13f4[165]},{n:OxO13f4[166],h:OxO13f4[167]},{n:OxO13f4[168],h:OxO13f4[169]},{n:OxO13f4[170],h:OxO13f4[171]},{n:OxO13f4[172],h:OxO13f4[173]},{n:OxO13f4[174],h:OxO13f4[175]},{n:OxO13f4[176],h:OxO13f4[177]},{n:OxO13f4[178],h:OxO13f4[179]},{n:OxO13f4[180],h:OxO13f4[181]},{n:OxO13f4[182],h:OxO13f4[183]},{n:OxO13f4[184],h:OxO13f4[185]},{n:OxO13f4[186],h:OxO13f4[187]},{n:OxO13f4[188],h:OxO13f4[189]},{n:OxO13f4[190],h:OxO13f4[191]},{n:OxO13f4[192],h:OxO13f4[193]},{n:OxO13f4[194],h:OxO13f4[195]},{n:OxO13f4[196],h:OxO13f4[197]},{n:OxO13f4[198],h:OxO13f4[199]},{n:OxO13f4[200],h:OxO13f4[201]},{n:OxO13f4[202],h:OxO13f4[203]},{n:OxO13f4[204],h:OxO13f4[205]},{n:OxO13f4[206],h:OxO13f4[207]},{n:OxO13f4[208],h:OxO13f4[209]},{n:OxO13f4[210],h:OxO13f4[211]},{n:OxO13f4[212],h:OxO13f4[213]},{n:OxO13f4[214],h:OxO13f4[215]},{n:OxO13f4[216],h:OxO13f4[217]},{n:OxO13f4[218],h:OxO13f4[219]},{n:OxO13f4[220],h:OxO13f4[221]},{n:OxO13f4[156],h:OxO13f4[157]},{n:OxO13f4[222],h:OxO13f4[223]},{n:OxO13f4[224],h:OxO13f4[225]},{n:OxO13f4[226],h:OxO13f4[227]},{n:OxO13f4[228],h:OxO13f4[229]},{n:OxO13f4[230],h:OxO13f4[231]},{n:OxO13f4[232],h:OxO13f4[233]},{n:OxO13f4[234],h:OxO13f4[235]},{n:OxO13f4[236],h:OxO13f4[237]},{n:OxO13f4[238],h:OxO13f4[239]},{n:OxO13f4[240],h:OxO13f4[241]},{n:OxO13f4[242],h:OxO13f4[243]},{n:OxO13f4[244],h:OxO13f4[245]},{n:OxO13f4[246],h:OxO13f4[247]},{n:OxO13f4[248],h:OxO13f4[249]},{n:OxO13f4[250],h:OxO13f4[251]},{n:OxO13f4[252],h:OxO13f4[253]},{n:OxO13f4[254],h:OxO13f4[255]},{n:OxO13f4[256],h:OxO13f4[257]},{n:OxO13f4[258],h:OxO13f4[259]},{n:OxO13f4[260],h:OxO13f4[261]},{n:OxO13f4[262],h:OxO13f4[263]},{n:OxO13f4[264],h:OxO13f4[265]},{n:OxO13f4[266],h:OxO13f4[267]},{n:OxO13f4[268],h:OxO13f4[269]},{n:OxO13f4[270],h:OxO13f4[271]},{n:OxO13f4[272],h:OxO13f4[273]}];
		
		</script>
	</head>
	<body>
		<div id="container">
			<div class="tab-pane-control tab-pane" id="tabPane1">
				<div class="tab-row">
					<h2 class="tab">
						<a tabindex="-1" href='colorpicker.aspx?<%=GetDialogQueryString%>'>
							<span style="white-space:nowrap;">
								[[WebPalette]]
							</span>
						</a>
					</h2>
					<h2 class="tab selected">
							<a tabindex="-1" href='colorpicker_basic.aspx?<%=GetDialogQueryString%>'>
								<span style="white-space:nowrap;">
									[[NamedColors]]
								</span>
							</a>
					</h2>
					<h2 class="tab">
							<a tabindex="-1" href='colorpicker_more.aspx?<%=GetDialogQueryString%>'>
								<span style="white-space:nowrap;">
									[[CustomColor]]
								</span>
							</a>
					</h2>
				</div>
				<div class="tab-page">			
					<table class="colortable" align="center">
						<tr>
							<td colspan="16" height="16"><p align="left">Basic:
								</p>
							</td>
						</tr>
						<tr>
							<script>
								var OxO3398=["length","\x3Ctd class=\x27colorcell\x27\x3E\x3Cdiv class=\x27colordiv\x27 style=\x27background-color:","\x27 title=\x27"," ","\x27 cname=\x27","\x27 cvalue=\x27","\x27\x3E\x3C/div\x3E\x3C/td\x3E",""];var arr=[];for(var i=0;i<colorlist[OxO3398[0]];i++){arr.push(OxO3398[1]);arr.push(colorlist[i].n);arr.push(OxO3398[2]);arr.push(colorlist[i].n);arr.push(OxO3398[3]);arr.push(colorlist[i].h);arr.push(OxO3398[4]);arr.push(colorlist[i].n);arr.push(OxO3398[5]);arr.push(colorlist[i].h);arr.push(OxO3398[6]);} ;document.write(arr.join(OxO3398[7]));
							</script>
						</tr>
						<tr>
							<td colspan="16" height="12"><p align="left"></p>
							</td>
						</tr>
						<tr>
							<td colspan="16"><p align="left">Additional:
								</p>
							</td>
						</tr>
						<script>
							var OxOe1c8=["length","\x3Ctr\x3E","\x3Ctd class=\x27colorcell\x27\x3E\x3Cdiv class=\x27colordiv\x27 style=\x27background-color:","\x27 title=\x27"," ","\x27 cname=\x27","\x27 cvalue=\x27","\x27\x3E\x3C/div\x3E\x3C/td\x3E","\x3C/tr\x3E",""];var arr=[];for(var i=0;i<colormore[OxOe1c8[0]];i++){if(i%16==0){arr.push(OxOe1c8[1]);} ;arr.push(OxOe1c8[2]);arr.push(colormore[i].n);arr.push(OxOe1c8[3]);arr.push(colormore[i].n);arr.push(OxOe1c8[4]);arr.push(colormore[i].h);arr.push(OxOe1c8[5]);arr.push(colormore[i].n);arr.push(OxOe1c8[6]);arr.push(colormore[i].h);arr.push(OxOe1c8[7]);if(i%16==15){arr.push(OxOe1c8[8]);} ;} ;if(colormore%16>0){arr.push(OxOe1c8[8]);} ;document.write(arr.join(OxOe1c8[9]));
						</script>
						<tr>
							<td colspan="16" height="8">
							</td>
						</tr>
						<tr>
							<td colspan="16" height="12">
								<input checked id="CheckboxColorNames" style="width: 16px; height: 20px" type="checkbox">
								<span style="width: 118px;">Use color names</span>
							</td>
						</tr>
						<tr>
							<td colspan="16" height="12">
							</td>
						</tr>
						<tr>
							<td colspan="16" valign="middle" height="24">
							<span style="height:24px;width:50px;vertical-align:middle;">Color : </span>&nbsp;
							<input type="text" id="divpreview" size="7" maxlength="7" style="width:180px;height:24px;border:#a0a0a0 1px solid; Padding:4;"/>
					
							</td>
						</tr>
				</table>
			</div>
		</div>
		<div id="container-bottom">
			<input type="button" id="buttonok" value="[[OK]]" class="formbutton" style="width:70px"	onclick="do_insert();" /> 
			&nbsp;&nbsp;&nbsp;&nbsp; 
			<input type="button" id="buttoncancel" value="[[Cancel]]" class="formbutton" style="width:70px"	onclick="do_Close();" />	
		</div>
	</div>
	</body>
</html>

