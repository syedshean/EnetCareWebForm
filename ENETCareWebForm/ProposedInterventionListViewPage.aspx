﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProposedInterventionListViewPage.aspx.cs" Inherits="ENETCareWebForm.ProposedInterventionListViewPage" MasterPageFile="MasterPage.Master" EnableEventValidation = "false"%>

<%--<!DOCTYPE html>--%>

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>--%>

<asp:Content ID="contentLogin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <body>
        <form id="form1">
            <asp:Label ID="viewProposedInterventionTitleLabel" runat="server" Text="View Proposed Intervention" Font-Bold="True" Font-Size="Large"></asp:Label>
            
                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="ErrorMessageLabel" runat="server" Style="color:darkred"></asp:Label>
&nbsp;<p style="margin-left: 80px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                <asp:GridView ID="interventionListGridView" AutoGenerateColumns="False" runat="server" AllowPaging="True" PageSize="5" EnableSortingAndPagingCallbacks="false" OnPageIndexChanging="interventionListGridView_PageIndexChanging" OnRowCommand="interventionListGridView_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText = "Row Number" ItemStyle-Width="100">
                             <ItemTemplate>
                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                            </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                        </asp:TemplateField> 
                         <asp:TemplateField HeaderText="Interventions">
                        <ItemTemplate>
                                <asp:HiddenField runat="server" ID="interventionIDHiddenField" Value='<%# Bind("InterventionID")%>'/>
                                <asp:Label runat="server" Text='<%#Eval("InterventionType")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                       
                        <asp:BoundField DataField="ClientName" HeaderText="Client Name" />
                        <asp:BoundField DataField="InterventionDate" HeaderText="Intervention Date" />
                        <asp:BoundField DataField="InterventionStatus" HeaderText="Intervention Status" />
                        
                        <asp:ButtonField CommandName="Approve" Text="Approve" HeaderText="Approve"  />
                        <%--<asp:ButtonField CommandName="Complete" Text="Complete" HeaderText="Complete"  />
                        <asp:ButtonField CommandName="Remove" Text="Cancel" HeaderText="Cancel"  />
                        --%>
                        
                    </Columns>
                </asp:GridView>
                </p>
            <p style="margin-left: 80px">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="managerHomePageButton" runat="server" Text="Manager Home Page" OnClick="managerHomePageButton_Click" />
                </p>
        </form>
    </body>
</asp:content>
