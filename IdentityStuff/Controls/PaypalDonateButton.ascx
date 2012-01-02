<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaypalDonateButton.ascx.cs" Inherits="IdentityStuff.Controls.PaypalDonateButton" %>

<form action="https://www.paypal.com/cgi-bin/webscr" method="post">
    <input type="hidden" name="cmd" value="_s-xclick">
    <input type="hidden" name="hosted_button_id" value="4632026">
    <input type="image" src="https://www.paypal.com/en_AU/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online.">
</form>