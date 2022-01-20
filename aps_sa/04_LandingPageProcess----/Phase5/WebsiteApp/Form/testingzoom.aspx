<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="testingzoom.aspx.vb" Inherits="WebsiteApp.testingzoom" %>
<html>
<head>
<title>Foto Order</title>
<script src="http://code.jquery.com/jquery-2.1.1.js"></script>
<script src="https://code.jquery.com/jquery-2.1.1.min.js" type="text/javascript"></script>
<script>
function rotateImage(degree) {
	$('#demo-image').animate({  transform: degree }, {
    step: function(now,fx) {
        $(this).css({
            '-webkit-transform':'rotate('+now+'deg)', 
            '-moz-transform':'rotate('+now+'deg)',
            'transform':'rotate('+now+'deg)'
        });
    }
    });
}
</script>

<script>
        $(document).ready(function(){
           $("#in").click(function(){
                $("img").width($("img").width()+100);
                $("img").height($("img").height()+100);
           });
           $("#out").click(function(){
                $("img").width($("img").width()-100);
                $("img").height($("img").height()-100);
           });
        });
    </script>
<style>
.btnRotate {padding: 5px 10px;background-color: #09F;border: 0;color: white;cursor: pointer;}
</style>

</head>

<div>
    <input type="button" class="btnRotate" value="90" onClick="rotateImage(this.value);" />
    <input type="button" class="btnRotate" value="-90" onClick="rotateImage(this.value);" />
    <input type="button" class="btnRotate" value="180" onClick="rotateImage(this.value);" />
    <input type="button" class="btnRotate" value="360" onClick="rotateImage(this.value);" />
    <button id="in">+</button><button id="out">-</button>
</div>
    <br />

    <div><img style="width:30%;height:70%" src="https://image.freepik.com/free-vector/golden-bell_1262-6415.jpg" alt="foto order" id="demo-image"/></div>
</body>

</html>


<!--

<html>
<head>
    <title>ZOOM</title>
    <script src="https://code.jquery.com/jquery-2.1.1.min.js" type="text/javascript"></script>
</head>
<body>
    <center>
        <h3>ZOOM BUTTON</h3>
        <button id="in">+</button>
        <button id="out">-</button>
        <br><br>
        <img src="https://image.freepik.com/free-vector/golden-bell_1262-6415.jpg"  width="320px" height="240px">
    </center>
    <script>
        $(document).ready(function(){
           $("#in").click(function(){
                $("img").width($("img").width()+100);
                $("img").height($("img").height()+100);
           });
           $("#out").click(function(){
                $("img").width($("img").width()-100);
                $("img").height($("img").height()-100);
           });
        });
    </script>
</body>
</html>  

-->