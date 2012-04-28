<%@ Control Language="C#" CodeBehind="ForeignKey.ascx.cs" Inherits="MVC.ForeignKeyField" %>

<asp:HyperLink ID="HyperLink1" runat="server"
    Text="<%# GetDisplayString() %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />

