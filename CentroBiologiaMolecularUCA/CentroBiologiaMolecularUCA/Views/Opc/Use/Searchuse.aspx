﻿<%@ Page Language="C#" MasterPageFile="~/configuration.Master" AutoEventWireup="true" CodeBehind="Searchuse.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewUsuario.BuscarUsuario" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">      
     <form runat="server">
          <asp:ScriptManager runat="server" ID="Update">

    </asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="Update1">
        <ContentTemplate>
              <div class="content mt-3">
            <div class="animated fadeIn">
                <div class="row">

                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Usuarios</strong>
                        </div>
                        <div class="card-body">
                            <!-- .Tabla donde se muestran los usuarios Activos-->
                  <table id="bootstrap-data-table" class="table table-striped table-bordered">
                    <thead>
                        <th>Nombre del Usuario</th>
                        <th>Rol</th>
                        <th>Opciones</th>
                    </thead>
                    <tbody>
                    </tbody>
                  </table>
                        </div>
                    </div>
                </div>
                </div>
            </div><!-- .animated -->
        </div><!-- .content -->
        </ContentTemplate>

    </asp:UpdatePanel>
    </form>
 
     <script src="../../../TablesJS/TableUsuario.js"></script> 


    
    
</asp:Content>