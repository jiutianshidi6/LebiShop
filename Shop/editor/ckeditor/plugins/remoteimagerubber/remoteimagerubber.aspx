 <%@ Page Language="C#" %> 
 <%@ Import Namespace="System.Net" %>
<%@ Implements Interface="System.Web.UI.ICallbackEventHandler" %>
 <script runat="server">
     /// <summary>
     /// 此处配置远程文件保存目录
     /// </summary>
     private static readonly string savePath = "~/Uploads/";
 
     /// <summary>
     /// 此处配置允许下载的文件扩展名
     /// <remarks>
     ///     暂未考虑使用动态网页输出的图片如：http://site/image.aspx?uid=00001 这样的URI;
     ///  若要实现此功能可读取流并判断ContentType,将流另存为相应文件格式即可。
     /// </remarks>
     /// </summary>
     private static readonly string[ ] allowImageExtension = new string[ ] { ".jpg" , ".png" , ".gif" };
 
     /// <summary>
     /// 此处配置本地（网站）主机名
     /// </summary>
     private static readonly string[ ] localhost = new string[ ] { "localhost" , "www.devedu.com" };
 
     private string localImageSrc = string.Empty;

     private void Page_Load( object obj , EventArgs args )
     {
         if ( !Page.IsPostBack )
         {
             ClientScriptManager csm = Page.ClientScript;
 
             string scripCallServerDownLoad = csm.GetCallbackEventReference( this , "args" , "__ReceiveServerData" , "context" );
             string callbackScriptDwonLoad = "function __CallServerDownLoad(args , context) {" + scripCallServerDownLoad + "; }";
             if ( !csm.IsClientScriptBlockRegistered( "__CallServerDownLoad" ) )
             {
                 csm.RegisterClientScriptBlock( this.GetType( ) , "__CallServerDownLoad" , callbackScriptDwonLoad , true );
             }
         }
     }
 
     #region ICallbackEventHandler 成员
 
     /// <summary>
     /// 返回数据
     /// </summary>
     /// <remarks>如果处理过程中出现错误，则仍然返回远程路径</remarks>
     /// <returns>服务器端处理后的本地图片路径</returns>
     public string GetCallbackResult( )
     {
         return localImageSrc;
 
     }
 
     /// <summary>
     /// 处理回调事件 
     /// </summary>
     /// <param name="eventArgument">一个字符串，表示要传递到事件处理程序的事件参数</param>
     public void RaiseCallbackEvent( string eventArgument )
     {
 
         string remoteImageSrc = eventArgument;
 
         string fileName = remoteImageSrc.Substring( remoteImageSrc.LastIndexOf( "/" ) + 1 );
         string ext = System.IO.Path.GetExtension( fileName );
 
         if ( !IsAllowedDownloadFile( ext ) )
         {
             //非指定类型图片不进行下载，直接返回原地址。
             localImageSrc = remoteImageSrc;
             return;
         }
 
         Uri uri = new Uri( remoteImageSrc );
         if ( IsLocalSource( uri ) )
         {
             //本地（本网站下）图片不进行下载，直接返回原地址。
             localImageSrc = remoteImageSrc;
             return;
         }

         try
         {
             //自动创建一个目录。
             DateTime now = DateTime.Now;
             string datePath = string.Format( @"{0}\{1}\{2}\{3}" , now.Year , now.Month.ToString( "00" ) , now.Day.ToString( "00" ) , Guid.NewGuid( ).ToString( ) );
 
             string localDirectory = System.IO.Path.Combine( Server.MapPath( savePath ) , datePath );
             if ( !System.IO.Directory.Exists( localDirectory ) )
             {
                 System.IO.Directory.CreateDirectory( localDirectory );
             }
 
             string localFilePath = System.IO.Path.Combine( localDirectory , fileName );
 
             //不存在同名文件则开始下载，若已经存在则不下载该文件，直接返回已有文件路径。
             if ( !System.IO.File.Exists( localFilePath ) )
             {
                 Client.DownloadFile( uri , localFilePath );
             }
 
             string localImageSrc = ResolveUrl( "~/" + localFilePath.Replace( Server.MapPath( "~/" ) , string.Empty ).Replace( "\\" , "/" ) );
 
         }
         catch
         {
             //下载过程中出现任何异常都不抛出(  有点狠啊 :)  )，仍然用远程图片链接。
             localImageSrc = remoteImageSrc;
         }
 
     }
 
 
     #endregion
 
     private WebClient client;
 
     /// <summary>
     /// <see cref="System.Net.WebClient"/>
     /// </summary>
     public WebClient Client
     {
         get
         {
             if ( client != null )
             {
                 return client;
             }
 
             client = new WebClient( );
             client.Headers.Add( "user-agent" , "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2;)" );
 
             return client;
 
         }
     } 
     /// <summary>
     /// 判断Uri是否为本地路径
     /// </summary>
     /// <param name="uri"></param>
     /// <returns></returns>
     private bool IsLocalSource( Uri uri )
     {
         for ( int i = localhost.Length ; --i >= 0 ; )
         {
             if ( localhost[ i ].ToLower( ) == uri.Host.ToLower( ) )
             {
                 return true;
             }
         }
         return false;
     }
     /// <summary>
     /// 检测文件类型是否为允许下载的文件类型
     /// </summary>
     /// <param name="extension">扩展名 eg: ".jpg"</param>
     /// <returns></returns>
     private bool IsAllowedDownloadFile( string extension )
     {
         for ( int i = allowImageExtension.Length ; --i >= 0 ; )
         {
             if ( allowImageExtension[ i ].ToLower( ) == extension.ToLower( ) )
             {
                 return true;
             }
         }
          return false;
     } 
 </script> 
 <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="server">
     <title></title>
     <style type="text/css">
     body { margin: 0px; overflow: hidden;  background-color: buttonface;  }
     td { font-size: 11pt; font-family: Arial;text-align: left;}
     #domProgressBarId{
         width: 0%;
         height: 15px;  
         border-right: buttonhighlight 1px solid;
         border-top: buttonshadow 1px solid; 
         border-left: buttonshadow 1px solid; 
         border-bottom: buttonhighlight 1px solid;
         background-color: highlight;
     }
 </style> 
      <script type="text/javascript" language="javascript" src="/Editor/ckeditor/ckeditor.js"></script>
     <script type="text/javascript" language="javascript">          
         var RemoteImageRubber = function ( remoteSrcList )
         {
             this._remoteSrcList = remoteSrcList;
             this._totalFilesCount = remoteSrcList.length; 
         }
         RemoteImageRubber.prototype.CurrentPercent = function()
         {
             return Math.round( 100 * (1-  this.CurrentFilesCount() / this.TotalFilesCount() ) )+"%";
         }      
         RemoteImageRubber.prototype.TotalFilesCount = function()
         {
             return this._totalFilesCount;
         }         
         RemoteImageRubber.prototype.CurrentFilesCount = function()
         {
             return this._remoteSrcList.length;
         }
         RemoteImageRubber.prototype.NextFile = function ()
         {            
             if(this._remoteSrcList.length >0)
             {
                 var currentRemoteSrc = this._remoteSrcList.shift( )
                 __PreCallServer(currentRemoteSrc);
             }        
         }         
     </script> 
     <script type="text/javascript" language="javascript">         
         var oEditor;
         var domProgressBar;
         var domCurrentFile;
         var domAllFilesCount;
         var domAlreadyDownloadFilesCount;         
         var imageUrls;
         var remoteList = new Array();
         var localList = new Array();         
         var progressBar;      
         function Ok()
         {
             var __imgIndex;
             for(__imgIndex = 0; __imgIndex < imageUrls.length; __imgIndex ++)
             {
                 imageUrls[__imgIndex].src = localList[__imgIndex];                    
             }                 
             return true ;
         }         
     </script> 
     <script language="javascript" type="text/javascript">     
         function __PreCallServer(currentRemoteSrc)
         {
             var start = currentRemoteSrc.lastIndexOf("/") + 1;
             var end = currentRemoteSrc.length - currentRemoteSrc.lastIndexOf("/");
             var currentFileName = currentRemoteSrc.substr(start,end);                         
             domCurrentFile.innerHTML = currentFileName;         
             __CallServerDownLoad(currentRemoteSrc,'');             
         }         
         function __ReceiveServerData(receiveValue ,context)
         {
             // 注意：-------------------------------------------------------------------------------------------
             //
             // （1）不要在接收回调数据时使用变量 "i"。
             // （2）如果再次回调请使用window.setTimeout(.这样的形式
             //
             //      否则会导致 "'__pendingCallbacks[].async' 为空或不是对象"的错误产生。
             //  
             //      因为MS的开发人员在WebForm_CallbackComplete函数内使用了全局变量"i" 。这是一个比较ugly的bug。
             //
             // 参见:
             //   http://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=101974
             //   http://developers.de/blogs/damir_dobric/archive/2006/03/02/4.aspx?Ajax_CallBack=true
             //   http://developers.de/files/folders/279/download.aspx
             //   http://blogs.sqlxml.org/bryantlikes/archive/2005/12/20/4593.aspx
             //
             //------------------------------------------------------------------------------------------------- 
             if(receiveValue )
             {
                 var localSrc = receiveValue;
                 localList.push(localSrc);                 
                 domAlreadyDownloadFilesCount.innerHTML = progressBar.TotalFilesCount() - progressBar.CurrentFilesCount();
                 domProgressBar.style.width = progressBar.CurrentPercent();                
                 if( progressBar.CurrentFilesCount() > 0 )
                 {
                    window.setTimeout("progressBar.NextFile()",0);        
                 }
             }                         
             if(progressBar.CurrentFilesCount() == 0)
             {                
                 window.setTimeout("__reFlush()",500)
             } 
         } 
         function __StartDownLoad()    
         {
             imageUrls = window.parent.CKEDITOR.instances.DescriptionCN.getData().getElementsByTagName("img"); // oEditor.EditorDocument.body.getElementsByTagName("img");                 
             var m; 
             for(m = 0; m < imageUrls.length; m ++)
             {
                remoteList[m] = imageUrls[m].src;                      
             }             
             progressBar = new RemoteImageRubber(remoteList);              
             domAllFilesCount.innerHTML = progressBar.TotalFilesCount();             
             window.setTimeout("progressBar.NextFile()",0);             
         }    
         function __reFlush()
         {                        
             domProgressBar.style.width  = "100%";            
             //display the 'OK' button            
             window.parent.SetOkButton( true ) ;
         }          
     </script> 
 </head>
 <body>
     <form id="aspnetForm" runat="server">
         <div style="width: 300px; padding-left: 10px;">
             <table border="0" cellspacing="0" cellpadding="2">
                 <tr>
                     <td nowrap="nowrap" style="width: 290px;">
                         当前文件:&nbsp;<span id="domCurrentFile" style="display: inline; text-overflow: ellipsis"></span></td>
                 </tr>
                 <tr>
                     <td style="text-align: left; width: 290px;">
                         <div id="domProgressBarId">
                         </div>
                     </td>
                 </tr>
                 <tr>
                     <td nowrap="nowrap" style="width: 290px;">
                         共有:&nbsp;<span id="domAllFilesCount"></span>&nbsp;&nbsp;个文件</td>
                 </tr>
                 <tr>
                     <td nowrap="nowrap" style="width: 290px;">
                         已下载:&nbsp;<span id="domAlreadyDownloadFilesCount"></span>个。</td>
                 </tr>
             </table>
         </div>
     </form> 
     <script type="text/javascript" language="javascript">
//     window.parent.SetOkButton( false ) ;
//         oEditor = window.parent.CKEDITOR.instancesInnerDialogLoaded().FCK;       
     domProgressBar = document.getElementById("domProgressBarId");
     domCurrentFile = document.getElementById("domCurrentFile");
     domAllFilesCount = document.getElementById("domAllFilesCount");
     domAlreadyDownloadFilesCount = document.getElementById("domAlreadyDownloadFilesCount");    
     window.setTimeout("__StartDownLoad()",0);  
     </script> 
 </body>
 </html>
