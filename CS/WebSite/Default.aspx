<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v10.1, Version=10.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.XtraScheduler.v10.1.Core, Version=10.1.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxwschs:ASPxScheduler ID="ASPxScheduler1" runat="server" OnAppointmentsInserted="ASPxScheduler1_AppointmentInserted">
        </dxwschs:ASPxScheduler>
    
    </div>
        <asp:ObjectDataSource ID="appointmentDataSource" runat="server" DataObjectTypeName="CustomEvent"
            TypeName="CustomEventDataSource" DeleteMethod="DeleteMethodHandler" SelectMethod="SelectMethodHandler" 
            InsertMethod="InsertMethodHandler" UpdateMethod="UpdateMethodHandler"
            OnObjectCreated="appointmentsDataSource_ObjectCreated" OnInserted="appointmentsDataSource_Inserted"/>
    </form>
</body>
</html>
