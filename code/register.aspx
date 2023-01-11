﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Code.register" %>
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



    
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
<script>
    $(document).ready(function () {
        $("#phone").change(function () {
            var phone = document.getElementById('phone').value;
            var intRegex = /^(7|8|9)[0-9]{9}$/;
            if ((phone.length < 6) || (!intRegex.test(phone))) {
                alert('Please enter a valid phone number.');
				 $("#phone").focus();
                return false;
            }
        });
    });
</script>
<script>
    $(document).ready(function () {
        $("#mailid").change(function () {
            var email = document.getElementById('mailid').value;
            var emailReg = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
           if(!emailReg.test(email) || email == '')
                {
                alert('Please enter a valid email id.');
				 $("#mailid").focus();
                return false;
            }
        });
    });
</script>
    <script>
    $(document).ready(function () {
        $("#name").change(function () {
            document.getElementById('uname').value = document.getElementById('name').value + Math.floor((Math.random() * 900) + 1);

        });
    });
</script>
<script>
    $(document).ready(function () {
        $("#age").change(function () {
            var age = document.getElementById('age').value;
            var regage = /^[0-9]{2}$/;
            if (!regage.test(age)) {
                alert("invalid age");
				
				 $("#age").focus();
            }
        });
    });
</script>
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
									<a class="nav-link" href="index.aspx">Home
										<span class="sr-only">(current)</span>
									</a>
								</li>
								<li class="nav-item active mx-xl-4 mx-lg-3 my-lg-0 my-3">
									<a class="nav-link" href="register.aspx">Register</a>
								</li>
								<li class="nav-item mx-xl-4 mx-lg-3 my-lg-0 my-3">
									<a class="nav-link" href="login.aspx">Login</a>
								</li>
								<li class="nav-item">
									<a class="nav-link" href="contact.aspx">Contact Us</a>
								</li>
					</ul>
				</div>
			</nav>
        </header>
        <!-- //header -->
       
    <div style="height:800px;background-color:#3366ff;color:black;padding-top:100px;">
<div style="width:50%;float:left;margin:0;">
    <img src="./images/reg.jpg" style="height:500px;width:100%" />
            </div>


            <div style="width:50%;float:left;padding-left:1px;">
            
	<form id="form1" runat="server">
				<table class="style1" style="color:#ffffcc;">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="center" colspan="2">
                            <span style="font-weight:bolder;font-size:25px;color:white;">Welcome to the signup page !!!</span></td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            Name:</td>
                        <td>
                        &nbsp;
                        <input type="text" placeholder="Enter your name" runat="server" 
                                id="name" />
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            Enter Desired Password:</td>
                        <td>
                        &nbsp;
                        <input type="password" placeholder="Enter desired password" runat="server" id="pswd" />
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            Confrm Password:</td>
                        <td>
                        &nbsp;
                        <input type="password" placeholder="Confirm password" runat="server" 
                                id="cpswd" />
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            Enter Desired Username:</td>
                        <td>&nbsp;
                        <input type="text" readonly="readonly" placeholder="Enter desired username" runat="server" id="uname" />
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            Age:</td>
                        <td>
                        &nbsp;
                        <input type="text" placeholder="Enter your age" runat="server" 
                                id="age" />
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style5">
                            </td>
                        <td class="style6">
                            </td>
                        <td align="right" class="style5">
                            Email Id:</td>
                        <td class="style5">
                        &nbsp;
                        <input type="text" placeholder="Enter your mail id" runat="server" 
                                id="mailid" />
                            &nbsp;</td>
                        <td class="style5">
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style5">
                            </td>
                        <td class="style6">
                            </td>
                        <td align="right" class="style5">
                            College:</td>
                        <td class="style5">
                        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" DataSourceID="SqlDataSource1" DataTextField="CName" DataValueField="CName">
                            <asp:ListItem>--Select--</asp:ListItem>
                              </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [CName] FROM [CollegeList]"></asp:SqlDataSource>
                            &nbsp;</td>
                        <td class="style5">
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3">
                            </td>
                        <td class="style4">
                            </td>
                        <td align="right">
                            Gender:</td>
                        <td>
                        &nbsp;
                        <select id="gender" runat="server">
                        <option>--Select--</option>                        
                        <option>Male</option>
                        <option>Female</option>
                        </select>
                            &nbsp;</td>
                        <td class="style3">
                            </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                           <%-- Select:</td>--%>
                        <td>
                          <%--  &nbsp;
                             <select id="Select2" runat="server">
                        <option>--Select--</option>                        
                        <option>HOD</option>
                        <option>Lecturer</option>
                       </select>
                        </td>--%>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            Phone Number:</td>
                        <td>
                        &nbsp;
                        <input type="text" placeholder="Enter your phone number" runat="server" 
                                id="phone" />
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            <input id="reset" type="button" value="Reset" runat="server" onserverclick="Reset" style="background-color:#B8D4E3;border-radius:5px;width:95px;" /></td>
                        <td>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <input id="login" type="button" value="Submit" runat="server" onserverclick="Submit" style="background-color:#B8D4E3;border-radius:5px;width:95px;" />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td align="center" colspan="2"  style="color:white;">
                            <a href="login.aspx"> Go to login page !!!</a>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    
                </table>
                </form>
            </div>


        </div>
	 <!-- //banner-text -->

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
