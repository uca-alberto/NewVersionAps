<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdnValidacion.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewADN.AdnValidacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
                      <div class="card-header">
                       <strong>Resultado ADN</strong>
                      </div>
                      <div class="card-body card-block">
                        <form method="post" class="form-horizontal">
                          <div>
                            <div class="col col-sm-3"><label>Nombre:</label><input type="text" placeholder="nombre de la persona" class="form-control"></div>
                          </div>
                          <div >
                            <div class="col col-sm-3"><label>Examen:</label><input type="text" placeholder="Prueba de paternidad" disabled="disabled" class="form-control"></div>
                          </div>
                          <div>
                            <div class="col col-sm-3"><label>Fecha:</label><input type="Date" class="form-control"></div>
                          </div>
                          <div class="row form-group">
                            <div class="col col-sm-8"><label>Mec Total:</label><input type="text" placeholder=".col-sm-6" class="form-control"></div>
                          </div>
                            </form>
                          &nbsp&nbsp
                          
                      <div class="card">
                      <div class="card-header">
                       <strong>Marcadores</strong>
                      </div>
                      <div class="card-body card-block">
                        <form method="post" class="form-horizontal" runat="server">
                          <div>
                            <div class="col col-sm-3"><label>Nombre Del Marcador:</label><div><asp:DropDownList ID="Mdepartamento" runat="server" ToolTip="Departamento" CssClass="form-control" DataTextField="Departamento" DataValueField="Id_departamento" ></asp:DropDownList></div></div>
                          </div>
                          <div >
                            <div class="col col-sm-3"><label>Cromosomas Padre/Madre:</label><div class="col-12 col-md-6"><asp:DropDownList ID="DropDownList1" runat="server" ToolTip="Departamento" CssClass="form-control" DataTextField="Departamento" DataValueField="Id_departamento" ></asp:DropDownList></div><div class="col-12 col-md-6"><asp:DropDownList ID="DropDownList2" runat="server" ToolTip="Departamento" CssClass="form-control" DataTextField="Departamento" DataValueField="Id_departamento" ></asp:DropDownList></div></div>
                          </div>
                          <div>
                            <div class="col col-sm-3"><label>Cromosomas Hijo/A:</label><div class="col-12 col-md-6"><asp:DropDownList ID="DropDownList3" runat="server" ToolTip="Departamento" CssClass="form-control" DataTextField="Departamento" DataValueField="Id_departamento" ></asp:DropDownList></div><div class="col-12 col-md-6"><asp:DropDownList ID="DropDownList4" runat="server" ToolTip="Departamento" CssClass="form-control" DataTextField="Departamento" DataValueField="Id_departamento" ></asp:DropDownList></div></div>
                          </div>
                          <div class="row form-group">
                            <div class="col col-sm-8"><label>Resultado IP</label><input type="text" placeholder="1.150000" class="form-control"></div>
                          </div>
                            </form>
                            </div>
                            </div>
                            </div>
                            </div>
                         
                            <div class="content mt-3">
                        <div class="animated fadeIn">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="card">
                                        <div class="card-header">
                                            <strong class="card-title">Tabla de Marcdores</strong>
                                        </div>
                                        <div class="card-body">
                                            <table class="table table-striped table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th>Marcador</th>
                                                        <th colspan="2">Presunta Madre</th>
                                                        <th colspan="2">Hijo/a</th>
                                                        <th>Ip</th>
                                                        
                                                    </tr>
                                                </thead>
                                                <tbody>  
                                                    <tr>
                                                        <td>AMEL</td>
                                                        <td>X</td>
                                                        <td>y</td>
                                                        <td>X</td>
                                                        <td>y</td>
                                                        <td>---------</td>
                                                    </tr>  
                                                   
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                </div>
                            </div>
                           </div>
                        <div class="card-footer">
                        <button type="submit" class="btn btn-primary btn-sm">
                          <i class="fa fa-user"></i> Login
                        </button>
                        <button type="reset" class="btn btn-danger btn-sm">
                          <i class="fa fa-ban"></i> Reset
                        </button>
                      </div>
                         <!--Tabla de cliente-->  
</asp:Content>
