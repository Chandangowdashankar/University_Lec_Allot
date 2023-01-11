﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delstaff.aspx.cs" Inherits="Code.delstaff" %>
<!DOCTYPE html>
<html lang="zxx">

<head>
    <title>University Lecturer Allotment</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8" />
    <meta name="keywords" content="Subject Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template, 
	SmartPhone Compatible web template, free WebDesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola web design" />
    <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
    <!-- Custom Theme files -->
    <link href="css/bootstrap.css" type="text/css" rel="stylesheet" media="all">
    <link href="css/style.css" type="text/css" rel="stylesheet" media="all">
	<!-- Testimonials-Css -->
	<link rel="stylesheet" href="css/owl.theme.css" type="text/css" media="all">
	<link rel="stylesheet" href="css/owl.carousel.css" type="text/css" media="screen" property="" />
    <!-- font-awesome icons -->
    <link href="css/fontawesome-all.min.css" rel="stylesheet">
	<!-- //Custom Theme files -->
    <!-- online-fonts -->
	<link href="//fonts.googleapis.com/css?family=Roboto:100i,400,500,700" rel="stylesheet">
	<link href="//fonts.googleapis.com/css?family=Montserrat:300,400,500,600,700,800" rel="stylesheet">
	<!-- //online-fonts -->
</head>

<body>
    <!-- banner -->
    <div class="banner">
        <!-- header -->
        <header>
            <nav class="navbar navbar-expand-lg navbar-light bg-gradient-secondary pt-3">
               <h1><a class="navbar-brand" href="index.aspx">E-Allotment
							<span>University Lecturer Allotment</span>
						</a></h1>

                <button class="navbar-toggler ml-md-auto" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ml-auto">
								<li class="nav-item ">
									<a class="nav-link" href="hodhome.aspx">Admin Home
										<span class="sr-only">(current)</span>
									</a>
								</li>
								<li class="nav-item active mx-xl-4 mx-lg-3 my-lg-0 my-3">
									<a class="nav-link" href="staffer.aspx">Manage Staff</a>
								</li>
								<li class="nav-item">
									<a class="nav-link" href="subjecter.aspx">Manage Subject</a>
								</li>
								<li class="nav-item">
									<a class="nav-link" href="allocsub.aspx">Allocate Subject</a>
								</li>
								<li class="nav-item mx-xl-4 mx-lg-3 my-lg-0 my-3">
									<a class="nav-link" href="login.aspx">Logout</a>
								</li>
					</ul>
				</div>
			</nav>
        </header>
        <!-- //header -->

    <div style="height:700px;background-color:#3366ff;color:black;padding-top:100px;">
        <div style="width:15%;float:left;margin:0;">.
            </div>


            <div style="width:50%;float:left;padding-left:1px;">
              <form id="form1" runat="server">
            <h3>Manage Staff page !!!</h3><br />
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataSourceID="SqlDataSource1" 
                    EmptyDataText="There are no data records to display." ForeColor="#333333" 
                    GridLines="None" Width="1000px" OnRowCommand="GridView1_RowCommand" OnRowDeleted="RowDelete">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" CssClass="abc" HorizontalAlign="Left" />
                    <Columns>
                    
                        <asp:BoundField DataField="Username" HeaderText="Username" 
                            SortExpression="Username" />
                         <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-HorizontalAlign="Center"
                            SortExpression="Name" />  
                         <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-HorizontalAlign="Center"
                            SortExpression="Email" /> 
                         <asp:BoundField DataField="TOU" HeaderText="User Type" HeaderStyle-HorizontalAlign="Center"
                            SortExpression="TOU" /> 
                
                                                              
                        <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="" ShowHeader="True" Text="Delete" ControlStyle-Width="150px" />
                   
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                          
                          <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                              
                  ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand=""></asp:SqlDataSource>
                  
            </form>
            </div>

            <div style="width:30%;float:right;">
            </div>

        </div>
<!--/newsletter-->

	<div class="copyright py-3">
		<div class="container">
			<div class="row">
				<div class="col-md-8">      
					<p class="copy-right mt-2">© <script>document.write(new Date().getFullYear());</script>E-Allotment All Rights Reserved 
					</p>
				</div>
				<div class="col-md-4">
					<ul class="social-icons scial justify-content-end">
						<li class="mr-1"><a href="#"><span class="fab fa-facebook-f"></span></a></li>
						<li class="mx-1"><a href="#"><span class="fab fa-twitter"></span></a></li>
						<li class="mx-1"><a href="#"><span class="fab fa-google-plus-g"></span></a></li>
						<li class="mx-1"><a href="#"><span class="fab fa-linkedin-in"></span></a></li>
					</ul>
				</div>
			</div>
		</div>
	</div>
    <!--//newsletter-->
    <div style="height:700px;background-color:#3366ff;color:black;padding-top:100px;">
    <img src="./images/uni.jpg" style="height:500px;width:100%" />

        </div>
<!-- js -->
    <script src="js/jquery-2.2.3.min.js"></script>
<!-- //js -->
<!-- carousel(for feedback) -->
	<script src="js/owl.carousel.js"></script>
	<script>
		$(document).ready(function () {
			$('.owl-carousel').owlCarousel({
				loop: true,
				margin: 10,
				responsiveClass: true,
				responsive: {
					0: {
						items: 1,
						nav: true
					},
					600: {
						items: 2,
						nav: false
					},
					1000: {
						items: 3,
						nav: true,
						loop: false,
						margin: 20
					}
				}
			})
		})
	</script>
	
	<!-- //carousel(for feedback) -->
<!-- stats -->
	<script src="js/jquery.waypoints.min.js"></script>
	<script src="js/jquery.countup.js"></script>
		<script>
			$('.counter').countUp();
		</script>
<!-- //stats -->

    <!-- start-smooth-scrolling -->
    <script src="js/move-top.js"></script>
    <script src="js/easing.js"></script>
    <script>
        jQuery(document).ready(function ($) {
            $(".scroll").click(function (event) {
                event.preventDefault();

                $('html,body').animate({
                    scrollTop: $(this.hash).offset().top
                }, 1000);
            });
        });
    </script>
    <!-- //end-smooth-scrolling -->
    <!-- smooth-scrolling-of-move-up -->
    <script>
        $(document).ready(function () {
            /*
            var defaults = {
                containerID: 'toTop', // fading element id
                containerHoverID: 'toTopHover', // fading element hover id
                scrollSpeed: 1200,
                easingType: 'linear' 
            };
            */

            $().UItoTop({
                easingType: 'easeOutQuart'
            });

        });
    </script>
    <script src="js/SmoothScroll.min.js"></script>
    <!-- //smooth-scrolling-of-move-up -->
    <!-- Bootstrap core JavaScript
================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="js/bootstrap.js"></script>
</body>
</html>
