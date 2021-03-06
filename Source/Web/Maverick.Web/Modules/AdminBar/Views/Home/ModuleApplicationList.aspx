﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<System.Collections.Generic.IList<ModuleApplicationViewModel>>" %>

<% if(Model.Count() > 0) {%>
<ul id="cp_module_app_list">
    <% foreach (ModuleApplicationViewModel appModel in Model) {%>
    <li>
        <% using (Html.BeginForm("Create", "Module")) {%>
        <input name="id" type="hidden" value="<%=appModel.Id%>" />
        <input type="submit" class="ui-corner-all ui-state-default" value="Add this Module" />
        <% } %>
        <img src="<%= Url.Content(appModel.LogoUrl ?? "~/Modules/AdminBar/Content/Images/UnknownModule.png") %>"
            alt="<%=appModel.Name %>" />
        <h4>
            <%= appModel.Name %>
            (Version:
            <%= appModel.Version %>)</h4>
        <h5>
            Developed by
            <%= appModel.Vendor ?? "<<Unknown>>" %></h5>
        <p>
            <%=appModel.Description %></p>
    </li>
    <% } %>
</ul>
<% } %>
