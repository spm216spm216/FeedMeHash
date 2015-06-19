<%@ Page Language="C#" Inherits="GiveMeHashFinal.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
</head>
<body>
	<form id="form1" runat="server">
		<div style="text-align: center;">
				<br /><br /><br /><br /><br />
				<br /><br /><br /><br /><br />
				<asp:Label id="feedMe" font-size="15pt" runat="server" Text="Feed Me Hash"></asp:Label>
				<br /><br /><br /><br />
				<asp:TextBox id="mainBox" columns="110" runat="server"></asp:TextBox><br /><br />
				<br /><br /><br /><br />
				<asp:Button id="tweetButton" runat="server" Text="Find Tweets" OnClick="tweetButtonClicked"></asp:Button>
		</div>
	</form>
</body>
</html>

