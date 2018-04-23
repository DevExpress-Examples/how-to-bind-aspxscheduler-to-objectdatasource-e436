using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.XtraScheduler;
using DevExpress.Web.ASPxScheduler;

public partial class Default : System.Web.UI.Page
{
    ASPxSchedulerStorage Storage { get { return ASPxScheduler1.Storage; } }
    Object lastInsertedAppointmentId;
    #region #pageload
    protected void Page_Load(object sender, EventArgs e) {
        SetupMappings();
        ResourceFiller.FillResources(this.ASPxScheduler1.Storage, 3);

        ASPxScheduler1.AppointmentDataSource = appointmentDataSource;
        ASPxScheduler1.DataBind();

        ASPxScheduler1.GroupType = SchedulerGroupType.Resource;
    }
    #endregion #pageload
    #region #setupmappings
    void SetupMappings() {
        ASPxAppointmentMappingInfo mappings = Storage.Appointments.Mappings;
        Storage.BeginUpdate();
        try {
            mappings.AppointmentId = "Id";
            mappings.Start = "StartTime";
            mappings.End = "EndTime";
            mappings.Subject = "Subject";
            mappings.AllDay = "AllDay";
            mappings.Description = "Description";
            mappings.Label = "Label";
            mappings.Location = "Location";
            mappings.RecurrenceInfo = "RecurrenceInfo";
            mappings.ReminderInfo = "ReminderInfo";
            mappings.ResourceId = "OwnerId";
            mappings.Status = "Status";
            mappings.Type = "EventType";
        }
        finally {
            Storage.EndUpdate();
        }
    }
#endregion #setupmappings
    //Initilazing ObjectDataSource
#region #objectcreated
    protected void appointmentsDataSource_ObjectCreated(object sender, ObjectDataSourceEventArgs e) {
        e.ObjectInstance = new CustomEventDataSource(GetCustomEvents());
    }
    CustomEventList GetCustomEvents() {
        CustomEventList events = Session["ListBoundModeObjects"] as CustomEventList;
        if (events == null) {
            events = new CustomEventList();
            Session["ListBoundModeObjects"] = events;
        }
        return events;
    }
#endregion #objectcreated

    // User generated appointment id 
    #region #appointmentid
    protected void ASPxScheduler1_AppointmentInserted(object sender, PersistentObjectsEventArgs e) {
        SetAppointmentId(sender, e);
    }
    protected void appointmentsDataSource_Inserted(object sender, ObjectDataSourceStatusEventArgs e) {
        this.lastInsertedAppointmentId = e.ReturnValue;
    }
    void SetAppointmentId(object sender, PersistentObjectsEventArgs e) {
        ASPxSchedulerStorage storage = (ASPxSchedulerStorage)sender;
        Appointment apt = (Appointment)e.Objects[0];
        storage.SetAppointmentId(apt, this.lastInsertedAppointmentId);
    }
    #endregion #appointmentid
}
