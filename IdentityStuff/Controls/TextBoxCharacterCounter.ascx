<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextBoxCharacterCounter.ascx.cs" Inherits="IdentityStuff.Controls.TextBoxCharacterCounter" %>

 <script type="text/javascript">  $(document).ready(function() {
$('#<%= TargetClientID %>').twitterCounter({ limit: <%= CharacterLimit %>, counter: '#textcounter', okSize: <%= CharacterLimit %>, okStyle: '.tcok', watchSize: 20, watchStyle: '.tcwatch', warningSize: 10, warningStyle: '.tcwarning', errorSize: 0, errorStyle: '.tcerror' });
}); </script>

<div class="textcounter"><span id="textcounter"></span> characters remaining</div>