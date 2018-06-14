var ShopstartX = document.body.clientWidth-170;
var ShopstartY = 450;
var verticalpos='fromtop';
var winWidth = 0;
function iecompattest(){
   return (document.compatMode && document.compatMode!='BackCompat')? document.documentElement : document.body
}
function ShopServicePannelstaticbar(){
	if (window.innerWidth)
	winWidth = window.innerWidth;
	else if ((document.body) && (document.body.clientWidth))
	winWidth = document.body.clientWidth;
	if (document.documentElement && document.documentElement.clientWidth){winWidth = document.documentElement.clientWidth;}
	ShopstartX = winWidth-170;
	barheight=document.getElementById('divShopServicePannel').offsetHeight
	var ns = (navigator.appName.indexOf('Netscape') != -1) || window.opera;
	var d = document;
	function ml(id){
		var el=d.getElementById(id);
		el.style.visibility='visible'
		if(d.layers)el.style=el;
		el.sP=function(x,y){this.style.left=x+'px';this.style.top=y+'px';};
		el.x = ShopstartX;
		if (verticalpos=='fromtop')
		el.y = ShopstartY;
		else{
		el.y = ns ? pageYOffset + innerHeight : iecompattest().scrollTop + iecompattest().clientHeight;
		el.y -= ShopstartY;
		}
		return el;
	}
	window.ShopServicePannel=function(){
		if (verticalpos=='fromtop'){
		var pY = ns ? pageYOffset : iecompattest().scrollTop;
		ftlObj.y += (pY + ShopstartY - ftlObj.y)/8;
		}
		else{
		var pY = ns ? pageYOffset + innerHeight - barheight: iecompattest().scrollTop + iecompattest().clientHeight - barheight;
		ftlObj.y += (pY - ShopstartY - ftlObj.y)/8;
		}
		ftlObj.sP(ftlObj.x, ftlObj.y);
		setTimeout('stayTopLeft()', 10);
	}
	ftlObj = ml('ShopServicePannel');
	ShopServicePannel();
}
if(typeof(HTMLElement)!='undefined'){
  HTMLElement.prototype.contains=function (obj)
  {
	  while(obj!=null&&typeof(obj.tagName)!='undefind'){
　 　 if(obj==this) return true;
　　	　obj=obj.parentNode;
　	  }
	  return false;
  }
}
if (window.addEventListener)
window.addEventListener('load', ShopServicePannelstaticbar, false)
else if (window.attachEvent)
window.attachEvent('onload', ShopServicePannelstaticbar)
else if (document.getElementById)
window.onload=ShopServicePannelstaticbar;
window.onresize=ShopServicePannelstaticbar;
function ShopServicePannelOver(){
   document.getElementById('ShopServicePannelMenu').style.display = 'none';
   document.getElementById('ShopServicePannelOnline').style.display = 'block';
   document.getElementById('divShopServicePannel').style.width = '170px';
}
function ShopServicePannelOut(){
   document.getElementById('ShopServicePannelMenu').style.display = 'block';
   document.getElementById('ShopServicePannelOnline').style.display = 'none';
}
if(typeof(HTMLElement)!='undefined') 
{
   HTMLElement.prototype.contains=function(obj)
   {
       while(obj!=null&&typeof(obj.tagName)!='undefind'){
   　　　 if(obj==this) return true;
   　　　 obj=obj.parentNode;
   　　}
          return false;
   };
}
function ShowShopServicePannel(theEvent){
　 if (theEvent){
　    var browser=navigator.userAgent;
　	if (browser.indexOf('Firefox')>0){
　　     if (document.getElementById('ShopServicePannelOnline').contains(theEvent.relatedTarget)) {
　　         return;
         }
      }
	    if (browser.indexOf('MSIE')>0 || browser.indexOf('Safari')>0){ //IE Safari
          if (document.getElementById('ShopServicePannelOnline').contains(event.toElement)) {
	          return;
          }
      }
   }
   document.getElementById('ShopServicePannelMenu').style.display = 'block';
   document.getElementById('ShopServicePannelOnline').style.display = 'none';
}