<%@ Control Language="C#" CodeBehind="ForeignKey.ascx.cs" Inherits="WebApplication2.ForeignKeyField" %>

<asp:HyperLink ID="HyperLink1" runat="server"
    Text="<%# GetDisplayString() %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />

