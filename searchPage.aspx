<%@ Page Language="C#" Inherits="GiveMeHashFinal.searchPage" %>
<!DOCTYPE html>
<html>
<head>
	<style type="text/css">
	.tab { margin-left: 40px; }
	</style>
	<title>searchPage</title>
</head>
<body>
	<div style="margin-left: 50px; margin-right: 50px; margin-top: 50px;">
		<form id="form1" runat="server">
			<asp:Label id="title" font-size= "20pt" runat="server" Text="Feed Me Hash"></asp:Label>
			<br /><br />
			<asp:TextBox id="hashBox" columns="145" runat="server"></asp:TextBox>
			<asp:Button style="display:block;float:right; forecolor:grey" id="findTweets" width="160px" runat="server" Text="Find Tweets" OnClick="findTweetsClicked"></asp:Button>
			<br /><br />
			<asp:TextBox id="filterBox" columns="145" runat="server"></asp:TextBox>
			<asp:Label id="sortBy" font-size="8pt" runat="server" Text="Sort By:"></asp:Label>
			<asp:DropDownList style="display:block;float:right;" ID="filter" runat="server" Width="160px">
				<asp:ListItem Text="Date (decending)" Value="0"></asp:ListItem>
				<asp:ListItem Text="Popularity" Value="1"></asp:ListItem>
				<asp:ListItem Text="Mixed" Value="2"></asp:ListItem>
			</asp:DropDownList>
			<br /><br /><br /><br />
			<asp:Literal ID="Literal1" runat="server" />
		</form>
	</div>
</body>
</html>
