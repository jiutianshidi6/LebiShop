<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Ajax.Ajax_order" validateRequest="false"%>
<%@ Import Namespace="Lebi.ERP" %>
<%
PLebi_User CurrentSonUser=Lebi.ERP.User.GetCurrentSonUser();
if(!CurrentSonUser.lebierp_UserLimit.Contains("showprice"))
CurrentUserLevel.IsHidePrice=1;
if(!CurrentSonUser.lebierp_UserLimit.Contains("usemoney"))
CurrentUserLevel.BuyRight=0;
LoadPage();
%>


  