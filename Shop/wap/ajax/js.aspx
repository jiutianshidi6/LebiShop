<%@ Page Language="C#" AutoEventWireup="true" Inherits="Shop.Ajax.js" validateRequest="false"%>
var languagetags=[];
<%=langs%>
function Tag(strin) {
    return languagetags[strin];
}