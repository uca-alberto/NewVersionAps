<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerResultadoOgm.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewResultadoMaria.VerResultadoOgm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card-header">
        <strong class="card-title">Vista de resultado ogm</strong>
           </div>  
             <div class="card">
               <div class="card-body card-block">
                 <form action="get" method="post" enctype="multipart/form-data" class="form-horizontal" runat="server">


                     <!--Comienzo de los formulario-->
                        <!--fecha-->
                           <div class="row form-group ">
                            <div class="col col-md-3 "><label for="text-input" class=" form-control-label">Fecha</label></div>
                            <div class="col-12 col-md-9">&nbsp; 
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </div>
                                

                                 <asp:TextBox ID="Mfecha" CssClass="form-control" BackColor="Wheat" Font-Bold="false" data-inputmask="'alias':'dd/mm/yyyy'"
                                    data-mask="" runat="server"></asp:TextBox> 
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="Mfecha" ErrorMessage="Siga este formato dd/mm/yyyy" ValidationExpression="^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$"></asp:RegularExpressionValidator>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Mfecha" Display="Dynamic" ErrorMessage="Este Campo es requerido"></asp:RequiredFieldValidator> 
                                     
                          </div>
                               </div>
                                    </div>

                            <!--validacion-->
                       <div class="row form-group ">
                            <div class="col col-md-3 "><label for="select" class=" form-control-label">Validacion</label></div>
                            <div class="col-12 col-md-9 ">
                             <asp:DropDownList ID="Mvalidacion" runat="server" ToolTip="caso" CssClass="form-control">
                              <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                               <asp:ListItem Value="1">Aprobado</asp:ListItem>
                               <asp:ListItem Value="2">No aprobado</asp:ListItem>
                                  <asp:ListItem Value="3">En espera</asp:ListItem>
                               </asp:DropDownList>
                            </div>
                          </div>

                         
                           <!--tipo proteinas-->
                          <div class="row form-group ">
                            <div class="col col-md-3 "><label for="select" class=" form-control-label">eventos</label></div>
                            <div class="col-12 col-md-9 ">
                             <asp:DropDownList ID="Mresultado" runat="server" ToolTip="caso" CssClass="form-control">
                              <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                               <asp:ListItem Value="1">Cry1Ab</asp:ListItem>
                               <asp:ListItem Value="2">RR</asp:ListItem>
                                  <asp:ListItem Value="3">Cry3Bb</asp:ListItem>
                                 <asp:ListItem Value="4">Cry1F</asp:ListItem>
                                 <asp:ListItem Value="5">LL pat</asp:ListItem>
                                 <asp:ListItem Value="6">Cry34</asp:ListItem>
                                 <asp:ListItem Value="7">mCry3A</asp:ListItem>
                                 <asp:ListItem Value="8">LL bar</asp:ListItem>
                               </asp:DropDownList>
                            </div>
                          </div>        

                                 <!--estado-->
                       <div class="row form-group ">
                            <div class="col col-md-3 "><label for="select" class=" form-control-label">Estado</label></div>
                            <div class="col-12 col-md-9 ">
                             <asp:DropDownList ID="Mestado" runat="server" ToolTip="caso" CssClass="form-control">
                              <asp:ListItem Value="0">SELECCIONE</asp:ListItem>
                               <asp:ListItem Value="1">Activo</asp:ListItem>
                               <asp:ListItem Value="2">en esperaa</asp:ListItem>
                                 
                               </asp:DropDownList>
                            </div>
                          </div>
                               
                               <!--usuario valida--> 
                         <div class="row form-group ">
                            <div class="col col-md-3 "><label for="password-input" class=" form-control-label">usuario que valida</label></div>
                            <div class="col-12 col-md-9">
                           <asp:TextBox ID="Musuariovalida" runat="server" Text="" ToolTip="usuariovalida" CssClass="form-control" placeholder="Ingrese el nombre del usuario que revisa"></asp:TextBox>
                               </div>
                          </div>


                          <!--usuario procesa--> 
                         <div class="row form-group ">
                            <div class="col col-md-3 "><label for="password-input" class=" form-control-label">usuario que procesa</label></div>
                            <div class="col-12 col-md-9">
                           <asp:TextBox ID="Musuarioprocesa" runat="server" Text="" ToolTip="usuarioprocesa" CssClass="form-control" placeholder="digite el usuario que realizo el examen"></asp:TextBox>
                               </div>
                          </div>


                          <!--analisis--> 
                         <div class="row form-group ">
                            <div class="col col-md-3 "><label for="password-input" class=" form-control-label">Analisis</label></div>
                            <div class="col-12 col-md-9">
                           <asp:TextBox ID="Manalisis" runat="server" Text="" ToolTip="analisis" CssClass="form-control" placeholder="Ingrese la fecha"></asp:TextBox>
                               </div>
                          </div>
                        
             <div class="modal-footer">
                        <asp:HiddenField runat="server" ID="Id_orden" />
                        <a class="btn btn-outline-success btn-lg btn-block" href="../../Views/ViewResultadoMaria/AgregarResultadoOgm.aspx">Regresar</a>  
                    </div>
                </form>
            </div>
            </div>
     <script type="text/javascript" src="../../Content/ListaOrdenOgm.js"></script>
     <script  type="text/javascript">
        window.onload = function () {
            edit( '<%=re.Fecha_procesamiento%>', '<%=re.Validacion%>', '<%=re.Parametros%>','<%=re.Estado%>',
                  '<%=re.Usuario_procesa%>','<%=re.Usuario_valida%>','<%=re.Analisis%>')
        };
    </script>    

    <script src="../../js/plugins/input-mask/jquery.inputmask.js"></script>
                       
                       <script src="../../js/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
                       
                       <script src="../../js/plugins/timepicker/bootstrap-timepicker.min.js"></script>
                       <script src="../../js/plugins/moment/moment.min.js"></script>

</asp:Content>
