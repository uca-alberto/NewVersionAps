<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CentroBiologiaMolecularUCA.Views.ViewLogin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="Contenedor" class="container">
        <div class="align-content-center">
            <div class="align-content-md-center">
                <img src="../../assets/imagenes/b-topCBM.png"/>
            </div>
            <div id="myCarousel" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                <li data-target="#myCarousel" data-slide-to="1"></li>
                <li data-target="#myCarousel" data-slide-to="2"></li>
                <li data-target="#myCarousel" data-slide-to="3"></li>
                <li data-target="#myCarousel" data-slide-to="4"></li>
                
            </ol>
    
            <div class="carousel-inner">
                
                <div class="item active">
                        <h5></h5>
                    <img src="../../assets/imagenes/1.png" />
                </div>
                
    
                <div class="item">
                        <h5></h5>
                    <img src="../../assets/imagenes/2.png" />
                </div>
                
    
                <div class="item">
                        <h5></h5>
                    <img src="../../assets/imagenes/3.png" />
                </div>
                
    
                <div class="item">
                        <h5></h5>
                    <img src="../../assets/imagenes/4.png" />
                </div>
                <div class="item">
                        <h5></h5>
                    <img src="../../assets/imagenes/5.png" />
                </div>
                <div class="item">
                        <h5></h5>
                    <img src="../../assets/imagenes/6.png" />
                </div>
    
    
            </div>
    
            <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left"></span>
                <span class="sr-only">Previous</span>
            </a>
    
            <a class="right carousel-control" href="#myCarousel" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right"></span>
                <span class="sr-only">Next</span>
            </a>
            
        </div>
            </div>

        </div>

</asp:Content>
