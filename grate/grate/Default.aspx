<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="grate._Default"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>李宁的格子屋</title>
    <meta name="keywords" content="李宁的格子屋,网站推广,链接">
    <meta name="description" content="李宁的格子屋,欢迎大家来入住">
    <meta name="author" content="李宁,lining_it@163.com">
    <style type="text/css">
        .center
        {
            margin: 0 auto;
        }
        .Grate
        {
            background-position: center center;
            width: 125px;
            height: 60px;
            background-repeat: no-repeat;
            float: left;
            cursor: pointer;
            border-width: 1px;
            border-style: solid;
            border-color: #ffffff;
        }
    </style>
    <style type="text/css">
        #addGrate
        {
            margin: 0;
            padding: 10px 30px;
        }
        .ftitle
        {
            font-size: 14px;
            font-weight: bold;
            color: #666;
            padding: 5px 0;
            margin-bottom: 10px;
            border-bottom: 1px solid #ccc;
        }
        .fitem
        {
            margin-bottom: 5px;
        }
        .fitem label
        {
            display: inline-block;
            width: 80px;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="/themes/default/easyui.css">
    <link rel="stylesheet" type="text/css" href="/themes/icon.css">
    <link rel="stylesheet" type="text/css" href="/themes/demo.css">
    <script type="text/javascript" src="Scripts/jquery-1.4.1-vsdoc.js"></script>
    <script type="text/javascript" src="Scripts/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="Scripts/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript">
        $(function () {
            $('.Grate').mouseover(function () {
                $(this).css("border-color", "red");
            });
            $('.Grate').mouseout(function () {
                $(this).css("border-color", "#ffffff");
            });

        });
        function OpenUrl(url, id) {
            if (id == 0) {
                $('#divAddGrate').fadeIn('slow');
                return;
            }
            if (url) {
                window.open(url);
            }
        }
        function closeDivAddGrate() {
            $("#divAddGrate").fadeOut("slow");
        }
        var ImageFormats = ".jpg.png.gif.bmp.";

        function check() {
            if ($("#addGrate").form('validate')) {
                var file = $('#fuImg').val();
                if (file) {
                    var dotArray = file.toLowerCase().split(".")
                    if (dotArray.length >= 2) {
                        var FileExt;
                        FileExt = dotArray[dotArray.length - 1]
                        if (ImageFormats.indexOf("." + FileExt + ".") != -1) {
                            return true;
                        } else {
                            alert("图片格式只可以为jpg,png,gif,bmp!");
                        }
                    }
                }
                else {
                    alert("请选择图片!");
                }
            }
            return false;
        }
        var _bdhmProtocol = (("https:" == document.location.protocol) ? " https://" : " http://");
        document.write(unescape("%3Cscript src='" + _bdhmProtocol + "hm.baidu.com/h.js%3Fd933c21ffb7232d94aa7a1bdccc19241' type='text/javascript'%3E%3C/script%3E"));
    </script>
</head>
<body bgcolor="#fffff">
    <form id="form1" runat="server">
    <div style="text-align: center">
        <div class="center" style="background-position: center top; width: 1024px; height: 170px;
            background-image: url('/image/<%= QianZhui %>title.png'); background-repeat: no-repeat;">
            <a href="#" style="position: relative; top: 25px; left: 275px; color: #FF0000; font-size: 30px;
                font-weight: 600; font-family: 华文行楷; font-variant: small-caps; text-decoration: none;"
                onclick="$('#divAddGrate').fadeIn('slow');">增加格子</a>
        </div>
        <div class="center" style="border: 1px solid #000000; width: 890px; text-align: center;
            background-color: #a6c6ff; height: 625px;">
            <asp:Repeater ID="rptGrate" runat="server">
                <ItemTemplate>
                    <div onclick='<%# "OpenUrl(\""+GetStr(Eval("cUrl")) +"\","+Eval("Id")+")" %>' class="Grate">
                        <img alt="<%# GetStr(Eval("CTitle"))  %>" title='<%#GetStr( Eval("CTitle") ) %>'
                            src='ImageUpload/<%# Eval("cImage") %>' height="60px" width="120px" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div id="divAddGrate" style="left: 431.5px; top: 184.5px; width: 400px; display: none;
        z-index: 9001;" class="panel window">
        <div style="width: 400px;" class="panel-header panel-header-noborder window-header">
            <div class="panel-title">
                增加格子</div>
            <div class="panel-tool">
                <a class="panel-tool-close" href="javascript:closeDivAddGrate()"></a>
            </div>
        </div>
        <div style="width: 400px; height: 260px; overflow: hidden;" id="Div1" class="panel-body panel-body-noborder window-body "
            title="">
            <div style="width: 400px; margin: 10px; display: block;" class="panel">
                <div style="width: 400px; height: 260px;" class="dialog-content panel-body panel-body-noheader panel-body-noborder"
                    title="添加格子">
                    <div class="ftitle">
                        格子信息</div>
                    <div class="fitem">
                        <label>
                            用户名:</label>
                        <asp:TextBox ID="txtName" runat="server" class="easyui-validatebox" required="true"></asp:TextBox>
                    </div>
                    <div class="fitem">
                        <label>
                            联系邮箱:</label>
                        <asp:TextBox ID="txtEmail" runat="server" required="true" class="easyui-validatebox"
                            validtype="email"></asp:TextBox>
                    </div>
                    <div class="fitem">
                        <label>
                            标题:</label>
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                    </div>
                    <div class="fitem">
                        <label>
                            连接地址:</label>
                        <asp:TextBox ID="txtUrl" required="true" runat="server" class="easyui-validatebox"
                            validtype="url"></asp:TextBox>例子:http://www.baidu.com
                    </div>
                    <div class="fitem">
                        <label>
                            图片:</label>
                        <asp:FileUpload ID="fuImg" runat="server" />
                    </div>
                    <div class="fitem">
                        推荐使用120*60比例的图片,否则可能造成失真
                    </div>
                    <div id="dlg-buttons" style="margin-top: 30px">
                        <asp:LinkButton ID="btnSvae" runat="server" class="easyui-linkbutton" iconcls="icon-ok"
                            OnClientClick="return check()" OnClick="btnSvae_Click">保存</asp:LinkButton>
                        <a href="#" class="easyui-linkbutton" iconcls="icon-cancel" onclick="closeDivAddGrate()">
                            取消</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div style="text-align: center">
        <a href="http://www.miibeian.gov.cn" target="_blank">沪ICP备12016126号</a> <em class="s-bottom-copyright">
            &nbsp;&nbsp;&nbsp;&nbsp;</em></div>
    </form>
</body>
</html>
